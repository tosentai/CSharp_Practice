namespace Autoservice.PL
{
    partial class Orders
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
            label2 = new Label();
            label1 = new Label();
            dtpOrderDate = new DateTimePicker();
            label4 = new Label();
            cmbCar = new ComboBox();
            txtTotalCost = new TextBox();
            label5 = new Label();
            btnOrderDelete = new Button();
            btnOrderEdit = new Button();
            btnOrderAdd = new Button();
            dgOrders = new DataGridView();
            label6 = new Label();
            cmbService = new ComboBox();
            label7 = new Label();
            txtQuantity = new TextBox();
            label8 = new Label();
            txtSubtotal = new TextBox();
            btnDetailAdd = new Button();
            btnDetailEdit = new Button();
            btnDetailDelete = new Button();
            dgOrderDetails = new DataGridView();
            cmbEmployee = new ComboBox();
            label9 = new Label();
            cmbStatus = new ComboBox();
            ((System.ComponentModel.ISupportInitialize)dgOrders).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgOrderDetails).BeginInit();
            SuspendLayout();
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Montserrat ExtraBold", 12F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label2.ForeColor = Color.White;
            label2.Location = new Point(28, 17);
            label2.Name = "label2";
            label2.Size = new Size(39, 22);
            label2.TabIndex = 5;
            label2.Text = "Car";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Montserrat ExtraBold", 12F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label1.ForeColor = Color.White;
            label1.Location = new Point(230, 17);
            label1.Name = "label1";
            label1.Size = new Size(102, 22);
            label1.TabIndex = 5;
            label1.Text = "Order date";
            // 
            // dtpOrderDate
            // 
            dtpOrderDate.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            dtpOrderDate.Location = new Point(230, 51);
            dtpOrderDate.Name = "dtpOrderDate";
            dtpOrderDate.Size = new Size(200, 29);
            dtpOrderDate.TabIndex = 7;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Montserrat ExtraBold", 12F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label4.ForeColor = Color.White;
            label4.Location = new Point(450, 17);
            label4.Name = "label4";
            label4.Size = new Size(64, 22);
            label4.TabIndex = 5;
            label4.Text = "Status";
            // 
            // cmbCar
            // 
            cmbCar.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            cmbCar.FormattingEnabled = true;
            cmbCar.Location = new Point(29, 51);
            cmbCar.Name = "cmbCar";
            cmbCar.Size = new Size(181, 29);
            cmbCar.TabIndex = 9;
            // 
            // txtTotalCost
            // 
            txtTotalCost.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            txtTotalCost.Location = new Point(753, 51);
            txtTotalCost.Name = "txtTotalCost";
            txtTotalCost.ReadOnly = true;
            txtTotalCost.Size = new Size(160, 29);
            txtTotalCost.TabIndex = 10;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Montserrat ExtraBold", 12F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label5.ForeColor = Color.White;
            label5.Location = new Point(753, 17);
            label5.Name = "label5";
            label5.Size = new Size(94, 22);
            label5.TabIndex = 5;
            label5.Text = "Total cost";
            // 
            // btnOrderDelete
            // 
            btnOrderDelete.BackColor = Color.FromArgb(5, 8, 15);
            btnOrderDelete.FlatStyle = FlatStyle.Flat;
            btnOrderDelete.Font = new Font("Montserrat ExtraBold", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 204);
            btnOrderDelete.ForeColor = Color.White;
            btnOrderDelete.Location = new Point(379, 312);
            btnOrderDelete.Name = "btnOrderDelete";
            btnOrderDelete.Size = new Size(150, 50);
            btnOrderDelete.TabIndex = 11;
            btnOrderDelete.Text = "Delete";
            btnOrderDelete.UseVisualStyleBackColor = false;
            btnOrderDelete.Click += btnOrderDelete_Click;
            // 
            // btnOrderEdit
            // 
            btnOrderEdit.BackColor = Color.FromArgb(5, 8, 15);
            btnOrderEdit.FlatStyle = FlatStyle.Flat;
            btnOrderEdit.Font = new Font("Montserrat ExtraBold", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 204);
            btnOrderEdit.ForeColor = Color.White;
            btnOrderEdit.Location = new Point(204, 312);
            btnOrderEdit.Name = "btnOrderEdit";
            btnOrderEdit.Size = new Size(150, 50);
            btnOrderEdit.TabIndex = 12;
            btnOrderEdit.Text = "Edit";
            btnOrderEdit.UseVisualStyleBackColor = false;
            btnOrderEdit.Click += btnOrderEdit_Click;
            // 
            // btnOrderAdd
            // 
            btnOrderAdd.BackColor = Color.FromArgb(5, 8, 15);
            btnOrderAdd.FlatStyle = FlatStyle.Flat;
            btnOrderAdd.Font = new Font("Montserrat ExtraBold", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 204);
            btnOrderAdd.ForeColor = Color.White;
            btnOrderAdd.Location = new Point(28, 312);
            btnOrderAdd.Name = "btnOrderAdd";
            btnOrderAdd.Size = new Size(150, 50);
            btnOrderAdd.TabIndex = 13;
            btnOrderAdd.Text = "Add";
            btnOrderAdd.UseVisualStyleBackColor = false;
            btnOrderAdd.Click += btnOrderAdd_Click;
            // 
            // dgOrders
            // 
            dgOrders.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgOrders.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgOrders.Location = new Point(28, 96);
            dgOrders.Name = "dgOrders";
            dgOrders.ReadOnly = true;
            dgOrders.Size = new Size(885, 200);
            dgOrders.TabIndex = 14;
            dgOrders.CellClick += dgOrders_CellClick;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Montserrat ExtraBold", 12F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label6.ForeColor = Color.White;
            label6.Location = new Point(28, 377);
            label6.Name = "label6";
            label6.Size = new Size(72, 22);
            label6.TabIndex = 5;
            label6.Text = "Service";
            // 
            // cmbService
            // 
            cmbService.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            cmbService.FormattingEnabled = true;
            cmbService.Location = new Point(29, 412);
            cmbService.Name = "cmbService";
            cmbService.Size = new Size(257, 29);
            cmbService.TabIndex = 9;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Montserrat ExtraBold", 12F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label7.ForeColor = Color.White;
            label7.Location = new Point(307, 377);
            label7.Name = "label7";
            label7.Size = new Size(85, 22);
            label7.TabIndex = 5;
            label7.Text = "Quantity";
            // 
            // txtQuantity
            // 
            txtQuantity.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            txtQuantity.Location = new Point(307, 412);
            txtQuantity.Name = "txtQuantity";
            txtQuantity.Size = new Size(257, 29);
            txtQuantity.TabIndex = 10;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Montserrat ExtraBold", 12F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label8.ForeColor = Color.White;
            label8.Location = new Point(583, 377);
            label8.Name = "label8";
            label8.Size = new Size(92, 22);
            label8.TabIndex = 5;
            label8.Text = "Summary";
            // 
            // txtSubtotal
            // 
            txtSubtotal.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            txtSubtotal.Location = new Point(583, 412);
            txtSubtotal.Name = "txtSubtotal";
            txtSubtotal.ReadOnly = true;
            txtSubtotal.Size = new Size(257, 29);
            txtSubtotal.TabIndex = 10;
            // 
            // btnDetailAdd
            // 
            btnDetailAdd.BackColor = Color.FromArgb(5, 8, 15);
            btnDetailAdd.FlatStyle = FlatStyle.Flat;
            btnDetailAdd.Font = new Font("Montserrat ExtraBold", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 204);
            btnDetailAdd.ForeColor = Color.White;
            btnDetailAdd.Location = new Point(798, 456);
            btnDetailAdd.Name = "btnDetailAdd";
            btnDetailAdd.Size = new Size(115, 50);
            btnDetailAdd.TabIndex = 13;
            btnDetailAdd.Text = "Add";
            btnDetailAdd.UseVisualStyleBackColor = false;
            btnDetailAdd.Click += btnDetailAdd_Click;
            // 
            // btnDetailEdit
            // 
            btnDetailEdit.BackColor = Color.FromArgb(5, 8, 15);
            btnDetailEdit.FlatStyle = FlatStyle.Flat;
            btnDetailEdit.Font = new Font("Montserrat ExtraBold", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 204);
            btnDetailEdit.ForeColor = Color.White;
            btnDetailEdit.Location = new Point(796, 530);
            btnDetailEdit.Name = "btnDetailEdit";
            btnDetailEdit.Size = new Size(117, 50);
            btnDetailEdit.TabIndex = 12;
            btnDetailEdit.Text = "Edit";
            btnDetailEdit.UseVisualStyleBackColor = false;
            btnDetailEdit.Click += btnDetailEdit_Click;
            // 
            // btnDetailDelete
            // 
            btnDetailDelete.BackColor = Color.FromArgb(5, 8, 15);
            btnDetailDelete.FlatStyle = FlatStyle.Flat;
            btnDetailDelete.Font = new Font("Montserrat ExtraBold", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 204);
            btnDetailDelete.ForeColor = Color.White;
            btnDetailDelete.Location = new Point(796, 606);
            btnDetailDelete.Name = "btnDetailDelete";
            btnDetailDelete.Size = new Size(117, 50);
            btnDetailDelete.TabIndex = 11;
            btnDetailDelete.Text = "Delete";
            btnDetailDelete.UseVisualStyleBackColor = false;
            btnDetailDelete.Click += btnDetailDelete_Click;
            // 
            // dgOrderDetails
            // 
            dgOrderDetails.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgOrderDetails.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgOrderDetails.Location = new Point(29, 456);
            dgOrderDetails.Name = "dgOrderDetails";
            dgOrderDetails.ReadOnly = true;
            dgOrderDetails.Size = new Size(742, 200);
            dgOrderDetails.TabIndex = 14;
            dgOrderDetails.CellClick += dgOrderDetails_CellClick;
            // 
            // cmbEmployee
            // 
            cmbEmployee.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            cmbEmployee.FormattingEnabled = true;
            cmbEmployee.Location = new Point(583, 51);
            cmbEmployee.Name = "cmbEmployee";
            cmbEmployee.Size = new Size(155, 29);
            cmbEmployee.TabIndex = 9;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Montserrat ExtraBold", 12F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label9.ForeColor = Color.White;
            label9.Location = new Point(583, 17);
            label9.Name = "label9";
            label9.Size = new Size(95, 22);
            label9.TabIndex = 5;
            label9.Text = "Employee";
            // 
            // cmbStatus
            // 
            cmbStatus.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            cmbStatus.FormattingEnabled = true;
            cmbStatus.Items.AddRange(new object[] { "Completed", "In Progress", "Cancelled" });
            cmbStatus.Location = new Point(447, 51);
            cmbStatus.Name = "cmbStatus";
            cmbStatus.Size = new Size(117, 29);
            cmbStatus.TabIndex = 9;
            // 
            // Orders
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(60, 60, 60);
            Controls.Add(dgOrderDetails);
            Controls.Add(dgOrders);
            Controls.Add(btnDetailDelete);
            Controls.Add(btnOrderDelete);
            Controls.Add(btnDetailEdit);
            Controls.Add(btnDetailAdd);
            Controls.Add(btnOrderEdit);
            Controls.Add(btnOrderAdd);
            Controls.Add(txtSubtotal);
            Controls.Add(txtTotalCost);
            Controls.Add(txtQuantity);
            Controls.Add(cmbService);
            Controls.Add(cmbStatus);
            Controls.Add(cmbEmployee);
            Controls.Add(cmbCar);
            Controls.Add(dtpOrderDate);
            Controls.Add(label1);
            Controls.Add(label7);
            Controls.Add(label8);
            Controls.Add(label5);
            Controls.Add(label9);
            Controls.Add(label4);
            Controls.Add(label6);
            Controls.Add(label2);
            Name = "Orders";
            Size = new Size(932, 678);
            ((System.ComponentModel.ISupportInitialize)dgOrders).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgOrderDetails).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label2;
        private Label label1;
        private DateTimePicker dtpOrderDate;
        private Label label4;
        private ComboBox cmbCar;
        private TextBox txtTotalCost;
        private Label label5;
        private Button btnOrderDelete;
        private Button btnOrderEdit;
        private Button btnOrderAdd;
        private DataGridView dgOrders;
        private Label label6;
        private ComboBox cmbService;
        private Label label7;
        private TextBox txtQuantity;
        private Label label8;
        private TextBox txtSubtotal;
        private Button btnDetailAdd;
        private Button btnDetailEdit;
        private Button btnDetailDelete;
        private DataGridView dgOrderDetails;
        private ComboBox cmbEmployee;
        private Label label9;
        private ComboBox cmbStatus;
    }
}
