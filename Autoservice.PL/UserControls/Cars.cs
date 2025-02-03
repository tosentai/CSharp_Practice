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
    public partial class Cars : UserControl
    {
        private AutoserviceContext _context;
        private UnitOfWork _unitOfWork;

        public Cars()
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

            LoadClientsToComboBox();
            DisplayCars();
        }

        public List<string> GetClients()
        {
            return _context.Clients
                .Select(c => c.FirstName + " " + c.LastName)
                .ToList();
        }

        public void LoadClientsToComboBox()
        {
            var clients = GetClients();

            cmbClients.DataSource = null;
            cmbClients.DataSource = clients;
            cmbClients.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void btnCarAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbClients.SelectedIndex == -1)
                {
                    MessageBox.Show("Будь ласка, виберіть клієнта.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var selectedClientFullName = cmbClients.SelectedItem.ToString();
                var client = _context.Clients.FirstOrDefault(c => (c.FirstName + " " + c.LastName) == selectedClientFullName);

                if (client == null)
                {
                    MessageBox.Show("Обраний клієнт не знайдений.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var licensePlate = txtLicensePlate.Text.Trim();
                var make = txtMake.Text.Trim();
                var model = txtModel.Text.Trim();
                var yearText = txtYear.Text.Trim();

                if (string.IsNullOrWhiteSpace(licensePlate) || string.IsNullOrWhiteSpace(make) ||
                    string.IsNullOrWhiteSpace(model) || string.IsNullOrWhiteSpace(yearText))
                {
                    MessageBox.Show("Будь ласка, заповніть всі поля.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!int.TryParse(yearText, out int year) || year < 1886 || year > DateTime.Now.Year)
                {
                    MessageBox.Show("Введіть коректний рік випуску автомобіля.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var car = new Car
                {
                    LicensePlate = licensePlate,
                    Make = make,
                    Model = model,
                    Year = year,
                    ClientId = client.ClientId
                };

                _unitOfWork.Cars.Add(car);
                _context.SaveChanges();
                DisplayCars();

                MessageBox.Show("Машину успішно додано!", "Успіх", MessageBoxButtons.OK, MessageBoxIcon.Information);

                txtLicensePlate.Clear();
                txtMake.Clear();
                txtModel.Clear();
                txtYear.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка при додаванні машини: {ex.Message}", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

            dgCars.DataSource = cars;
        }

        private void btnCarEdit_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgCars.SelectedRows.Count > 0)
                {
                    int selectedCarId = Convert.ToInt32(dgCars.SelectedRows[0].Cells["CarId"].Value);

                    var carToUpdate = _unitOfWork.Cars.GetById(selectedCarId);
                    if (carToUpdate != null)
                    {
                        if (string.IsNullOrWhiteSpace(txtLicensePlate.Text) ||
                            string.IsNullOrWhiteSpace(txtMake.Text) ||
                            string.IsNullOrWhiteSpace(txtModel.Text) ||
                            string.IsNullOrWhiteSpace(txtYear.Text))
                        {
                            MessageBox.Show("Заповніть всі обов'язкові поля: Номер, Марка, Модель, Рік.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        if (!int.TryParse(txtYear.Text.Trim(), out int year) || year < 1886 || year > DateTime.Now.Year)
                        {
                            MessageBox.Show("Введіть коректний рік випуску автомобіля.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }

                        var selectedClientFullName = cmbClients.SelectedItem.ToString();
                        var client = _context.Clients.FirstOrDefault(c => (c.FirstName + " " + c.LastName) == selectedClientFullName);

                        if (client == null)
                        {
                            MessageBox.Show("Обраний клієнт не знайдений.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        carToUpdate.LicensePlate = txtLicensePlate.Text.Trim();
                        carToUpdate.Make = txtMake.Text.Trim();
                        carToUpdate.Model = txtModel.Text.Trim();
                        carToUpdate.Year = year;
                        carToUpdate.ClientId = client.ClientId;

                        _unitOfWork.Cars.Update(carToUpdate);
                        _unitOfWork.SaveAsync();

                        MessageBox.Show("Дані автомобіля успішно оновлено!", "Успіх", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        DisplayCars();
                    }
                    else
                    {
                        MessageBox.Show("Автомобіль не знайдено.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Виберіть автомобіль для редагування.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Сталася помилка: {ex.Message}", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgCars_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    DataGridViewRow selectedRow = dgCars.Rows[e.RowIndex];

                    txtLicensePlate.Text = selectedRow.Cells["LicensePlate"].Value.ToString();
                    txtMake.Text = selectedRow.Cells["Make"].Value.ToString();
                    txtModel.Text = selectedRow.Cells["Model"].Value.ToString();
                    txtYear.Text = selectedRow.Cells["Year"].Value.ToString();

                    string clientFullName = selectedRow.Cells["FirstName"].Value.ToString() + " " + selectedRow.Cells["LastName"].Value.ToString();
                    cmbClients.SelectedItem = clientFullName;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Сталася помилка при виборі клієнта: {ex.Message}", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCarDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgCars.SelectedRows.Count > 0)
                {
                    int selectedCarId = Convert.ToInt32(dgCars.SelectedRows[0].Cells["CarId"].Value);

                    var confirmResult = MessageBox.Show("Ви впевнені, що хочете видалити цей автомобіль?", "Підтвердження видалення", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (confirmResult == DialogResult.Yes)
                    {
                        _unitOfWork.Cars.Delete(selectedCarId);
                        _unitOfWork.SaveAsync();

                        MessageBox.Show("Автомобіль успішно видалено!", "Успіх", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        DisplayCars();
                    }
                }
                else
                {
                    MessageBox.Show("Виберіть автомобіль для видалення.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Сталася помилка: {ex.Message}", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
