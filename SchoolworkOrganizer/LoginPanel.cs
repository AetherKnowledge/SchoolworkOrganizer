using SchoolworkOrganizer.Design;
using SchoolworkOrganizer.Panels;
using SchoolworkOrganizer.Popups;
using SchoolworkOrganizerUtils;


namespace SchoolworkOrganizer
{
    public partial class LoginPanel : Form
    {

        public LoginPanel()
        {
            InitializeComponent();
            FormUtilities.InitializeTextBoxWithPlaceholder(txtUsername);
            FormUtilities.InitializeTextBoxWithPlaceholder(txtPassword);

            this.FormClosing += MyFormClosing;

            OpenPanels.loginPage = this;
        }

        public new void Show()
        {
            base.Show();
            Program.Logout();
            this.Size = Template.size;
            this.Location = Template.location;
            this.WindowState = Template.windowState;
        }

        public new void Hide()
        {
            Template.size = this.Size;
            Template.location = this.Location;
            Template.windowState = this.WindowState;
            base.Hide();
        }

        public static void MyFormClosing(object? sender, FormClosingEventArgs e)
        {
            Program.client.Disconnect();
        }

        private async void ButtonLogIn_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;

            if (username == "Username" || password == "Password")
            {
                MessageBox.Show("Please enter valid credentials", "Error");
                return;
            }

            bool loginSuccess = await Program.client.Login(username, password);

            if (!loginSuccess)
            {
                MessageBox.Show("Invalid Credentials", "Error");
                return;
            }

            this.Hide();
            OpenPanels.homePanel.Show();
            Clear();

        }
        private void showPassword_CheckedChanged(object sender, EventArgs e)
        {
            if (showPassword.Checked)
            {
                txtPassword.UseSystemPasswordChar = false;
            }
            else
            {
                txtPassword.UseSystemPasswordChar = true;
            }
        }

        private void labelForgotPassword_Click(object sender, EventArgs e)
        {
            this.Hide();
            ForgotPassword forgotPassword = new ForgotPassword();
            forgotPassword.Show();

        }

        private void registerLabel_Click(object sender, EventArgs e)
        {
            this.Hide();
            OpenPanels.registerPage.Show();
            Clear();
        }

        private void Clear()
        {
            txtUsername.Text = "";
            txtPassword.Text = "";
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
    }
}
