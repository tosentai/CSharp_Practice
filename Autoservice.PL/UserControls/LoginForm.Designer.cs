namespace Autoservice.PL
{
    partial class LoginForm
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
            label1 = new Label();
            panel1 = new Panel();
            btnLogin = new Button();
            cbShowPass = new CheckBox();
            txtPassword = new TextBox();
            label5 = new Label();
            txtUsername = new TextBox();
            label4 = new Label();
            label3 = new Label();
            pictureBox1 = new PictureBox();
            btnRegister = new Button();
            label2 = new Label();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Montserrat ExtraBold", 26.2499962F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label1.ForeColor = Color.White;
            label1.Location = new Point(0, 148);
            label1.Name = "label1";
            label1.Size = new Size(325, 120);
            label1.TabIndex = 2;
            label1.Text = "Autoservice\r\nManagement\r\n";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(5, 8, 15);
            panel1.Controls.Add(btnLogin);
            panel1.Controls.Add(cbShowPass);
            panel1.Controls.Add(txtPassword);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(txtUsername);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(label3);
            panel1.Dock = DockStyle.Right;
            panel1.Location = new Point(325, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(325, 500);
            panel1.TabIndex = 3;
            // 
            // btnLogin
            // 
            btnLogin.BackColor = Color.FromArgb(60, 60, 60);
            btnLogin.FlatStyle = FlatStyle.Flat;
            btnLogin.Font = new Font("Montserrat ExtraBold", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 204);
            btnLogin.ForeColor = Color.White;
            btnLogin.Location = new Point(37, 335);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(250, 50);
            btnLogin.TabIndex = 4;
            btnLogin.Text = "Continue";
            btnLogin.UseVisualStyleBackColor = false;
            btnLogin.Click += btnLogin_Click;
            // 
            // cbShowPass
            // 
            cbShowPass.AutoSize = true;
            cbShowPass.Font = new Font("Montserrat ExtraBold", 12F, FontStyle.Bold, GraphicsUnit.Point, 204);
            cbShowPass.ForeColor = Color.White;
            cbShowPass.Location = new Point(12, 292);
            cbShowPass.Name = "cbShowPass";
            cbShowPass.Size = new Size(164, 26);
            cbShowPass.TabIndex = 3;
            cbShowPass.Text = "Show password";
            cbShowPass.UseVisualStyleBackColor = true;
            cbShowPass.CheckedChanged += cbShowPass_CheckedChanged;
            // 
            // txtPassword
            // 
            txtPassword.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            txtPassword.Location = new Point(12, 257);
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '*';
            txtPassword.Size = new Size(300, 29);
            txtPassword.TabIndex = 2;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Montserrat ExtraBold", 12F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label5.ForeColor = Color.White;
            label5.Location = new Point(12, 232);
            label5.Name = "label5";
            label5.Size = new Size(94, 22);
            label5.TabIndex = 3;
            label5.Text = "Password";
            // 
            // txtUsername
            // 
            txtUsername.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            txtUsername.Location = new Point(12, 199);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(300, 29);
            txtUsername.TabIndex = 1;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Montserrat ExtraBold", 12F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label4.ForeColor = Color.White;
            label4.Location = new Point(12, 174);
            label4.Name = "label4";
            label4.Size = new Size(97, 22);
            label4.TabIndex = 3;
            label4.Text = "Username";
            // 
            // label3
            // 
            label3.BackColor = Color.Transparent;
            label3.Font = new Font("Montserrat ExtraBold", 26.2499962F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label3.ForeColor = Color.White;
            label3.Location = new Point(0, 101);
            label3.Name = "label3";
            label3.Size = new Size(325, 61);
            label3.TabIndex = 2;
            label3.Text = "Welcome back";
            label3.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.logo100;
            pictureBox1.Location = new Point(113, 45);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(100, 100);
            pictureBox1.SizeMode = PictureBoxSizeMode.AutoSize;
            pictureBox1.TabIndex = 4;
            pictureBox1.TabStop = false;
            // 
            // btnRegister
            // 
            btnRegister.BackColor = Color.FromArgb(5, 8, 15);
            btnRegister.FlatStyle = FlatStyle.Flat;
            btnRegister.Font = new Font("Montserrat ExtraBold", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 204);
            btnRegister.ForeColor = Color.White;
            btnRegister.Location = new Point(37, 430);
            btnRegister.Name = "btnRegister";
            btnRegister.Size = new Size(250, 50);
            btnRegister.TabIndex = 5;
            btnRegister.Text = "Register";
            btnRegister.UseVisualStyleBackColor = false;
            btnRegister.Click += btnRegister_Click;
            // 
            // label2
            // 
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Montserrat ExtraBold", 17.9999981F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label2.ForeColor = Color.White;
            label2.Location = new Point(0, 379);
            label2.Name = "label2";
            label2.Size = new Size(325, 48);
            label2.TabIndex = 2;
            label2.Text = "Create new account";
            label2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // LoginForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(60, 60, 60);
            Controls.Add(btnRegister);
            Controls.Add(pictureBox1);
            Controls.Add(panel1);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "LoginForm";
            Size = new Size(650, 500);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Panel panel1;
        private PictureBox pictureBox1;
        private Button btnRegister;
        private Button btnLogin;
        private CheckBox cbShowPass;
        private TextBox txtPassword;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label2;
        private TextBox txtUsername;
    }
}
