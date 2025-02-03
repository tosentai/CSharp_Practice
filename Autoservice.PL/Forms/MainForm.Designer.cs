namespace Autoservice.PL
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            panel1 = new Panel();
            pbSearch = new PictureBox();
            pictureBox1 = new PictureBox();
            panel2 = new Panel();
            btnMainReport = new Button();
            btnMainEmployees = new Button();
            btnMainBilling = new Button();
            btnMainOrders = new Button();
            btnMainCars = new Button();
            btnMainClients = new Button();
            close = new PictureBox();
            panel3 = new Panel();
            clients1 = new Clients();
            cars1 = new Cars();
            reports1 = new Reports();
            billing1 = new Billing();
            orders1 = new Orders();
            empAndServ1 = new EmpAndServ();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pbSearch).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)close).BeginInit();
            panel3.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(60, 60, 60);
            panel1.Controls.Add(pbSearch);
            panel1.Controls.Add(pictureBox1);
            panel1.Controls.Add(panel2);
            panel1.Dock = DockStyle.Left;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(200, 750);
            panel1.TabIndex = 0;
            // 
            // pbSearch
            // 
            pbSearch.Image = Properties.Resources.member_search;
            pbSearch.Location = new Point(168, 168);
            pbSearch.Name = "pbSearch";
            pbSearch.Size = new Size(32, 32);
            pbSearch.SizeMode = PictureBoxSizeMode.AutoSize;
            pbSearch.TabIndex = 5;
            pbSearch.TabStop = false;
            pbSearch.Click += pbSearch_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.logo128;
            pictureBox1.Location = new Point(36, 36);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(128, 128);
            pictureBox1.SizeMode = PictureBoxSizeMode.AutoSize;
            pictureBox1.TabIndex = 1;
            pictureBox1.TabStop = false;
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(5, 8, 15);
            panel2.Controls.Add(btnMainReport);
            panel2.Controls.Add(btnMainEmployees);
            panel2.Controls.Add(btnMainBilling);
            panel2.Controls.Add(btnMainOrders);
            panel2.Controls.Add(btnMainCars);
            panel2.Controls.Add(btnMainClients);
            panel2.Dock = DockStyle.Bottom;
            panel2.Location = new Point(0, 200);
            panel2.Name = "panel2";
            panel2.Size = new Size(200, 550);
            panel2.TabIndex = 0;
            // 
            // btnMainReport
            // 
            btnMainReport.BackColor = Color.FromArgb(60, 60, 60);
            btnMainReport.FlatStyle = FlatStyle.Flat;
            btnMainReport.Font = new Font("Montserrat ExtraBold", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 204);
            btnMainReport.ForeColor = Color.White;
            btnMainReport.Location = new Point(25, 475);
            btnMainReport.Name = "btnMainReport";
            btnMainReport.Size = new Size(150, 50);
            btnMainReport.TabIndex = 5;
            btnMainReport.Text = "Reports";
            btnMainReport.UseVisualStyleBackColor = false;
            btnMainReport.Click += btnMainReport_Click;
            // 
            // btnMainEmployees
            // 
            btnMainEmployees.BackColor = Color.FromArgb(60, 60, 60);
            btnMainEmployees.FlatStyle = FlatStyle.Flat;
            btnMainEmployees.Font = new Font("Montserrat ExtraBold", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 204);
            btnMainEmployees.ForeColor = Color.White;
            btnMainEmployees.Location = new Point(25, 175);
            btnMainEmployees.Name = "btnMainEmployees";
            btnMainEmployees.Size = new Size(150, 125);
            btnMainEmployees.TabIndex = 5;
            btnMainEmployees.Text = "Employees\r\nand\r\nServices";
            btnMainEmployees.UseVisualStyleBackColor = false;
            btnMainEmployees.Click += btnMainEmployees_Click;
            // 
            // btnMainBilling
            // 
            btnMainBilling.BackColor = Color.FromArgb(60, 60, 60);
            btnMainBilling.FlatStyle = FlatStyle.Flat;
            btnMainBilling.Font = new Font("Montserrat ExtraBold", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 204);
            btnMainBilling.ForeColor = Color.White;
            btnMainBilling.Location = new Point(25, 400);
            btnMainBilling.Name = "btnMainBilling";
            btnMainBilling.Size = new Size(150, 50);
            btnMainBilling.TabIndex = 5;
            btnMainBilling.Text = "Billing";
            btnMainBilling.UseVisualStyleBackColor = false;
            btnMainBilling.Click += btnMainBilling_Click;
            // 
            // btnMainOrders
            // 
            btnMainOrders.BackColor = Color.FromArgb(60, 60, 60);
            btnMainOrders.FlatStyle = FlatStyle.Flat;
            btnMainOrders.Font = new Font("Montserrat ExtraBold", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 204);
            btnMainOrders.ForeColor = Color.White;
            btnMainOrders.Location = new Point(25, 325);
            btnMainOrders.Name = "btnMainOrders";
            btnMainOrders.Size = new Size(150, 50);
            btnMainOrders.TabIndex = 5;
            btnMainOrders.Text = "Orders";
            btnMainOrders.UseVisualStyleBackColor = false;
            btnMainOrders.Click += btnMainOrders_Click;
            // 
            // btnMainCars
            // 
            btnMainCars.BackColor = Color.FromArgb(60, 60, 60);
            btnMainCars.FlatStyle = FlatStyle.Flat;
            btnMainCars.Font = new Font("Montserrat ExtraBold", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 204);
            btnMainCars.ForeColor = Color.White;
            btnMainCars.Location = new Point(25, 100);
            btnMainCars.Name = "btnMainCars";
            btnMainCars.Size = new Size(150, 50);
            btnMainCars.TabIndex = 5;
            btnMainCars.Text = "Cars";
            btnMainCars.UseVisualStyleBackColor = false;
            btnMainCars.Click += btnMainCars_Click;
            // 
            // btnMainClients
            // 
            btnMainClients.BackColor = Color.FromArgb(60, 60, 60);
            btnMainClients.FlatStyle = FlatStyle.Flat;
            btnMainClients.Font = new Font("Montserrat ExtraBold", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 204);
            btnMainClients.ForeColor = Color.White;
            btnMainClients.Location = new Point(25, 25);
            btnMainClients.Name = "btnMainClients";
            btnMainClients.Size = new Size(150, 50);
            btnMainClients.TabIndex = 5;
            btnMainClients.Text = "Clients";
            btnMainClients.UseVisualStyleBackColor = false;
            btnMainClients.Click += btnMainClients_Click;
            // 
            // close
            // 
            close.BackColor = Color.Transparent;
            close.Image = Properties.Resources.close;
            close.Location = new Point(1194, 12);
            close.Name = "close";
            close.Size = new Size(24, 24);
            close.SizeMode = PictureBoxSizeMode.AutoSize;
            close.TabIndex = 3;
            close.TabStop = false;
            close.Click += close_Click;
            // 
            // panel3
            // 
            panel3.BackColor = Color.Transparent;
            panel3.Controls.Add(clients1);
            panel3.Controls.Add(cars1);
            panel3.Controls.Add(reports1);
            panel3.Controls.Add(billing1);
            panel3.Controls.Add(orders1);
            panel3.Controls.Add(empAndServ1);
            panel3.Location = new Point(250, 36);
            panel3.Name = "panel3";
            panel3.Size = new Size(932, 678);
            panel3.TabIndex = 4;
            // 
            // clients1
            // 
            clients1.BackColor = Color.FromArgb(60, 60, 60);
            clients1.Location = new Point(0, 0);
            clients1.Name = "clients1";
            clients1.Size = new Size(932, 678);
            clients1.TabIndex = 0;
            // 
            // cars1
            // 
            cars1.BackColor = Color.FromArgb(60, 60, 60);
            cars1.Location = new Point(0, 0);
            cars1.Name = "cars1";
            cars1.Size = new Size(932, 678);
            cars1.TabIndex = 1;
            // 
            // reports1
            // 
            reports1.BackColor = Color.FromArgb(60, 60, 60);
            reports1.Location = new Point(0, 0);
            reports1.Name = "reports1";
            reports1.Size = new Size(932, 678);
            reports1.TabIndex = 5;
            // 
            // billing1
            // 
            billing1.BackColor = Color.FromArgb(60, 60, 60);
            billing1.Location = new Point(0, 0);
            billing1.Name = "billing1";
            billing1.Size = new Size(932, 678);
            billing1.TabIndex = 4;
            // 
            // orders1
            // 
            orders1.BackColor = Color.FromArgb(60, 60, 60);
            orders1.Location = new Point(0, 0);
            orders1.Name = "orders1";
            orders1.Size = new Size(932, 678);
            orders1.TabIndex = 3;
            // 
            // empAndServ1
            // 
            empAndServ1.BackColor = Color.FromArgb(60, 60, 60);
            empAndServ1.Location = new Point(0, 0);
            empAndServ1.Name = "empAndServ1";
            empAndServ1.Size = new Size(932, 678);
            empAndServ1.TabIndex = 2;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.wallpaperblue;
            ClientSize = new Size(1230, 750);
            Controls.Add(panel3);
            Controls.Add(close);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            MouseDown += MainForm_MouseDown;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pbSearch).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)close).EndInit();
            panel3.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private Panel panel2;
        private PictureBox pictureBox1;
        private PictureBox close;
        private Button btnMainCars;
        private Button btnMainClients;
        private Button btnMainEmployees;
        private Button btnMainOrders;
        private Button btnMainBilling;
        private Button btnMainReport;
        private Panel panel3;
        private EmpAndServ employees1;
        private Clients clients1;
        private Cars cars1;
        private Reports reports1;
        private Billing billing1;
        private Orders orders1;
        private EmpAndServ empAndServ1;
        private PictureBox pbSearch;
    }
}