using SchoolworkOrganizer.Design;
using SchoolworkOrganizerUtils;

namespace SchoolworkOrganizer.Panels
{
    public partial class SettingsPanel : Template
    {
        public SettingsPanel()
        {
            InitializeComponent();
        }

        public new void Show()
        {
            base.Show();
            RefreshUser();
        }

        private void upload_button_Click(object sender, EventArgs e)
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

        private async void updateBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (Program.client == null)
                {
                    MessageBox.Show("Please login to update user", "Error");
                    return;
                }

                if (Program.user == null) return;
                string previousUsername = Program.user.Username;
                string username = usernameTxt.Text;
                string email = emailTxt.Text;
                string password = passwordTxt.Text;
                string verifyPass = verifyTxt.Text;

                if (password == "" || password == "Password")
                {
                    MessageBox.Show("Please Enter a password", "Error");
                    return;
                }
                if (password != verifyPass)
                {
                    MessageBox.Show("Password does not match", "Error");
                    return;
                }

                User user = new User(email, username, password, Utilities.ConvertToSKImage(uploadPicture.Image));
                bool success = await Program.user.UpdateUser(user);
                if (success) MessageBox.Show("User updated successfully", "Success");
                MessageBox.Show("User update failed", "Error");
                RefreshUser();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
                if (Program.user == null) return;

            }
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            RefreshUser();
        }

        protected new void RefreshUser()
        {
            base.RefreshUser();
            if (Program.user == null) return;

            usernameTxt.Text = Program.user.Username;
            emailTxt.Text = Program.user.Email;
            if (uploadPicture.Image != Program.user.WinformImage) uploadPicture.Image = Program.user.WinformImage ?? Properties.Resources.user; ;
        }
    }

}



