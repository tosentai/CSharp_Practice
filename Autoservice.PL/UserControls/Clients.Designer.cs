namespace Autoservice.PL
{
    partial class Clients
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
            txtFirstName = new TextBox();
            txtLastName = new TextBox();
            txtPhone = new TextBox();
            txtEmail = new TextBox();
            txtAddress = new TextBox();
            panel1 = new Panel();
            label6 = new Label();
            btnClientsDelete = new Button();
            btnClientsEdit = new Button();
            btnClientsAdd = new Button();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            dgClients = new DataGridView();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgClients).BeginInit();
            SuspendLayout();
            // 
            // txtFirstName
            // 
            txtFirstName.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            txtFirstName.Location = new Point(22, 127);
            txtFirstName.Name = "txtFirstName";
            txtFirstName.PlaceholderText = "e.g. Anton";
            txtFirstName.Size = new Size(257, 29);
            txtFirstName.TabIndex = 1;
            // 
            // txtLastName
            // 
            txtLastName.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            txtLastName.Location = new Point(22, 197);
            txtLastName.Name = "txtLastName";
            txtLastName.PlaceholderText = "e.g. Anpilohov";
            txtLastName.Size = new Size(257, 29);
            txtLastName.TabIndex = 2;
            // 
            // txtPhone
            // 
            txtPhone.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            txtPhone.Location = new Point(22, 267);
            txtPhone.Name = "txtPhone";
            txtPhone.PlaceholderText = "+380XXXXXXXXX";
            txtPhone.Size = new Size(257, 29);
            txtPhone.TabIndex = 3;
            // 
            // txtEmail
            // 
            txtEmail.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            txtEmail.Location = new Point(22, 337);
            txtEmail.Name = "txtEmail";
            txtEmail.PlaceholderText = "example@email.com";
            txtEmail.Size = new Size(257, 29);
            txtEmail.TabIndex = 4;
            // 
            // txtAddress
            // 
            txtAddress.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            txtAddress.Location = new Point(22, 407);
            txtAddress.Name = "txtAddress";
            txtAddress.PlaceholderText = "e.g. New York, Main Street, 123";
            txtAddress.Size = new Size(257, 29);
            txtAddress.TabIndex = 5;
            // 
            // panel1
            // 
            panel1.Controls.Add(label6);
            panel1.Controls.Add(btnClientsDelete);
            panel1.Controls.Add(btnClientsEdit);
            panel1.Controls.Add(btnClientsAdd);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(txtAddress);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(txtEmail);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(txtFirstName);
            panel1.Controls.Add(txtPhone);
            panel1.Controls.Add(txtLastName);
            panel1.Dock = DockStyle.Left;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(300, 678);
            panel1.TabIndex = 3;
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
            label6.Text = "Manage Client";
            label6.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnClientsDelete
            // 
            btnClientsDelete.BackColor = Color.FromArgb(5, 8, 15);
            btnClientsDelete.FlatStyle = FlatStyle.Flat;
            btnClientsDelete.Font = new Font("Montserrat ExtraBold", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 204);
            btnClientsDelete.ForeColor = Color.White;
            btnClientsDelete.Location = new Point(22, 604);
            btnClientsDelete.Name = "btnClientsDelete";
            btnClientsDelete.Size = new Size(257, 50);
            btnClientsDelete.TabIndex = 6;
            btnClientsDelete.Text = "Delete";
            btnClientsDelete.UseVisualStyleBackColor = false;
            btnClientsDelete.Click += btnClientsDelete_Click;
            // 
            // btnClientsEdit
            // 
            btnClientsEdit.BackColor = Color.FromArgb(5, 8, 15);
            btnClientsEdit.FlatStyle = FlatStyle.Flat;
            btnClientsEdit.Font = new Font("Montserrat ExtraBold", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 204);
            btnClientsEdit.ForeColor = Color.White;
            btnClientsEdit.Location = new Point(22, 529);
            btnClientsEdit.Name = "btnClientsEdit";
            btnClientsEdit.Size = new Size(257, 50);
            btnClientsEdit.TabIndex = 6;
            btnClientsEdit.Text = "Edit";
            btnClientsEdit.UseVisualStyleBackColor = false;
            btnClientsEdit.Click += btnClientsEdit_Click;
            // 
            // btnClientsAdd
            // 
            btnClientsAdd.BackColor = Color.FromArgb(5, 8, 15);
            btnClientsAdd.FlatStyle = FlatStyle.Flat;
            btnClientsAdd.Font = new Font("Montserrat ExtraBold", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 204);
            btnClientsAdd.ForeColor = Color.White;
            btnClientsAdd.Location = new Point(22, 454);
            btnClientsAdd.Name = "btnClientsAdd";
            btnClientsAdd.Size = new Size(257, 50);
            btnClientsAdd.TabIndex = 6;
            btnClientsAdd.Text = "Add";
            btnClientsAdd.UseVisualStyleBackColor = false;
            btnClientsAdd.Click += btnClientsAdd_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Montserrat ExtraBold", 12F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label5.ForeColor = Color.White;
            label5.Location = new Point(22, 377);
            label5.Name = "label5";
            label5.Size = new Size(168, 22);
            label5.TabIndex = 4;
            label5.Text = "Address (optional)";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Montserrat ExtraBold", 12F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label4.ForeColor = Color.White;
            label4.Location = new Point(22, 307);
            label4.Name = "label4";
            label4.Size = new Size(146, 22);
            label4.TabIndex = 4;
            label4.Text = "Email (optional)";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Montserrat ExtraBold", 12F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label3.ForeColor = Color.White;
            label3.Location = new Point(22, 237);
            label3.Name = "label3";
            label3.Size = new Size(77, 22);
            label3.TabIndex = 4;
            label3.Text = "Phone *";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Montserrat ExtraBold", 12F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label2.ForeColor = Color.White;
            label2.Location = new Point(22, 167);
            label2.Name = "label2";
            label2.Size = new Size(111, 22);
            label2.TabIndex = 4;
            label2.Text = "Last name *";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Montserrat ExtraBold", 12F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label1.ForeColor = Color.White;
            label1.Location = new Point(22, 97);
            label1.Name = "label1";
            label1.Size = new Size(113, 22);
            label1.TabIndex = 4;
            label1.Text = "First name *";
            // 
            // dgClients
            // 
            dgClients.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgClients.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgClients.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Window;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle1.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgClients.DefaultCellStyle = dataGridViewCellStyle1;
            dgClients.Location = new Point(306, 13);
            dgClients.Name = "dgClients";
            dgClients.Size = new Size(612, 652);
            dgClients.TabIndex = 4;
            dgClients.CellClick += dgClients_CellClick;
            // 
            // Clients
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(60, 60, 60);
            Controls.Add(dgClients);
            Controls.Add(panel1);
            Name = "Clients";
            Size = new Size(932, 678);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgClients).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TextBox txtFirstName;
        private TextBox txtLastName;
        private TextBox txtPhone;
        private TextBox txtEmail;
        private TextBox txtAddress;
        private Panel panel1;
        private Label label1;
        private Label label2;
        private Label label5;
        private Label label4;
        private Label label3;
        private Button btnClientsAdd;
        private Label label6;
        private DataGridView dgClients;
        private Button btnClientsDelete;
        private Button btnClientsEdit;
    }
}
