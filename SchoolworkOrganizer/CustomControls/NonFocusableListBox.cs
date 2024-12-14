using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolworkOrganizer.CustomControls
{
    public class NonFocusableListBox : ListBox
    {
        protected override void WndProc(ref Message m)
        {
            const int WM_SETFOCUS = 0x0007;
            if (m.Msg == WM_SETFOCUS)
            {
                // Prevent focus from being set
                return;
            }
            base.WndProc(ref m);
        }

        protected override bool ShowFocusCues => false;

    }
}
