namespace SchoolworkOrganizer.Panels
{
    partial class SettingsPanel
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
            label9 = new Label();
            label3 = new Label();
            label6 = new Label();
            label29 = new Label();
            updateBtn = new Button();
            emailTxt = new TextBox();
            verifyTxt = new TextBox();
            passwordTxt = new TextBox();
            usernameTxt = new TextBox();
            upload_button = new Button();
            uploadPicture = new PictureBox();
            label1 = new Label();
            cancelBtn = new Button();
            SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)uploadPicture).BeginInit();
            SuspendLayout();
            Controls.Add(cancelBtn);
            Controls.Add(label1);
            Controls.Add(uploadPicture);
            Controls.Add(upload_button);
            Controls.Add(usernameTxt);
            Controls.Add(passwordTxt);
            Controls.Add(verifyTxt);
            Controls.Add(label9);
            Controls.Add(emailTxt);
            Controls.Add(label3);
            Controls.Add(label6);
            Controls.Add(updateBtn);
            Controls.Add(label29);
            Margin = new Padding(5, 3, 5, 3);
            Size = new Size(1089, 626);
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Roboto Light", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label9.Location = new Point(107, 133);
            label9.Margin = new Padding(4, 0, 4, 0);
            label9.Name = "label9";
            label9.Size = new Size(62, 25);
            label9.TabIndex = 52;
            label9.Text = "Email:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Roboto Light", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(13, 249);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(152, 25);
            label3.TabIndex = 50;
            label3.Text = "Verify Password:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Roboto Light", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label6.Location = new Point(63, 189);
            label6.Margin = new Padding(4, 0, 4, 0);
            label6.Name = "label6";
            label6.Size = new Size(100, 25);
            label6.TabIndex = 49;
            label6.Text = "Password:";
            // 
            // label29
            // 
            label29.AutoSize = true;
            label29.Font = new Font("Roboto Light", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label29.Location = new Point(59, 84);
            label29.Margin = new Padding(4, 0, 4, 0);
            label29.Name = "label29";
            label29.Size = new Size(103, 25);
            label29.TabIndex = 46;
            label29.Text = "Username:";
            // 
            // updateBtn
            // 
            updateBtn.BackColor = Color.FromArgb(95, 192, 170);
            updateBtn.FlatStyle = FlatStyle.Flat;
            updateBtn.Font = new Font("Roboto Light", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            updateBtn.ForeColor = Color.FromArgb(231, 231, 231);
            updateBtn.Location = new Point(574, 423);
            updateBtn.Margin = new Padding(4, 3, 4, 3);
            updateBtn.Name = "updateBtn";
            updateBtn.Size = new Size(150, 47);
            updateBtn.TabIndex = 45;
            updateBtn.Text = "Update";
            updateBtn.UseVisualStyleBackColor = false;
            updateBtn.Click += updateBtn_Click;
            // 
            // emailTxt
            // 
            emailTxt.Font = new Font("Roboto Light", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            emailTxt.Location = new Point(187, 133);
            emailTxt.Margin = new Padding(4, 3, 4, 3);
            emailTxt.Name = "emailTxt";
            emailTxt.Size = new Size(247, 33);
            emailTxt.TabIndex = 41;
            // 
            // verifyTxt
            // 
            verifyTxt.Font = new Font("Roboto Light", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            verifyTxt.Location = new Point(187, 246);
            verifyTxt.Margin = new Padding(4, 3, 4, 3);
            verifyTxt.Name = "verifyTxt";
            verifyTxt.Size = new Size(247, 33);
            verifyTxt.TabIndex = 39;
            // 
            // passwordTxt
            // 
            passwordTxt.Font = new Font("Roboto Light", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            passwordTxt.Location = new Point(187, 189);
            passwordTxt.Margin = new Padding(4, 3, 4, 3);
            passwordTxt.Name = "passwordTxt";
            passwordTxt.Size = new Size(247, 33);
            passwordTxt.TabIndex = 38;
            // 
            // usernameTxt
            // 
            usernameTxt.Font = new Font("Roboto Light", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            usernameTxt.Location = new Point(187, 81);
            usernameTxt.Margin = new Padding(4, 3, 4, 3);
            usernameTxt.Name = "usernameTxt";
            usernameTxt.Size = new Size(247, 33);
            usernameTxt.TabIndex = 36;
            // 
            // upload_button
            // 
            upload_button.BackColor = Color.FromArgb(52, 63, 82);
            upload_button.BackgroundImageLayout = ImageLayout.None;
            upload_button.FlatAppearance.BorderSize = 0;
            upload_button.FlatStyle = FlatStyle.Flat;
            upload_button.Font = new Font("Roboto Light", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            upload_button.ForeColor = Color.FromArgb(231, 231, 231);
            upload_button.Location = new Point(672, 277);
            upload_button.Margin = new Padding(4, 3, 4, 3);
            upload_button.Name = "upload_button";
            upload_button.Size = new Size(210, 43);
            upload_button.TabIndex = 35;
            upload_button.Text = "Upload";
            upload_button.UseVisualStyleBackColor = false;
            upload_button.Click += upload_button_Click;
            // 
            // uploadPicture
            // 
            uploadPicture.Location = new Point(671, 81);
            uploadPicture.Margin = new Padding(4, 3, 4, 3);
            uploadPicture.Name = "uploadPicture";
            uploadPicture.Size = new Size(210, 182);
            uploadPicture.SizeMode = PictureBoxSizeMode.StretchImage;
            uploadPicture.TabIndex = 34;
            uploadPicture.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Roboto", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(7, 12);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(174, 38);
            label1.TabIndex = 53;
            label1.Text = "Edit Profile";
            // 
            // cancelBtn
            // 
            cancelBtn.BackColor = Color.FromArgb(171, 37, 51);
            cancelBtn.FlatStyle = FlatStyle.Flat;
            cancelBtn.Font = new Font("Roboto Light", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cancelBtn.ForeColor = Color.FromArgb(231, 231, 231);
            cancelBtn.Location = new Point(732, 423);
            cancelBtn.Margin = new Padding(4, 3, 4, 3);
            cancelBtn.Name = "cancelBtn";
            cancelBtn.Size = new Size(150, 47);
            cancelBtn.TabIndex = 54;
            cancelBtn.Text = "Cancel";
            cancelBtn.UseVisualStyleBackColor = false;
            cancelBtn.Click += cancelBtn_Click;
            // 
            // SettingsPanel
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1280, 720);
            Margin = new Padding(5, 3, 5, 3);
            Name = "SettingsPanel";
            Text = "Settings";
            ResumeLayout(false);
            PerformLayout();
            ((System.ComponentModel.ISupportInitialize)uploadPicture).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.Button updateBtn;
        private System.Windows.Forms.TextBox emailTxt;
        private System.Windows.Forms.TextBox verifyTxt;
        private System.Windows.Forms.TextBox passwordTxt;
        private System.Windows.Forms.TextBox usernameTxt;
        private System.Windows.Forms.Button upload_button;
        private System.Windows.Forms.PictureBox uploadPicture;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button cancelBtn;
    }
}