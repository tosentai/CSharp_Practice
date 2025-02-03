using Autoservice.BL.Repository;
using Autoservice.DAL.Context;
using Autoservice.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Autoservice.PL
{
    public partial class Orders : UserControl
    {
        private AutoserviceContext _context;
        private UnitOfWork _unitOfWork;

        public Orders()
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

                LoadCarsToComboBox();
                LoadServicesToComboBox();
                LoadEmployeesToComboBox();
                DisplayOrders();
            }
        }

        private void LoadCarsToComboBox()
        {
            var cars = _context.Cars.Select(c => new { c.CarId, Name = c.Make + " " + c.Model }).ToList();
            cmbCar.DataSource = cars;
            cmbCar.DisplayMember = "Name";
            cmbCar.ValueMember = "CarId";
        }

        private void LoadServicesToComboBox()
        {
            var services = _context.Services.Select(s => new { s.ServiceId, s.Name }).ToList();
            cmbService.DataSource = services;
            cmbService.DisplayMember = "Name";
            cmbService.ValueMember = "ServiceId";
        }

        private void DisplayOrders()
        {
            var orders = _context.Orders
                .Include(o => o.Employees)  
                .Select(o => new
                {
                    o.OrderId,
                    Car = o.Car.Make + " " + o.Car.Model,
                    o.OrderDate,
                    o.Status,
                    o.TotalCost,
                    Employees = string.Join(", ", o.Employees.Select(e => e.Name)) 
                })
                .ToList();

            dgOrders.DataSource = orders;
        }


        private void DisplayOrderDetails(int orderId)
        {
            var details = _context.OrderDetails
                .Where(od => od.OrderId == orderId)
                .Select(od => new
                {
                    od.OrderDetailId,
                    Service = od.Service.Name,
                    od.Quantity,
                    od.Subtotal
                }).ToList();

            dgOrderDetails.DataSource = details;
        }

        private void dgOrders_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var selectedOrderId = (int)dgOrders.Rows[e.RowIndex].Cells["OrderId"].Value;

                var selectedOrder = _unitOfWork.Orders.GetById(selectedOrderId);

                if (selectedOrder != null)
                {
                    cmbCar.SelectedValue = selectedOrder.CarId;
                    dtpOrderDate.Value = selectedOrder.OrderDate;
                    cmbStatus.SelectedItem = selectedOrder.Status;
                    txtTotalCost.Text = selectedOrder.TotalCost.ToString();

                    DisplayOrderDetails(selectedOrderId);
                }
            }
        }

        private void dgOrderDetails_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var selectedOrderDetailId = (int)dgOrderDetails.Rows[e.RowIndex].Cells["OrderDetailId"].Value;

                var selectedOrderDetail = _unitOfWork.OrderDetails.GetById(selectedOrderDetailId);

                if (selectedOrderDetail != null)
                {
                    cmbService.SelectedValue = selectedOrderDetail.ServiceId;
                    txtQuantity.Text = selectedOrderDetail.Quantity.ToString();
                    txtSubtotal.Text = selectedOrderDetail.Subtotal.ToString();
                }
            }
        }

        private async void btnOrderAdd_Click(object sender, EventArgs e)
        {
            try
            {
                var carId = (int)cmbCar.SelectedValue;
                var orderDate = dtpOrderDate.Value;
                var status = cmbStatus.SelectedItem?.ToString();

                if (string.IsNullOrWhiteSpace(status))
                {
                    MessageBox.Show("Оберіть статус.");
                    return;
                }

                var order = new Order
                {
                    CarId = carId,
                    OrderDate = orderDate,
                    Status = status,
                    TotalCost = 0
                };

                var selectedEmployeeId = (int)cmbEmployee.SelectedValue;
                var employee = await _context.Employees.FindAsync(selectedEmployeeId);

                if (employee != null)
                {
                    order.Employees.Add(employee);
                }

                _unitOfWork.Orders.Add(order);
                await _unitOfWork.SaveAsync();

                MessageBox.Show("Замовлення додано успішно!");
                DisplayOrders();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка: {ex.Message}");
            }
        }


        private async void btnOrderEdit_Click(object sender, EventArgs e)
        {
            if (dgOrders.SelectedRows.Count > 0)
            {
                var selectedOrderId = (int)dgOrders.SelectedRows[0].Cells["OrderId"].Value;

                var order = _unitOfWork.Orders.GetById(selectedOrderId);
                if (order != null)
                {
                    order.CarId = (int)cmbCar.SelectedValue;
                    order.OrderDate = dtpOrderDate.Value;
                    order.Status = cmbStatus.SelectedItem.ToString();

                    var selectedEmployeeId = (int)cmbEmployee.SelectedValue;

                    if (!order.Employees.Any(e => e.EmployeeId == selectedEmployeeId))
                    {
                        var employee = await _context.Employees.FindAsync(selectedEmployeeId);
                        if (employee != null)
                        {
                            order.Employees.Add(employee);
                        }
                    }

                    _unitOfWork.Orders.Update(order);
                    await _unitOfWork.SaveAsync();

                    MessageBox.Show("Замовлення оновлено!");
                    DisplayOrders();
                }
            }
        }



        private void btnOrderDelete_Click(object sender, EventArgs e)
        {
            if (dgOrders.SelectedRows.Count > 0)
            {
                var selectedOrderId = (int)dgOrders.SelectedRows[0].Cells["OrderId"].Value;

                _unitOfWork.Orders.Delete(selectedOrderId);
                _unitOfWork.SaveAsync();

                MessageBox.Show("Замовлення видалено!");
                DisplayOrders();
            }
        }

        private async void btnDetailAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgOrders.SelectedRows.Count > 0)
                {
                    var selectedOrderId = (int)dgOrders.SelectedRows[0].Cells["OrderId"].Value;
                    var serviceId = (int)cmbService.SelectedValue;
                    var quantity = int.Parse(txtQuantity.Text);
                    var service = _context.Services.FirstOrDefault(s => s.ServiceId == serviceId);

                    if (service != null)
                    {
                        var orderDetail = new OrderDetail
                        {
                            OrderId = selectedOrderId,
                            ServiceId = serviceId,
                            Quantity = quantity,
                            Subtotal = service.Price * quantity
                        };

                        _unitOfWork.OrderDetails.Add(orderDetail);
                        await _unitOfWork.SaveAsync();

                        var totalCost = _context.OrderDetails
                            .Where(od => od.OrderId == selectedOrderId)
                            .Sum(od => od.Subtotal);

                        var order = _unitOfWork.Orders.GetById(selectedOrderId);
                        order.TotalCost = totalCost;
                        _unitOfWork.Orders.Update(order);
                        await _unitOfWork.SaveAsync();

                        txtTotalCost.Text = totalCost.ToString();
                        txtSubtotal.Text = orderDetail.Subtotal.ToString();

                        MessageBox.Show("Деталь замовлення додано успішно!");
                        DisplayOrderDetails(selectedOrderId);
                        DisplayOrders();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка: {ex.Message}");
            }
        }

        private async void btnDetailEdit_Click(object sender, EventArgs e)
        {
            if (dgOrderDetails.SelectedRows.Count > 0)
            {
                var selectedDetailId = (int)dgOrderDetails.SelectedRows[0].Cells["OrderDetailId"].Value;
                var orderDetail = _unitOfWork.OrderDetails.GetById(selectedDetailId);

                if (orderDetail != null)
                {
                    var serviceId = (int)cmbService.SelectedValue;
                    var quantity = int.Parse(txtQuantity.Text);
                    var service = _context.Services.FirstOrDefault(s => s.ServiceId == serviceId);

                    if (service != null)
                    {
                        orderDetail.ServiceId = serviceId;
                        orderDetail.Quantity = quantity;
                        orderDetail.Subtotal = service.Price * quantity;

                        _unitOfWork.OrderDetails.Update(orderDetail);
                        await _unitOfWork.SaveAsync();

                        var totalCost = _context.OrderDetails
                            .Where(od => od.OrderId == orderDetail.OrderId)
                            .Sum(od => od.Subtotal);

                        var order = _unitOfWork.Orders.GetById(orderDetail.OrderId);
                        order.TotalCost = totalCost;
                        _unitOfWork.Orders.Update(order);
                        await _unitOfWork.SaveAsync();

                        txtTotalCost.Text = totalCost.ToString();
                        txtSubtotal.Text = orderDetail.Subtotal.ToString();

                        MessageBox.Show("Деталь замовлення оновлено!");
                        DisplayOrderDetails(orderDetail.OrderId);
                        DisplayOrders();
                    }
                }
            }
        }


        private async void btnDetailDelete_Click(object sender, EventArgs e)
        {
            if (dgOrderDetails.SelectedRows.Count > 0)
            {
                var selectedDetailId = (int)dgOrderDetails.SelectedRows[0].Cells["OrderDetailId"].Value;
                var orderDetail = _unitOfWork.OrderDetails.GetById(selectedDetailId);

                if (orderDetail != null)
                {
                    var orderId = orderDetail.OrderId;

                    _unitOfWork.OrderDetails.Delete(selectedDetailId);
                    await _unitOfWork.SaveAsync();

                    var totalCost = _context.OrderDetails
                        .Where(od => od.OrderId == orderId)
                        .Sum(od => od.Subtotal);

                    var order = _unitOfWork.Orders.GetById(orderId);
                    order.TotalCost = totalCost;
                    _unitOfWork.Orders.Update(order);
                    await _unitOfWork.SaveAsync();

                    txtTotalCost.Text = totalCost.ToString();

                    MessageBox.Show("Деталь замовлення видалено!");
                    DisplayOrderDetails(orderId);
                    DisplayOrders();
                }
            }
        }

        private void LoadEmployeesToComboBox()
        {
            var employees = _context.Employees.Select(e => new { e.EmployeeId, e.Name }).ToList();
            cmbEmployee.DataSource = employees;
            cmbEmployee.DisplayMember = "Name";
            cmbEmployee.ValueMember = "EmployeeId";
        }
    }
}
