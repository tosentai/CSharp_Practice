using System;
using System.Linq;
using System.Windows.Forms;
using Autoservice.DAL.Models;
using Autoservice.DAL.Context;
using Microsoft.EntityFrameworkCore;
using System.Text;
using Autoservice.BL.Repository;

namespace Autoservice.PL
{
    public partial class RegForm : UserControl
    {
        private AutoserviceContext _context;
        private UnitOfWork _unitOfWork;

        public RegForm()
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

        private void btnLogin_Click(object sender, EventArgs e)
        {
            var parentForm = (LoginRegForm)this.Parent;
            parentForm.ShowLoginForm();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtUsername == null || txtPassword == null || txtConfPassword == null)
                {
                    MessageBox.Show("Не вдалося знайти поля вводу. Перевірте компоненти форми.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                string username = txtUsername.Text.Trim();
                string password = txtPassword.Text.Trim();
                string confirmPassword = txtConfPassword.Text.Trim();

                if (string.IsNullOrEmpty(username))
                {
                    MessageBox.Show("Поле 'Username' не може бути порожнім.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (string.IsNullOrEmpty(password))
                {
                    MessageBox.Show("Поле 'Password' не може бути порожнім.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (password != confirmPassword)
                {
                    MessageBox.Show("Паролі не збігаються. Спробуйте ще раз.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (_unitOfWork.Users == null)
                {
                    MessageBox.Show("Репозиторій користувачів не ініціалізовано.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var existingUser = _unitOfWork.Users.GetAll().FirstOrDefault(u => u.Username == username);
                if (existingUser != null)
                {
                    MessageBox.Show("Користувач з таким іменем уже існує.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                string hashedPassword = HashPassword(password);

                var newUser = new User
                {
                    Username = username,
                    Password = hashedPassword,
                    CreatedAt = DateTime.Now,
                    LastLogin = DateTime.Now
                };

                _unitOfWork.Users.Add(newUser);
                _unitOfWork.SaveAsync();

                MessageBox.Show("Реєстрація пройшла успішно!", "Успіх", MessageBoxButtons.OK, MessageBoxIcon.Information);

                txtUsername.Text = string.Empty;
                txtPassword.Text = string.Empty;
                txtConfPassword.Text = string.Empty;

                var parentForm = (LoginRegForm)this.Parent;
                parentForm.ShowLoginForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Сталася помилка: {ex.Message}", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string HashPassword(string password)
        {
            using (var sha256 = System.Security.Cryptography.SHA256.Create())
            {
                var bytes = Encoding.UTF8.GetBytes(password);
                var hash = sha256.ComputeHash(bytes);
                return Convert.ToBase64String(hash);
            }
        }

        private void cbShowPass_CheckedChanged(object sender, EventArgs e)
        {
            txtPassword.PasswordChar = cbShowPass.Checked ? '\0' : '*';
            txtConfPassword.PasswordChar = cbShowPass.Checked ? '\0' : '*';
        }
    }
}
