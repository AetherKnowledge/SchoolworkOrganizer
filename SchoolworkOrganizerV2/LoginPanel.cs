using SchoolworkOrganizer.Panels;
using SchoolworkOrganizer.Popups;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace SchoolworkOrganizer
{
    public partial class LoginPanel : Form
    {

        public LoginPanel()
        {
            InitializeComponent();
            Utilities.InitializeTextBoxWithPlaceholder(txtUsername);
            Utilities.InitializeTextBoxWithPlaceholder(txtPassword);

            User.LoadUsers();
            CheckForFiles();
            this.FormClosing += MyFormClosing;

            OpenPanels.loginPage = this;
        }

        public static void CheckForFiles()
        {
            User.Users
            .SelectMany(user => user.Subjects)
            .ToList()
            .ForEach(subject => subject.CheckForFiles());
        }

        public new void Show()
        {
            base.Show();
            User.Logout();
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
            User.SaveUsers();
        }

        private void ButtonLogIn_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;

            if (username == "Username" || password == "Password")
            {
                MessageBox.Show("Please enter valid credentials", "Error");
                return;
            }

            if (!User.Login(username, password))
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
            foreach (User user in User.Users)
            {
                user.AddUserToDatabase();
            }
        }
    }
}
