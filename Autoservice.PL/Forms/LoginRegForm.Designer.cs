namespace Autoservice.PL
{
    partial class LoginRegForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            close = new PictureBox();
            regForm1 = new RegForm();
            loginForm1 = new LoginForm();
            ((System.ComponentModel.ISupportInitialize)close).BeginInit();
            SuspendLayout();
            // 
            // close
            // 
            close.BackColor = Color.Transparent;
            close.Image = Properties.Resources.close;
            close.Location = new Point(1044, 12);
            close.Name = "close";
            close.Size = new Size(24, 24);
            close.SizeMode = PictureBoxSizeMode.AutoSize;
            close.TabIndex = 2;
            close.TabStop = false;
            close.Click += close_Click;
            // 
            // regForm1
            // 
            regForm1.BackColor = Color.FromArgb(60, 60, 60);
            regForm1.ImeMode = ImeMode.NoControl;
            regForm1.Location = new Point(215, 110);
            regForm1.Name = "regForm1";
            regForm1.Size = new Size(650, 500);
            regForm1.TabIndex = 3;
            // 
            // loginForm1
            // 
            loginForm1.BackColor = Color.FromArgb(60, 60, 60);
            loginForm1.Location = new Point(215, 110);
            loginForm1.Name = "loginForm1";
            loginForm1.Size = new Size(650, 500);
            loginForm1.TabIndex = 4;
            // 
            // LoginRegForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            BackgroundImage = Properties.Resources.wallpaperblue;
            ClientSize = new Size(1080, 720);
            Controls.Add(loginForm1);
            Controls.Add(regForm1);
            Controls.Add(close);
            Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 204);
            FormBorderStyle = FormBorderStyle.None;
            Name = "LoginRegForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "LoginRegForm";
            MouseDown += LoginRegForm_MouseDown;
            ((System.ComponentModel.ISupportInitialize)close).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private PictureBox close;
        private RegForm regForm1;
        private LoginForm loginForm1;
    }
}
