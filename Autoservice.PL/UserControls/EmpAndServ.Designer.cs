namespace Autoservice.PL
{
    partial class EmpAndServ
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
            txtPhone = new TextBox();
            txtPosition = new TextBox();
            txtName = new TextBox();
            panel1 = new Panel();
            btnServDelete = new Button();
            label1 = new Label();
            btnServEdit = new Button();
            label6 = new Label();
            btnServAdd = new Button();
            btnEmpDelete = new Button();
            btnEmpEdit = new Button();
            btnEmpAdd = new Button();
            label4 = new Label();
            label3 = new Label();
            label7 = new Label();
            label5 = new Label();
            label2 = new Label();
            txtServPrice = new TextBox();
            txtServName = new TextBox();
            dgEmployee = new DataGridView();
            dgService = new DataGridView();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgEmployee).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgService).BeginInit();
            SuspendLayout();
            // 
            // txtPhone
            // 
            txtPhone.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            txtPhone.Location = new Point(22, 231);
            txtPhone.Name = "txtPhone";
            txtPhone.PlaceholderText = "+380XXXXXXXXX";
            txtPhone.Size = new Size(257, 29);
            txtPhone.TabIndex = 4;
            // 
            // txtPosition
            // 
            txtPosition.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            txtPosition.Location = new Point(22, 161);
            txtPosition.Name = "txtPosition";
            txtPosition.PlaceholderText = "e.g. Mechanic";
            txtPosition.Size = new Size(257, 29);
            txtPosition.TabIndex = 3;
            // 
            // txtName
            // 
            txtName.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            txtName.Location = new Point(22, 91);
            txtName.Name = "txtName";
            txtName.PlaceholderText = "e.g. Anton Anpilohov";
            txtName.Size = new Size(257, 29);
            txtName.TabIndex = 2;
            // 
            // panel1
            // 
            panel1.Controls.Add(btnServDelete);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(btnServEdit);
            panel1.Controls.Add(label6);
            panel1.Controls.Add(btnServAdd);
            panel1.Controls.Add(btnEmpDelete);
            panel1.Controls.Add(btnEmpEdit);
            panel1.Controls.Add(btnEmpAdd);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(txtPhone);
            panel1.Controls.Add(label7);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(txtPosition);
            panel1.Controls.Add(txtServPrice);
            panel1.Controls.Add(txtServName);
            panel1.Controls.Add(txtName);
            panel1.Dock = DockStyle.Left;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(300, 678);
            panel1.TabIndex = 7;
            // 
            // btnServDelete
            // 
            btnServDelete.BackColor = Color.FromArgb(5, 8, 15);
            btnServDelete.FlatStyle = FlatStyle.Flat;
            btnServDelete.Font = new Font("Montserrat ExtraBold", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 204);
            btnServDelete.ForeColor = Color.White;
            btnServDelete.Location = new Point(22, 614);
            btnServDelete.Name = "btnServDelete";
            btnServDelete.Size = new Size(257, 50);
            btnServDelete.TabIndex = 9;
            btnServDelete.Text = "Delete";
            btnServDelete.UseVisualStyleBackColor = false;
            btnServDelete.Click += btnServDelete_Click;
            // 
            // label1
            // 
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Montserrat ExtraBold", 26.2499962F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label1.ForeColor = Color.White;
            label1.Location = new Point(0, 328);
            label1.Name = "label1";
            label1.Size = new Size(300, 61);
            label1.TabIndex = 7;
            label1.Text = "Services";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnServEdit
            // 
            btnServEdit.BackColor = Color.FromArgb(5, 8, 15);
            btnServEdit.FlatStyle = FlatStyle.Flat;
            btnServEdit.Font = new Font("Montserrat ExtraBold", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 204);
            btnServEdit.ForeColor = Color.White;
            btnServEdit.Location = new Point(154, 549);
            btnServEdit.Name = "btnServEdit";
            btnServEdit.Size = new Size(125, 50);
            btnServEdit.TabIndex = 10;
            btnServEdit.Text = "Edit";
            btnServEdit.UseVisualStyleBackColor = false;
            btnServEdit.Click += btnServEdit_Click;
            // 
            // label6
            // 
            label6.BackColor = Color.Transparent;
            label6.Font = new Font("Montserrat ExtraBold", 26.2499962F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label6.ForeColor = Color.White;
            label6.Location = new Point(0, 0);
            label6.Name = "label6";
            label6.Size = new Size(300, 61);
            label6.TabIndex = 7;
            label6.Text = "Employees";
            label6.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnServAdd
            // 
            btnServAdd.BackColor = Color.FromArgb(5, 8, 15);
            btnServAdd.FlatStyle = FlatStyle.Flat;
            btnServAdd.Font = new Font("Montserrat ExtraBold", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 204);
            btnServAdd.ForeColor = Color.White;
            btnServAdd.Location = new Point(22, 549);
            btnServAdd.Name = "btnServAdd";
            btnServAdd.Size = new Size(125, 50);
            btnServAdd.TabIndex = 11;
            btnServAdd.Text = "Add";
            btnServAdd.UseVisualStyleBackColor = false;
            btnServAdd.Click += btnServAdd_Click;
            // 
            // btnEmpDelete
            // 
            btnEmpDelete.BackColor = Color.FromArgb(5, 8, 15);
            btnEmpDelete.FlatStyle = FlatStyle.Flat;
            btnEmpDelete.Font = new Font("Montserrat ExtraBold", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 204);
            btnEmpDelete.ForeColor = Color.White;
            btnEmpDelete.Location = new Point(100, 275);
            btnEmpDelete.Name = "btnEmpDelete";
            btnEmpDelete.Size = new Size(102, 50);
            btnEmpDelete.TabIndex = 6;
            btnEmpDelete.Text = "Delete";
            btnEmpDelete.UseVisualStyleBackColor = false;
            btnEmpDelete.Click += btnEmpDelete_Click;
            // 
            // btnEmpEdit
            // 
            btnEmpEdit.BackColor = Color.FromArgb(5, 8, 15);
            btnEmpEdit.FlatStyle = FlatStyle.Flat;
            btnEmpEdit.Font = new Font("Montserrat ExtraBold", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 204);
            btnEmpEdit.ForeColor = Color.White;
            btnEmpEdit.Location = new Point(208, 275);
            btnEmpEdit.Name = "btnEmpEdit";
            btnEmpEdit.Size = new Size(71, 50);
            btnEmpEdit.TabIndex = 6;
            btnEmpEdit.Text = "Edit";
            btnEmpEdit.UseVisualStyleBackColor = false;
            btnEmpEdit.Click += btnEmpEdit_Click;
            // 
            // btnEmpAdd
            // 
            btnEmpAdd.BackColor = Color.FromArgb(5, 8, 15);
            btnEmpAdd.FlatStyle = FlatStyle.Flat;
            btnEmpAdd.Font = new Font("Montserrat ExtraBold", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 204);
            btnEmpAdd.ForeColor = Color.White;
            btnEmpAdd.Location = new Point(22, 275);
            btnEmpAdd.Name = "btnEmpAdd";
            btnEmpAdd.Size = new Size(72, 50);
            btnEmpAdd.TabIndex = 6;
            btnEmpAdd.Text = "Add";
            btnEmpAdd.UseVisualStyleBackColor = false;
            btnEmpAdd.Click += btnEmpAdd_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Montserrat ExtraBold", 12F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label4.ForeColor = Color.White;
            label4.Location = new Point(22, 201);
            label4.Name = "label4";
            label4.Size = new Size(153, 22);
            label4.TabIndex = 4;
            label4.Text = "Phone (optional)";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Montserrat ExtraBold", 12F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label3.ForeColor = Color.White;
            label3.Location = new Point(22, 131);
            label3.Name = "label3";
            label3.Size = new Size(93, 22);
            label3.TabIndex = 4;
            label3.Text = "Position *";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Montserrat ExtraBold", 12F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label7.ForeColor = Color.White;
            label7.Location = new Point(22, 469);
            label7.Name = "label7";
            label7.Size = new Size(81, 22);
            label7.TabIndex = 4;
            label7.Text = "Price $ *";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Montserrat ExtraBold", 12F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label5.ForeColor = Color.White;
            label5.Location = new Point(22, 389);
            label5.Name = "label5";
            label5.Size = new Size(137, 22);
            label5.TabIndex = 4;
            label5.Text = "Service name *";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Montserrat ExtraBold", 12F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label2.ForeColor = Color.White;
            label2.Location = new Point(22, 61);
            label2.Name = "label2";
            label2.Size = new Size(160, 22);
            label2.TabIndex = 4;
            label2.Text = "Employee name *";
            // 
            // txtServPrice
            // 
            txtServPrice.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            txtServPrice.Location = new Point(22, 499);
            txtServPrice.Name = "txtServPrice";
            txtServPrice.PlaceholderText = "e.g. 300";
            txtServPrice.Size = new Size(257, 29);
            txtServPrice.TabIndex = 2;
            // 
            // txtServName
            // 
            txtServName.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            txtServName.Location = new Point(22, 419);
            txtServName.Name = "txtServName";
            txtServName.PlaceholderText = "e.g. Oil change";
            txtServName.Size = new Size(257, 29);
            txtServName.TabIndex = 2;
            // 
            // dgEmployee
            // 
            dgEmployee.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgEmployee.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgEmployee.Location = new Point(306, 13);
            dgEmployee.Name = "dgEmployee";
            dgEmployee.Size = new Size(612, 312);
            dgEmployee.TabIndex = 8;
            dgEmployee.CellClick += dgEmployee_CellClick;
            // 
            // dgService
            // 
            dgService.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgService.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgService.Location = new Point(306, 341);
            dgService.Name = "dgService";
            dgService.Size = new Size(612, 323);
            dgService.TabIndex = 9;
            dgService.CellClick += dgService_CellClick;
            // 
            // EmpAndServ
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(60, 60, 60);
            Controls.Add(dgService);
            Controls.Add(panel1);
            Controls.Add(dgEmployee);
            Name = "EmpAndServ";
            Size = new Size(932, 678);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgEmployee).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgService).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private TextBox txtPhone;
        private TextBox txtPosition;
        private TextBox txtName;
        private Panel panel1;
        private Label label6;
        private Button btnEmpDelete;
        private Button btnEmpEdit;
        private Button btnEmpAdd;
        private Label label4;
        private Label label3;
        private Label label2;
        private DataGridView dgEmployee;
        private Label label1;
        private Label label7;
        private Label label5;
        private TextBox txtServPrice;
        private TextBox txtServName;
        private Button btnServEdit;
        private Button btnServAdd;
        private Button btnServDelete;
        private DataGridView dgService;
    }
}
