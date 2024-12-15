using MaterialSkin.Controls;
using SchoolworkOrganizer.Design;
using SchoolworkOrganizer.Panels;
using SchoolworkOrganizer.Popup;
using SchoolworkOrganizer.Popups;
using SchoolworkOrganizerUtils;
using System;
using System.Windows.Forms;
using Timer = System.Windows.Forms.Timer;


namespace SchoolworkOrganizer
{
    public partial class LoginPanel : MaterialForm
    {
        private Timer animationTimer = new Timer();
        float animationProgress = 0;
        bool login = true;

        public LoginPanel()
        {
            InitializeComponent();
            FormUtilities.InitializeTextBoxWithPlaceholder(loginTxtUsername);
            FormUtilities.InitializeTextBoxWithPlaceholder(loginTxtPassword);

            this.FormClosing += MyFormClosing;

            this.Size = OpenPanels.size;
            this.Location = OpenPanels.location;
            this.WindowState = OpenPanels.windowState;

            OpenPanels.loginPage = this;
            animationTimer.Interval = 8; // ~60 FPS
            animationTimer.Tick += AnimationTimer_Tick;
        }

        public new void Show()
        {
            base.Show();
            Program.Logout();
            this.Size = OpenPanels.size;
            this.Location = OpenPanels.location;
            this.WindowState = OpenPanels.windowState;


        }

        public new void Hide()
        {
            OpenPanels.size = this.Size;
            OpenPanels.location = this.Location;
            OpenPanels.windowState = this.WindowState;
            base.Hide();
        }

        private void AnimationTimer_Tick(object? sender, EventArgs e)
        {
            // Adjust hover progress gradually
            float target = login ? 0 : 1;

            animationProgress += (target - animationProgress) * 0.1f; // Smooth transition

            if (Math.Abs(target - animationProgress) < 0.00001f)
            {
                animationProgress = target;
                animationTimer.Stop();
            }

            int panelGap = 4;
            int min = panelGap / 2;
            int max = Width - mainPanel.Width - (panelGap * 2);
            int progress = min + (int)(animationProgress * (Width - mainPanel.Width - (min * 2)));

            //prevents stutter at the end
            progress = Math.Max(panelGap, progress);
            progress = Math.Min(max, progress);

            int mainPanelX = progress;
            int topPanelX = (-mainPanel.Width - 5) + (int)(animationProgress * ((mainPanel.Width + 5) * 2));

            mainPanel.Location = new Point(mainPanelX, mainPanel.Location.Y);
            loginImagePanel.Location = new Point(mainPanel.Right + 7, loginImagePanel.Location.Y);
            topPanel.Location = new Point(topPanelX, topPanel.Location.Y);

            if (login)
            {
                if (animationProgress < 0.5 && topLabel.Text != "Login") topLabel.Text = "Login";
            }
            else
            {
                if (animationProgress > 0.5 && topLabel.Text != "Register") topLabel.Text = "Register";

            }

            Invalidate();
        }

        public static void MyFormClosing(object? sender, FormClosingEventArgs e)
        {
            Program.client.Disconnect();
        }
        private void showPassword_CheckedChanged(object sender, EventArgs e)
        {
            if (loginShowPassword.Checked)
            {
                loginTxtPassword.UseSystemPasswordChar = false;
                loginShowPassword.ImageIndex = 1;
            }
            else
            {
                loginTxtPassword.UseSystemPasswordChar = true;
                loginShowPassword.ImageIndex = 0;
            }
        }

        private void labelForgotPassword_Click(object sender, EventArgs e)
        {
            this.Hide();
            ForgotPassword forgotPassword = new ForgotPassword();
            forgotPassword.Show();

        }

        private void switchLabel_Click(object sender, EventArgs e)
        {
            //this.Hide();
            //OpenPanels.registerPage.Show();
            //Clear();
            login = !login;
            animationTimer.Start();

            if (login)
            {
                loginSwitchLabel.Text = "Don't Have an Account?";
                loginLabelForgotPassword.Location = new Point(loginSwitchLabel.Right - loginLabelForgotPassword.Width, loginLabelForgotPassword.Location.Y);
                loginBtn.Text = "Login";
            }
            else
            {
                loginSwitchLabel.Text = "Already have an Account?";
                loginLabelForgotPassword.Location = new Point(loginSwitchLabel.Right - loginLabelForgotPassword.Width, loginLabelForgotPassword.Location.Y);
                loginBtn.Text = "Register";
            }
        }

        private void Clear()
        {
            loginTxtUsername.Text = "";
            loginTxtPassword.Text = "";
        }

        private void testBtn_Click(object sender, EventArgs e)
        {
            OpenPanels.adminPage.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //foreach (User user in User.Users)
            //{
            //    user.AddToDatabase();
            //}
        }

        private async void loginBtn_Click(object sender, EventArgs e)
        {
            string username = loginTxtUsername.Text;
            string password = loginTxtPassword.Text;

            if (username == "Username" || password == "Password")
            {
                PopupForm.Show("Please enter valid credentials", "Error");
                return;
            }

            Cursor.Current = Cursors.WaitCursor;
            bool loginSuccess = await Program.client.Login(username, password);
            Cursor.Current = Cursors.Default;

            if (!loginSuccess)
            {
                PopupForm.Show("Invalid Credentials", "Error");
                return;
            }

            this.Hide();
            OpenPanels.adminPage.Show();
            Clear();
        }
    }
}
