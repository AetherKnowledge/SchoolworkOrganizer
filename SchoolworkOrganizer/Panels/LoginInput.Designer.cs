namespace SchoolworkOrganizer.Panels
{
    partial class LoginInput
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            hidePanel = new Panel();
            showPassword = new CheckBox();
            txtUsername = new MaterialSkin.Controls.MaterialTextBox2();
            txtPassword = new MaterialSkin.Controls.MaterialTextBox2();
            switchLabel = new CustomControls.CustomLabel();
            forgotPassword = new CustomControls.CustomLabel();
            loginBtn = new CustomControls.RoundedButton();
            SuspendLayout();
            // 
            // hidePanel
            // 
            hidePanel.Location = new Point(321, 197);
            hidePanel.Margin = new Padding(3, 4, 3, 4);
            hidePanel.Name = "hidePanel";
            hidePanel.Size = new Size(16, 39);
            hidePanel.TabIndex = 18;
            // 
            // showPassword
            // 
            showPassword.AutoSize = true;
            showPassword.Cursor = Cursors.Hand;
            showPassword.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            showPassword.Location = new Point(321, 193);
            showPassword.Margin = new Padding(0);
            showPassword.Name = "showPassword";
            showPassword.Size = new Size(151, 24);
            showPassword.TabIndex = 7;
            showPassword.Text = "Show Password";
            showPassword.TextImageRelation = TextImageRelation.ImageBeforeText;
            showPassword.UseVisualStyleBackColor = true;
            showPassword.CheckedChanged += showPassword_CheckedChanged;
            // 
            // txtUsername
            // 
            txtUsername.AnimateReadOnly = false;
            txtUsername.AutoCompleteMode = AutoCompleteMode.None;
            txtUsername.AutoCompleteSource = AutoCompleteSource.None;
            txtUsername.BackgroundImageLayout = ImageLayout.None;
            txtUsername.CharacterCasing = CharacterCasing.Normal;
            txtUsername.Depth = 0;
            txtUsername.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtUsername.HideSelection = true;
            txtUsername.LeadingIcon = Properties.Resources.Capture;
            txtUsername.Location = new Point(61, 53);
            txtUsername.Margin = new Padding(5, 4, 5, 4);
            txtUsername.MaxLength = 32767;
            txtUsername.MouseState = MaterialSkin.MouseState.OUT;
            txtUsername.Name = "txtUsername";
            txtUsername.PasswordChar = '\0';
            txtUsername.PrefixSuffixText = null;
            txtUsername.ReadOnly = false;
            txtUsername.RightToLeft = RightToLeft.No;
            txtUsername.SelectedText = "";
            txtUsername.SelectionLength = 0;
            txtUsername.SelectionStart = 0;
            txtUsername.ShortcutsEnabled = true;
            txtUsername.Size = new Size(445, 48);
            txtUsername.TabIndex = 1;
            txtUsername.TabStop = false;
            txtUsername.Text = "Username";
            txtUsername.TextAlign = HorizontalAlignment.Left;
            txtUsername.TrailingIcon = null;
            txtUsername.UseOwnColors = true;
            txtUsername.UseSystemPasswordChar = false;
            // 
            // txtPassword
            // 
            txtPassword.AnimateReadOnly = false;
            txtPassword.AutoCompleteMode = AutoCompleteMode.None;
            txtPassword.AutoCompleteSource = AutoCompleteSource.None;
            txtPassword.BackgroundImageLayout = ImageLayout.None;
            txtPassword.CharacterCasing = CharacterCasing.Normal;
            txtPassword.Depth = 0;
            txtPassword.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtPassword.HideSelection = true;
            txtPassword.LeadingIcon = Properties.Resources.password1;
            txtPassword.Location = new Point(61, 125);
            txtPassword.Margin = new Padding(5, 4, 5, 4);
            txtPassword.MaxLength = 32767;
            txtPassword.MouseState = MaterialSkin.MouseState.OUT;
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '●';
            txtPassword.PrefixSuffixText = null;
            txtPassword.ReadOnly = false;
            txtPassword.RightToLeft = RightToLeft.No;
            txtPassword.SelectedText = "";
            txtPassword.SelectionLength = 0;
            txtPassword.SelectionStart = 0;
            txtPassword.ShortcutsEnabled = true;
            txtPassword.Size = new Size(445, 48);
            txtPassword.TabIndex = 2;
            txtPassword.TabStop = false;
            txtPassword.Text = "Password";
            txtPassword.TextAlign = HorizontalAlignment.Left;
            txtPassword.TrailingIcon = null;
            txtPassword.UseOwnColors = false;
            txtPassword.UseSystemPasswordChar = true;
            // 
            // switchLabel
            // 
            switchLabel.AutoSize = true;
            switchLabel.Cursor = Cursors.Hand;
            switchLabel.Font = new Font("Microsoft Sans Serif", 9.75F);
            switchLabel.ForeColor = Color.FromArgb(65, 78, 101);
            switchLabel.Location = new Point(61, 193);
            switchLabel.Margin = new Padding(5, 0, 5, 0);
            switchLabel.Name = "switchLabel";
            switchLabel.Size = new Size(185, 20);
            switchLabel.TabIndex = 14;
            switchLabel.Text = "Don't have an account?";
            switchLabel.Click += switchLabel_Click;
            // 
            // forgotPassword
            // 
            forgotPassword.AutoSize = true;
            forgotPassword.Cursor = Cursors.Hand;
            forgotPassword.Font = new Font("Microsoft Sans Serif", 9.75F);
            forgotPassword.ForeColor = Color.FromArgb(65, 78, 101);
            forgotPassword.Location = new Point(93, 217);
            forgotPassword.Margin = new Padding(5, 0, 5, 0);
            forgotPassword.Name = "forgotPassword";
            forgotPassword.Size = new Size(145, 20);
            forgotPassword.TabIndex = 5;
            forgotPassword.Text = "Forgot Password?";
            forgotPassword.Click += forgotPassword_Click;
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
            loginBtn.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            loginBtn.ForeColor = Color.White;
            loginBtn.HoverColor = Color.FromArgb(66, 134, 118);
            loginBtn.IconLocation = CustomControls.RoundedButton.ImageLocation.Center;
            loginBtn.Image = null;
            loginBtn.ImageSize = new Size(0, 0);
            loginBtn.Location = new Point(366, 439);
            loginBtn.Margin = new Padding(3, 4, 3, 4);
            loginBtn.Name = "loginBtn";
            loginBtn.PressedColor = Color.FromArgb(46, 93, 82);
            loginBtn.Size = new Size(139, 56);
            loginBtn.TabIndex = 17;
            loginBtn.Text = "Log In";
            loginBtn.UseVisualStyleBackColor = true;
            loginBtn.Click += loginBtn_Click;
            // 
            // LoginInput
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(hidePanel);
            Controls.Add(showPassword);
            Controls.Add(txtUsername);
            Controls.Add(txtPassword);
            Controls.Add(switchLabel);
            Controls.Add(forgotPassword);
            Controls.Add(loginBtn);
            Margin = new Padding(3, 4, 3, 4);
            Name = "LoginInput";
            Size = new Size(557, 644);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Panel hidePanel;
        private CheckBox showPassword;
        private MaterialSkin.Controls.MaterialTextBox2 txtUsername;
        private MaterialSkin.Controls.MaterialTextBox2 txtPassword;
        private CustomControls.CustomLabel switchLabel;
        private CustomControls.CustomLabel forgotPassword;
        private CustomControls.RoundedButton loginBtn;
    }
}
