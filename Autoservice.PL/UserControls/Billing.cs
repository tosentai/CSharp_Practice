using Autoservice.BL.Repository;
using Autoservice.DAL.Context;
using Microsoft.EntityFrameworkCore;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Autoservice.PL
{
    public partial class Billing : UserControl
    {
        private AutoserviceContext _context;
        private UnitOfWork _unitOfWork;

        public Billing()
        {
            InitializeComponent();
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial; 
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

                InitializeDataGridViewColumns(); 

                LoadClientsToComboBox();
            }
        }

        private void LoadCarsToComboBox(int? clientId = null)
        {
            var carsQuery = _context.Cars.AsQueryable();

            if (clientId.HasValue)
            {
                carsQuery = carsQuery.Where(c => c.ClientId == clientId.Value);
            }

            var cars = carsQuery.Select(c => new { c.CarId, Name = c.Make + " " + c.Model }).ToList();
            cmbCar.DataSource = cars;
            cmbCar.DisplayMember = "Name";
            cmbCar.ValueMember = "CarId";
        }

        private void LoadClientsToComboBox()
        {
            var clients = _context.Clients
                                  .Select(c => new { c.ClientId, Name = c.FirstName + " " + c.LastName })
                                  .ToList();

            cmbClient.DataSource = clients;
            cmbClient.DisplayMember = "Name";
            cmbClient.ValueMember = "ClientId";
        }

        private void cmbClient_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbClient.SelectedItem != null)
            {
                var selectedClient = (dynamic)cmbClient.SelectedItem;
                int clientId = selectedClient.ClientId;

                LoadCarsToComboBox(clientId); 
            }
        }

        private void LoadBillingData(int carId)
        {
            var orders = _context.Orders
                                 .Where(o => o.CarId == carId)
                                 .Select(o => new
                                 {
                                     o.OrderId,
                                     o.OrderDate,
                                     o.Status,
                                     o.TotalCost,
                                     Services = string.Join(", ", o.OrderDetails.Select(od => od.Service.Name)),
                                     Employees = string.Join(", ", o.Employees.Select(e => e.Name))
                                 })
                                 .ToList();

            dgBilling.Rows.Clear();

            foreach (var order in orders)
            {
                dgBilling.Rows.Add(order.OrderId, order.OrderDate, order.Status, order.TotalCost, order.Services, order.Employees);
            }
        }


        private void cmbCar_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbCar.SelectedItem != null)
            {
                var selectedCar = (dynamic)cmbCar.SelectedItem; 
                int carId = selectedCar.CarId; 
                LoadBillingData(carId); 
            }
        }

        private void InitializeDataGridViewColumns()
        {
            if (dgBilling.Columns.Count == 0)
            {
                dgBilling.Columns.Add("OrderId", "Order ID");
                dgBilling.Columns.Add("OrderDate", "Order Date");
                dgBilling.Columns.Add("Status", "Status");
                dgBilling.Columns.Add("TotalCost", "Total Cost");
                dgBilling.Columns.Add("Services", "Services");
                dgBilling.Columns.Add("Employees", "Employees");
            }
        }

        private void btnGenExcel_Click(object sender, EventArgs e)
        {
            if (dgBilling.SelectedRows.Count > 0)
            {
                int selectedOrderId = Convert.ToInt32(dgBilling.SelectedRows[0].Cells["OrderId"].Value);

                GenerateBillingExcel(selectedOrderId);
            }
            else
            {
                MessageBox.Show("Будь ласка, виберіть замовлення у таблиці!");
            }
        }

        private void GenerateBillingExcel(int orderId)
        {
            var order = _context.Orders
                .Include(o => o.Car).ThenInclude(c => c.Client)
                .Include(o => o.OrderDetails).ThenInclude(od => od.Service)
                .Include(o => o.Employees)
                .Where(o => o.OrderId == orderId)
                .Select(o => new
                {
                    o.OrderId,
                    o.OrderDate,
                    o.Status,
                    o.TotalCost,
                    Services = o.OrderDetails
                        .GroupBy(od => od.Service.Name)
                        .Select(g => new
                        {
                            Name = g.Key,
                            Count = g.Sum(od => od.Quantity),
                            Price = g.First().Service.Price,
                            TotalServiceCost = g.Sum(od => od.Quantity * od.Service.Price)
                        }).ToList(),
                    Employees = o.Employees.Select(e => e.Name).ToList(),
                    ClientName = o.Car.Client.FirstName + " " + o.Car.Client.LastName,
                    CarMakeModel = o.Car.Make + " " + o.Car.Model
                })
                .FirstOrDefault();

            if (order == null)
            {
                MessageBox.Show("Замовлення не знайдено.");
                return;
            }

            using (var package = new ExcelPackage())
            {
                var worksheet = package.Workbook.Worksheets.Add("Billing");

                worksheet.Cells[1, 1].Value = "Invoice";
                worksheet.Cells[1, 1, 1, 8].Merge = true;
                worksheet.Cells[1, 1].Style.Font.Size = 16;
                worksheet.Cells[1, 1].Style.Font.Bold = true;
                worksheet.Cells[1, 1].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                worksheet.Cells[1, 1].Style.Fill.PatternType = ExcelFillStyle.Solid;
                worksheet.Cells[1, 1].Style.Fill.BackgroundColor.SetColor(Color.DarkSlateGray);
                worksheet.Cells[1, 1].Style.Font.Color.SetColor(Color.White);

                worksheet.Cells[2, 1].Value = "Client: " + order.ClientName;
                worksheet.Cells[3, 1].Value = "Car: " + order.CarMakeModel;
                worksheet.Cells[2, 1, 3, 8].Merge = true;
                worksheet.Cells[2, 1].Style.Font.Size = 12;
                worksheet.Cells[2, 1].Style.Font.Italic = true;
                worksheet.Cells[2, 1].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                worksheet.Cells[2, 1].Style.Fill.PatternType = ExcelFillStyle.Solid;
                worksheet.Cells[2, 1].Style.Fill.BackgroundColor.SetColor(Color.LightGray);

                worksheet.Cells[4, 1].Value = "Order ID";
                worksheet.Cells[4, 2].Value = "Order Date";
                worksheet.Cells[4, 3].Value = "Status";
                worksheet.Cells[4, 4].Value = "Service";
                worksheet.Cells[4, 5].Value = "Quantity";
                worksheet.Cells[4, 6].Value = "Price";
                worksheet.Cells[4, 7].Value = "Total Service Cost";
                worksheet.Cells[4, 8].Value = "Employees";

                worksheet.Cells[4, 1, 4, 8].Style.Font.Bold = true;
                worksheet.Cells[4, 1, 4, 8].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                worksheet.Cells[4, 1, 4, 8].Style.Fill.PatternType = ExcelFillStyle.Solid;
                worksheet.Cells[4, 1, 4, 8].Style.Fill.BackgroundColor.SetColor(Color.Teal);
                worksheet.Cells[4, 1, 4, 8].Style.Font.Color.SetColor(Color.White);

                int row = 5;
                worksheet.Cells[row, 1].Value = order.OrderId;
                worksheet.Cells[row, 2].Value = order.OrderDate.ToString("yyyy-MM-dd");
                worksheet.Cells[row, 3].Value = order.Status;

                int serviceStartRow = row;
                foreach (var service in order.Services)
                {
                    worksheet.Cells[serviceStartRow, 4].Value = service.Name;
                    worksheet.Cells[serviceStartRow, 5].Value = service.Count;
                    worksheet.Cells[serviceStartRow, 6].Value = service.Price;
                    worksheet.Cells[serviceStartRow, 7].Value = service.TotalServiceCost;
                    serviceStartRow++;
                }

                int employeeStartRow = row;
                foreach (var employee in order.Employees)
                {
                    worksheet.Cells[employeeStartRow, 8].Value = employee;
                    employeeStartRow++;
                }

                worksheet.Cells[serviceStartRow + 1, 6].Value = "Total Cost:";
                worksheet.Cells[serviceStartRow + 1, 6].Style.Font.Bold = true;
                worksheet.Cells[serviceStartRow + 1, 7].Value = order.TotalCost;
                worksheet.Cells[serviceStartRow + 1, 7].Style.Font.Bold = true;

                worksheet.Cells[serviceStartRow + 3, 1].Value = "Payment is required upon car collection either in cash or via bank transfer.";
                worksheet.Cells[serviceStartRow + 3, 1, serviceStartRow + 3, 8].Merge = true;
                worksheet.Cells[serviceStartRow + 3, 1].Style.Font.Bold = true;
                worksheet.Cells[serviceStartRow + 3, 1].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                worksheet.Cells[serviceStartRow + 3, 1].Style.Font.Size = 12;

                worksheet.Cells[worksheet.Dimension.Address].AutoFitColumns();

                using (SaveFileDialog saveFileDialog = new SaveFileDialog())
                {
                    saveFileDialog.Filter = "Excel files (*.xlsx)|*.xlsx";
                    saveFileDialog.FileName = $"Billing_{orderId}.xlsx";

                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        try
                        {
                            package.SaveAs(new FileInfo(saveFileDialog.FileName));
                            MessageBox.Show("Накладна згенерована успішно");
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Помилка при збереженні файлу: {ex.Message}");
                        }
                    }
                }
            }
        }
    }
}
