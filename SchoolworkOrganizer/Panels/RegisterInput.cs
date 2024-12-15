using SchoolworkOrganizer.Design;
using SchoolworkOrganizer.Popup;
using SchoolworkOrganizer.Popups;
using SchoolworkOrganizerUtils;
using SkiaSharp;

namespace SchoolworkOrganizer.Panels
{
    public partial class RegisterInput : UserControl
    {
        public event EventHandler? Switch;
        private Image hidePassImage;
        private Image showPassImage;
        public RegisterInput()
        {
            InitializeComponent();
            FormUtilities.InitializeTextBoxWithPlaceholder(txtEmail);
            FormUtilities.InitializeTextBoxWithPlaceholder(txtUsername);
            FormUtilities.InitializeTextBoxWithPlaceholder(txtPassword);
            FormUtilities.InitializeTextBoxWithPlaceholder(txtVerify);

            hidePassImage = FormUtilities.ResizeImage(Properties.Resources.eye, 32, 32);
            showPassImage = FormUtilities.ResizeImage(Properties.Resources.view, 32, 32);

            showPassword.Image = hidePassImage;
        }

        private void showPassword_CheckedChanged(object? sender, EventArgs e)
        {
            if (showPassword.Checked)
            {
                txtPassword.UseSystemPasswordChar = false;
                txtVerify.UseSystemPasswordChar = false;
                showPassword.Image = showPassImage;
            }
            else
            {
                txtPassword.UseSystemPasswordChar = true;
                txtVerify.UseSystemPasswordChar = true;
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
            txtEmail.Text = "";
            txtUsername.Text = "";
            txtPassword.Text = "";
            txtVerify.Text = "";
            showPassword.Checked = false;
            showPassword_CheckedChanged(null, EventArgs.Empty);
        }

        private void switchLabel_Click(object sender, EventArgs e)
        {
            Switch?.Invoke(this, EventArgs.Empty);
        }

        private async void registerBtn_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text;
            string username = txtUsername.Text;
            string password = txtPassword.Text;
            string verifyPass = txtVerify.Text;
            SKImage? userImage = null;

            if (password != verifyPass)
            {
                PopupForm.Show("Password does not match", "Error");
                return;
            }

            User user = new User(email, username, password, userImage);
            bool registerSuccess = await Program.client.Register(user);
            if (!registerSuccess)
            {
                PopupForm.Show("User already exists", "Error");
                return;
            }

            PopupForm.Show("Register Successful", "Success");
            Clear();
        }

    }
}
