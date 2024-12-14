using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolworkOrganizer.CustomControls
{
    public class NonFocusableForm : Form
    {
        protected override bool ShowWithoutActivation
        {
            get { return true; }
        }

        public NonFocusableForm()
        {
            FormBorderStyle = FormBorderStyle.None;
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.Manual;
            BackColor = Color.White;
        }

    }
}
