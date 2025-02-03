namespace Autoservice.PL
{
    partial class Cars
    {
        /// <summary> 
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором компонентов

        /// <summary> 
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            txtYear = new TextBox();
            txtModel = new TextBox();
            txtMake = new TextBox();
            txtLicensePlate = new TextBox();
            panel1 = new Panel();
            cmbClients = new ComboBox();
            label6 = new Label();
            btnCarDelete = new Button();
            btnCarEdit = new Button();
            btnCarAdd = new Button();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            dgCars = new DataGridView();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgCars).BeginInit();
            SuspendLayout();
            // 
            // txtYear
            // 
            txtYear.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            txtYear.Location = new Point(22, 410);
            txtYear.Name = "txtYear";
            txtYear.PlaceholderText = "e.g. 2000";
            txtYear.Size = new Size(257, 29);
            txtYear.TabIndex = 5;
            // 
            // txtModel
            // 
            txtModel.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            txtModel.Location = new Point(22, 340);
            txtModel.Name = "txtModel";
            txtModel.PlaceholderText = "e.g. 911";
            txtModel.Size = new Size(257, 29);
            txtModel.TabIndex = 4;
            // 
            // txtMake
            // 
            txtMake.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            txtMake.Location = new Point(22, 270);
            txtMake.Name = "txtMake";
            txtMake.PlaceholderText = "e.g. Porsсhe";
            txtMake.Size = new Size(257, 29);
            txtMake.TabIndex = 3;
            // 
            // txtLicensePlate
            // 
            txtLicensePlate.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            txtLicensePlate.Location = new Point(22, 200);
            txtLicensePlate.Name = "txtLicensePlate";
            txtLicensePlate.PlaceholderText = "e.g. АА1234ВС";
            txtLicensePlate.Size = new Size(257, 29);
            txtLicensePlate.TabIndex = 2;
            // 
            // panel1
            // 
            panel1.Controls.Add(cmbClients);
            panel1.Controls.Add(label6);
            panel1.Controls.Add(btnCarDelete);
            panel1.Controls.Add(btnCarEdit);
            panel1.Controls.Add(btnCarAdd);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(txtYear);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(txtModel);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(txtMake);
            panel1.Controls.Add(txtLicensePlate);
            panel1.Dock = DockStyle.Left;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(300, 678);
            panel1.TabIndex = 5;
            // 
            // cmbClients
            // 
            cmbClients.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            cmbClients.FormattingEnabled = true;
            cmbClients.Location = new Point(22, 130);
            cmbClients.Name = "cmbClients";
            cmbClients.Size = new Size(257, 29);
            cmbClients.TabIndex = 8;
            // 
            // label6
            // 
            label6.BackColor = Color.Transparent;
            label6.Font = new Font("Montserrat ExtraBold", 26.2499962F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label6.ForeColor = Color.White;
            label6.Location = new Point(0, 37);
            label6.Name = "label6";
            label6.Size = new Size(300, 61);
            label6.TabIndex = 7;
            label6.Text = "Manage Car";
            label6.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnCarDelete
            // 
            btnCarDelete.BackColor = Color.FromArgb(5, 8, 15);
            btnCarDelete.FlatStyle = FlatStyle.Flat;
            btnCarDelete.Font = new Font("Montserrat ExtraBold", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 204);
            btnCarDelete.ForeColor = Color.White;
            btnCarDelete.Location = new Point(22, 604);
            btnCarDelete.Name = "btnCarDelete";
            btnCarDelete.Size = new Size(257, 50);
            btnCarDelete.TabIndex = 6;
            btnCarDelete.Text = "Delete";
            btnCarDelete.UseVisualStyleBackColor = false;
            btnCarDelete.Click += btnCarDelete_Click;
            // 
            // btnCarEdit
            // 
            btnCarEdit.BackColor = Color.FromArgb(5, 8, 15);
            btnCarEdit.FlatStyle = FlatStyle.Flat;
            btnCarEdit.Font = new Font("Montserrat ExtraBold", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 204);
            btnCarEdit.ForeColor = Color.White;
            btnCarEdit.Location = new Point(22, 529);
            btnCarEdit.Name = "btnCarEdit";
            btnCarEdit.Size = new Size(257, 50);
            btnCarEdit.TabIndex = 6;
            btnCarEdit.Text = "Edit";
            btnCarEdit.UseVisualStyleBackColor = false;
            btnCarEdit.Click += btnCarEdit_Click;
            // 
            // btnCarAdd
            // 
            btnCarAdd.BackColor = Color.FromArgb(5, 8, 15);
            btnCarAdd.FlatStyle = FlatStyle.Flat;
            btnCarAdd.Font = new Font("Montserrat ExtraBold", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 204);
            btnCarAdd.ForeColor = Color.White;
            btnCarAdd.Location = new Point(22, 454);
            btnCarAdd.Name = "btnCarAdd";
            btnCarAdd.Size = new Size(257, 50);
            btnCarAdd.TabIndex = 6;
            btnCarAdd.Text = "Add";
            btnCarAdd.UseVisualStyleBackColor = false;
            btnCarAdd.Click += btnCarAdd_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Montserrat ExtraBold", 12F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label5.ForeColor = Color.White;
            label5.Location = new Point(22, 380);
            label5.Name = "label5";
            label5.Size = new Size(59, 22);
            label5.TabIndex = 4;
            label5.Text = "Year *";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Montserrat ExtraBold", 12F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label4.ForeColor = Color.White;
            label4.Location = new Point(22, 310);
            label4.Name = "label4";
            label4.Size = new Size(74, 22);
            label4.TabIndex = 4;
            label4.Text = "Model *";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Montserrat ExtraBold", 12F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label3.ForeColor = Color.White;
            label3.Location = new Point(22, 240);
            label3.Name = "label3";
            label3.Size = new Size(68, 22);
            label3.TabIndex = 4;
            label3.Text = "Make *";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Montserrat ExtraBold", 12F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label2.ForeColor = Color.White;
            label2.Location = new Point(22, 170);
            label2.Name = "label2";
            label2.Size = new Size(135, 22);
            label2.TabIndex = 4;
            label2.Text = "License plate *";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Montserrat ExtraBold", 12F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label1.ForeColor = Color.White;
            label1.Location = new Point(22, 100);
            label1.Name = "label1";
            label1.Size = new Size(72, 22);
            label1.TabIndex = 4;
            label1.Text = "Client *";
            // 
            // dgCars
            // 
            dgCars.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgCars.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgCars.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Window;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle1.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgCars.DefaultCellStyle = dataGridViewCellStyle1;
            dgCars.Location = new Point(306, 13);
            dgCars.Name = "dgCars";
            dgCars.Size = new Size(612, 652);
            dgCars.TabIndex = 6;
            dgCars.CellClick += dgCars_CellClick;
            // 
            // Cars
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(60, 60, 60);
            Controls.Add(panel1);
            Controls.Add(dgCars);
            Name = "Cars";
            Size = new Size(932, 678);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgCars).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TextBox txtYear;
        private TextBox txtModel;
        private TextBox txtMake;
        private TextBox txtLicensePlate;
        private Panel panel1;
        private Label label6;
        private Button btnCarDelete;
        private Button btnCarEdit;
        private Button btnCarAdd;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
        private DataGridView dgCars;
        private ComboBox cmbClients;
    }
}
