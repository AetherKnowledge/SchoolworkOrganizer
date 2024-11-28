using SchoolworkOrganizerV2.Panels;
using SchoolworkOrganizerV2.Popups;
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

namespace SchoolworkOrganizerV2
{
    public partial class LoginPanel : Form
    {
        public static User currentUser = null;
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
            currentUser = null;
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

        public static void MyFormClosing(object sender, FormClosingEventArgs e)
        {
            User.SaveUsers();
        }

        private void Log_In_Page_Load(object sender, EventArgs e)
        {

        }

        private void GetUsers()
        {
            
        }
        private void ButtonLogIn_Click(object sender, EventArgs e)
        {
            User user = User.GetUser(txtUsername.Text);

            if (txtUsername.Text == "Username"  || txtPassword.Text == "Password" || user == null)
            {
                MessageBox.Show("Please enter valid credentials", "Error");
                return;
            }

            if (txtPassword.Text != user.Password)
            {
                MessageBox.Show("Invalid Password", "Error");
                return;
            }

            currentUser = user;
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

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {

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
    }
}
