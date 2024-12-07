namespace SchoolworkOrganizer.Panels
{
    partial class Template
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Template));
            sidePanel = new Panel();
            userPanel = new Panel();
            imagePanel = new Panel();
            userImageBox = new PictureBox();
            usernamePanel = new Panel();
            usernameLabel = new Label();
            subjectsBtn = new Button();
            reviewerBtn = new Button();
            activityBtn = new Button();
            logoutBtn = new Button();
            settingsBtn = new Button();
            homeBtn = new Button();
            topPanel = new Panel();
            datePanel = new Panel();
            timeTxtBox = new Label();
            iconImageBox = new PictureBox();
            timeKeeper = new System.Windows.Forms.Timer(components);
            mainPanel = new Panel();
            sidePanel.SuspendLayout();
            userPanel.SuspendLayout();
            imagePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)userImageBox).BeginInit();
            usernamePanel.SuspendLayout();
            topPanel.SuspendLayout();
            datePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)iconImageBox).BeginInit();
            SuspendLayout();
            // 
            // sidePanel
            // 
            sidePanel.BackColor = Color.FromArgb(65, 78, 101);
            sidePanel.Controls.Add(userPanel);
            sidePanel.Controls.Add(subjectsBtn);
            sidePanel.Controls.Add(reviewerBtn);
            sidePanel.Controls.Add(activityBtn);
            sidePanel.Controls.Add(logoutBtn);
            sidePanel.Controls.Add(settingsBtn);
            sidePanel.Controls.Add(homeBtn);
            sidePanel.Dock = DockStyle.Left;
            sidePanel.Location = new Point(1, 93);
            sidePanel.Margin = new Padding(4, 3, 4, 3);
            sidePanel.Name = "sidePanel";
            sidePanel.Size = new Size(189, 626);
            sidePanel.TabIndex = 5;
            // 
            // userPanel
            // 
            userPanel.Controls.Add(imagePanel);
            userPanel.Controls.Add(usernamePanel);
            userPanel.Dock = DockStyle.Top;
            userPanel.Location = new Point(0, 0);
            userPanel.Margin = new Padding(4, 3, 4, 3);
            userPanel.Name = "userPanel";
            userPanel.Size = new Size(189, 162);
            userPanel.TabIndex = 12;
            // 
            // imagePanel
            // 
            imagePanel.Controls.Add(userImageBox);
            imagePanel.Dock = DockStyle.Fill;
            imagePanel.Location = new Point(0, 0);
            imagePanel.Margin = new Padding(4, 3, 4, 3);
            imagePanel.Name = "imagePanel";
            imagePanel.Padding = new Padding(12, 12, 12, 0);
            imagePanel.Size = new Size(189, 137);
            imagePanel.TabIndex = 1;
            // 
            // userImageBox
            // 
            userImageBox.Dock = DockStyle.Fill;
            userImageBox.Image = Properties.Resources.user;
            userImageBox.Location = new Point(12, 12);
            userImageBox.Margin = new Padding(4, 3, 4, 3);
            userImageBox.Name = "userImageBox";
            userImageBox.Size = new Size(165, 125);
            userImageBox.SizeMode = PictureBoxSizeMode.Zoom;
            userImageBox.TabIndex = 2;
            userImageBox.TabStop = false;
            // 
            // usernamePanel
            // 
            usernamePanel.Controls.Add(usernameLabel);
            usernamePanel.Dock = DockStyle.Bottom;
            usernamePanel.Location = new Point(0, 137);
            usernamePanel.Margin = new Padding(4, 3, 4, 3);
            usernamePanel.Name = "usernamePanel";
            usernamePanel.Size = new Size(189, 25);
            usernamePanel.TabIndex = 0;
            // 
            // usernameLabel
            // 
            usernameLabel.Dock = DockStyle.Fill;
            usernameLabel.Font = new Font("Roboto Light", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            usernameLabel.ForeColor = Color.FromArgb(231, 231, 231);
            usernameLabel.Location = new Point(0, 0);
            usernameLabel.Margin = new Padding(4, 0, 4, 0);
            usernameLabel.Name = "usernameLabel";
            usernameLabel.Size = new Size(189, 25);
            usernameLabel.TabIndex = 2;
            usernameLabel.Text = "label1";
            usernameLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // subjectsBtn
            // 
            subjectsBtn.BackColor = Color.FromArgb(52, 63, 82);
            subjectsBtn.FlatAppearance.BorderSize = 0;
            subjectsBtn.FlatStyle = FlatStyle.Flat;
            subjectsBtn.Font = new Font("Roboto Light", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            subjectsBtn.ForeColor = Color.FromArgb(231, 231, 231);
            subjectsBtn.Location = new Point(12, 234);
            subjectsBtn.Margin = new Padding(4, 3, 4, 3);
            subjectsBtn.Name = "subjectsBtn";
            subjectsBtn.Size = new Size(166, 36);
            subjectsBtn.TabIndex = 11;
            subjectsBtn.Text = "Subjects";
            subjectsBtn.UseVisualStyleBackColor = false;
            subjectsBtn.Click += subjectsBtn_Click;
            // 
            // reviewerBtn
            // 
            reviewerBtn.BackColor = Color.FromArgb(52, 63, 82);
            reviewerBtn.FlatAppearance.BorderSize = 0;
            reviewerBtn.FlatStyle = FlatStyle.Flat;
            reviewerBtn.Font = new Font("Roboto Light", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            reviewerBtn.ForeColor = Color.FromArgb(231, 231, 231);
            reviewerBtn.Location = new Point(12, 320);
            reviewerBtn.Margin = new Padding(4, 3, 4, 3);
            reviewerBtn.Name = "reviewerBtn";
            reviewerBtn.Size = new Size(166, 36);
            reviewerBtn.TabIndex = 10;
            reviewerBtn.Text = "Reviewers";
            reviewerBtn.UseVisualStyleBackColor = false;
            reviewerBtn.Click += reviewerBtn_Click;
            // 
            // activityBtn
            // 
            activityBtn.BackColor = Color.FromArgb(52, 63, 82);
            activityBtn.FlatAppearance.BorderSize = 0;
            activityBtn.FlatStyle = FlatStyle.Flat;
            activityBtn.Font = new Font("Roboto Light", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            activityBtn.ForeColor = Color.FromArgb(231, 231, 231);
            activityBtn.Location = new Point(12, 277);
            activityBtn.Margin = new Padding(4, 3, 4, 3);
            activityBtn.Name = "activityBtn";
            activityBtn.Size = new Size(166, 36);
            activityBtn.TabIndex = 9;
            activityBtn.Text = "Activites";
            activityBtn.UseVisualStyleBackColor = false;
            activityBtn.Click += activityBtn_Click;
            // 
            // logoutBtn
            // 
            logoutBtn.BackColor = Color.FromArgb(52, 63, 82);
            logoutBtn.FlatAppearance.BorderSize = 0;
            logoutBtn.FlatStyle = FlatStyle.Flat;
            logoutBtn.Font = new Font("Roboto Light", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            logoutBtn.ForeColor = Color.FromArgb(231, 231, 231);
            logoutBtn.Location = new Point(12, 405);
            logoutBtn.Margin = new Padding(4, 3, 4, 3);
            logoutBtn.Name = "logoutBtn";
            logoutBtn.Size = new Size(166, 36);
            logoutBtn.TabIndex = 7;
            logoutBtn.Text = "Log Out";
            logoutBtn.UseVisualStyleBackColor = false;
            logoutBtn.Click += logoutBtn_Click;
            // 
            // settingsBtn
            // 
            settingsBtn.BackColor = Color.FromArgb(52, 63, 82);
            settingsBtn.FlatAppearance.BorderSize = 0;
            settingsBtn.FlatStyle = FlatStyle.Flat;
            settingsBtn.Font = new Font("Roboto Light", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            settingsBtn.ForeColor = Color.FromArgb(231, 231, 231);
            settingsBtn.Location = new Point(12, 362);
            settingsBtn.Margin = new Padding(4, 3, 4, 3);
            settingsBtn.Name = "settingsBtn";
            settingsBtn.Size = new Size(166, 36);
            settingsBtn.TabIndex = 6;
            settingsBtn.Text = "Settings";
            settingsBtn.UseVisualStyleBackColor = false;
            settingsBtn.Click += settingsBtn_Click;
            // 
            // homeBtn
            // 
            homeBtn.BackColor = Color.FromArgb(52, 63, 82);
            homeBtn.FlatAppearance.BorderSize = 0;
            homeBtn.FlatStyle = FlatStyle.Flat;
            homeBtn.Font = new Font("Roboto Light", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            homeBtn.ForeColor = Color.FromArgb(231, 231, 231);
            homeBtn.Location = new Point(12, 192);
            homeBtn.Margin = new Padding(4, 3, 4, 3);
            homeBtn.Name = "homeBtn";
            homeBtn.Size = new Size(166, 36);
            homeBtn.TabIndex = 2;
            homeBtn.Text = "Home";
            homeBtn.UseVisualStyleBackColor = false;
            homeBtn.Click += homeBtn_Click;
            // 
            // topPanel
            // 
            topPanel.AutoSize = true;
            topPanel.BackColor = Color.FromArgb(43, 49, 65);
            topPanel.Controls.Add(datePanel);
            topPanel.Controls.Add(iconImageBox);
            topPanel.Dock = DockStyle.Top;
            topPanel.Location = new Point(1, 24);
            topPanel.Margin = new Padding(4, 3, 4, 3);
            topPanel.MaximumSize = new Size(0, 69);
            topPanel.Name = "topPanel";
            topPanel.Size = new Size(1278, 69);
            topPanel.TabIndex = 4;
            // 
            // datePanel
            // 
            datePanel.Controls.Add(timeTxtBox);
            datePanel.Dock = DockStyle.Right;
            datePanel.ForeColor = Color.FromArgb(231, 231, 231);
            datePanel.Location = new Point(1014, 0);
            datePanel.Margin = new Padding(4, 3, 4, 3);
            datePanel.Name = "datePanel";
            datePanel.Size = new Size(264, 69);
            datePanel.TabIndex = 12;
            // 
            // timeTxtBox
            // 
            timeTxtBox.AutoSize = true;
            timeTxtBox.Font = new Font("Roboto Light", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            timeTxtBox.Location = new Point(4, 45);
            timeTxtBox.Margin = new Padding(4, 0, 4, 0);
            timeTxtBox.Name = "timeTxtBox";
            timeTxtBox.Size = new Size(36, 20);
            timeTxtBox.TabIndex = 9;
            timeTxtBox.Text = "looo";
            // 
            // iconImageBox
            // 
            iconImageBox.Image = Properties.Resources.Screenshot_2024_11_13_231616_removebg_preview;
            iconImageBox.Location = new Point(4, 5);
            iconImageBox.Margin = new Padding(4, 3, 4, 3);
            iconImageBox.Name = "iconImageBox";
            iconImageBox.Size = new Size(186, 69);
            iconImageBox.SizeMode = PictureBoxSizeMode.StretchImage;
            iconImageBox.TabIndex = 10;
            iconImageBox.TabStop = false;
            // 
            // timeKeeper
            // 
            timeKeeper.Interval = 1000;
            // 
            // mainPanel
            // 
            mainPanel.Dock = DockStyle.Fill;
            mainPanel.Location = new Point(190, 93);
            mainPanel.Margin = new Padding(4, 3, 4, 3);
            mainPanel.Name = "mainPanel";
            mainPanel.Size = new Size(1089, 626);
            mainPanel.TabIndex = 6;
            // 
            // Template
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1280, 720);
            Controls.Add(mainPanel);
            Controls.Add(sidePanel);
            Controls.Add(topPanel);
            FormStyle = FormStyles.ActionBar_None;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(4, 3, 4, 3);
            Name = "Template";
            Padding = new Padding(1, 24, 1, 1);
            Text = "Template";
            sidePanel.ResumeLayout(false);
            userPanel.ResumeLayout(false);
            imagePanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)userImageBox).EndInit();
            usernamePanel.ResumeLayout(false);
            topPanel.ResumeLayout(false);
            datePanel.ResumeLayout(false);
            datePanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)iconImageBox).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Panel sidePanel;
        private System.Windows.Forms.Label usernameLabel;
        private System.Windows.Forms.Button logoutBtn;
        private System.Windows.Forms.Button settingsBtn;
        private System.Windows.Forms.Button homeBtn;
        private System.Windows.Forms.PictureBox userImageBox;
        private System.Windows.Forms.Panel topPanel;
        private System.Windows.Forms.PictureBox iconImageBox;
        private System.Windows.Forms.Label timeTxtBox;
        private System.Windows.Forms.Button activityBtn;
        private System.Windows.Forms.Timer timeKeeper;
        protected System.Windows.Forms.Panel mainPanel;
        private System.Windows.Forms.Panel datePanel;
        private System.Windows.Forms.Button reviewerBtn;
        private System.Windows.Forms.Button subjectsBtn;
        private System.Windows.Forms.Panel userPanel;
        private System.Windows.Forms.Panel imagePanel;
        private System.Windows.Forms.Panel usernamePanel;
    }
}