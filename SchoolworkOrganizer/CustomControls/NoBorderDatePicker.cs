using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentRequestingUtils.CustomControls
{
    public class NoBorderDatePicker : DateTimePicker
    {
        public NoBorderDatePicker()
        {
            //this.SetStyle(ControlStyles.UserPaint, true); // Enable custom painting
            //this.SetStyle(ControlStyles.FixedHeight, false);
            //this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            //this.UpdateStyles();

        }

        public void RemoveBorder()
        {
            Rectangle rect = new Rectangle(1, 1, Width - 2, Height - 2);
            this.Region = new Region(rect);
        }

    }
}
