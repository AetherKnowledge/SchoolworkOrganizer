namespace SchoolworkOrganizerV2.Panels
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
            this.label9 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label29 = new System.Windows.Forms.Label();
            this.updateBtn = new System.Windows.Forms.Button();
            this.emailTxt = new System.Windows.Forms.TextBox();
            this.verifyTxt = new System.Windows.Forms.TextBox();
            this.passwordTxt = new System.Windows.Forms.TextBox();
            this.usernameTxt = new System.Windows.Forms.TextBox();
            this.upload_button = new System.Windows.Forms.Button();
            this.uploadPicture = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cancelBtn = new System.Windows.Forms.Button();
            this.mainPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uploadPicture)).BeginInit();
            this.SuspendLayout();
            // 
            // mainPanel
            // 
            this.mainPanel.Controls.Add(this.cancelBtn);
            this.mainPanel.Controls.Add(this.label1);
            this.mainPanel.Controls.Add(this.uploadPicture);
            this.mainPanel.Controls.Add(this.upload_button);
            this.mainPanel.Controls.Add(this.usernameTxt);
            this.mainPanel.Controls.Add(this.passwordTxt);
            this.mainPanel.Controls.Add(this.verifyTxt);
            this.mainPanel.Controls.Add(this.label9);
            this.mainPanel.Controls.Add(this.emailTxt);
            this.mainPanel.Controls.Add(this.label3);
            this.mainPanel.Controls.Add(this.label6);
            this.mainPanel.Controls.Add(this.updateBtn);
            this.mainPanel.Controls.Add(this.label29);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Roboto Light", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(92, 115);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(62, 25);
            this.label9.TabIndex = 52;
            this.label9.Text = "Email:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Roboto Light", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(11, 216);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(152, 25);
            this.label3.TabIndex = 50;
            this.label3.Text = "Verify Password:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Roboto Light", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(54, 164);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(100, 25);
            this.label6.TabIndex = 49;
            this.label6.Text = "Password:";
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Font = new System.Drawing.Font("Roboto Light", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label29.Location = new System.Drawing.Point(51, 73);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(103, 25);
            this.label29.TabIndex = 46;
            this.label29.Text = "Username:";
            // 
            // updateBtn
            // 
            this.updateBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(192)))), ((int)(((byte)(170)))));
            this.updateBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.updateBtn.Font = new System.Drawing.Font("Roboto Light", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.updateBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(231)))), ((int)(((byte)(231)))));
            this.updateBtn.Location = new System.Drawing.Point(492, 367);
            this.updateBtn.Name = "updateBtn";
            this.updateBtn.Size = new System.Drawing.Size(129, 41);
            this.updateBtn.TabIndex = 45;
            this.updateBtn.Text = "Update";
            this.updateBtn.UseVisualStyleBackColor = false;
            this.updateBtn.Click += new System.EventHandler(this.updateBtn_Click);
            // 
            // emailTxt
            // 
            this.emailTxt.Font = new System.Drawing.Font("Roboto Light", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.emailTxt.Location = new System.Drawing.Point(160, 115);
            this.emailTxt.Name = "emailTxt";
            this.emailTxt.Size = new System.Drawing.Size(212, 33);
            this.emailTxt.TabIndex = 41;
            // 
            // verifyTxt
            // 
            this.verifyTxt.Font = new System.Drawing.Font("Roboto Light", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.verifyTxt.Location = new System.Drawing.Point(160, 213);
            this.verifyTxt.Name = "verifyTxt";
            this.verifyTxt.Size = new System.Drawing.Size(212, 33);
            this.verifyTxt.TabIndex = 39;
            // 
            // passwordTxt
            // 
            this.passwordTxt.Font = new System.Drawing.Font("Roboto Light", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.passwordTxt.Location = new System.Drawing.Point(160, 164);
            this.passwordTxt.Name = "passwordTxt";
            this.passwordTxt.Size = new System.Drawing.Size(212, 33);
            this.passwordTxt.TabIndex = 38;
            // 
            // usernameTxt
            // 
            this.usernameTxt.Font = new System.Drawing.Font("Roboto Light", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.usernameTxt.Location = new System.Drawing.Point(160, 70);
            this.usernameTxt.Name = "usernameTxt";
            this.usernameTxt.Size = new System.Drawing.Size(212, 33);
            this.usernameTxt.TabIndex = 36;
            // 
            // upload_button
            // 
            this.upload_button.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(63)))), ((int)(((byte)(82)))));
            this.upload_button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.upload_button.FlatAppearance.BorderSize = 0;
            this.upload_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.upload_button.Font = new System.Drawing.Font("Roboto Light", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.upload_button.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(231)))), ((int)(((byte)(231)))));
            this.upload_button.Location = new System.Drawing.Point(576, 240);
            this.upload_button.Name = "upload_button";
            this.upload_button.Size = new System.Drawing.Size(180, 37);
            this.upload_button.TabIndex = 35;
            this.upload_button.Text = "Upload";
            this.upload_button.UseVisualStyleBackColor = false;
            this.upload_button.Click += new System.EventHandler(this.upload_button_Click);
            // 
            // uploadPicture
            // 
            this.uploadPicture.Location = new System.Drawing.Point(575, 70);
            this.uploadPicture.Name = "uploadPicture";
            this.uploadPicture.Size = new System.Drawing.Size(180, 158);
            this.uploadPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.uploadPicture.TabIndex = 34;
            this.uploadPicture.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Roboto", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(6, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(174, 38);
            this.label1.TabIndex = 53;
            this.label1.Text = "Edit Profile";
            // 
            // cancelBtn
            // 
            this.cancelBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(37)))), ((int)(((byte)(51)))));
            this.cancelBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cancelBtn.Font = new System.Drawing.Font("Roboto Light", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cancelBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(231)))), ((int)(((byte)(231)))));
            this.cancelBtn.Location = new System.Drawing.Point(627, 367);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(129, 41);
            this.cancelBtn.TabIndex = 54;
            this.cancelBtn.Text = "Cancel";
            this.cancelBtn.UseVisualStyleBackColor = false;
            this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // SettingsPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(930, 480);
            this.Name = "SettingsPanel";
            this.Text = "Settings";
            this.mainPanel.ResumeLayout(false);
            this.mainPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uploadPicture)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

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