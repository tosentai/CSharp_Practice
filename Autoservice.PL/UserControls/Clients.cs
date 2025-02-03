using System;
using System.Windows.Forms;
using Autoservice.BL.Repository;
using Autoservice.DAL.Context;
using Autoservice.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace Autoservice.PL
{
    public partial class Clients : UserControl
    {
        private AutoserviceContext _context;
        private UnitOfWork _unitOfWork;
        private Cars _carsForm;
        public event Action ClientsUpdated;

        public Clients()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            if (!DesignMode)
            {
                try
                {
                    var options = new DbContextOptionsBuilder<AutoserviceContext>()
                        .UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=AutoserviceDB;Trusted_Connection=True;TrustServerCertificate=True;")
                        .Options;

                    _context = new AutoserviceContext(options);
                    _unitOfWork = new UnitOfWork(_context);

                    DisplayClients();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Помилка ініціалізації бази даних: {ex.Message}", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnClientsAdd_Click(object sender, EventArgs e)
        {
            try
            {
                var newClient = new Client
                {
                    FirstName = txtFirstName.Text.Trim(),
                    LastName = txtLastName.Text.Trim(),
                    Phone = txtPhone.Text.Trim(),
                    Email = string.IsNullOrWhiteSpace(txtEmail.Text) ? null : txtEmail.Text.Trim(),
                    Address = string.IsNullOrWhiteSpace(txtAddress.Text) ? null : txtAddress.Text.Trim()
                };

                _unitOfWork.Clients.Add(newClient);
                _unitOfWork.SaveAsync();

                MessageBox.Show("Клієнта успішно додано!", "Успіх", MessageBoxButtons.OK, MessageBoxIcon.Information);

                ClientsUpdated?.Invoke();

                DisplayClients();

                txtFirstName.Clear();
                txtLastName.Clear();
                txtPhone.Clear();
                txtEmail.Clear();
                txtAddress.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Сталася помилка: {ex.Message}", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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

                dgClients.DataSource = clients;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Сталася помилка при завантаженні клієнтів: {ex.Message}", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void SetCarsForm(Cars carsForm)
        {
            _carsForm = carsForm;
        }

        private void dgClients_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    DataGridViewRow selectedRow = dgClients.Rows[e.RowIndex];

                    txtFirstName.Text = selectedRow.Cells["FirstName"].Value?.ToString();
                    txtLastName.Text = selectedRow.Cells["LastName"].Value?.ToString();
                    txtPhone.Text = selectedRow.Cells["Phone"].Value?.ToString();
                    txtEmail.Text = selectedRow.Cells["Email"].Value?.ToString();
                    txtAddress.Text = selectedRow.Cells["Address"].Value?.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Сталася помилка при виборі клієнта: {ex.Message}", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClientsEdit_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgClients.SelectedRows.Count > 0)
                {
                    int selectedClientId = Convert.ToInt32(dgClients.SelectedRows[0].Cells["ClientId"].Value);

                    var clientToUpdate = _unitOfWork.Clients.GetById(selectedClientId);
                    if (clientToUpdate != null)
                    {
                        if (string.IsNullOrWhiteSpace(txtFirstName.Text) || string.IsNullOrWhiteSpace(txtLastName.Text) || string.IsNullOrWhiteSpace(txtPhone.Text))
                        {
                            MessageBox.Show("Заповніть всі обов'язкові поля: Ім'я, Прізвище, Телефон.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        clientToUpdate.FirstName = txtFirstName.Text.Trim();
                        clientToUpdate.LastName = txtLastName.Text.Trim();
                        clientToUpdate.Phone = txtPhone.Text.Trim();
                        clientToUpdate.Email = string.IsNullOrWhiteSpace(txtEmail.Text) ? null : txtEmail.Text.Trim();
                        clientToUpdate.Address = string.IsNullOrWhiteSpace(txtAddress.Text) ? null : txtAddress.Text.Trim();

                        _unitOfWork.Clients.Update(clientToUpdate);
                        _unitOfWork.SaveAsync();

                        MessageBox.Show("Дані клієнта успішно оновлено!", "Успіх", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        ClientsUpdated?.Invoke();

                        DisplayClients();
                    }
                    else
                    {
                        MessageBox.Show("Клієнта не знайдено.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Виберіть клієнта для редагування.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Сталася помилка: {ex.Message}", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClientsDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgClients.SelectedRows.Count > 0)
                {
                    int selectedClientId = Convert.ToInt32(dgClients.SelectedRows[0].Cells["ClientId"].Value);

                    var confirmResult = MessageBox.Show("Ви впевнені, що хочете видалити цього клієнта?", "Підтвердження видалення", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (confirmResult == DialogResult.Yes)
                    {
                        _unitOfWork.Clients.Delete(selectedClientId);
                        _unitOfWork.SaveAsync();

                        MessageBox.Show("Клієнта успішно видалено!", "Успіх", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        ClientsUpdated?.Invoke();

                        DisplayClients();
                    }
                }
                else
                {
                    MessageBox.Show("Виберіть клієнта для видалення.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Сталася помилка: {ex.Message}", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
