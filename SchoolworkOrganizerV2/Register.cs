using SchoolworkOrganizer.Panels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SchoolworkOrganizer
{
    public partial class RegisterPanel : Form
    {
        public RegisterPanel()
        {
            InitializeComponent();

            Utilities.InitializeTextBoxWithPlaceholder(txtEmail);
            Utilities.InitializeTextBoxWithPlaceholder(txtUsername);
            Utilities.InitializeTextBoxWithPlaceholder(txtPassword);
            Utilities.InitializeTextBoxWithPlaceholder(txtVerify);
            this.FormClosing += Template.MyFormClosing;
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

        private void RegisterBtn_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text;
            string username = txtUsername.Text;
            string password = txtPassword.Text;
            string verifyPass = txtVerify.Text;
            Image userImage = uploadPicture.Image;

            if (User.DoesUserExist(username))
            {
                MessageBox.Show("User already exists", "Error");
                return;
            }

            if (password != verifyPass)
            {
                MessageBox.Show("Password does not match", "Error");
                return;
            }

            User.Users.Add(new User(email, username, password, userImage));
            User.SaveUsers();
            MessageBox.Show("Register Successful", "Success");
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
