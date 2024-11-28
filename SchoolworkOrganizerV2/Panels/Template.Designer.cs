namespace SchoolworkOrganizerV2.Panels
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Template));
            this.sidePanel = new System.Windows.Forms.Panel();
            this.userPanel = new System.Windows.Forms.Panel();
            this.imagePanel = new System.Windows.Forms.Panel();
            this.userImageBox = new System.Windows.Forms.PictureBox();
            this.usernamePanel = new System.Windows.Forms.Panel();
            this.usernameLabel = new System.Windows.Forms.Label();
            this.subjectsBtn = new System.Windows.Forms.Button();
            this.reviewerBtn = new System.Windows.Forms.Button();
            this.activityBtn = new System.Windows.Forms.Button();
            this.logoutBtn = new System.Windows.Forms.Button();
            this.settingsBtn = new System.Windows.Forms.Button();
            this.homeBtn = new System.Windows.Forms.Button();
            this.topPanel = new System.Windows.Forms.Panel();
            this.datePanel = new System.Windows.Forms.Panel();
            this.timeTxtBox = new System.Windows.Forms.Label();
            this.iconImageBox = new System.Windows.Forms.PictureBox();
            this.timeKeeper = new System.Windows.Forms.Timer(this.components);
            this.mainPanel = new System.Windows.Forms.Panel();
            this.sidePanel.SuspendLayout();
            this.userPanel.SuspendLayout();
            this.imagePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.userImageBox)).BeginInit();
            this.usernamePanel.SuspendLayout();
            this.topPanel.SuspendLayout();
            this.datePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iconImageBox)).BeginInit();
            this.SuspendLayout();
            // 
            // sidePanel
            // 
            this.sidePanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(78)))), ((int)(((byte)(101)))));
            this.sidePanel.Controls.Add(this.userPanel);
            this.sidePanel.Controls.Add(this.subjectsBtn);
            this.sidePanel.Controls.Add(this.reviewerBtn);
            this.sidePanel.Controls.Add(this.activityBtn);
            this.sidePanel.Controls.Add(this.logoutBtn);
            this.sidePanel.Controls.Add(this.settingsBtn);
            this.sidePanel.Controls.Add(this.homeBtn);
            this.sidePanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.sidePanel.Location = new System.Drawing.Point(1, 84);
            this.sidePanel.Name = "sidePanel";
            this.sidePanel.Size = new System.Drawing.Size(162, 395);
            this.sidePanel.TabIndex = 5;
            // 
            // userPanel
            // 
            this.userPanel.Controls.Add(this.imagePanel);
            this.userPanel.Controls.Add(this.usernamePanel);
            this.userPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.userPanel.Location = new System.Drawing.Point(0, 0);
            this.userPanel.Name = "userPanel";
            this.userPanel.Size = new System.Drawing.Size(162, 140);
            this.userPanel.TabIndex = 12;
            // 
            // imagePanel
            // 
            this.imagePanel.Controls.Add(this.userImageBox);
            this.imagePanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.imagePanel.Location = new System.Drawing.Point(0, 0);
            this.imagePanel.Name = "imagePanel";
            this.imagePanel.Padding = new System.Windows.Forms.Padding(10, 10, 10, 0);
            this.imagePanel.Size = new System.Drawing.Size(162, 118);
            this.imagePanel.TabIndex = 1;
            // 
            // userImageBox
            // 
            this.userImageBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.userImageBox.Location = new System.Drawing.Point(10, 10);
            this.userImageBox.Name = "userImageBox";
            this.userImageBox.Size = new System.Drawing.Size(142, 108);
            this.userImageBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.userImageBox.TabIndex = 2;
            this.userImageBox.TabStop = false;
            // 
            // usernamePanel
            // 
            this.usernamePanel.Controls.Add(this.usernameLabel);
            this.usernamePanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.usernamePanel.Location = new System.Drawing.Point(0, 118);
            this.usernamePanel.Name = "usernamePanel";
            this.usernamePanel.Size = new System.Drawing.Size(162, 22);
            this.usernamePanel.TabIndex = 0;
            // 
            // usernameLabel
            // 
            this.usernameLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.usernameLabel.Font = new System.Drawing.Font("Roboto Light", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.usernameLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(231)))), ((int)(((byte)(231)))));
            this.usernameLabel.Location = new System.Drawing.Point(0, 0);
            this.usernameLabel.Name = "usernameLabel";
            this.usernameLabel.Size = new System.Drawing.Size(162, 22);
            this.usernameLabel.TabIndex = 2;
            this.usernameLabel.Text = "label1";
            this.usernameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // subjectsBtn
            // 
            this.subjectsBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(63)))), ((int)(((byte)(82)))));
            this.subjectsBtn.FlatAppearance.BorderSize = 0;
            this.subjectsBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.subjectsBtn.Font = new System.Drawing.Font("Roboto Light", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.subjectsBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(231)))), ((int)(((byte)(231)))));
            this.subjectsBtn.Location = new System.Drawing.Point(10, 203);
            this.subjectsBtn.Name = "subjectsBtn";
            this.subjectsBtn.Size = new System.Drawing.Size(142, 31);
            this.subjectsBtn.TabIndex = 11;
            this.subjectsBtn.Text = "Subjects";
            this.subjectsBtn.UseVisualStyleBackColor = false;
            this.subjectsBtn.Click += new System.EventHandler(this.subjectsBtn_Click);
            // 
            // reviewerBtn
            // 
            this.reviewerBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(63)))), ((int)(((byte)(82)))));
            this.reviewerBtn.FlatAppearance.BorderSize = 0;
            this.reviewerBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.reviewerBtn.Font = new System.Drawing.Font("Roboto Light", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.reviewerBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(231)))), ((int)(((byte)(231)))));
            this.reviewerBtn.Location = new System.Drawing.Point(10, 277);
            this.reviewerBtn.Name = "reviewerBtn";
            this.reviewerBtn.Size = new System.Drawing.Size(142, 31);
            this.reviewerBtn.TabIndex = 10;
            this.reviewerBtn.Text = "Reviewers";
            this.reviewerBtn.UseVisualStyleBackColor = false;
            this.reviewerBtn.Click += new System.EventHandler(this.reviewerBtn_Click);
            // 
            // activityBtn
            // 
            this.activityBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(63)))), ((int)(((byte)(82)))));
            this.activityBtn.FlatAppearance.BorderSize = 0;
            this.activityBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.activityBtn.Font = new System.Drawing.Font("Roboto Light", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.activityBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(231)))), ((int)(((byte)(231)))));
            this.activityBtn.Location = new System.Drawing.Point(10, 240);
            this.activityBtn.Name = "activityBtn";
            this.activityBtn.Size = new System.Drawing.Size(142, 31);
            this.activityBtn.TabIndex = 9;
            this.activityBtn.Text = "Activites";
            this.activityBtn.UseVisualStyleBackColor = false;
            this.activityBtn.Click += new System.EventHandler(this.activityBtn_Click);
            // 
            // logoutBtn
            // 
            this.logoutBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(63)))), ((int)(((byte)(82)))));
            this.logoutBtn.FlatAppearance.BorderSize = 0;
            this.logoutBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.logoutBtn.Font = new System.Drawing.Font("Roboto Light", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.logoutBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(231)))), ((int)(((byte)(231)))));
            this.logoutBtn.Location = new System.Drawing.Point(10, 351);
            this.logoutBtn.Name = "logoutBtn";
            this.logoutBtn.Size = new System.Drawing.Size(142, 31);
            this.logoutBtn.TabIndex = 7;
            this.logoutBtn.Text = "Log Out";
            this.logoutBtn.UseVisualStyleBackColor = false;
            this.logoutBtn.Click += new System.EventHandler(this.logoutBtn_Click);
            // 
            // settingsBtn
            // 
            this.settingsBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(63)))), ((int)(((byte)(82)))));
            this.settingsBtn.FlatAppearance.BorderSize = 0;
            this.settingsBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.settingsBtn.Font = new System.Drawing.Font("Roboto Light", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.settingsBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(231)))), ((int)(((byte)(231)))));
            this.settingsBtn.Location = new System.Drawing.Point(10, 314);
            this.settingsBtn.Name = "settingsBtn";
            this.settingsBtn.Size = new System.Drawing.Size(142, 31);
            this.settingsBtn.TabIndex = 6;
            this.settingsBtn.Text = "Settings";
            this.settingsBtn.UseVisualStyleBackColor = false;
            this.settingsBtn.Click += new System.EventHandler(this.settingsBtn_Click);
            // 
            // homeBtn
            // 
            this.homeBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(63)))), ((int)(((byte)(82)))));
            this.homeBtn.FlatAppearance.BorderSize = 0;
            this.homeBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.homeBtn.Font = new System.Drawing.Font("Roboto Light", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.homeBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(231)))), ((int)(((byte)(231)))));
            this.homeBtn.Location = new System.Drawing.Point(10, 166);
            this.homeBtn.Name = "homeBtn";
            this.homeBtn.Size = new System.Drawing.Size(142, 31);
            this.homeBtn.TabIndex = 2;
            this.homeBtn.Text = "Home";
            this.homeBtn.UseVisualStyleBackColor = false;
            this.homeBtn.Click += new System.EventHandler(this.homeBtn_Click);
            // 
            // topPanel
            // 
            this.topPanel.AutoSize = true;
            this.topPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(49)))), ((int)(((byte)(65)))));
            this.topPanel.Controls.Add(this.datePanel);
            this.topPanel.Controls.Add(this.iconImageBox);
            this.topPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.topPanel.Location = new System.Drawing.Point(1, 24);
            this.topPanel.MaximumSize = new System.Drawing.Size(0, 60);
            this.topPanel.Name = "topPanel";
            this.topPanel.Size = new System.Drawing.Size(928, 60);
            this.topPanel.TabIndex = 4;
            // 
            // datePanel
            // 
            this.datePanel.Controls.Add(this.timeTxtBox);
            this.datePanel.Dock = System.Windows.Forms.DockStyle.Right;
            this.datePanel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(231)))), ((int)(((byte)(231)))));
            this.datePanel.Location = new System.Drawing.Point(702, 0);
            this.datePanel.Name = "datePanel";
            this.datePanel.Size = new System.Drawing.Size(226, 60);
            this.datePanel.TabIndex = 12;
            // 
            // timeTxtBox
            // 
            this.timeTxtBox.AutoSize = true;
            this.timeTxtBox.Font = new System.Drawing.Font("Roboto Light", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.timeTxtBox.Location = new System.Drawing.Point(3, 39);
            this.timeTxtBox.Name = "timeTxtBox";
            this.timeTxtBox.Size = new System.Drawing.Size(36, 20);
            this.timeTxtBox.TabIndex = 9;
            this.timeTxtBox.Text = "looo";
            // 
            // iconImageBox
            // 
            this.iconImageBox.Image = global::SchoolworkOrganizerV2.Properties.Resources.Screenshot_2024_11_13_231616_removebg_preview;
            this.iconImageBox.Location = new System.Drawing.Point(3, 4);
            this.iconImageBox.Name = "iconImageBox";
            this.iconImageBox.Size = new System.Drawing.Size(159, 60);
            this.iconImageBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.iconImageBox.TabIndex = 10;
            this.iconImageBox.TabStop = false;
            // 
            // timeKeeper
            // 
            this.timeKeeper.Interval = 1000;
            // 
            // mainPanel
            // 
            this.mainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainPanel.Location = new System.Drawing.Point(163, 84);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(766, 395);
            this.mainPanel.TabIndex = 6;
            // 
            // Template
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(930, 480);
            this.Controls.Add(this.mainPanel);
            this.Controls.Add(this.sidePanel);
            this.Controls.Add(this.topPanel);
            this.FormStyle = MaterialSkin.Controls.MaterialForm.FormStyles.ActionBar_None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Template";
            this.Padding = new System.Windows.Forms.Padding(1, 24, 1, 1);
            this.Text = "Template";
            this.sidePanel.ResumeLayout(false);
            this.userPanel.ResumeLayout(false);
            this.imagePanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.userImageBox)).EndInit();
            this.usernamePanel.ResumeLayout(false);
            this.topPanel.ResumeLayout(false);
            this.datePanel.ResumeLayout(false);
            this.datePanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iconImageBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

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