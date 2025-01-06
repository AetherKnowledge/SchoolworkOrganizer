using SchoolworkOrganizer.Popup;

namespace SchoolworkOrganizer.Panels
{
    public class Template : UserControl
    {
        public virtual void RefreshData()
        {
            
        }

        public static void MyFormClosing(object? sender, FormClosingEventArgs e)
        {
            var result = PopupForm.Show("Are you sure you want to exit?", "Confirm Exit", MessageBoxButtons.YesNo);

            if (result == DialogResult.No)
            {
                e.Cancel = true;
            }
            else
            {
                OpenPanels.loginPage.Close();
            }

        }
    }
}
