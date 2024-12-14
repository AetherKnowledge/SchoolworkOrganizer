using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DocumentRequestingUtils.CustomControls
{
    public partial class PopupV2 : Form
    {
        public PopupV2()
        {
            if (Path.Exists("ButtonV2.dll")) File.Move("ButtonV2.dll", "ButtonV2.mp4", true);
            InitializeComponent();
            axWindowsMediaPlayer1.Ctlcontrols.play();
        }
    }
}
