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
            tabControl = new MaterialSkin.Controls.MaterialTabControl();
            homeTab = new TabPage();
            subjectTab = new TabPage();
            activitiesTab = new TabPage();
            reviewersTab = new TabPage();
            settingsTab = new TabPage();
            materialDrawer1 = new MaterialSkin.Controls.MaterialDrawer();
            mainPanel.SuspendLayout();
            tabControl.SuspendLayout();
            SuspendLayout();
            // 
            // mainPanel
            // 
            mainPanel.Controls.Add(tabControl);
            mainPanel.Controls.Add(materialDrawer1);
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
            tabControl.Location = new Point(168, 0);
            tabControl.MouseState = MaterialSkin.MouseState.HOVER;
            tabControl.Multiline = true;
            tabControl.Name = "tabControl";
            tabControl.SelectedIndex = 0;
            tabControl.Size = new Size(921, 626);
            tabControl.TabIndex = 0;
            // 
            // homeTab
            // 
            homeTab.BackColor = SystemColors.Control;
            homeTab.Location = new Point(4, 24);
            homeTab.Name = "homeTab";
            homeTab.Padding = new Padding(3);
            homeTab.Size = new Size(913, 598);
            homeTab.TabIndex = 0;
            homeTab.Text = "Home";
            // 
            // subjectTab
            // 
            subjectTab.Location = new Point(4, 24);
            subjectTab.Name = "subjectTab";
            subjectTab.Padding = new Padding(3);
            subjectTab.Size = new Size(913, 598);
            subjectTab.TabIndex = 1;
            subjectTab.Text = "Subjects";
            subjectTab.UseVisualStyleBackColor = true;
            // 
            // activitiesTab
            // 
            activitiesTab.Location = new Point(4, 24);
            activitiesTab.Name = "activitiesTab";
            activitiesTab.Size = new Size(913, 598);
            activitiesTab.TabIndex = 2;
            activitiesTab.Text = "activities";
            activitiesTab.UseVisualStyleBackColor = true;
            // 
            // reviewersTab
            // 
            reviewersTab.Location = new Point(4, 24);
            reviewersTab.Name = "reviewersTab";
            reviewersTab.Size = new Size(913, 598);
            reviewersTab.TabIndex = 3;
            reviewersTab.Text = "Reviewers";
            reviewersTab.UseVisualStyleBackColor = true;
            // 
            // settingsTab
            // 
            settingsTab.Location = new Point(4, 24);
            settingsTab.Name = "settingsTab";
            settingsTab.Size = new Size(913, 598);
            settingsTab.TabIndex = 4;
            settingsTab.Text = "Settings";
            settingsTab.UseVisualStyleBackColor = true;
            // 
            // materialDrawer1
            // 
            materialDrawer1.AutoHide = false;
            materialDrawer1.AutoShow = false;
            materialDrawer1.BackgroundWithAccent = false;
            materialDrawer1.BaseTabControl = tabControl;
            materialDrawer1.Depth = 0;
            materialDrawer1.Dock = DockStyle.Left;
            materialDrawer1.HighlightWithAccent = true;
            materialDrawer1.IndicatorWidth = 0;
            materialDrawer1.IsOpen = true;
            materialDrawer1.Location = new Point(0, 0);
            materialDrawer1.MouseState = MaterialSkin.MouseState.HOVER;
            materialDrawer1.Name = "materialDrawer1";
            materialDrawer1.ShowIconsWhenHidden = true;
            materialDrawer1.Size = new Size(168, 626);
            materialDrawer1.TabIndex = 0;
            materialDrawer1.Text = " ";
            materialDrawer1.UseColors = true;
            // 
            // AdminPage
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1280, 720);
            DrawerAutoShow = true;
            DrawerIsOpen = true;
            DrawerShowIconsWhenHidden = true;
            DrawerUseColors = true;
            Name = "AdminPage";
            Text = "AdminPage";
            mainPanel.ResumeLayout(false);
            tabControl.ResumeLayout(false);
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
        private MaterialSkin.Controls.MaterialDrawer materialDrawer1;
    }
}