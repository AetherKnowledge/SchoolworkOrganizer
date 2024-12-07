namespace SchoolworkOrganizer
{
    partial class LoginPanel
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginPanel));
            txtUsername = new TextBox();
            txtPassword = new TextBox();
            labelForgotPassword = new Label();
            ButtonLogIn = new Button();
            showPassword = new CheckBox();
            registerLabel = new Label();
            pictureBox3 = new PictureBox();
            pictureBox2 = new PictureBox();
            pictureBox1 = new PictureBox();
            testBtn = new Button();
            button1 = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // txtUsername
            // 
            txtUsername.Font = new Font("Roboto Light", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtUsername.Location = new Point(508, 276);
            txtUsername.Margin = new Padding(4, 3, 4, 3);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(291, 33);
            txtUsername.TabIndex = 1;
            txtUsername.Text = "Username";
            // 
            // txtPassword
            // 
            txtPassword.Font = new Font("Roboto Light", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtPassword.Location = new Point(508, 345);
            txtPassword.Margin = new Padding(4, 3, 4, 3);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(291, 33);
            txtPassword.TabIndex = 2;
            txtPassword.Text = "Password";
            txtPassword.UseSystemPasswordChar = true;
            // 
            // labelForgotPassword
            // 
            labelForgotPassword.AutoSize = true;
            labelForgotPassword.Cursor = Cursors.Hand;
            labelForgotPassword.Font = new Font("Roboto Light", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelForgotPassword.ForeColor = Color.SteelBlue;
            labelForgotPassword.Location = new Point(504, 408);
            labelForgotPassword.Margin = new Padding(4, 0, 4, 0);
            labelForgotPassword.Name = "labelForgotPassword";
            labelForgotPassword.Size = new Size(96, 15);
            labelForgotPassword.TabIndex = 5;
            labelForgotPassword.Text = "Forgot Password?";
            labelForgotPassword.Click += labelForgotPassword_Click;
            // 
            // ButtonLogIn
            // 
            ButtonLogIn.BackColor = Color.FromArgb(95, 192, 170);
            ButtonLogIn.FlatAppearance.BorderSize = 0;
            ButtonLogIn.FlatStyle = FlatStyle.Flat;
            ButtonLogIn.Font = new Font("Roboto Light", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ButtonLogIn.ForeColor = Color.White;
            ButtonLogIn.Location = new Point(677, 449);
            ButtonLogIn.Margin = new Padding(4, 3, 4, 3);
            ButtonLogIn.Name = "ButtonLogIn";
            ButtonLogIn.Size = new Size(122, 37);
            ButtonLogIn.TabIndex = 6;
            ButtonLogIn.Text = "Log In";
            ButtonLogIn.UseVisualStyleBackColor = false;
            ButtonLogIn.Click += ButtonLogIn_Click;
            // 
            // showPassword
            // 
            showPassword.AutoSize = true;
            showPassword.Font = new Font("Roboto Light", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            showPassword.Location = new Point(677, 390);
            showPassword.Margin = new Padding(4, 3, 4, 3);
            showPassword.Name = "showPassword";
            showPassword.Size = new Size(105, 19);
            showPassword.TabIndex = 7;
            showPassword.Text = "Show Password";
            showPassword.UseVisualStyleBackColor = true;
            showPassword.CheckedChanged += showPassword_CheckedChanged;
            // 
            // registerLabel
            // 
            registerLabel.AutoSize = true;
            registerLabel.Cursor = Cursors.Hand;
            registerLabel.Font = new Font("Roboto Light", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            registerLabel.ForeColor = Color.SteelBlue;
            registerLabel.Location = new Point(504, 390);
            registerLabel.Margin = new Padding(4, 0, 4, 0);
            registerLabel.Name = "registerLabel";
            registerLabel.Size = new Size(119, 15);
            registerLabel.TabIndex = 14;
            registerLabel.Text = "Dont have an account?";
            registerLabel.Click += registerLabel_Click;
            // 
            // pictureBox3
            // 
            pictureBox3.Image = Properties.Resources.password;
            pictureBox3.Location = new Point(459, 348);
            pictureBox3.Margin = new Padding(4, 3, 4, 3);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(42, 36);
            pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox3.TabIndex = 4;
            pictureBox3.TabStop = false;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = Properties.Resources.username;
            pictureBox2.Location = new Point(459, 276);
            pictureBox2.Margin = new Padding(4, 3, 4, 3);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(42, 38);
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.TabIndex = 3;
            pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.bg_dark;
            pictureBox1.Location = new Point(433, 78);
            pictureBox1.Margin = new Padding(4, 3, 4, 3);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(410, 136);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // testBtn
            // 
            testBtn.Location = new Point(289, 206);
            testBtn.Name = "testBtn";
            testBtn.Size = new Size(75, 23);
            testBtn.TabIndex = 15;
            testBtn.Text = "button1";
            testBtn.UseVisualStyleBackColor = true;
            testBtn.Click += testBtn_Click;
            // 
            // button1
            // 
            button1.Location = new Point(243, 442);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 16;
            button1.Text = "button1";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // LoginPanel
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1264, 681);
            Controls.Add(button1);
            Controls.Add(testBtn);
            Controls.Add(registerLabel);
            Controls.Add(showPassword);
            Controls.Add(ButtonLogIn);
            Controls.Add(labelForgotPassword);
            Controls.Add(pictureBox3);
            Controls.Add(pictureBox2);
            Controls.Add(txtPassword);
            Controls.Add(txtUsername);
            Controls.Add(pictureBox1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(4, 3, 4, 3);
            Name = "LoginPanel";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Login";
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Label labelForgotPassword;
        private System.Windows.Forms.Button ButtonLogIn;
        private System.Windows.Forms.CheckBox showPassword;
        private System.Windows.Forms.Label registerLabel;
        private Button testBtn;
        private Button button1;
    }
}