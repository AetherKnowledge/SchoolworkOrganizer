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
            testBtn = new Button();
            hidePanel = new Panel();
            showPassword = new CheckBox();
            txtUsername = new MaterialSkin.Controls.MaterialTextBox2();
            txtPassword = new MaterialSkin.Controls.MaterialTextBox2();
            switchLabel = new CustomControls.CustomLabel();
            forgotPassword = new CustomControls.CustomLabel();
            loginBtn = new CustomControls.RoundedButton();
            SuspendLayout();
            // 
            // testBtn
            // 
            testBtn.Location = new Point(44, 348);
            testBtn.Name = "testBtn";
            testBtn.Size = new Size(75, 23);
            testBtn.TabIndex = 15;
            testBtn.Text = "button1";
            testBtn.UseVisualStyleBackColor = true;
            // 
            // hidePanel
            // 
            hidePanel.Location = new Point(281, 148);
            hidePanel.Name = "hidePanel";
            hidePanel.Size = new Size(14, 29);
            hidePanel.TabIndex = 18;
            // 
            // showPassword
            // 
            showPassword.AutoSize = true;
            showPassword.Cursor = Cursors.Hand;
            showPassword.Font = new Font("Roboto Light", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            showPassword.Location = new Point(281, 145);
            showPassword.Margin = new Padding(0);
            showPassword.Name = "showPassword";
            showPassword.Size = new Size(129, 23);
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
            txtUsername.Font = new Font("Roboto Light", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtUsername.HideSelection = true;
            txtUsername.LeadingIcon = Properties.Resources.Capture;
            txtUsername.Location = new Point(53, 40);
            txtUsername.Margin = new Padding(4, 3, 4, 3);
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
            txtUsername.Size = new Size(389, 48);
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
            txtPassword.Font = new Font("Roboto Light", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtPassword.HideSelection = true;
            txtPassword.LeadingIcon = Properties.Resources.password1;
            txtPassword.Location = new Point(53, 94);
            txtPassword.Margin = new Padding(4, 3, 4, 3);
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
            txtPassword.Size = new Size(389, 48);
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
            switchLabel.Font = new Font("Roboto Light", 9.75F);
            switchLabel.ForeColor = Color.FromArgb(65, 78, 101);
            switchLabel.Location = new Point(53, 145);
            switchLabel.Margin = new Padding(4, 0, 4, 0);
            switchLabel.Name = "switchLabel";
            switchLabel.Size = new Size(139, 18);
            switchLabel.TabIndex = 14;
            switchLabel.Text = "Don't have an account?";
            switchLabel.Click += switchLabel_Click;
            // 
            // forgotPassword
            // 
            forgotPassword.AutoSize = true;
            forgotPassword.Cursor = Cursors.Hand;
            forgotPassword.Font = new Font("Roboto Light", 9.75F);
            forgotPassword.ForeColor = Color.FromArgb(65, 78, 101);
            forgotPassword.Location = new Point(81, 163);
            forgotPassword.Margin = new Padding(4, 0, 4, 0);
            forgotPassword.Name = "forgotPassword";
            forgotPassword.Size = new Size(111, 18);
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
            loginBtn.Font = new Font("Roboto Light", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            loginBtn.ForeColor = Color.White;
            loginBtn.HoverColor = Color.FromArgb(66, 134, 118);
            loginBtn.IconLocation = CustomControls.RoundedButton.ImageLocation.Center;
            loginBtn.Image = null;
            loginBtn.ImageSize = new Size(0, 0);
            loginBtn.Location = new Point(320, 329);
            loginBtn.Name = "loginBtn";
            loginBtn.PressedColor = Color.FromArgb(46, 93, 82);
            loginBtn.Size = new Size(122, 42);
            loginBtn.TabIndex = 17;
            loginBtn.Text = "Log In";
            loginBtn.UseVisualStyleBackColor = true;
            loginBtn.Click += loginBtn_Click;
            // 
            // LoginInput
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(testBtn);
            Controls.Add(hidePanel);
            Controls.Add(showPassword);
            Controls.Add(txtUsername);
            Controls.Add(txtPassword);
            Controls.Add(switchLabel);
            Controls.Add(forgotPassword);
            Controls.Add(loginBtn);
            Name = "LoginInput";
            Size = new Size(487, 483);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button testBtn;
        private Panel hidePanel;
        private CheckBox showPassword;
        private MaterialSkin.Controls.MaterialTextBox2 txtUsername;
        private MaterialSkin.Controls.MaterialTextBox2 txtPassword;
        private CustomControls.CustomLabel switchLabel;
        private CustomControls.CustomLabel forgotPassword;
        private CustomControls.RoundedButton loginBtn;
    }
}
