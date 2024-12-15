using MaterialSkin.Controls;

namespace SchoolworkOrganizer
{
    partial class RegisterPanel
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RegisterPanel));
            RegisterBtn = new Button();
            LoginLabel = new Label();
            txtPassword = new TextBox();
            txtEmail = new TextBox();
            txtUsername = new TextBox();
            pictureBox4 = new PictureBox();
            pictureBox3 = new PictureBox();
            pictureBox2 = new PictureBox();
            pictureBox1 = new PictureBox();
            uploadPicture = new PictureBox();
            uploadBtn = new Button();
            showPassword = new CheckBox();
            pictureBox5 = new PictureBox();
            txtVerify = new TextBox();
            showPassVerify = new CheckBox();
            comboBox1 = new MaterialComboBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)uploadPicture).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox5).BeginInit();
            SuspendLayout();
            // 
            // RegisterBtn
            // 
            RegisterBtn.BackColor = Color.FromArgb(95, 192, 170);
            RegisterBtn.FlatAppearance.BorderSize = 0;
            RegisterBtn.FlatStyle = FlatStyle.Flat;
            RegisterBtn.Font = new Font("Roboto Light", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            RegisterBtn.ForeColor = Color.White;
            RegisterBtn.Location = new Point(571, 508);
            RegisterBtn.Margin = new Padding(4, 3, 4, 3);
            RegisterBtn.Name = "RegisterBtn";
            RegisterBtn.Size = new Size(99, 37);
            RegisterBtn.TabIndex = 14;
            RegisterBtn.Text = "Register";
            RegisterBtn.UseVisualStyleBackColor = false;
            RegisterBtn.Click += RegisterBtn_Click;
            // 
            // LoginLabel
            // 
            LoginLabel.AutoSize = true;
            LoginLabel.Font = new Font("Roboto Light", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            LoginLabel.ForeColor = Color.SteelBlue;
            LoginLabel.Location = new Point(577, 458);
            LoginLabel.Margin = new Padding(4, 0, 4, 0);
            LoginLabel.Name = "LoginLabel";
            LoginLabel.Size = new Size(133, 15);
            LoginLabel.TabIndex = 13;
            LoginLabel.Text = "Already have an account?";
            LoginLabel.Click += LoginLabel_Click;
            // 
            // txtPassword
            // 
            txtPassword.Font = new Font("Roboto Light", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtPassword.Location = new Point(530, 399);
            txtPassword.Margin = new Padding(4, 3, 4, 3);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(200, 22);
            txtPassword.TabIndex = 10;
            txtPassword.Text = "Password";
            txtPassword.UseSystemPasswordChar = true;
            // 
            // txtEmail
            // 
            txtEmail.Font = new Font("Roboto Light", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtEmail.Location = new Point(530, 339);
            txtEmail.Margin = new Padding(4, 3, 4, 3);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(200, 22);
            txtEmail.TabIndex = 9;
            txtEmail.Text = "Email";
            // 
            // txtUsername
            // 
            txtUsername.Font = new Font("Roboto Light", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtUsername.Location = new Point(530, 369);
            txtUsername.Margin = new Padding(4, 3, 4, 3);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(200, 22);
            txtUsername.TabIndex = 16;
            txtUsername.Text = "Username";
            // 
            // pictureBox4
            // 
            pictureBox4.Image = Properties.Resources.username;
            pictureBox4.Location = new Point(495, 369);
            pictureBox4.Margin = new Padding(4, 3, 4, 3);
            pictureBox4.Name = "pictureBox4";
            pictureBox4.Size = new Size(28, 23);
            pictureBox4.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox4.TabIndex = 17;
            pictureBox4.TabStop = false;
            // 
            // pictureBox3
            // 
            pictureBox3.Image = Properties.Resources.password;
            pictureBox3.Location = new Point(495, 399);
            pictureBox3.Margin = new Padding(4, 3, 4, 3);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(28, 23);
            pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox3.TabIndex = 12;
            pictureBox3.TabStop = false;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = Properties.Resources.username;
            pictureBox2.Location = new Point(495, 339);
            pictureBox2.Margin = new Padding(4, 3, 4, 3);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(28, 23);
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.TabIndex = 11;
            pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.bg_dark;
            pictureBox1.Location = new Point(430, 66);
            pictureBox1.Margin = new Padding(4, 3, 4, 3);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(410, 136);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 8;
            pictureBox1.TabStop = false;
            // 
            // uploadPicture
            // 
            uploadPicture.BorderStyle = BorderStyle.FixedSingle;
            uploadPicture.Image = Properties.Resources.user;
            uploadPicture.Location = new Point(614, 242);
            uploadPicture.Margin = new Padding(4, 3, 4, 3);
            uploadPicture.Name = "uploadPicture";
            uploadPicture.Size = new Size(116, 90);
            uploadPicture.SizeMode = PictureBoxSizeMode.Zoom;
            uploadPicture.TabIndex = 36;
            uploadPicture.TabStop = false;
            // 
            // uploadBtn
            // 
            uploadBtn.BackColor = Color.FromArgb(52, 63, 82);
            uploadBtn.FlatAppearance.BorderSize = 0;
            uploadBtn.FlatStyle = FlatStyle.Flat;
            uploadBtn.Font = new Font("Roboto Light", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            uploadBtn.ForeColor = Color.FromArgb(231, 231, 231);
            uploadBtn.Location = new Point(484, 269);
            uploadBtn.Margin = new Padding(4, 3, 4, 3);
            uploadBtn.Name = "uploadBtn";
            uploadBtn.Size = new Size(122, 31);
            uploadBtn.TabIndex = 37;
            uploadBtn.Text = "Upload";
            uploadBtn.UseVisualStyleBackColor = false;
            uploadBtn.Click += uploadBtn_Click;
            // 
            // showPassword
            // 
            showPassword.AutoSize = true;
            showPassword.Font = new Font("Roboto Light", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            showPassword.Location = new Point(738, 403);
            showPassword.Margin = new Padding(4, 3, 4, 3);
            showPassword.Name = "showPassword";
            showPassword.Size = new Size(105, 19);
            showPassword.TabIndex = 38;
            showPassword.Text = "Show Password";
            showPassword.UseVisualStyleBackColor = true;
            showPassword.CheckedChanged += showPassword_CheckedChanged;
            // 
            // pictureBox5
            // 
            pictureBox5.Image = Properties.Resources.password;
            pictureBox5.Location = new Point(495, 429);
            pictureBox5.Margin = new Padding(4, 3, 4, 3);
            pictureBox5.Name = "pictureBox5";
            pictureBox5.Size = new Size(28, 23);
            pictureBox5.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox5.TabIndex = 40;
            pictureBox5.TabStop = false;
            // 
            // txtVerify
            // 
            txtVerify.Font = new Font("Roboto Light", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtVerify.Location = new Point(530, 429);
            txtVerify.Margin = new Padding(4, 3, 4, 3);
            txtVerify.Name = "txtVerify";
            txtVerify.Size = new Size(200, 22);
            txtVerify.TabIndex = 39;
            txtVerify.Text = "Password";
            txtVerify.UseSystemPasswordChar = true;
            // 
            // showPassVerify
            // 
            showPassVerify.AutoSize = true;
            showPassVerify.Font = new Font("Roboto Light", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            showPassVerify.Location = new Point(738, 432);
            showPassVerify.Margin = new Padding(4, 3, 4, 3);
            showPassVerify.Name = "showPassVerify";
            showPassVerify.Size = new Size(105, 19);
            showPassVerify.TabIndex = 41;
            showPassVerify.Text = "Show Password";
            showPassVerify.UseVisualStyleBackColor = true;
            showPassVerify.CheckedChanged += showPassVerify_CheckedChanged;
            // 
            // comboBox1
            // 
            comboBox1.AutoResize = false;
            comboBox1.BackColor = Color.FromArgb(255, 255, 255);
            comboBox1.Depth = 0;
            comboBox1.DrawMode = DrawMode.OwnerDrawVariable;
            comboBox1.DropDownHeight = 118;
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox1.DropDownWidth = 121;
            comboBox1.Font = new Font("Roboto Medium", 14F, FontStyle.Bold, GraphicsUnit.Pixel);
            comboBox1.ForeColor = Color.FromArgb(222, 0, 0, 0);
            comboBox1.FormattingEnabled = true;
            comboBox1.IntegralHeight = false;
            comboBox1.ItemHeight = 29;
            comboBox1.Location = new Point(71, 313);
            comboBox1.MaxDropDownItems = 4;
            comboBox1.MouseState = MaterialSkin.MouseState.OUT;
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(121, 35);
            comboBox1.StartIndex = 0;
            comboBox1.TabIndex = 42;
            comboBox1.UseTallSize = false;
            // 
            // RegisterPanel
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1264, 681);
            Controls.Add(comboBox1);
            Controls.Add(showPassVerify);
            Controls.Add(pictureBox5);
            Controls.Add(txtVerify);
            Controls.Add(showPassword);
            Controls.Add(uploadPicture);
            Controls.Add(uploadBtn);
            Controls.Add(pictureBox4);
            Controls.Add(txtUsername);
            Controls.Add(RegisterBtn);
            Controls.Add(LoginLabel);
            Controls.Add(pictureBox3);
            Controls.Add(pictureBox2);
            Controls.Add(txtPassword);
            Controls.Add(txtEmail);
            Controls.Add(pictureBox1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(4, 3, 4, 3);
            Name = "RegisterPanel";
            Text = "Register";
            ((System.ComponentModel.ISupportInitialize)pictureBox4).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)uploadPicture).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox5).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private System.Windows.Forms.Button RegisterBtn;
        private System.Windows.Forms.Label LoginLabel;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.PictureBox uploadPicture;
        private System.Windows.Forms.Button uploadBtn;
        private System.Windows.Forms.CheckBox showPassword;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.TextBox txtVerify;
        private System.Windows.Forms.CheckBox showPassVerify;
        private MaterialComboBox comboBox1;
    }
}