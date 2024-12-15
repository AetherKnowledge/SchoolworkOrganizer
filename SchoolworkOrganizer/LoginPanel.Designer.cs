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
            registerPanel = new Panel();
            pictureBox3 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            mainPanel.SuspendLayout();
            loginImagePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)loginImageBox).BeginInit();
            panel1.SuspendLayout();
            registerPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            SuspendLayout();
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
            // mainPanel
            // 
            mainPanel.BackColor = SystemColors.Control;
            mainPanel.Controls.Add(changePanel);
            mainPanel.Controls.Add(loginInput);
            mainPanel.Controls.Add(registerInput);
            mainPanel.Controls.Add(topLabel);
            mainPanel.Controls.Add(pictureBox1);
            mainPanel.Location = new Point(3, 6);
            mainPanel.Name = "mainPanel";
            mainPanel.Size = new Size(487, 682);
            mainPanel.TabIndex = 18;
            // 
            // changePanel
            // 
            changePanel.BackColor = Color.FromArgb(65, 78, 101);
            changePanel.Location = new Point(-487, 125);
            changePanel.Name = "changePanel";
            changePanel.Size = new Size(487, 557);
            changePanel.TabIndex = 20;
            // 
            // loginInput
            // 
            loginInput.Dock = DockStyle.Fill;
            loginInput.Location = new Point(0, 207);
            loginInput.Name = "loginInput";
            loginInput.Size = new Size(487, 475);
            loginInput.TabIndex = 21;
            // 
            // registerInput
            // 
            registerInput.Dock = DockStyle.Fill;
            registerInput.Location = new Point(0, 207);
            registerInput.Name = "registerInput";
            registerInput.Size = new Size(487, 475);
            registerInput.TabIndex = 0;
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
            loginImagePanel.BackColor = SystemColors.Control;
            loginImagePanel.Controls.Add(loginImageBox);
            loginImagePanel.Location = new Point(496, 6);
            loginImagePanel.Name = "loginImagePanel";
            loginImagePanel.Size = new Size(779, 682);
            loginImagePanel.TabIndex = 19;
            // 
            // pictureBox2
            // 
            loginImageBox.BackColor = SystemColors.Control;
            loginImageBox.Dock = DockStyle.Fill;
            loginImageBox.Image = Properties.Resources.login_bg;
            loginImageBox.Location = new Point(0, 0);
            loginImageBox.Name = "pictureBox2";
            loginImageBox.Size = new Size(779, 682);
            loginImageBox.SizeMode = PictureBoxSizeMode.Zoom;
            loginImageBox.TabIndex = 0;
            loginImageBox.TabStop = false;
            // 
            // panel1
            // 
            panel1.Controls.Add(registerPanel);
            panel1.Controls.Add(loginImagePanel);
            panel1.Controls.Add(mainPanel);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(2, 24);
            panel1.Name = "panel1";
            panel1.Size = new Size(1276, 694);
            panel1.TabIndex = 0;
            // 
            // registerPanel
            // 
            registerPanel.BackColor = Color.FromArgb(65, 78, 101);
            registerPanel.Controls.Add(pictureBox3);
            registerPanel.Location = new Point(-779, 0);
            registerPanel.Name = "registerPanel";
            registerPanel.Size = new Size(779, 682);
            registerPanel.TabIndex = 20;
            // 
            // pictureBox3
            // 
            pictureBox3.Dock = DockStyle.Fill;
            pictureBox3.Location = new Point(0, 0);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(779, 682);
            pictureBox3.TabIndex = 0;
            pictureBox3.TabStop = false;
            // 
            // LoginPanel
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(65, 78, 101);
            ClientSize = new Size(1280, 720);
            Controls.Add(panel1);
            FormStyle = FormStyles.ActionBar_None;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(4, 3, 4, 3);
            Name = "LoginPanel";
            Padding = new Padding(2, 24, 2, 2);
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Login";
            Resize += RefreshPanel;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            mainPanel.ResumeLayout(false);
            loginImagePanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)loginImageBox).EndInit();
            panel1.ResumeLayout(false);
            registerPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
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
        private Panel registerPanel;
        private PictureBox pictureBox3;
    }
}