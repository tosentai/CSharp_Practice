using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Autoservice.DAL.Context;
using Microsoft.EntityFrameworkCore;
using Autoservice.DAL.Models;
using Autoservice.BL.Repository;

namespace Autoservice.PL
{
    public partial class EmpAndServ : UserControl
    {
        private AutoserviceContext _context;
        private UnitOfWork _unitOfWork;

        public EmpAndServ()
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

                DisplayEmployees();
                DisplayServices();
            }
        }

        private void btnEmpAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtName.Text) || string.IsNullOrWhiteSpace(txtPosition.Text))
                {
                    MessageBox.Show("Заповніть всі обов'язкові поля: Ім'я, Посада.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var newEmployee = new Employee
                {
                    Name = txtName.Text.Trim(),
                    Position = txtPosition.Text.Trim(),
                    Phone = string.IsNullOrWhiteSpace(txtPhone.Text) ? null : txtPhone.Text.Trim()
                };

                _unitOfWork.Employees.Add(newEmployee);
                _unitOfWork.SaveAsync();

                MessageBox.Show("Співробітника успішно додано!", "Успіх", MessageBoxButtons.OK, MessageBoxIcon.Information);

                txtName.Clear();
                txtPosition.Clear();
                txtPhone.Clear();

                DisplayEmployees();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Сталася помилка: {ex.Message}", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEmpEdit_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgEmployee.SelectedRows.Count > 0)
                {
                    int selectedEmployeeId = Convert.ToInt32(dgEmployee.SelectedRows[0].Cells["EmployeeId"].Value);

                    var employeeToUpdate = _unitOfWork.Employees.GetById(selectedEmployeeId);
                    if (employeeToUpdate != null)
                    {
                        if (string.IsNullOrWhiteSpace(txtName.Text) || string.IsNullOrWhiteSpace(txtPosition.Text))
                        {
                            MessageBox.Show("Заповніть всі обов'язкові поля: Ім'я, Посада.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }

                        employeeToUpdate.Name = txtName.Text.Trim();
                        employeeToUpdate.Position = txtPosition.Text.Trim();
                        employeeToUpdate.Phone = string.IsNullOrWhiteSpace(txtPhone.Text) ? null : txtPhone.Text.Trim();

                        _unitOfWork.Employees.Update(employeeToUpdate);
                        _unitOfWork.SaveAsync();

                        MessageBox.Show("Дані співробітника успішно оновлено!", "Успіх", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        DisplayEmployees();
                    }
                    else
                    {
                        MessageBox.Show("Співробітника не знайдено.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Виберіть співробітника для редагування.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Сталася помилка: {ex.Message}", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEmpDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgEmployee.SelectedRows.Count > 0)
                {
                    int selectedEmployeeId = Convert.ToInt32(dgEmployee.SelectedRows[0].Cells["EmployeeId"].Value);

                    var confirmResult = MessageBox.Show("Ви впевнені, що хочете видалити цього співробітника?", "Підтвердження видалення", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (confirmResult == DialogResult.Yes)
                    {
                        _unitOfWork.Employees.Delete(selectedEmployeeId);
                        _unitOfWork.SaveAsync();

                        MessageBox.Show("Співробітника успішно видалено!", "Успіх", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        DisplayEmployees();
                        DisplayServices();
                    }
                }
                else
                {
                    MessageBox.Show("Виберіть співробітника для видалення.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Сталася помилка: {ex.Message}", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgEmployee_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    DataGridViewRow selectedRow = dgEmployee.Rows[e.RowIndex];

                    txtName.Text = selectedRow.Cells["Name"].Value?.ToString();
                    txtPosition.Text = selectedRow.Cells["Position"].Value?.ToString();
                    txtPhone.Text = selectedRow.Cells["Phone"].Value?.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Сталася помилка при виборі співробітника: {ex.Message}", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DisplayEmployees()
        {
            try
            {
                var employees = _context.Employees.Select(emp => new
                {
                    emp.EmployeeId,
                    emp.Name,
                    emp.Position,
                    emp.Phone
                }).ToList();

                dgEmployee.DataSource = employees;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Сталася помилка при завантаженні співробітників: {ex.Message}", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnServAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtServName.Text) || string.IsNullOrWhiteSpace(txtServPrice.Text))
                {
                    MessageBox.Show("Заповніть всі обов'язкові поля: Назва послуги, Ціна.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!decimal.TryParse(txtServPrice.Text.Trim(), out var price) || price < 0)
                {
                    MessageBox.Show("Ціна повинна бути числовим значенням більше 0.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var newService = new Service
                {
                    Name = txtServName.Text.Trim(),
                    Price = price
                };

                _unitOfWork.Services.Add(newService);
                _unitOfWork.SaveAsync();

                MessageBox.Show("Послугу успішно додано!", "Успіх", MessageBoxButtons.OK, MessageBoxIcon.Information);

                txtServName.Clear();
                txtServPrice.Clear();

                DisplayServices();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Сталася помилка: {ex.Message}", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnServEdit_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgService.SelectedRows.Count > 0)
                {
                    int selectedServiceId = Convert.ToInt32(dgService.SelectedRows[0].Cells["ServiceId"].Value);

                    var serviceToUpdate = _unitOfWork.Services.GetById(selectedServiceId);
                    if (serviceToUpdate != null)
                    {
                        if (string.IsNullOrWhiteSpace(txtServName.Text) || string.IsNullOrWhiteSpace(txtServPrice.Text))
                        {
                            MessageBox.Show("Заповніть всі обов'язкові поля: Назва послуги, Ціна.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }

                        if (!decimal.TryParse(txtServPrice.Text.Trim(), out var price) || price < 0)
                        {
                            MessageBox.Show("Ціна повинна бути числовим значенням більше 0.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }

                        serviceToUpdate.Name = txtServName.Text.Trim();
                        serviceToUpdate.Price = price;

                        _unitOfWork.Services.Update(serviceToUpdate);
                        _unitOfWork.SaveAsync();

                        MessageBox.Show("Дані послуги успішно оновлено!", "Успіх", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        DisplayServices();
                    }
                    else
                    {
                        MessageBox.Show("Послугу не знайдено.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Виберіть послугу для редагування.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Сталася помилка: {ex.Message}", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnServDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgService.SelectedRows.Count > 0)
                {
                    int selectedServiceId = Convert.ToInt32(dgService.SelectedRows[0].Cells["ServiceId"].Value);

                    var confirmResult = MessageBox.Show("Ви впевнені, що хочете видалити цю послугу?", "Підтвердження видалення", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (confirmResult == DialogResult.Yes)
                    {
                        _unitOfWork.Services.Delete(selectedServiceId);
                        _unitOfWork.SaveAsync();

                        MessageBox.Show("Послугу успішно видалено!", "Успіх", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        DisplayServices();
                    }
                }
                else
                {
                    MessageBox.Show("Виберіть послугу для видалення.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Сталася помилка: {ex.Message}", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgService_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    DataGridViewRow selectedRow = dgService.Rows[e.RowIndex];

                    txtServName.Text = selectedRow.Cells["Name"].Value?.ToString();
                    txtServPrice.Text = selectedRow.Cells["Price"].Value?.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Сталася помилка при виборі послуги: {ex.Message}", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DisplayServices()
        {
            try
            {
                var services = _context.Services.Select(s => new
                {
                    s.ServiceId,
                    s.Name,
                    s.Price
                }).ToList();

                dgService.DataSource = services;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Сталася помилка при завантаженні послуг: {ex.Message}", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
