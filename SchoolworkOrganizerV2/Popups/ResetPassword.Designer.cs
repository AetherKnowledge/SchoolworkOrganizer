namespace SchoolworkOrganizerV2.Popups
{
    partial class ResetPassword
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ResetPassword));
            this.changePasswordBtn = new System.Windows.Forms.Button();
            this.verifyPasswordTxtBox = new System.Windows.Forms.TextBox();
            this.newPasswordTxtBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // changePasswordBtn
            // 
            this.changePasswordBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(63)))), ((int)(((byte)(82)))));
            this.changePasswordBtn.FlatAppearance.BorderSize = 0;
            this.changePasswordBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.changePasswordBtn.Font = new System.Drawing.Font("Roboto Light", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.changePasswordBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(231)))), ((int)(((byte)(231)))));
            this.changePasswordBtn.Location = new System.Drawing.Point(296, 342);
            this.changePasswordBtn.Name = "changePasswordBtn";
            this.changePasswordBtn.Size = new System.Drawing.Size(144, 29);
            this.changePasswordBtn.TabIndex = 7;
            this.changePasswordBtn.Text = "Change Password";
            this.changePasswordBtn.UseVisualStyleBackColor = false;
            this.changePasswordBtn.Click += new System.EventHandler(this.changePasswordBtn_Click);
            // 
            // verifyPasswordTxtBox
            // 
            this.verifyPasswordTxtBox.Font = new System.Drawing.Font("Roboto Light", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.verifyPasswordTxtBox.Location = new System.Drawing.Point(224, 262);
            this.verifyPasswordTxtBox.Name = "verifyPasswordTxtBox";
            this.verifyPasswordTxtBox.Size = new System.Drawing.Size(300, 33);
            this.verifyPasswordTxtBox.TabIndex = 5;
            this.verifyPasswordTxtBox.Text = "VerifyPassword";
            this.verifyPasswordTxtBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // newPasswordTxtBox
            // 
            this.newPasswordTxtBox.Font = new System.Drawing.Font("Roboto Light", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.newPasswordTxtBox.Location = new System.Drawing.Point(224, 210);
            this.newPasswordTxtBox.Name = "newPasswordTxtBox";
            this.newPasswordTxtBox.Size = new System.Drawing.Size(300, 33);
            this.newPasswordTxtBox.TabIndex = 4;
            this.newPasswordTxtBox.Text = "New Password";
            this.newPasswordTxtBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Roboto", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(262, 149);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(227, 35);
            this.label1.TabIndex = 9;
            this.label1.Text = "Reset Password";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Image = global::SchoolworkOrganizerV2.Properties.Resources.bg_dark;
            this.pictureBox1.Location = new System.Drawing.Point(196, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(351, 118);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 8;
            this.pictureBox1.TabStop = false;
            // 
            // ResetPassword
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.changePasswordBtn);
            this.Controls.Add(this.verifyPasswordTxtBox);
            this.Controls.Add(this.newPasswordTxtBox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ResetPassword";
            this.Text = "Reset Password";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button changePasswordBtn;
        private System.Windows.Forms.TextBox verifyPasswordTxtBox;
        private System.Windows.Forms.TextBox newPasswordTxtBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}