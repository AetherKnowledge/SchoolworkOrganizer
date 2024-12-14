using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MaterialSkin.Controls
{
    internal class NonFocusablePicBox : System.Windows.Forms.PictureBox
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
