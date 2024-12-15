namespace SchoolworkOrganizer.Panels
{
    partial class AdminPage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AdminPage));
            tabControl = new MaterialSkin.Controls.MaterialTabControl();
            homeTab = new TabPage();
            homePanel = new HomePanel();
            subjectTab = new TabPage();
            subjectsPanel = new SubjectsPanel();
            activitiesTab = new TabPage();
            activitiesPanel = new ActivitiesPanel();
            reviewersTab = new TabPage();
            reviewerPanel = new ReviewerPanel();
            settingsTab = new TabPage();
            settingsPanel = new SettingsPanel();
            logoImages = new ImageList(components);
            timeKeeper = new System.Windows.Forms.Timer(components);
            topPanel = new Panel();
            datePanel = new Panel();
            timeTxtBox = new Label();
            iconImageBox = new PictureBox();
            mainPanel = new Panel();
            tabControl.SuspendLayout();
            homeTab.SuspendLayout();
            subjectTab.SuspendLayout();
            activitiesTab.SuspendLayout();
            reviewersTab.SuspendLayout();
            settingsTab.SuspendLayout();
            topPanel.SuspendLayout();
            datePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)iconImageBox).BeginInit();
            mainPanel.SuspendLayout();
            SuspendLayout();
            // 
            // drawerControl
            // 
            drawerControl.AutoShow = true;
            drawerControl.BackColor = Color.FromArgb(65, 78, 101);
            drawerControl.BigLogo = Properties.Resources.Screenshot_2024_11_13_231616_removebg_preview;
            drawerControl.BigLogoBounds = new Rectangle(69, 5, 186, 69);
            drawerControl.BigLogoDockStyle = DockStyle.None;
            drawerControl.DisplayImage = true;
            drawerControl.Image = Properties.Resources.user;
            drawerControl.ImageSize = new Size(200, 100);
            drawerControl.ImageSizeMode = PictureBoxSizeMode.Zoom;
            drawerControl.IsOpen = true;
            drawerControl.LabelText = "Drawer";
            drawerControl.LogoPanelBackColor = Color.FromArgb(43, 49, 65);
            drawerControl.LogoPanelHeight = 69;
            drawerControl.LogoutImage = Properties.Resources.logout_white;
            drawerControl.ShowIconsWhenHidden = true;
            drawerControl.SmallLogo = Properties.Resources.Logo_nobg;
            drawerControl.UseBackColor = true;
            drawerControl.UseColors = true;
            // 
            // tabControl
            // 
            tabControl.Controls.Add(homeTab);
            tabControl.Controls.Add(subjectTab);
            tabControl.Controls.Add(activitiesTab);
            tabControl.Controls.Add(reviewersTab);
            tabControl.Controls.Add(settingsTab);
            tabControl.Depth = 0;
            tabControl.Dock = DockStyle.Fill;
            tabControl.ImageList = logoImages;
            tabControl.Location = new Point(0, 0);
            tabControl.MouseState = MaterialSkin.MouseState.HOVER;
            tabControl.Multiline = true;
            tabControl.Name = "tabControl";
            tabControl.SelectedIndex = 0;
            tabControl.Size = new Size(1278, 626);
            tabControl.TabIndex = 0;
            tabControl.SelectedIndexChanged += tabControl_SelectedIndexChanged;
            // 
            // homeTab
            // 
            homeTab.BackColor = Color.White;
            homeTab.Controls.Add(homePanel);
            homeTab.ImageKey = "home.png";
            homeTab.Location = new Point(4, 71);
            homeTab.Name = "homeTab";
            homeTab.Padding = new Padding(3);
            homeTab.Size = new Size(1270, 551);
            homeTab.TabIndex = 0;
            homeTab.Text = "Home";
            // 
            // homePanel
            // 
            homePanel.Dock = DockStyle.Fill;
            homePanel.Location = new Point(3, 3);
            homePanel.Margin = new Padding(5, 3, 5, 3);
            homePanel.Name = "homePanel";
            homePanel.Size = new Size(1264, 545);
            homePanel.TabIndex = 0;
            // 
            // subjectTab
            // 
            subjectTab.BackColor = Color.White;
            subjectTab.Controls.Add(subjectsPanel);
            subjectTab.ImageKey = "subjects-white.png";
            subjectTab.Location = new Point(4, 71);
            subjectTab.Name = "subjectTab";
            subjectTab.Padding = new Padding(3);
            subjectTab.Size = new Size(1270, 551);
            subjectTab.TabIndex = 1;
            subjectTab.Text = "Subjects";
            // 
            // subjectsPanel
            // 
            subjectsPanel.Dock = DockStyle.Fill;
            subjectsPanel.Location = new Point(3, 3);
            subjectsPanel.Margin = new Padding(5, 3, 5, 3);
            subjectsPanel.Name = "subjectsPanel";
            subjectsPanel.Size = new Size(1264, 545);
            subjectsPanel.TabIndex = 0;
            // 
            // activitiesTab
            // 
            activitiesTab.BackColor = Color.White;
            activitiesTab.Controls.Add(activitiesPanel);
            activitiesTab.ImageKey = "activities.png";
            activitiesTab.Location = new Point(4, 71);
            activitiesTab.Name = "activitiesTab";
            activitiesTab.Size = new Size(1270, 551);
            activitiesTab.TabIndex = 2;
            activitiesTab.Text = "Activities";
            // 
            // activitiesPanel
            // 
            activitiesPanel.Dock = DockStyle.Fill;
            activitiesPanel.Location = new Point(0, 0);
            activitiesPanel.Margin = new Padding(5, 3, 5, 3);
            activitiesPanel.Name = "activitiesPanel";
            activitiesPanel.Size = new Size(1270, 551);
            activitiesPanel.TabIndex = 0;
            // 
            // reviewersTab
            // 
            reviewersTab.BackColor = Color.White;
            reviewersTab.Controls.Add(reviewerPanel);
            reviewersTab.ImageKey = "reviewer.png";
            reviewersTab.Location = new Point(4, 71);
            reviewersTab.Name = "reviewersTab";
            reviewersTab.Size = new Size(1270, 551);
            reviewersTab.TabIndex = 3;
            reviewersTab.Text = "Reviewers";
            // 
            // reviewerPanel
            // 
            reviewerPanel.Dock = DockStyle.Fill;
            reviewerPanel.Location = new Point(0, 0);
            reviewerPanel.Margin = new Padding(5, 3, 5, 3);
            reviewerPanel.Name = "reviewerPanel";
            reviewerPanel.Size = new Size(1270, 551);
            reviewerPanel.TabIndex = 0;
            // 
            // settingsTab
            // 
            settingsTab.BackColor = Color.White;
            settingsTab.Controls.Add(settingsPanel);
            settingsTab.ImageKey = "settings.png";
            settingsTab.Location = new Point(4, 71);
            settingsTab.Name = "settingsTab";
            settingsTab.Size = new Size(1270, 551);
            settingsTab.TabIndex = 4;
            settingsTab.Text = "Settings";
            // 
            // settingsPanel
            // 
            settingsPanel.Dock = DockStyle.Fill;
            settingsPanel.Location = new Point(0, 0);
            settingsPanel.Margin = new Padding(5, 3, 5, 3);
            settingsPanel.Name = "settingsPanel";
            settingsPanel.Size = new Size(1270, 551);
            settingsPanel.TabIndex = 0;
            // 
            // logoImages
            // 
            logoImages.ColorDepth = ColorDepth.Depth32Bit;
            logoImages.ImageStream = (ImageListStreamer)resources.GetObject("logoImages.ImageStream");
            logoImages.TransparentColor = Color.Transparent;
            logoImages.Images.SetKeyName(0, "home.png");
            logoImages.Images.SetKeyName(1, "reviewer.png");
            logoImages.Images.SetKeyName(2, "settings.png");
            logoImages.Images.SetKeyName(3, "subjects-white.png");
            logoImages.Images.SetKeyName(4, "activities.png");
            // 
            // timeKeeper
            // 
            timeKeeper.Interval = 1000;
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
            topPanel.TabIndex = 5;
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
            // mainPanel
            // 
            mainPanel.Controls.Add(tabControl);
            mainPanel.Dock = DockStyle.Fill;
            mainPanel.Location = new Point(1, 93);
            mainPanel.Margin = new Padding(4, 3, 4, 3);
            mainPanel.Name = "mainPanel";
            mainPanel.Size = new Size(1278, 626);
            mainPanel.TabIndex = 7;
            // 
            // AdminPage
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BigLogo = Properties.Resources.Screenshot_2024_11_13_231616_removebg_preview;
            BigLogoBounds = new Rectangle(69, 5, 186, 69);
            BigLogoDockStyle = DockStyle.None;
            ClientSize = new Size(1280, 720);
            Controls.Add(mainPanel);
            Controls.Add(topPanel);
            DisplayImage = true;
            DrawerAutoShow = true;
            DrawerBackColor = Color.FromArgb(65, 78, 101);
            DrawerImage = Properties.Resources.user;
            DrawerImageSize = new Size(200, 100);
            DrawerImageSizeMode = PictureBoxSizeMode.Zoom;
            DrawerIsOpen = true;
            DrawerLabelText = "Drawer";
            DrawerShowIconsWhenHidden = true;
            DrawerTabControl = tabControl;
            DrawerUseColors = true;
            DrawerWidth = 250;
            FormStyle = FormStyles.ActionBar_None;
            LogoPanelBackColor = Color.FromArgb(43, 49, 65);
            LogoPanelHeight = 69;
            LogoutImage = Properties.Resources.logout_white;
            Name = "AdminPage";
            Padding = new Padding(1, 24, 1, 1);
            SmallLogo = Properties.Resources.Logo_nobg;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "AdminPage";
            DrawerUseBackColor = true;
            tabControl.ResumeLayout(false);
            homeTab.ResumeLayout(false);
            subjectTab.ResumeLayout(false);
            activitiesTab.ResumeLayout(false);
            reviewersTab.ResumeLayout(false);
            settingsTab.ResumeLayout(false);
            topPanel.ResumeLayout(false);
            datePanel.ResumeLayout(false);
            datePanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)iconImageBox).EndInit();
            mainPanel.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MaterialSkin.Controls.MaterialTabControl tabControl;
        private TabPage homeTab;
        private TabPage subjectTab;
        private TabPage activitiesTab;
        private TabPage reviewersTab;
        private TabPage settingsTab;
        private System.Windows.Forms.Timer timeKeeper;
        private Panel topPanel;
        private Panel datePanel;
        private Label timeTxtBox;
        private PictureBox iconImageBox;
        protected Panel mainPanel;
        private HomePanel homePanel;
        private SubjectsPanel subjectsPanel;
        private ActivitiesPanel activitiesPanel;
        private ReviewerPanel reviewerPanel;
        private SettingsPanel settingsPanel;
        private ImageList logoImages;
    }
}