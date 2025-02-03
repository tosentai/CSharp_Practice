using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Autoservice.DAL.Context;
using Microsoft.EntityFrameworkCore;

namespace Autoservice.PL.Forms
{
    public partial class SearchForm : Form
    {
        private readonly AutoserviceContext _context;

        public SearchForm()
        {
            InitializeComponent();

            var options = new DbContextOptionsBuilder<AutoserviceContext>()
                .UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=AutoserviceDB;Trusted_Connection=True;TrustServerCertificate=True;")
                .Options;
            _context = new AutoserviceContext(options);

            DisplayClients();
            DisplayCars();
            DisplayOrders();
        }

        private void close_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Ви точно хочете закрити пошук?", "Confirmation Message"
                , MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close();
                _context.Dispose();
            }
        }

        private void ClearGrids()
        {
            dgSearchClient.DataSource = null;
            dgSearchCar.DataSource = null;
            dgSearchOrder.DataSource = null;
        }

        public void DisplayClients()
        {
            try
            {
                if (_context == null)
                {
                    MessageBox.Show("Контекст бази даних не ініціалізовано.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var clients = _context.Clients.Select(c => new
                {
                    c.ClientId,
                    c.FirstName,
                    c.LastName,
                    c.Phone,
                    c.Email,
                    c.Address
                }).ToList();

                dgSearchClient.DataSource = clients;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Сталася помилка при завантаженні клієнтів: {ex.Message}", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void DisplayCars()
        {
            var cars = _context.Cars.Select(c => new
            {
                c.CarId,
                c.LicensePlate,
                c.Make,
                c.Model,
                c.Year,
                c.Client.FirstName,
                c.Client.LastName
            }).ToList();

            dgSearchCar.DataSource = cars;
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

            dgSearchOrder.DataSource = orders;
        }

        private async void txtSearch_TextChanged(object sender, EventArgs e)
        {
            var searchText = txtSearch.Text.Trim();

            if (string.IsNullOrWhiteSpace(searchText))
            {
                ClearGrids();
                return;
            }

            try
            {
                var clients = await _context.Clients
                    .Where(c => c.FirstName.Contains(searchText) || c.LastName.Contains(searchText))
                    .ToListAsync();

                if (!clients.Any())
                {
                    ClearGrids();
                    return;
                }

                dgSearchClient.DataSource = clients.Select(c => new
                {
                    c.ClientId,
                    c.FirstName,
                    c.LastName,
                    c.Phone,
                    c.Email,
                    c.Address
                }).ToList();

                var clientIds = clients.Select(c => c.ClientId).ToList();
                var cars = await _context.Cars
                    .Where(car => clientIds.Contains(car.ClientId))
                    .Include(car => car.Client)
                    .ToListAsync();

                dgSearchCar.DataSource = cars.Select(car => new
                {
                    car.CarId,
                    car.LicensePlate,
                    car.Make,
                    car.Model,
                    car.Year,
                    Client = $"{car.Client.FirstName} {car.Client.LastName}"
                }).ToList();

                var carIds = cars.Select(car => car.CarId).ToList();
                var orders = await _context.Orders
                    .Where(order => carIds.Contains(order.CarId))
                    .Include(order => order.Car)
                    .ThenInclude(car => car.Client)
                    .ToListAsync();

                dgSearchOrder.DataSource = orders.Select(order => new
                {
                    order.OrderId,
                    Car = $"{order.Car.Make} {order.Car.Model} ({order.Car.LicensePlate})",
                    Client = $"{order.Car.Client.FirstName} {order.Car.Client.LastName}",
                    order.OrderDate,
                    order.Status,
                    order.TotalCost
                }).ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка під час пошуку: {ex.Message}", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnMainOrders_Click(object sender, EventArgs e)
        {
            txtSearch.Text = null;
            DisplayClients();
            DisplayCars();
            DisplayOrders();
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);

        private void SearchForm_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
    }
}
