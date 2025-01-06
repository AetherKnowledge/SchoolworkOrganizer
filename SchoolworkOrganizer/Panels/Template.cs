using SchoolworkOrganizer.Popup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolworkOrganizer.Panels
{
    public abstract class Template : UserControl
    {
        public abstract void RefreshData();

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
