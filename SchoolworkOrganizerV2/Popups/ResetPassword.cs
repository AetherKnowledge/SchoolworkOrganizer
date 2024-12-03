using SchoolworkOrganizer.Panels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SchoolworkOrganizer.Popups
{
    public partial class ResetPassword : Form
    {
        private readonly string Email;
        

        public ResetPassword(string Email)
        {
            this.Email = Email;
            InitializeComponent();
            Utilities.InitializeTextBoxWithPlaceholder(newPasswordTxtBox);
            Utilities.InitializeTextBoxWithPlaceholder(verifyPasswordTxtBox);
            this.FormClosing += MyFormClosing;
        }
        public new void Show()
        {
            base.Show();
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

        public void MyFormClosing(object sender, FormClosingEventArgs e)
        {
            OpenPanels.loginPage.Show();
        }

        private void changePasswordBtn_Click(object sender, EventArgs e)
        {
            if(newPasswordTxtBox.Text == "New Password" || newPasswordTxtBox.Text != verifyPasswordTxtBox.Text)
            {
                MessageBox.Show("Password not the same", "Error");
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
