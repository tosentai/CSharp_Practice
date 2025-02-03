namespace Autoservice.PL.Forms
{
    partial class SearchForm
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            dgSearchClient = new DataGridView();
            dgSearchOrder = new DataGridView();
            dgSearchCar = new DataGridView();
            txtSearch = new TextBox();
            close = new PictureBox();
            btnMainOrders = new Button();
            ((System.ComponentModel.ISupportInitialize)dgSearchClient).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgSearchOrder).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgSearchCar).BeginInit();
            ((System.ComponentModel.ISupportInitialize)close).BeginInit();
            SuspendLayout();
            // 
            // dgSearchClient
            // 
            dgSearchClient.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgSearchClient.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgSearchClient.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Window;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle1.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgSearchClient.DefaultCellStyle = dataGridViewCellStyle1;
            dgSearchClient.Location = new Point(50, 50);
            dgSearchClient.Name = "dgSearchClient";
            dgSearchClient.Size = new Size(520, 250);
            dgSearchClient.TabIndex = 0;
            // 
            // dgSearchOrder
            // 
            dgSearchOrder.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgSearchOrder.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgSearchOrder.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Window;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dgSearchOrder.DefaultCellStyle = dataGridViewCellStyle2;
            dgSearchOrder.Location = new Point(50, 330);
            dgSearchOrder.Name = "dgSearchOrder";
            dgSearchOrder.Size = new Size(520, 250);
            dgSearchOrder.TabIndex = 1;
            // 
            // dgSearchCar
            // 
            dgSearchCar.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgSearchCar.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgSearchCar.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = SystemColors.Window;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle3.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
            dgSearchCar.DefaultCellStyle = dataGridViewCellStyle3;
            dgSearchCar.Location = new Point(600, 50);
            dgSearchCar.Name = "dgSearchCar";
            dgSearchCar.Size = new Size(580, 530);
            dgSearchCar.TabIndex = 2;
            // 
            // txtSearch
            // 
            txtSearch.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            txtSearch.Location = new Point(350, 611);
            txtSearch.Name = "txtSearch";
            txtSearch.PlaceholderText = "Client first name or last name";
            txtSearch.Size = new Size(530, 29);
            txtSearch.TabIndex = 3;
            txtSearch.TextChanged += txtSearch_TextChanged;
            // 
            // close
            // 
            close.BackColor = Color.Transparent;
            close.Image = Properties.Resources.close;
            close.Location = new Point(1194, 12);
            close.Name = "close";
            close.Size = new Size(24, 24);
            close.SizeMode = PictureBoxSizeMode.AutoSize;
            close.TabIndex = 13;
            close.TabStop = false;
            close.Click += close_Click;
            // 
            // btnMainOrders
            // 
            btnMainOrders.BackColor = Color.FromArgb(60, 60, 60);
            btnMainOrders.FlatStyle = FlatStyle.Flat;
            btnMainOrders.Font = new Font("Montserrat ExtraBold", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 204);
            btnMainOrders.ForeColor = Color.White;
            btnMainOrders.Location = new Point(350, 659);
            btnMainOrders.Name = "btnMainOrders";
            btnMainOrders.Size = new Size(530, 50);
            btnMainOrders.TabIndex = 14;
            btnMainOrders.Text = "Show all information";
            btnMainOrders.UseVisualStyleBackColor = false;
            btnMainOrders.Click += btnMainOrders_Click;
            // 
            // SearchForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.wallpaperblue;
            ClientSize = new Size(1230, 750);
            Controls.Add(btnMainOrders);
            Controls.Add(close);
            Controls.Add(txtSearch);
            Controls.Add(dgSearchCar);
            Controls.Add(dgSearchOrder);
            Controls.Add(dgSearchClient);
            FormBorderStyle = FormBorderStyle.None;
            Name = "SearchForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "SearchForm";
            MouseDown += SearchForm_MouseDown;
            ((System.ComponentModel.ISupportInitialize)dgSearchClient).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgSearchOrder).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgSearchCar).EndInit();
            ((System.ComponentModel.ISupportInitialize)close).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgSearchClient;
        private DataGridView dgSearchOrder;
        private DataGridView dgSearchCar;
        private TextBox txtSearch;
        private PictureBox close;
        private Button btnMainOrders;
    }
}