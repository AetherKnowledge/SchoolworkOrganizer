using SchoolworkOrganizer.Design;
using SchoolworkOrganizer.Popup;
using SchoolworkOrganizer.Popups;

namespace SchoolworkOrganizer.Panels
{
    public partial class LoginInput : UserControl
    {
        public event EventHandler? Switch;
        private Image hidePassImage;
        private Image showPassImage;
        public LoginInput()
        {
            InitializeComponent();
            FormUtilities.InitializeTextBoxWithPlaceholder(txtUsername);
            FormUtilities.InitializeTextBoxWithPlaceholder(txtPassword);

            hidePassImage = FormUtilities.ResizeImage(Properties.Resources.eye, 32, 32);
            showPassImage = FormUtilities.ResizeImage(Properties.Resources.view, 32, 32);

            showPassword.Image = hidePassImage;
        }

        private void showPassword_CheckedChanged(object? sender, EventArgs e)
        {
            if (showPassword.Checked)
            {
                txtPassword.UseSystemPasswordChar = false;
                showPassword.Image = showPassImage;
            }
            else
            {
                txtPassword.UseSystemPasswordChar = true;
                showPassword.Image = hidePassImage;
            }
        }

        private void forgotPassword_Click(object sender, EventArgs e)
        {
            this.Hide();
            ForgotPassword forgotPassword = new ForgotPassword();
            forgotPassword.Show();

        }

        public void Clear()
        {
            txtUsername.Text = "";
            txtPassword.Text = "";
            showPassword.CheckState = CheckState.Unchecked;
            showPassword_CheckedChanged(null, EventArgs.Empty);
        }

        private async void loginBtn_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;

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

            OpenPanels.loginPage.Hide();
            OpenPanels.adminPage.Show();
            Clear();
        }

        private void switchLabel_Click(object sender, EventArgs e)
        {
            Switch?.Invoke(this, EventArgs.Empty);
        }
    }
}
