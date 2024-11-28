using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SchoolworkOrganizerV2.Panels
{
    public partial class Template : MaterialForm
    {
        protected OleDbConnection conn;
        public static Point location = new Point(0,0);
        public static Size size = new Size(946, 519);
        public static FormWindowState windowState = FormWindowState.Normal;

        public Template()
        {
            InitializeComponent();
            timeKeeper.Interval = 1000;
            timeKeeper.Tick += Timer1_Tick;
            timeKeeper.Start();
            this.FormClosing += MyFormClosing;

            Utilities.ChangeButtonColors(homeBtn);

        }

        public static void MyFormClosing(object sender, FormClosingEventArgs e)
        {
            var result = MessageBox.Show("Are you sure you want to exit?", "Confirm Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.No)
            {
                e.Cancel = true;
            }
            else
            {
                OpenPanels.loginPage.Close();
            }

        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            timeTxtBox.Text = DateTime.Now.ToString("MMMM dd, yyyy hh:mm:ss tt");
        }

        //hide panels before showing it first to save location and size
        public new void Show()
        {
            base.Show();

            if (LoginPanel.currentUser == null) return;
            
            this.Size = size;
            this.Location = location;
            this.WindowState = windowState;
            

            RefreshUser();
        }

        public new void Hide()
        {
            size = this.Size;
            location = this.Location;
            windowState = this.WindowState;

            base.Hide();
        }

        protected void RefreshUser()
        {
            usernameLabel.Text = LoginPanel.currentUser.Username;
            userImageBox.Image = LoginPanel.currentUser.UserImage;
        }

        public void homeBtn_Click(object sender, EventArgs e)
        {
            if (this == OpenPanels.homePanel) return;
            this.Hide();
            OpenPanels.homePanel.Show();
        }

        public void activityBtn_Click(object sender, EventArgs e)
        {
            if (this == OpenPanels.activitiesPanel) return;
            this.Hide();
            OpenPanels.activitiesPanel.Show();
        }

        public void settingsBtn_Click(object sender, EventArgs e)
        {
            if (this == OpenPanels.settingsPanel) return;
            this.Hide();
            OpenPanels.settingsPanel.Show();
        }

        private void reviewerBtn_Click(object sender, EventArgs e)
        {
            if (this == OpenPanels.reviewerPanel) return;
            this.Hide();
            OpenPanels.reviewerPanel.Show();
        }

        private void subjectsBtn_Click(object sender, EventArgs e)
        {
            if (this == OpenPanels.subjectsPanel) return;
            this.Hide();
            OpenPanels.subjectsPanel.Show();
        }

        public void logoutBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            OpenPanels.loginPage.Show();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            Color borderColor = Color.Black; // Change to your preferred color
            int borderThickness = 2;

            // Draw the border
            using (Pen pen = new Pen(borderColor, borderThickness))
            {
                Rectangle rect = new Rectangle(0, 0, this.ClientSize.Width, this.ClientSize.Height);
                e.Graphics.DrawRectangle(pen, rect);
            }
        }



    }
}
