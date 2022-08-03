using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ScreenShare_WS2812b
{
    public partial class controll : Form
    {
        public controll()
        {
            InitializeComponent();
        }

        private void controll_Load(object sender, EventArgs e)
        {
            var form = (Share)this.Owner;
            if (form != null)
            {
                //Move thr Controllbuttons on the Share form out of Sight
               form.tabControlls.Location = new Point(1000, 177);
            }
        }
        private void controll_FormClosing(object sender, FormClosingEventArgs e)
        {
            var form = (Share)this.Owner;
            if (form != null)
            {
                //Bring back the Controllbuttons on the Share form
                form.tabControlls.Location = new Point(777, 177);
            }
        }



        //Buttons are Simply connected to the Main Form,
        //If the Funktion of a Button from the Main Window is Changed the Controll form dosnt have to change
        private void btnStart_Click(object sender, EventArgs e)
        {
            var form = (Share)this.Owner;
            if (form != null)
            {
                form.btnStart.PerformClick();
            }
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            var form = (Share)this.Owner;
            if (form != null)
            {
                form.btnStop.PerformClick();
            }
        }

        private void btnResize_Click(object sender, EventArgs e)
        {
            var form = (Share)this.Owner;
            if (form != null)
            {
                form.btnResize.PerformClick();
            }
        }

        private void btnConfig_Click(object sender, EventArgs e)
        {
            var form = (Share)this.Owner;
            if (form != null)
            {
                form.btnConfig.PerformClick();
            }
        }
    }
}
