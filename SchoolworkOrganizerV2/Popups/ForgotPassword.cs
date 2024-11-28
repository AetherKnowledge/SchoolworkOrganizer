using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SchoolworkOrganizerV2.Panels;

namespace SchoolworkOrganizerV2.Popups
{
    public partial class ForgotPassword : Form
    {
        private bool isSuccess = false;
        private string code;
        public ForgotPassword()
        {
            InitializeComponent();
            Utilities.InitializeTextBoxWithPlaceholder(employeeIDTxtBox);
            Utilities.InitializeTextBoxWithPlaceholder(codeTxtBox);

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
            if (isSuccess) return;
            OpenPanels.loginPage.Show();
        }

        private void sendBtn_Click(object sender, EventArgs e)
        {
            string email = employeeIDTxtBox.Text;
            if (!doesUserExist(email))
            {
                MessageBox.Show("Employee does not exist", "Error");
                return;
            }

            Random random = new Random();
            code = random.Next(100001,999999).ToString();

            //kung gusto mong mag gmail shit comment mo ung line nasa baba
            MessageBox.Show(code.ToString());

            //// Set up the SMTP client configuration
            //string smtpHost = "smtp.gmail.com"; // e.g., smtp.gmail.com for Gmail
            //int smtpPort = 465; // Typically 587 or 465 for SSL
            //string smtpUsername = "your-email@example.com";
            //string smtpPassword = "your-email-password";

            ////kung gusto mo mag email shit madali lng nman setup
            ////uncomment mo nlng mula dine
            //// Set up the email details
            //string fromAddress = smtpUsername;
            //string toAddress = getEmployee(employeeID).EmployeeEmail;
            //string subject = "Reset Password";
            //string body = "This is your verification code: " + code;

            //try
            //{
            //    // Create a new MailMessage object
            //    MailMessage mail = new MailMessage();
            //    mail.From = new MailAddress(fromAddress);
            //    mail.To.Add(toAddress);
            //    mail.Subject = subject;
            //    mail.Body = body;

            //    // Optional: set up additional properties
            //    mail.IsBodyHtml = false; // Set to true if sending HTML content

            //    // Set up the SMTP client
            //    SmtpClient smtp = new SmtpClient(smtpHost, smtpPort);
            //    smtp.Credentials = new NetworkCredential(smtpUsername, smtpPassword);
            //    smtp.EnableSsl = true; // True for SSL

            //    // Send the email
            //    smtp.Send(mail);
            //    MessageBox.Show("Verification code has been sent to your email.", "Success");
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("An error occurred: " + ex.Message, "Error");
            //}
            ////hanggang dine kung ayaw mo muna mag gmail shit

        }

        private bool doesUserExist(string email)
        {
            foreach (User employee in User.Users)
            {
                if(employee.Email == email) return true;
            }

            return false;
        }

        private User getEmployee(string email)
        {
            foreach (User employee in User.Users)
            {
                if (employee.Email == email) return employee;
            }

            return null;
        }

        private void proceedBtn_Click(object sender, EventArgs e)
        {
            if (codeTxtBox.Text != code)
            {
                MessageBox.Show("Invalid Verification Code", "Error");
                return;
            }
            isSuccess = true;

            string employeeID = employeeIDTxtBox.Text;
            ResetPassword resetPassword = new ResetPassword(employeeID);
            resetPassword.Show();
            this.Close();
        }
    }
}
