using Autoservice.DAL.Context;
using Microsoft.EntityFrameworkCore;
using OfficeOpenXml.Style;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Autoservice.BL.Repository;

namespace Autoservice.PL
{
    public partial class Reports : UserControl
    {
        private AutoserviceContext _context;
        private UnitOfWork _unitOfWork;

        public Reports()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            if (!DesignMode)
            {
                _context = new AutoserviceContext(new DbContextOptionsBuilder<AutoserviceContext>()
                    .UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=AutoserviceDB;Trusted_Connection=True;TrustServerCertificate=True;")
                    .Options);
                _unitOfWork = new UnitOfWork(_context);
            }
        }

        private void btnFinRep_Click(object sender, EventArgs e)
        {
            GenerateFinancialReport();
        }

        private void GenerateFinancialReport()
        {
            var reportData = _context.Orders
                .Include(o => o.OrderDetails).ThenInclude(od => od.Service)
                .Include(o => o.Employees)
                .ToList();

            if (!reportData.Any())
            {
                MessageBox.Show("Немає завершених замовлень для формування звіту.");
                return;
            }

            int totalOrders = reportData.Count;
            decimal totalRevenue = reportData.Sum(o => o.TotalCost);
            decimal averageCheck = totalOrders > 0 ? totalRevenue / totalOrders : 0;

            var topServices = reportData
                .SelectMany(o => o.OrderDetails)
                .GroupBy(od => od.Service.Name)
                .Select(g => new { Name = g.Key, Count = g.Sum(od => od.Quantity) })
                .OrderByDescending(g => g.Count)
                .Take(5)
                .ToList();

            var topEmployees = reportData
                .SelectMany(o => o.Employees)
                .GroupBy(e => e.Name)
                .Select(g => new { Name = g.Key, OrdersHandled = g.Count() })
                .OrderByDescending(g => g.OrdersHandled)
                .Take(3)
                .ToList();

            using (var package = new ExcelPackage())
            {
                var worksheet = package.Workbook.Worksheets.Add("Financial Report");

                worksheet.Cells[1, 1].Value = "Financial Report";
                worksheet.Cells[1, 1, 1, 4].Merge = true;
                worksheet.Cells[1, 1].Style.Font.Size = 16;
                worksheet.Cells[1, 1].Style.Font.Bold = true;
                worksheet.Cells[1, 1].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                worksheet.Cells[1, 1].Style.Fill.PatternType = ExcelFillStyle.Solid;
                worksheet.Cells[1, 1].Style.Fill.BackgroundColor.SetColor(Color.DarkSlateGray);
                worksheet.Cells[1, 1].Style.Font.Color.SetColor(Color.White);

                worksheet.Cells[2, 1].Value = "Total Orders:";
                worksheet.Cells[2, 4].Value = totalOrders;
                worksheet.Cells[3, 1].Value = "Total Revenue:";
                worksheet.Cells[3, 4].Value = totalRevenue;
                worksheet.Cells[4, 1].Value = "Average Check:";
                worksheet.Cells[4, 4].Value = averageCheck;

                worksheet.Cells[6, 1].Value = "Top Services";
                worksheet.Cells[6, 1, 6, 4].Merge = true;
                worksheet.Cells[6, 1].Style.Font.Bold = true;
                worksheet.Cells[7, 1].Value = "Service Name";
                worksheet.Cells[7, 4].Value = "Usage Count";
                worksheet.Cells[7, 1, 7, 4].Style.Font.Bold = true;

                int row = 8;
                foreach (var service in topServices)
                {
                    worksheet.Cells[row, 1].Value = service.Name;
                    worksheet.Cells[row, 4].Value = service.Count;
                    row++;
                }

                worksheet.Cells[row + 1, 1].Value = "Top Employees";
                worksheet.Cells[row + 1, 1, row + 1, 4].Merge = true;
                worksheet.Cells[row + 1, 1].Style.Font.Bold = true;
                worksheet.Cells[row + 2, 1].Value = "Employee Name";
                worksheet.Cells[row + 2, 4].Value = "Orders Handled";
                worksheet.Cells[row + 2, 1, row + 2, 4].Style.Font.Bold = true;

                row += 3;
                foreach (var employee in topEmployees)
                {
                    worksheet.Cells[row, 1].Value = employee.Name;
                    worksheet.Cells[row, 4].Value = employee.OrdersHandled;
                    row++;
                }

                worksheet.Cells[worksheet.Dimension.Address].AutoFitColumns();

                using (SaveFileDialog saveFileDialog = new SaveFileDialog())
                {
                    saveFileDialog.Filter = "Excel files (*.xlsx)|*.xlsx";
                    saveFileDialog.FileName = "Financial_Report.xlsx";

                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        try
                        {
                            package.SaveAs(new FileInfo(saveFileDialog.FileName));
                            MessageBox.Show("Фінансовий звіт згенеровано успішно");
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Помилка при збереженні файлу: {ex.Message}");
                        }
                    }
                }
            }
        }

        private async void btnOrdRep_Click(object sender, EventArgs e)
        {
            await GenerateOrdersReportAsync();
        }

        private async Task GenerateOrdersReportAsync()
        {
            var orders = await _context.Orders
                .Include(o => o.Car).ThenInclude(c => c.Client)
                .Include(o => o.OrderDetails).ThenInclude(od => od.Service)
                .Include(o => o.Employees)
                .ToListAsync();

            if (!orders.Any())
            {
                MessageBox.Show("Немає замовлень для формування звіту.");
                return;
            }

            using (var package = new ExcelPackage())
            {
                var worksheet = package.Workbook.Worksheets.Add("Orders Report");

                worksheet.Cells[1, 1].Value = "Звіт по всім замовленням";
                worksheet.Cells[1, 1, 1, 7].Merge = true;
                worksheet.Cells[1, 1].Style.Font.Size = 16;
                worksheet.Cells[1, 1].Style.Font.Bold = true;
                worksheet.Cells[1, 1].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                worksheet.Cells[1, 1].Style.Fill.PatternType = ExcelFillStyle.Solid;
                worksheet.Cells[1, 1].Style.Fill.BackgroundColor.SetColor(Color.DarkSlateGray);
                worksheet.Cells[1, 1].Style.Font.Color.SetColor(Color.White);

                worksheet.Cells[2, 1].Value = "ID замовлення";
                worksheet.Cells[2, 2].Value = "Клієнт";
                worksheet.Cells[2, 3].Value = "Автомобіль";
                worksheet.Cells[2, 4].Value = "Дата замовлення";
                worksheet.Cells[2, 5].Value = "Статус";
                worksheet.Cells[2, 6].Value = "Загальна вартість";
                worksheet.Cells[2, 7].Value = "Працівники";

                for (int col = 1; col <= 7; col++)
                {
                    worksheet.Cells[2, col].Style.Font.Bold = true;
                    worksheet.Cells[2, col].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    worksheet.Cells[2, col].Style.Fill.BackgroundColor.SetColor(Color.LightGray);
                }

                int row = 3;
                foreach (var order in orders)
                {
                    worksheet.Cells[row, 1].Value = order.OrderId;
                    worksheet.Cells[row, 2].Value = $"{order.Car.Client.FirstName} {order.Car.Client.LastName}";
                    worksheet.Cells[row, 3].Value = $"{order.Car.Make} {order.Car.Model} ({order.Car.LicensePlate})";
                    worksheet.Cells[row, 4].Value = order.OrderDate.ToShortDateString();
                    worksheet.Cells[row, 5].Value = order.Status;
                    worksheet.Cells[row, 6].Value = order.TotalCost;

                    var employees = string.Join(", ", order.Employees.Select(e => e.Name));
                    worksheet.Cells[row, 7].Value = employees;

                    row++;
                }

                worksheet.Cells[row + 1, 1].Value = "Деталі послуг";
                worksheet.Cells[row + 1, 1, row + 1, 7].Merge = true;
                worksheet.Cells[row + 1, 1].Style.Font.Bold = true;
                worksheet.Cells[row + 1, 1].Style.Fill.PatternType = ExcelFillStyle.Solid;
                worksheet.Cells[row + 1, 1].Style.Fill.BackgroundColor.SetColor(Color.LightBlue);

                worksheet.Cells[row + 2, 1].Value = "ID замовлення";
                worksheet.Cells[row + 2, 2].Value = "Послуга";
                worksheet.Cells[row + 2, 3].Value = "Кількість";
                worksheet.Cells[row + 2, 4].Value = "Вартість за одиницю";
                worksheet.Cells[row + 2, 5].Value = "Загальна вартість";

                for (int col = 1; col <= 5; col++)
                {
                    worksheet.Cells[row + 2, col].Style.Font.Bold = true;
                    worksheet.Cells[row + 2, col].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    worksheet.Cells[row + 2, col].Style.Fill.BackgroundColor.SetColor(Color.LightGray);
                }

                row += 3;
                foreach (var order in orders)
                {
                    foreach (var detail in order.OrderDetails)
                    {
                        worksheet.Cells[row, 1].Value = order.OrderId;
                        worksheet.Cells[row, 2].Value = detail.Service.Name;
                        worksheet.Cells[row, 3].Value = detail.Quantity;
                        worksheet.Cells[row, 4].Value = detail.Service.Price;
                        worksheet.Cells[row, 5].Value = detail.Subtotal;
                        row++;
                    }
                }

                worksheet.Cells[worksheet.Dimension.Address].AutoFitColumns();

                using (SaveFileDialog saveFileDialog = new SaveFileDialog())
                {
                    saveFileDialog.Filter = "Excel files (*.xlsx)|*.xlsx";
                    saveFileDialog.FileName = "Orders_Report.xlsx";

                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        try
                        {
                            package.SaveAs(new FileInfo(saveFileDialog.FileName));
                            MessageBox.Show("Звіт по замовленням згенеровано успішно.");
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Помилка при збереженні файлу: {ex.Message}");
                        }
                    }
                }
            }
        }

        private async void btnClientRep_Click(object sender, EventArgs e)
        {
            await GenerateClientsAndCarsReportAsync();
        }

        private async Task GenerateClientsAndCarsReportAsync()
        {
            var clients = await _context.Clients
                .Include(c => c.Cars)
                .ThenInclude(car => car.Orders)
                .ThenInclude(order => order.OrderDetails)
                .ThenInclude(detail => detail.Service)
                .ToListAsync();

            if (!clients.Any())
            {
                MessageBox.Show("Немає клієнтів для формування звіту.");
                return;
            }

            using (var package = new ExcelPackage())
            {
                var worksheet = package.Workbook.Worksheets.Add("Clients and Cars Report");

                worksheet.Cells[1, 1].Value = "Звіт по клієнтах та їх автомобілях";
                worksheet.Cells[1, 1, 1, 6].Merge = true;
                worksheet.Cells[1, 1].Style.Font.Size = 16;
                worksheet.Cells[1, 1].Style.Font.Bold = true;
                worksheet.Cells[1, 1].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                worksheet.Cells[1, 1].Style.Fill.PatternType = ExcelFillStyle.Solid;
                worksheet.Cells[1, 1].Style.Fill.BackgroundColor.SetColor(Color.DarkSlateGray);
                worksheet.Cells[1, 1].Style.Font.Color.SetColor(Color.White);

                worksheet.Cells[2, 1].Value = "ID клієнта";
                worksheet.Cells[2, 2].Value = "Ім'я";
                worksheet.Cells[2, 3].Value = "Прізвище";
                worksheet.Cells[2, 4].Value = "Телефон";
                worksheet.Cells[2, 5].Value = "Кількість автомобілів";
                worksheet.Cells[2, 6].Value = "Загальна вартість обслуговування";

                for (int col = 1; col <= 6; col++)
                {
                    worksheet.Cells[2, col].Style.Font.Bold = true;
                    worksheet.Cells[2, col].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    worksheet.Cells[2, col].Style.Fill.BackgroundColor.SetColor(Color.LightGray);
                }

                int row = 3;
                foreach (var client in clients)
                {
                    worksheet.Cells[row, 1].Value = client.ClientId;
                    worksheet.Cells[row, 2].Value = client.FirstName;
                    worksheet.Cells[row, 3].Value = client.LastName;
                    worksheet.Cells[row, 4].Value = client.Phone;

                    int carCount = client.Cars.Count;
                    worksheet.Cells[row, 5].Value = carCount;

                    decimal totalServiceCost = client.Cars
                        .SelectMany(car => car.Orders)
                        .SelectMany(order => order.OrderDetails)
                        .Sum(detail => detail.Subtotal);

                    worksheet.Cells[row, 6].Value = totalServiceCost;

                    row++;
                }

                worksheet.Cells[row + 1, 1].Value = "Деталі автомобілів";
                worksheet.Cells[row + 1, 1, row + 1, 6].Merge = true;
                worksheet.Cells[row + 1, 1].Style.Font.Bold = true;
                worksheet.Cells[row + 1, 1].Style.Fill.PatternType = ExcelFillStyle.Solid;
                worksheet.Cells[row + 1, 1].Style.Fill.BackgroundColor.SetColor(Color.LightBlue);

                worksheet.Cells[row + 2, 1].Value = "ID клієнта";
                worksheet.Cells[row + 2, 2].Value = "Автомобіль";
                worksheet.Cells[row + 2, 3].Value = "Держ. номер";
                worksheet.Cells[row + 2, 4].Value = "Марка";
                worksheet.Cells[row + 2, 5].Value = "Модель";
                worksheet.Cells[row + 2, 6].Value = "Рік випуску";

                for (int col = 1; col <= 6; col++)
                {
                    worksheet.Cells[row + 2, col].Style.Font.Bold = true;
                    worksheet.Cells[row + 2, col].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    worksheet.Cells[row + 2, col].Style.Fill.BackgroundColor.SetColor(Color.LightGray);
                }

                row += 3;
                foreach (var client in clients)
                {
                    foreach (var car in client.Cars)
                    {
                        worksheet.Cells[row, 1].Value = client.ClientId;
                        worksheet.Cells[row, 2].Value = $"{car.Make} {car.Model}";
                        worksheet.Cells[row, 3].Value = car.LicensePlate;
                        worksheet.Cells[row, 4].Value = car.Make;
                        worksheet.Cells[row, 5].Value = car.Model;
                        worksheet.Cells[row, 6].Value = car.Year;
                        row++;
                    }
                }

                worksheet.Cells[worksheet.Dimension.Address].AutoFitColumns();

                using (SaveFileDialog saveFileDialog = new SaveFileDialog())
                {
                    saveFileDialog.Filter = "Excel files (*.xlsx)|*.xlsx";
                    saveFileDialog.FileName = "Clients_and_Cars_Report.xlsx";

                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        try
                        {
                            package.SaveAs(new FileInfo(saveFileDialog.FileName));
                            MessageBox.Show("Звіт по клієнтах та їх автомобілях згенеровано успішно.");
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Помилка при збереженні файлу: {ex.Message}");
                        }
                    }
                }
            }
        }

        private async Task GenerateEmployeesAndServicesReportAsync()
        {
            var employees = await _context.Employees
                .Include(e => e.Orders)
                .ThenInclude(o => o.OrderDetails)
                .ThenInclude(od => od.Service)
                .ToListAsync();

            if (!employees.Any())
            {
                MessageBox.Show("Немає працівників для формування звіту.");
                return;
            }

            using (var package = new ExcelPackage())
            {
                var worksheet = package.Workbook.Worksheets.Add("Employees and Services Report");

                worksheet.Cells[1, 1].Value = "Звіт по працівниках та послугах";
                worksheet.Cells[1, 1, 1, 5].Merge = true;
                worksheet.Cells[1, 1].Style.Font.Size = 16;
                worksheet.Cells[1, 1].Style.Font.Bold = true;
                worksheet.Cells[1, 1].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                worksheet.Cells[1, 1].Style.Fill.PatternType = ExcelFillStyle.Solid;
                worksheet.Cells[1, 1].Style.Fill.BackgroundColor.SetColor(Color.DarkSlateGray);
                worksheet.Cells[1, 1].Style.Font.Color.SetColor(Color.White);

                worksheet.Cells[2, 1].Value = "ID працівника";
                worksheet.Cells[2, 2].Value = "Ім'я";
                worksheet.Cells[2, 3].Value = "Посада";
                worksheet.Cells[2, 4].Value = "Кількість замовлень";
                worksheet.Cells[2, 5].Value = "Загальна вартість послуг";

                for (int col = 1; col <= 5; col++)
                {
                    worksheet.Cells[2, col].Style.Font.Bold = true;
                    worksheet.Cells[2, col].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    worksheet.Cells[2, col].Style.Fill.BackgroundColor.SetColor(Color.LightGray);
                }

                int row = 3;
                foreach (var employee in employees)
                {
                    worksheet.Cells[row, 1].Value = employee.EmployeeId;
                    worksheet.Cells[row, 2].Value = employee.Name;
                    worksheet.Cells[row, 3].Value = employee.Position;

                    int orderCount = employee.Orders.Count;
                    worksheet.Cells[row, 4].Value = orderCount;

                    decimal totalServiceCost = employee.Orders
                        .SelectMany(o => o.OrderDetails)
                        .Sum(od => od.Subtotal);

                    worksheet.Cells[row, 5].Value = totalServiceCost;

                    row++;
                }

                worksheet.Cells[row + 1, 1].Value = "Деталі послуг";
                worksheet.Cells[row + 1, 1, row + 1, 5].Merge = true;
                worksheet.Cells[row + 1, 1].Style.Font.Bold = true;
                worksheet.Cells[row + 1, 1].Style.Fill.PatternType = ExcelFillStyle.Solid;
                worksheet.Cells[row + 1, 1].Style.Fill.BackgroundColor.SetColor(Color.LightBlue);

                worksheet.Cells[row + 2, 1].Value = "ID працівника";
                worksheet.Cells[row + 2, 2].Value = "Послуга";
                worksheet.Cells[row + 2, 3].Value = "Кількість";
                worksheet.Cells[row + 2, 4].Value = "Вартість за одиницю";
                worksheet.Cells[row + 2, 5].Value = "Загальна вартість";

                for (int col = 1; col <= 5; col++)
                {
                    worksheet.Cells[row + 2, col].Style.Font.Bold = true;
                    worksheet.Cells[row + 2, col].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    worksheet.Cells[row + 2, col].Style.Fill.BackgroundColor.SetColor(Color.LightGray);
                }

                row += 3;
                foreach (var employee in employees)
                {
                    var services = employee.Orders
                        .SelectMany(o => o.OrderDetails)
                        .GroupBy(od => od.Service.Name)
                        .Select(g => new
                        {
                            ServiceName = g.Key,
                            Quantity = g.Sum(od => od.Quantity),
                            UnitPrice = g.First().Service.Price,
                            TotalCost = g.Sum(od => od.Subtotal)
                        });

                    foreach (var service in services)
                    {
                        worksheet.Cells[row, 1].Value = employee.EmployeeId;
                        worksheet.Cells[row, 2].Value = service.ServiceName;
                        worksheet.Cells[row, 3].Value = service.Quantity;
                        worksheet.Cells[row, 4].Value = service.UnitPrice;
                        worksheet.Cells[row, 5].Value = service.TotalCost;
                        row++;
                    }
                }

                worksheet.Cells[worksheet.Dimension.Address].AutoFitColumns();

                using (SaveFileDialog saveFileDialog = new SaveFileDialog())
                {
                    saveFileDialog.Filter = "Excel files (*.xlsx)|*.xlsx";
                    saveFileDialog.FileName = "Employees_and_Services_Report.xlsx";

                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        try
                        {
                            package.SaveAs(new FileInfo(saveFileDialog.FileName));
                            MessageBox.Show("Звіт по працівниках та послугах згенеровано успішно.");
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Помилка при збереженні файлу: {ex.Message}");
                        }
                    }
                }
            }
        }

        private void btnEmpRep_Click(object sender, EventArgs e)
        {
            GenerateEmployeesAndServicesReportAsync();
        }
    }
}
