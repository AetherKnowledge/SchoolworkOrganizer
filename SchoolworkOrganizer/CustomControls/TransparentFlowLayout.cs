using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentRequestingUtils.CustomControls
{
    public class TransparentFlowLayout : FlowLayoutPanel
    {
        public TransparentFlowLayout()
        {
            this.SetStyle(
                ControlStyles.SupportsTransparentBackColor |
                ControlStyles.OptimizedDoubleBuffer |
                ControlStyles.UserPaint |
                ControlStyles.AllPaintingInWmPaint,
                true
            );
            this.UpdateStyles();

            this.BackColor = Color.Transparent;
        }

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000; // WS_EX_COMPOSITED to enable advanced double buffering
                return cp;
            }
        }
    }
}
