using MaterialSkin.Controls;
using SchoolworkOrganizer.Design;
using SchoolworkOrganizer.Popup;
using SchoolworkOrganizerUtils;

namespace SchoolworkOrganizer.Panels
{
    public partial class Template : MaterialForm
    {
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

            FormUtilities.ChangeButtonColors(homeBtn);

        }

        public static void MyFormClosing(object? sender, FormClosingEventArgs e)
        {
            var result = PopupForm.Show("Are you sure you want to exit?", "Confirm Exit", MessageBoxButtons.YesNo);

            if (result == DialogResult.No)
            {
                e.Cancel = true;
            }
            else
            {
                OpenPanels.loginPage.Close();
            }

        }

        private void Timer1_Tick(object? sender, EventArgs e)
        {
            timeTxtBox.Text = DateTime.Now.ToString("MMMM dd, yyyy hh:mm:ss tt");
        }

        //hide panels before showing it first to save location and size
        public new void Show()
        {
            base.Show();

            if (Program.user == null) return;
            
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
            if (Program.user == null) return;

            usernameLabel.Text = Program.user.Username;
            if (userImageBox.Image != Program.user.WinformImage) userImageBox.Image = Program.user.WinformImage ?? Properties.Resources.user;
        }

        public void homeBtn_Click(object sender, EventArgs e)
        {
            //if (this == OpenPanels.homePanel) return;
            //this.Hide();
            //OpenPanels.homePanel.Show();
        }

        public void activityBtn_Click(object sender, EventArgs e)
        {
            //if (this == OpenPanels.activitiesPanel) return;
            //this.Hide();
            //OpenPanels.activitiesPanel.Show();
        }

        public void settingsBtn_Click(object sender, EventArgs e)
        {
            //if (this == OpenPanels.settingsPanel) return;
            //this.Hide();
            //OpenPanels.settingsPanel.Show();
        }

        private void reviewerBtn_Click(object sender, EventArgs e)
        {
            //if (this == OpenPanels.reviewerPanel) return;
            //this.Hide();
            //OpenPanels.reviewerPanel.Show();
        }

        private void subjectsBtn_Click(object sender, EventArgs e)
        {
            //if (this == OpenPanels.subjectsPanel) return;
            //this.Hide();
            //OpenPanels.subjectsPanel.Show();
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
