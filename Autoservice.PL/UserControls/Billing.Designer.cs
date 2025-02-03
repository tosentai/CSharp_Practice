namespace Autoservice.PL
{
    partial class Billing
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
            cmbCar = new ComboBox();
            label2 = new Label();
            cmbClient = new ComboBox();
            label1 = new Label();
            dgBilling = new DataGridView();
            btnGenExcel = new Button();
            pictureBox1 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)dgBilling).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // cmbCar
            // 
            cmbCar.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            cmbCar.FormattingEnabled = true;
            cmbCar.Location = new Point(294, 68);
            cmbCar.Name = "cmbCar";
            cmbCar.Size = new Size(220, 29);
            cmbCar.TabIndex = 10;
            cmbCar.SelectedIndexChanged += cmbCar_SelectedIndexChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Montserrat ExtraBold", 12F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label2.ForeColor = Color.White;
            label2.Location = new Point(294, 26);
            label2.Name = "label2";
            label2.Size = new Size(39, 22);
            label2.TabIndex = 11;
            label2.Text = "Car";
            // 
            // cmbClient
            // 
            cmbClient.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            cmbClient.FormattingEnabled = true;
            cmbClient.Location = new Point(24, 68);
            cmbClient.Name = "cmbClient";
            cmbClient.Size = new Size(241, 29);
            cmbClient.TabIndex = 10;
            cmbClient.SelectedIndexChanged += cmbClient_SelectedIndexChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Montserrat ExtraBold", 12F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label1.ForeColor = Color.White;
            label1.Location = new Point(24, 26);
            label1.Name = "label1";
            label1.Size = new Size(60, 22);
            label1.TabIndex = 11;
            label1.Text = "Client";
            // 
            // dgBilling
            // 
            dgBilling.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgBilling.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgBilling.Location = new Point(24, 147);
            dgBilling.Name = "dgBilling";
            dgBilling.Size = new Size(880, 508);
            dgBilling.TabIndex = 12;
            // 
            // btnGenExcel
            // 
            btnGenExcel.BackColor = Color.FromArgb(5, 8, 15);
            btnGenExcel.FlatStyle = FlatStyle.Flat;
            btnGenExcel.Font = new Font("Montserrat ExtraBold", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 204);
            btnGenExcel.ForeColor = Color.White;
            btnGenExcel.Location = new Point(541, 56);
            btnGenExcel.Name = "btnGenExcel";
            btnGenExcel.Size = new Size(229, 47);
            btnGenExcel.TabIndex = 13;
            btnGenExcel.Text = "Generate invoice";
            btnGenExcel.UseVisualStyleBackColor = false;
            btnGenExcel.Click += btnGenExcel_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.dollar128white;
            pictureBox1.Location = new Point(776, 13);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(128, 128);
            pictureBox1.SizeMode = PictureBoxSizeMode.AutoSize;
            pictureBox1.TabIndex = 14;
            pictureBox1.TabStop = false;
            // 
            // Billing
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(60, 60, 60);
            Controls.Add(pictureBox1);
            Controls.Add(btnGenExcel);
            Controls.Add(dgBilling);
            Controls.Add(label1);
            Controls.Add(label2);
            Controls.Add(cmbClient);
            Controls.Add(cmbCar);
            Name = "Billing";
            Size = new Size(932, 678);
            ((System.ComponentModel.ISupportInitialize)dgBilling).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox cmbCar;
        private Label label2;
        private ComboBox cmbClient;
        private Label label1;
        private DataGridView dgBilling;
        private Button btnGenExcel;
        private PictureBox pictureBox1;
    }
}
