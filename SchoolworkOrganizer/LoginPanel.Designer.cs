﻿using MaterialSkin.Controls;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginPanel));
            pictureBox1 = new PictureBox();
            mainPanel = new Panel();
            changePanel = new Panel();
            loginInput = new Panels.LoginInput();
            registerInput = new Panels.RegisterInput();
            topLabel = new Label();
            loginImagePanel = new Panel();
            loginImageBox = new PictureBox();
            panel1 = new Panel();
            registerImagePanel = new Panel();
            registerImageBox = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            mainPanel.SuspendLayout();
            loginImagePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)loginImageBox).BeginInit();
            panel1.SuspendLayout();
            registerImagePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)registerImageBox).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Dock = DockStyle.Top;
            pictureBox1.Image = Properties.Resources.bg_dark;
            pictureBox1.Location = new Point(0, 0);
            pictureBox1.Margin = new Padding(5, 4, 5, 4);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(557, 168);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // mainPanel
            // 
            mainPanel.BackColor = SystemColors.Control;
            mainPanel.Controls.Add(changePanel);
            mainPanel.Controls.Add(loginInput);
            mainPanel.Controls.Add(registerInput);
            mainPanel.Controls.Add(topLabel);
            mainPanel.Controls.Add(pictureBox1);
            mainPanel.Location = new Point(3, 8);
            mainPanel.Margin = new Padding(3, 4, 3, 4);
            mainPanel.Name = "mainPanel";
            mainPanel.Size = new Size(557, 909);
            mainPanel.TabIndex = 18;
            // 
            // changePanel
            // 
            changePanel.BackColor = Color.FromArgb(65, 78, 101);
            changePanel.Location = new Point(-557, 167);
            changePanel.Margin = new Padding(3, 4, 3, 4);
            changePanel.Name = "changePanel";
            changePanel.Size = new Size(557, 743);
            changePanel.TabIndex = 20;
            // 
            // loginInput
            // 
            loginInput.Dock = DockStyle.Fill;
            loginInput.Location = new Point(0, 276);
            loginInput.Margin = new Padding(3, 5, 3, 5);
            loginInput.Name = "loginInput";
            loginInput.Size = new Size(557, 633);
            loginInput.TabIndex = 21;
            loginInput.Load += loginInput_Load;
            // 
            // registerInput
            // 
            registerInput.Dock = DockStyle.Fill;
            registerInput.Location = new Point(0, 276);
            registerInput.Margin = new Padding(3, 5, 3, 5);
            registerInput.Name = "registerInput";
            registerInput.Size = new Size(557, 633);
            registerInput.TabIndex = 0;
            // 
            // topLabel
            // 
            topLabel.Dock = DockStyle.Top;
            topLabel.Font = new Font("Microsoft Sans Serif", 26.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            topLabel.ForeColor = Color.FromArgb(65, 78, 101);
            topLabel.Location = new Point(0, 168);
            topLabel.Name = "topLabel";
            topLabel.Size = new Size(557, 108);
            topLabel.TabIndex = 19;
            topLabel.Text = "LOGIN";
            topLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // loginImagePanel
            // 
            loginImagePanel.BackColor = SystemColors.Control;
            loginImagePanel.Controls.Add(loginImageBox);
            loginImagePanel.Location = new Point(567, 8);
            loginImagePanel.Margin = new Padding(3, 4, 3, 4);
            loginImagePanel.Name = "loginImagePanel";
            loginImagePanel.Size = new Size(890, 909);
            loginImagePanel.TabIndex = 19;
            // 
            // loginImageBox
            // 
            loginImageBox.BackColor = SystemColors.Control;
            loginImageBox.Dock = DockStyle.Fill;
            loginImageBox.Image = Properties.Resources.login_bg;
            loginImageBox.Location = new Point(0, 0);
            loginImageBox.Margin = new Padding(3, 4, 3, 4);
            loginImageBox.Name = "loginImageBox";
            loginImageBox.Size = new Size(890, 909);
            loginImageBox.SizeMode = PictureBoxSizeMode.Zoom;
            loginImageBox.TabIndex = 0;
            loginImageBox.TabStop = false;
            // 
            // panel1
            // 
            panel1.Controls.Add(registerImagePanel);
            panel1.Controls.Add(loginImagePanel);
            panel1.Controls.Add(mainPanel);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(1, 24);
            panel1.Margin = new Padding(3, 4, 3, 4);
            panel1.Name = "panel1";
            panel1.Size = new Size(1461, 921);
            panel1.TabIndex = 0;
            // 
            // registerImagePanel
            // 
            registerImagePanel.BackColor = Color.FromArgb(65, 78, 101);
            registerImagePanel.Controls.Add(registerImageBox);
            registerImagePanel.Location = new Point(-890, 0);
            registerImagePanel.Margin = new Padding(3, 4, 3, 4);
            registerImagePanel.Name = "registerImagePanel";
            registerImagePanel.Size = new Size(890, 909);
            registerImagePanel.TabIndex = 20;
            // 
            // registerImageBox
            // 
            registerImageBox.Dock = DockStyle.Fill;
            registerImageBox.Image = Properties.Resources.pngtree_online_e_learning_flat_bundle_design_png_image_13081087__1_;
            registerImageBox.Location = new Point(0, 0);
            registerImageBox.Margin = new Padding(3, 4, 3, 4);
            registerImageBox.Name = "registerImageBox";
            registerImageBox.Size = new Size(890, 909);
            registerImageBox.SizeMode = PictureBoxSizeMode.StretchImage;
            registerImageBox.TabIndex = 0;
            registerImageBox.TabStop = false;
            // 
            // LoginPanel
            // 
            AutoScaleMode = AutoScaleMode.None;
            BackColor = Color.FromArgb(65, 78, 101);
            ClientSize = new Size(1463, 946);
            Controls.Add(panel1);
            FormStyle = FormStyles.ActionBar_None;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(5, 4, 5, 4);
            MinimumSize = new Size(1463, 946);
            Name = "LoginPanel";
            Padding = new Padding(1, 24, 1, 1);
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Login";
            Resize += RefreshPanel;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            mainPanel.ResumeLayout(false);
            loginImagePanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)loginImageBox).EndInit();
            panel1.ResumeLayout(false);
            registerImagePanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)registerImageBox).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button ButtonLogIn;
        private Panel mainPanel;
        private System.Windows.Forms.Label topLabel;
        private Panel loginImagePanel;
        private Panel changePanel;
        private Panels.LoginInput loginInput;
        private Panels.RegisterInput registerInput;
        private Panel panel1;
        private PictureBox loginImageBox;
        private Panel registerImagePanel;
        private PictureBox registerImageBox;
    }
}