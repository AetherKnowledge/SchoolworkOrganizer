using SchoolworkOrganizer.Design;
using SchoolworkOrganizer.Popup;
using SchoolworkOrganizerUtils;

namespace SchoolworkOrganizer.Panels
{
    public partial class SettingsPanel : Template2
    {
        public SettingsPanel()
        {
            InitializeComponent();
        }

        public override void RefreshData()
        {
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
                    PopupForm.Show("Please login to update user", "Error");
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
                    PopupForm.Show("Please Enter a password", "Error");
                    return;
                }
                if (password != verifyPass)
                {
                    PopupForm.Show("Password does not match", "Error");
                    return;
                }

                User user = new User(email, username, password, Utilities.ConvertToSKImage(uploadPicture.Image));
                bool success = await Program.user.UpdateUser(user);
                if (success) PopupForm.Show("User updated successfully", "Success");
                PopupForm.Show("User update failed", "Error");
                RefreshUser();
            }
            catch (Exception ex)
            {
                PopupForm.Show(ex.Message, "Error");
                if (Program.user == null) return;

            }
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            RefreshUser();
        }

        protected void RefreshUser()
        {
            if (Program.user == null) return;

            usernameTxt.Text = Program.user.Username;
            emailTxt.Text = Program.user.Email;
            if (uploadPicture.Image != Program.user.WinformImage) uploadPicture.Image = Program.user.WinformImage ?? Properties.Resources.user; ;
        }
    }

}



