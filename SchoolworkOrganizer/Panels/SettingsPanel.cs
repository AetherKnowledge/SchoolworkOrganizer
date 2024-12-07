﻿using SchoolworkOrganizer.Design;
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

        private void updateBtn_Click(object sender, EventArgs e)
        {

            string previousUsername = User.currentUser.Username;
            string username = usernameTxt.Text;
            string email = emailTxt.Text;  
            string password = passwordTxt.Text;
            string verifyPass = verifyTxt.Text;

            //if (User.currentUser.Username != username && User.DoesUserExist(username))
            //{
            //    MessageBox.Show("User already exists", "Error");
            //    return;
            //}

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

            
            User.currentUser.Username = username;
            User.currentUser.Email = email;
            User.currentUser.Password = password;
            User.currentUser.UserImage = uploadPicture.Image != Properties.Resources.user ? Utilities.ConvertToSKImage(uploadPicture.Image) : null;
            Client.UpdateUser(previousUsername, User.currentUser);

            RefreshUser();
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            RefreshUser();
        }

        protected new void RefreshUser()
        {
            base.RefreshUser();
            if (User.currentUser == null) return;

            usernameTxt.Text = User.currentUser.Username;
            emailTxt.Text = User.currentUser.Email;
            if (uploadPicture.Image != User.currentUser.WinformImage) uploadPicture.Image = User.currentUser.WinformImage ?? Properties.Resources.user; ;
        }
    }

}


