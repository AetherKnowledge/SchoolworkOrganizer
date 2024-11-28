namespace SchoolworkOrganizerV2.Popups
{
    partial class ForgotPassword
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ForgotPassword));
            this.employeeIDTxtBox = new System.Windows.Forms.TextBox();
            this.codeTxtBox = new System.Windows.Forms.TextBox();
            this.sendBtn = new System.Windows.Forms.Button();
            this.proceedBtn = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // employeeIDTxtBox
            // 
            this.employeeIDTxtBox.Font = new System.Drawing.Font("Roboto Light", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.employeeIDTxtBox.Location = new System.Drawing.Point(185, 254);
            this.employeeIDTxtBox.Name = "employeeIDTxtBox";
            this.employeeIDTxtBox.Size = new System.Drawing.Size(300, 33);
            this.employeeIDTxtBox.TabIndex = 0;
            this.employeeIDTxtBox.Text = "Employee ID";
            this.employeeIDTxtBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // codeTxtBox
            // 
            this.codeTxtBox.Font = new System.Drawing.Font("Roboto Light", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.codeTxtBox.Location = new System.Drawing.Point(185, 321);
            this.codeTxtBox.Name = "codeTxtBox";
            this.codeTxtBox.Size = new System.Drawing.Size(300, 33);
            this.codeTxtBox.TabIndex = 1;
            this.codeTxtBox.Text = "Verification Code";
            this.codeTxtBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // sendBtn
            // 
            this.sendBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(63)))), ((int)(((byte)(82)))));
            this.sendBtn.FlatAppearance.BorderSize = 0;
            this.sendBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.sendBtn.Font = new System.Drawing.Font("Roboto Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sendBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(231)))), ((int)(((byte)(231)))));
            this.sendBtn.Location = new System.Drawing.Point(535, 254);
            this.sendBtn.Name = "sendBtn";
            this.sendBtn.Size = new System.Drawing.Size(144, 33);
            this.sendBtn.TabIndex = 2;
            this.sendBtn.Text = "Send Verification Code";
            this.sendBtn.UseVisualStyleBackColor = false;
            this.sendBtn.Click += new System.EventHandler(this.sendBtn_Click);
            // 
            // proceedBtn
            // 
            this.proceedBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(63)))), ((int)(((byte)(82)))));
            this.proceedBtn.FlatAppearance.BorderSize = 0;
            this.proceedBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.proceedBtn.Font = new System.Drawing.Font("Roboto Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.proceedBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(231)))), ((int)(((byte)(231)))));
            this.proceedBtn.Location = new System.Drawing.Point(535, 321);
            this.proceedBtn.Name = "proceedBtn";
            this.proceedBtn.Size = new System.Drawing.Size(144, 33);
            this.proceedBtn.TabIndex = 3;
            this.proceedBtn.Text = "Proceed";
            this.proceedBtn.UseVisualStyleBackColor = false;
            this.proceedBtn.Click += new System.EventHandler(this.proceedBtn_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Image = global::SchoolworkOrganizerV2.Properties.Resources.bg_dark;
            this.pictureBox1.Location = new System.Drawing.Point(196, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(351, 118);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Roboto", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(215, 143);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(313, 35);
            this.label1.TabIndex = 5;
            this.label1.Text = "Forgot your password?";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Roboto Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(117, 188);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(578, 21);
            this.label2.TabIndex = 6;
            this.label2.Text = "Enter your Employee ID in the field below to recieve your validation code by emai" +
    "l";
            // 
            // ForgotPassword
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.proceedBtn);
            this.Controls.Add(this.sendBtn);
            this.Controls.Add(this.codeTxtBox);
            this.Controls.Add(this.employeeIDTxtBox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ForgotPassword";
            this.Text = "Forgot Password";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox employeeIDTxtBox;
        private System.Windows.Forms.TextBox codeTxtBox;
        private System.Windows.Forms.Button sendBtn;
        private System.Windows.Forms.Button proceedBtn;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}