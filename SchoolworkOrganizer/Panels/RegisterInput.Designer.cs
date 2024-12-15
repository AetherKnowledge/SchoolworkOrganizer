namespace SchoolworkOrganizer.Panels
{
    partial class RegisterInput
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
            txtEmail = new MaterialSkin.Controls.MaterialTextBox2();
            txtPassword = new MaterialSkin.Controls.MaterialTextBox2();
            switchLabel = new CustomControls.CustomLabel();
            forgotPassword = new CustomControls.CustomLabel();
            registerBtn = new CustomControls.RoundedButton();
            txtUsername = new MaterialSkin.Controls.MaterialTextBox2();
            txtVerify = new MaterialSkin.Controls.MaterialTextBox2();
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
            hidePanel.Location = new Point(281, 256);
            hidePanel.Name = "hidePanel";
            hidePanel.Size = new Size(14, 29);
            hidePanel.TabIndex = 18;
            // 
            // showPassword
            // 
            showPassword.AutoSize = true;
            showPassword.Cursor = Cursors.Hand;
            showPassword.Font = new Font("Roboto Light", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            showPassword.ImageIndex = 0;
            showPassword.Location = new Point(281, 253);
            showPassword.Margin = new Padding(0);
            showPassword.Name = "showPassword";
            showPassword.Size = new Size(161, 32);
            showPassword.TabIndex = 7;
            showPassword.Text = "Show Password";
            showPassword.TextImageRelation = TextImageRelation.ImageBeforeText;
            showPassword.UseVisualStyleBackColor = true;
            showPassword.CheckedChanged += showPassword_CheckedChanged;
            // 
            // txtEmail
            // 
            txtEmail.AnimateReadOnly = false;
            txtEmail.AutoCompleteMode = AutoCompleteMode.None;
            txtEmail.AutoCompleteSource = AutoCompleteSource.None;
            txtEmail.BackgroundImageLayout = ImageLayout.None;
            txtEmail.CharacterCasing = CharacterCasing.Normal;
            txtEmail.Depth = 0;
            txtEmail.Font = new Font("Roboto Light", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtEmail.HideSelection = true;
            txtEmail.LeadingIcon = Properties.Resources.mail;
            txtEmail.Location = new Point(53, 40);
            txtEmail.Margin = new Padding(4, 3, 4, 3);
            txtEmail.MaxLength = 32767;
            txtEmail.MouseState = MaterialSkin.MouseState.OUT;
            txtEmail.Name = "txtEmail";
            txtEmail.PasswordChar = '\0';
            txtEmail.PrefixSuffixText = null;
            txtEmail.ReadOnly = false;
            txtEmail.RightToLeft = RightToLeft.No;
            txtEmail.SelectedText = "";
            txtEmail.SelectionLength = 0;
            txtEmail.SelectionStart = 0;
            txtEmail.ShortcutsEnabled = true;
            txtEmail.Size = new Size(389, 48);
            txtEmail.TabIndex = 1;
            txtEmail.TabStop = false;
            txtEmail.Text = "Email";
            txtEmail.TextAlign = HorizontalAlignment.Left;
            txtEmail.TrailingIcon = null;
            txtEmail.UseOwnColors = true;
            txtEmail.UseSystemPasswordChar = false;
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
            txtPassword.Location = new Point(53, 148);
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
            switchLabel.Location = new Point(53, 253);
            switchLabel.Margin = new Padding(4, 0, 4, 0);
            switchLabel.Name = "switchLabel";
            switchLabel.Size = new Size(152, 18);
            switchLabel.TabIndex = 14;
            switchLabel.Text = "Already have an account?";
            switchLabel.Click += switchLabel_Click;
            // 
            // forgotPassword
            // 
            forgotPassword.AutoSize = true;
            forgotPassword.Cursor = Cursors.Hand;
            forgotPassword.Font = new Font("Roboto Light", 9.75F);
            forgotPassword.ForeColor = Color.FromArgb(65, 78, 101);
            forgotPassword.Location = new Point(94, 271);
            forgotPassword.Margin = new Padding(4, 0, 4, 0);
            forgotPassword.Name = "forgotPassword";
            forgotPassword.Size = new Size(111, 18);
            forgotPassword.TabIndex = 5;
            forgotPassword.Text = "Forgot Password?";
            forgotPassword.Click += forgotPassword_Click;
            // 
            // registerBtn
            // 
            registerBtn.BackImageSize = new Size(0, 0);
            registerBtn.BorderColor = Color.Black;
            registerBtn.BorderRadius = 10;
            registerBtn.BorderThickness = 1;
            registerBtn.ButtonColor = Color.FromArgb(95, 192, 170);
            registerBtn.FlatAppearance.BorderSize = 0;
            registerBtn.FlatStyle = FlatStyle.Flat;
            registerBtn.Font = new Font("Roboto Light", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            registerBtn.ForeColor = Color.White;
            registerBtn.HoverColor = Color.FromArgb(66, 134, 118);
            registerBtn.IconLocation = CustomControls.RoundedButton.ImageLocation.Center;
            registerBtn.Image = null;
            registerBtn.ImageSize = new Size(0, 0);
            registerBtn.Location = new Point(320, 329);
            registerBtn.Name = "registerBtn";
            registerBtn.PressedColor = Color.FromArgb(46, 93, 82);
            registerBtn.Size = new Size(122, 42);
            registerBtn.TabIndex = 17;
            registerBtn.Text = "Register";
            registerBtn.UseVisualStyleBackColor = true;
            registerBtn.Click += registerBtn_Click;
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
            txtUsername.Location = new Point(53, 94);
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
            txtUsername.TabIndex = 19;
            txtUsername.TabStop = false;
            txtUsername.Text = "Username";
            txtUsername.TextAlign = HorizontalAlignment.Left;
            txtUsername.TrailingIcon = null;
            txtUsername.UseOwnColors = true;
            txtUsername.UseSystemPasswordChar = false;
            // 
            // txtVerify
            // 
            txtVerify.AnimateReadOnly = false;
            txtVerify.AutoCompleteMode = AutoCompleteMode.None;
            txtVerify.AutoCompleteSource = AutoCompleteSource.None;
            txtVerify.BackgroundImageLayout = ImageLayout.None;
            txtVerify.CharacterCasing = CharacterCasing.Normal;
            txtVerify.Depth = 0;
            txtVerify.Font = new Font("Roboto Light", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtVerify.HideSelection = true;
            txtVerify.LeadingIcon = Properties.Resources.approve;
            txtVerify.Location = new Point(53, 202);
            txtVerify.Margin = new Padding(4, 3, 4, 3);
            txtVerify.MaxLength = 32767;
            txtVerify.MouseState = MaterialSkin.MouseState.OUT;
            txtVerify.Name = "txtVerify";
            txtVerify.PasswordChar = '●';
            txtVerify.PrefixSuffixText = null;
            txtVerify.ReadOnly = false;
            txtVerify.RightToLeft = RightToLeft.No;
            txtVerify.SelectedText = "";
            txtVerify.SelectionLength = 0;
            txtVerify.SelectionStart = 0;
            txtVerify.ShortcutsEnabled = true;
            txtVerify.Size = new Size(389, 48);
            txtVerify.TabIndex = 20;
            txtVerify.TabStop = false;
            txtVerify.Text = "Password";
            txtVerify.TextAlign = HorizontalAlignment.Left;
            txtVerify.TrailingIcon = null;
            txtVerify.UseOwnColors = false;
            txtVerify.UseSystemPasswordChar = true;
            // 
            // RegisterInput
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(txtVerify);
            Controls.Add(txtUsername);
            Controls.Add(testBtn);
            Controls.Add(hidePanel);
            Controls.Add(showPassword);
            Controls.Add(txtEmail);
            Controls.Add(txtPassword);
            Controls.Add(switchLabel);
            Controls.Add(forgotPassword);
            Controls.Add(registerBtn);
            Name = "RegisterInput";
            Size = new Size(487, 483);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button testBtn;
        private Panel hidePanel;
        private CheckBox showPassword;
        private MaterialSkin.Controls.MaterialTextBox2 txtEmail;
        private MaterialSkin.Controls.MaterialTextBox2 txtPassword;
        private CustomControls.CustomLabel switchLabel;
        private CustomControls.CustomLabel forgotPassword;
        private CustomControls.RoundedButton registerBtn;
        private MaterialSkin.Controls.MaterialTextBox2 txtUsername;
        private MaterialSkin.Controls.MaterialTextBox2 txtVerify;
    }
}
