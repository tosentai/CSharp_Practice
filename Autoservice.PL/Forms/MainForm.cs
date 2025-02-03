using Autoservice.PL.Forms;
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

namespace Autoservice.PL
{
    public partial class MainForm : Form
    {

        public MainForm()
        {
            InitializeComponent();
            clients1.ClientsUpdated += cars1.LoadClientsToComboBox;
        }

        private void close_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Ви точно хочете вийти?", "Confirmation Message"
                , MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void btnMainClients_Click(object sender, EventArgs e)
        {
            clients1.Visible = true;
            cars1.Visible = false;
            empAndServ1.Visible = false;
            orders1.Visible = false;
            billing1.Visible = false;
            reports1.Visible = false;
        }

        private void btnMainCars_Click(object sender, EventArgs e)
        {
            clients1.Visible = false;
            cars1.Visible = true;
            empAndServ1.Visible = false;
            orders1.Visible = false;
            billing1.Visible = false;
            reports1.Visible = false;
        }

        private void btnMainEmployees_Click(object sender, EventArgs e)
        {
            clients1.Visible = false;
            cars1.Visible = false;
            empAndServ1.Visible = true;
            orders1.Visible = false;
            billing1.Visible = false;
            reports1.Visible = false;
        }

        private void btnMainOrders_Click(object sender, EventArgs e)
        {
            clients1.Visible = false;
            cars1.Visible = false;
            empAndServ1.Visible = false;
            orders1.Visible = true;
            billing1.Visible = false;
            reports1.Visible = false;
        }

        private void btnMainBilling_Click(object sender, EventArgs e)
        {
            clients1.Visible = false;
            cars1.Visible = false;
            empAndServ1.Visible = false;
            orders1.Visible = false;
            billing1.Visible = true;
            reports1.Visible = false;
        }

        private void btnMainReport_Click(object sender, EventArgs e)
        {
            clients1.Visible = false;
            cars1.Visible = false;
            empAndServ1.Visible = false;
            orders1.Visible = false;
            billing1.Visible = false;
            reports1.Visible = true;
        }

        private async void pbSearch_Click(object sender, EventArgs e)
        {
            var originalImage = pbSearch.Image;
            var blueImage = Properties.Resources.member_search_blue;
            pbSearch.Image = blueImage;
            await Task.Delay(100);
            pbSearch.Image = originalImage;

            SearchForm searchForm = new SearchForm();
            searchForm.Show();
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);

        private void MainForm_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
    }
}
