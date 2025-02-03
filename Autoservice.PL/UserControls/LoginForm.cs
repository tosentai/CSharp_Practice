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
    public partial class LoginForm : UserControl
    {
        private AutoserviceContext _context;
        private UnitOfWork _unitOfWork;

        public LoginForm()
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

        private void btnRegister_Click(object sender, EventArgs e)
        {
            var parentForm = (LoginRegForm)this.Parent;
            parentForm.ShowRegForm();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                string username = txtUsername.Text.Trim();
                string password = txtPassword.Text.Trim();

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

                var user = _unitOfWork.Users.GetAll().FirstOrDefault(u => u.Username == username);
                if (user == null)
                {
                    MessageBox.Show("Користувача з таким іменем не знайдено.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (user.Password != HashPassword(password))
                {
                    MessageBox.Show("Невірний пароль.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                MessageBox.Show("Вітаємо, ви увійшли в систему!", "Успіх", MessageBoxButtons.OK, MessageBoxIcon.Information);

                var parentForm = (LoginRegForm)this.Parent;
                parentForm.HideLoginFormAndShowMainForm();
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
        }
    }
}
