using MaterialSkin.Controls;
using SchoolworkOrganizer.CustomControls;

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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginPanel));
            loginTxtUsername = new MaterialTextBox2();
            loginTxtPassword = new MaterialTextBox2();
            loginLabelForgotPassword = new CustomLabel();
            loginShowPassword = new CheckBox();
            password = new ImageList(components);
            loginSwitchLabel = new CustomLabel();
            pictureBox1 = new PictureBox();
            testBtn = new Button();
            loginBtn = new RoundedButton();
            mainPanel = new Panel();
            inputPanel = new Panel();
            hidePanel = new Panel();
            topPanel = new Panel();
            topLabel = new CustomLabel();
            loginImagePanel = new Panel();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            mainPanel.SuspendLayout();
            inputPanel.SuspendLayout();
            SuspendLayout();
            // 
            // loginTxtUsername
            // 
            loginTxtUsername.AnimateReadOnly = false;
            loginTxtUsername.AutoCompleteMode = AutoCompleteMode.None;
            loginTxtUsername.AutoCompleteSource = AutoCompleteSource.None;
            loginTxtUsername.BackgroundImageLayout = ImageLayout.None;
            loginTxtUsername.CharacterCasing = CharacterCasing.Normal;
            loginTxtUsername.Depth = 0;
            loginTxtUsername.Font = new Font("Roboto Light", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            loginTxtUsername.HideSelection = true;
            loginTxtUsername.LeadingIcon = Properties.Resources.Capture;
            loginTxtUsername.Location = new Point(53, 40);
            loginTxtUsername.Margin = new Padding(4, 3, 4, 3);
            loginTxtUsername.MaxLength = 32767;
            loginTxtUsername.MouseState = MaterialSkin.MouseState.OUT;
            loginTxtUsername.Name = "loginTxtUsername";
            loginTxtUsername.PasswordChar = '\0';
            loginTxtUsername.PrefixSuffixText = null;
            loginTxtUsername.ReadOnly = false;
            loginTxtUsername.RightToLeft = RightToLeft.No;
            loginTxtUsername.SelectedText = "";
            loginTxtUsername.SelectionLength = 0;
            loginTxtUsername.SelectionStart = 0;
            loginTxtUsername.ShortcutsEnabled = true;
            loginTxtUsername.Size = new Size(389, 48);
            loginTxtUsername.TabIndex = 1;
            loginTxtUsername.TabStop = false;
            loginTxtUsername.Text = "Username";
            loginTxtUsername.TextAlign = HorizontalAlignment.Left;
            loginTxtUsername.TrailingIcon = null;
            loginTxtUsername.UseOwnColors = true;
            loginTxtUsername.UseSystemPasswordChar = false;
            // 
            // loginTxtPassword
            // 
            loginTxtPassword.AnimateReadOnly = false;
            loginTxtPassword.AutoCompleteMode = AutoCompleteMode.None;
            loginTxtPassword.AutoCompleteSource = AutoCompleteSource.None;
            loginTxtPassword.BackgroundImageLayout = ImageLayout.None;
            loginTxtPassword.CharacterCasing = CharacterCasing.Normal;
            loginTxtPassword.Depth = 0;
            loginTxtPassword.Font = new Font("Roboto Light", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            loginTxtPassword.HideSelection = true;
            loginTxtPassword.LeadingIcon = Properties.Resources.password1;
            loginTxtPassword.Location = new Point(53, 94);
            loginTxtPassword.Margin = new Padding(4, 3, 4, 3);
            loginTxtPassword.MaxLength = 32767;
            loginTxtPassword.MouseState = MaterialSkin.MouseState.OUT;
            loginTxtPassword.Name = "loginTxtPassword";
            loginTxtPassword.PasswordChar = '●';
            loginTxtPassword.PrefixSuffixText = null;
            loginTxtPassword.ReadOnly = false;
            loginTxtPassword.RightToLeft = RightToLeft.No;
            loginTxtPassword.SelectedText = "";
            loginTxtPassword.SelectionLength = 0;
            loginTxtPassword.SelectionStart = 0;
            loginTxtPassword.ShortcutsEnabled = true;
            loginTxtPassword.Size = new Size(389, 48);
            loginTxtPassword.TabIndex = 2;
            loginTxtPassword.TabStop = false;
            loginTxtPassword.Text = "Password";
            loginTxtPassword.TextAlign = HorizontalAlignment.Left;
            loginTxtPassword.TrailingIcon = null;
            loginTxtPassword.UseOwnColors = false;
            loginTxtPassword.UseSystemPasswordChar = true;
            // 
            // loginLabelForgotPassword
            // 
            loginLabelForgotPassword.AutoSize = true;
            loginLabelForgotPassword.Cursor = Cursors.Hand;
            loginLabelForgotPassword.Font = new Font("Roboto Light", 9.75F);
            loginLabelForgotPassword.ForeColor = Color.FromArgb(65, 78, 101);
            loginLabelForgotPassword.Location = new Point(81, 163);
            loginLabelForgotPassword.Margin = new Padding(4, 0, 4, 0);
            loginLabelForgotPassword.Name = "loginLabelForgotPassword";
            loginLabelForgotPassword.Size = new Size(111, 18);
            loginLabelForgotPassword.TabIndex = 5;
            loginLabelForgotPassword.Text = "Forgot Password?";
            loginLabelForgotPassword.Click += labelForgotPassword_Click;
            // 
            // loginShowPassword
            // 
            loginShowPassword.AutoSize = true;
            loginShowPassword.Cursor = Cursors.Hand;
            loginShowPassword.Font = new Font("Roboto Light", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            loginShowPassword.ImageIndex = 0;
            loginShowPassword.ImageList = password;
            loginShowPassword.Location = new Point(281, 145);
            loginShowPassword.Margin = new Padding(0);
            loginShowPassword.Name = "loginShowPassword";
            loginShowPassword.Size = new Size(161, 32);
            loginShowPassword.TabIndex = 7;
            loginShowPassword.Text = "Show Password";
            loginShowPassword.TextImageRelation = TextImageRelation.ImageBeforeText;
            loginShowPassword.UseVisualStyleBackColor = true;
            loginShowPassword.CheckedChanged += showPassword_CheckedChanged;
            // 
            // password
            // 
            password.ColorDepth = ColorDepth.Depth32Bit;
            password.ImageStream = (ImageListStreamer)resources.GetObject("password.ImageStream");
            password.TransparentColor = Color.Transparent;
            password.Images.SetKeyName(0, "eye.png");
            password.Images.SetKeyName(1, "view.png");
            // 
            // loginSwitchLabel
            // 
            loginSwitchLabel.AutoSize = true;
            loginSwitchLabel.Cursor = Cursors.Hand;
            loginSwitchLabel.Font = new Font("Roboto Light", 9.75F);
            loginSwitchLabel.ForeColor = Color.FromArgb(65, 78, 101);
            loginSwitchLabel.Location = new Point(53, 145);
            loginSwitchLabel.Margin = new Padding(4, 0, 4, 0);
            loginSwitchLabel.Name = "loginSwitchLabel";
            loginSwitchLabel.Size = new Size(139, 18);
            loginSwitchLabel.TabIndex = 14;
            loginSwitchLabel.Text = "Don't have an account?";
            loginSwitchLabel.Click += switchLabel_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Dock = DockStyle.Top;
            pictureBox1.Image = Properties.Resources.bg_dark;
            pictureBox1.Location = new Point(0, 0);
            pictureBox1.Margin = new Padding(4, 3, 4, 3);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(487, 126);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // testBtn
            // 
            testBtn.Location = new Point(44, 348);
            testBtn.Name = "testBtn";
            testBtn.Size = new Size(75, 23);
            testBtn.TabIndex = 15;
            testBtn.Text = "button1";
            testBtn.UseVisualStyleBackColor = true;
            testBtn.Click += testBtn_Click;
            // 
            // loginBtn
            // 
            loginBtn.BackImageSize = new Size(0, 0);
            loginBtn.BorderColor = Color.Black;
            loginBtn.BorderRadius = 10;
            loginBtn.BorderThickness = 1;
            loginBtn.ButtonColor = Color.FromArgb(95, 192, 170);
            loginBtn.FlatAppearance.BorderSize = 0;
            loginBtn.FlatStyle = FlatStyle.Flat;
            loginBtn.Font = new Font("Roboto Light", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            loginBtn.ForeColor = Color.White;
            loginBtn.HoverColor = Color.FromArgb(66, 134, 118);
            loginBtn.IconLocation = RoundedButton.ImageLocation.Center;
            loginBtn.Image = null;
            loginBtn.ImageSize = new Size(0, 0);
            loginBtn.Location = new Point(320, 232);
            loginBtn.Name = "loginBtn";
            loginBtn.PressedColor = Color.FromArgb(46, 93, 82);
            loginBtn.Size = new Size(122, 42);
            loginBtn.TabIndex = 17;
            loginBtn.Text = "Log In";
            loginBtn.UseVisualStyleBackColor = true;
            loginBtn.Click += loginBtn_Click;
            // 
            // mainPanel
            // 
            mainPanel.BackColor = SystemColors.Control;
            mainPanel.Controls.Add(inputPanel);
            mainPanel.Controls.Add(topPanel);
            mainPanel.Controls.Add(topLabel);
            mainPanel.Controls.Add(pictureBox1);
            mainPanel.Location = new Point(4, 27);
            mainPanel.Name = "mainPanel";
            mainPanel.Size = new Size(487, 689);
            mainPanel.TabIndex = 18;
            // 
            // inputPanel
            // 
            inputPanel.Controls.Add(testBtn);
            inputPanel.Controls.Add(hidePanel);
            inputPanel.Controls.Add(loginShowPassword);
            inputPanel.Controls.Add(loginTxtUsername);
            inputPanel.Controls.Add(loginTxtPassword);
            inputPanel.Controls.Add(loginSwitchLabel);
            inputPanel.Controls.Add(loginLabelForgotPassword);
            inputPanel.Controls.Add(loginBtn);
            inputPanel.Dock = DockStyle.Fill;
            inputPanel.Location = new Point(0, 207);
            inputPanel.Name = "inputPanel";
            inputPanel.Size = new Size(487, 482);
            inputPanel.TabIndex = 21;
            // 
            // hidePanel
            // 
            hidePanel.Location = new Point(281, 148);
            hidePanel.Name = "hidePanel";
            hidePanel.Size = new Size(14, 29);
            hidePanel.TabIndex = 18;
            // 
            // topPanel
            // 
            topPanel.BackColor = SystemColors.ActiveCaption;
            topPanel.Location = new Point(-487, 125);
            topPanel.Name = "topPanel";
            topPanel.Size = new Size(487, 82);
            topPanel.TabIndex = 20;
            // 
            // topLabel
            // 
            topLabel.Dock = DockStyle.Top;
            topLabel.Font = new Font("Roboto Medium", 26.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            topLabel.ForeColor = Color.FromArgb(65, 78, 101);
            topLabel.Location = new Point(0, 126);
            topLabel.Name = "topLabel";
            topLabel.Size = new Size(487, 81);
            topLabel.TabIndex = 19;
            topLabel.Text = "LOGIN";
            topLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // loginImagePanel
            // 
            loginImagePanel.BackColor = SystemColors.ActiveCaption;
            loginImagePanel.Location = new Point(497, 27);
            loginImagePanel.Name = "loginImagePanel";
            loginImagePanel.Size = new Size(779, 689);
            loginImagePanel.TabIndex = 19;
            // 
            // LoginPanel
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            ClientSize = new Size(1280, 720);
            Controls.Add(loginImagePanel);
            Controls.Add(mainPanel);
            FormStyle = FormStyles.ActionBar_None;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(4, 3, 4, 3);
            Name = "LoginPanel";
            Padding = new Padding(1, 24, 1, 1);
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Login";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            mainPanel.ResumeLayout(false);
            inputPanel.ResumeLayout(false);
            inputPanel.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private MaterialTextBox2 loginTxtUsername;
        private MaterialTextBox2 loginTxtPassword;
        private CustomLabel loginLabelForgotPassword;
        private System.Windows.Forms.Button ButtonLogIn;
        private System.Windows.Forms.CheckBox loginShowPassword;
        private CustomLabel loginSwitchLabel;
        private Button testBtn;
        private CustomControls.RoundedButton loginBtn;
        private Panel mainPanel;
        private Panel hidePanel;
        private ImageList password;
        private CustomLabel topLabel;
        private Panel loginImagePanel;
        private Panel topPanel;
        private Panel inputPanel;
    }
}