using SchoolworkOrganizer.Panels;
using SchoolworkOrganizerUtils;
using SchoolworkOrganizer.Design;
using SkiaSharp;
using SchoolworkOrganizer.Popup;

namespace SchoolworkOrganizer
{
    public partial class RegisterPanel : Form
    {
        public RegisterPanel()
        {
            InitializeComponent();

            FormUtilities.InitializeTextBoxWithPlaceholder(txtEmail);
            FormUtilities.InitializeTextBoxWithPlaceholder(txtUsername);
            FormUtilities.InitializeTextBoxWithPlaceholder(txtPassword);
            FormUtilities.InitializeTextBoxWithPlaceholder(txtVerify);
            this.FormClosing += Template.MyFormClosing;

            this.Size = OpenPanels.size;
            this.Location = OpenPanels.location;
            this.WindowState = OpenPanels.windowState;
        }

        public new void Show()
        {
            base.Show();
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

        private void uploadBtn_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp"
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                uploadPicture.Image = new Bitmap(openFileDialog.FileName);
            }
        }

        private async void RegisterBtn_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text;
            string username = txtUsername.Text;
            string password = txtPassword.Text;
            string verifyPass = txtVerify.Text;
            SKImage? userImage = uploadPicture.Image == Properties.Resources.user ? Utilities.ConvertToSKImage(uploadPicture.Image) : null;

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
            this.Hide();
            OpenPanels.loginPage.Show();
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

        private void LoginLabel_Click(object sender, EventArgs e)
        {
            this.Hide();
            OpenPanels.loginPage.Show();
            
            Clear();
        }

        private void Clear()
        {
            txtEmail.Text = "";
            txtUsername.Text = "";
            txtPassword.Text = "";
            uploadPicture.Image = null;
        }

        private void showPassVerify_CheckedChanged(object sender, EventArgs e)
        {
            if (showPassVerify.Checked)
            {
                txtVerify.UseSystemPasswordChar = false;
            }
            else
            {
                txtVerify.UseSystemPasswordChar = true;
            }
        }
    }
}
