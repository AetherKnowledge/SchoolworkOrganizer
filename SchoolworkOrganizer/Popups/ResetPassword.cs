using SchoolworkOrganizer.Panels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using SchoolworkOrganizer.Design;
using SchoolworkOrganizer.Popup;

namespace SchoolworkOrganizer.Popups
{
    public partial class ResetPassword : Form
    {
        private readonly string Email;
        

        public ResetPassword(string Email)
        {
            this.Email = Email;
            InitializeComponent();
            FormUtilities.InitializeTextBoxWithPlaceholder(newPasswordTxtBox);
            FormUtilities.InitializeTextBoxWithPlaceholder(verifyPasswordTxtBox);
            this.FormClosing += MyFormClosing;
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

        public void MyFormClosing(object sender, FormClosingEventArgs e)
        {
            OpenPanels.loginPage.Show();
        }

        private void changePasswordBtn_Click(object sender, EventArgs e)
        {
            if(newPasswordTxtBox.Text == "New Password" || newPasswordTxtBox.Text != verifyPasswordTxtBox.Text)
            {
                PopupForm.Show("Password not the same", "Error");
                return;
            }

            string newPassword = newPasswordTxtBox.Text;

            updateDatabase(newPassword);

        }

        private void updateDatabase(string newPassword)
        {
            
        }
    }
}
