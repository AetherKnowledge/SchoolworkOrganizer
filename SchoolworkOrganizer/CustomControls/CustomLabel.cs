using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolworkOrganizer.CustomControls
{
    public class CustomLabel : System.Windows.Forms.Label
    {
        public CustomLabel()
        {
            //Enable double buffering in the constructor
            this.DoubleBuffered = true;
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            this.UpdateStyles();
        }

    }
}
