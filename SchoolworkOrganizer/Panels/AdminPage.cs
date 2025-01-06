using MaterialSkin.Controls;
using SchoolworkOrganizer.Popup;

namespace SchoolworkOrganizer.Panels
{
    public partial class AdminPage : MaterialForm
    {
        public AdminPage()
        {
            InitializeComponent();

            timeKeeper.Interval = 1000;
            timeKeeper.Tick += Timer1_Tick;
            timeKeeper.Start();
            this.FormClosing += MyFormClosing;
            drawerControl.LogoutImageClick += logoutBtn_Click;

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

            this.Size = OpenPanels.size;
            this.Location = OpenPanels.location;
            this.WindowState = OpenPanels.windowState;

            RefreshUser();
        }

        public new void Hide()
        {
            OpenPanels.size = this.Size;
            OpenPanels.location = this.Location;
            OpenPanels.windowState = this.WindowState;

            base.Hide();
        }

        protected void RefreshUser()
        {
            if (Program.user == null) return;

            DrawerLabelText = Program.user.Username;
            if (DrawerImage != Program.user.WinformImage) DrawerImage = Program.user.WinformImage ?? Properties.Resources.user;
        }

        public void logoutBtn_Click(object? sender, EventArgs e)
        {
            this.Hide();
            OpenPanels.loginPage.Show();
            OpenPanels.loginPage.Focus();
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

        private void tabControl_SelectedIndexChanged(object? sender, EventArgs e)
        {
            if (tabControl.SelectedTab == null) return;
            if (tabControl.SelectedTab.Controls.Count == 0) return;
            if (tabControl.SelectedTab.Controls[0] is not Template) return;

            Template tabPage = (Template)tabControl.SelectedTab.Controls[0];
            tabPage.RefreshData();
            RefreshUser();
        }
    }
}
