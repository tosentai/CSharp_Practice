using System.Runtime.InteropServices;

namespace Autoservice.PL
{
    public partial class LoginRegForm : Form
    {
        public LoginRegForm()
        {
            InitializeComponent();

            loginForm1.Visible = true;
            regForm1.Visible = false;
        }

        private void close_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Ви точно хочете вийти?", "Confirmation Message"
                , MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        public void ShowLoginForm()
        {
            loginForm1.Visible = true;
            regForm1.Visible = false;
        }

        public void ShowRegForm()
        {
            loginForm1.Visible = false;
            regForm1.Visible = true;
        }

        public void HideLoginFormAndShowMainForm()
        {
            this.Hide();

            MainForm mainForm = new MainForm();
            mainForm.Show();
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);

        private void LoginRegForm_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
    }
}
