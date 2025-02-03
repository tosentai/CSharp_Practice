namespace Autoservice.PL
{
    partial class Reports
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
            btnFinRep = new Button();
            btnOrdRep = new Button();
            btnClientRep = new Button();
            btnEmpRep = new Button();
            SuspendLayout();
            // 
            // btnFinRep
            // 
            btnFinRep.BackColor = Color.FromArgb(5, 8, 15);
            btnFinRep.FlatStyle = FlatStyle.Flat;
            btnFinRep.Font = new Font("Montserrat ExtraBold", 27.7499962F, FontStyle.Bold, GraphicsUnit.Point, 204);
            btnFinRep.ForeColor = Color.White;
            btnFinRep.Location = new Point(30, 30);
            btnFinRep.Name = "btnFinRep";
            btnFinRep.Size = new Size(421, 294);
            btnFinRep.TabIndex = 6;
            btnFinRep.Text = "Financial report";
            btnFinRep.UseVisualStyleBackColor = false;
            btnFinRep.Click += btnFinRep_Click;
            // 
            // btnOrdRep
            // 
            btnOrdRep.BackColor = Color.FromArgb(5, 8, 15);
            btnOrdRep.FlatStyle = FlatStyle.Flat;
            btnOrdRep.Font = new Font("Montserrat ExtraBold", 27.7499962F, FontStyle.Bold);
            btnOrdRep.ForeColor = Color.White;
            btnOrdRep.Location = new Point(30, 354);
            btnOrdRep.Name = "btnOrdRep";
            btnOrdRep.Size = new Size(421, 294);
            btnOrdRep.TabIndex = 6;
            btnOrdRep.Text = "Order report";
            btnOrdRep.UseVisualStyleBackColor = false;
            btnOrdRep.Click += btnOrdRep_Click;
            // 
            // btnClientRep
            // 
            btnClientRep.BackColor = Color.FromArgb(5, 8, 15);
            btnClientRep.FlatStyle = FlatStyle.Flat;
            btnClientRep.Font = new Font("Montserrat ExtraBold", 27.7499962F, FontStyle.Bold);
            btnClientRep.ForeColor = Color.White;
            btnClientRep.Location = new Point(480, 30);
            btnClientRep.Name = "btnClientRep";
            btnClientRep.Size = new Size(421, 294);
            btnClientRep.TabIndex = 6;
            btnClientRep.Text = "Client report";
            btnClientRep.UseVisualStyleBackColor = false;
            btnClientRep.Click += btnClientRep_Click;
            // 
            // btnEmpRep
            // 
            btnEmpRep.BackColor = Color.FromArgb(5, 8, 15);
            btnEmpRep.FlatStyle = FlatStyle.Flat;
            btnEmpRep.Font = new Font("Montserrat ExtraBold", 27.7499962F, FontStyle.Bold);
            btnEmpRep.ForeColor = Color.White;
            btnEmpRep.Location = new Point(480, 354);
            btnEmpRep.Name = "btnEmpRep";
            btnEmpRep.Size = new Size(421, 294);
            btnEmpRep.TabIndex = 6;
            btnEmpRep.Text = "Employee report";
            btnEmpRep.UseVisualStyleBackColor = false;
            btnEmpRep.Click += btnEmpRep_Click;
            // 
            // Reports
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(60, 60, 60);
            Controls.Add(btnEmpRep);
            Controls.Add(btnClientRep);
            Controls.Add(btnOrdRep);
            Controls.Add(btnFinRep);
            Name = "Reports";
            Size = new Size(932, 678);
            ResumeLayout(false);
        }

        #endregion

        private Button btnFinRep;
        private Button btnOrdRep;
        private Button btnClientRep;
        private Button btnEmpRep;
    }
}
