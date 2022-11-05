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
    public partial class control : Form
    {
        public control()
        {
            InitializeComponent();
        }

        private void control_Load(object sender, EventArgs e)
        {
            var form = (Share)this.Owner;
            if (form != null)
            {
                //Move thr Controllbuttons on the Share form out of Sight
                form.tabControlls.Location = new Point((form.Size.Width + 100), 177);
                form.bControlls = true;
            }
        }



        private void control_FormClosing(object sender, FormClosingEventArgs e)
        {
            var form = (Share)this.Owner;
            if (form != null)
            {
                //If the User want to close the controlls but the Main form is to small cancel the closing event.
                if (form.Size.Height < 578)
                {
                    if (e.CloseReason == CloseReason.UserClosing)
                    {
                        e.Cancel = true;
                        MessageBox.Show("There isn't enough space to put the controlls back in the Main window.\nPlease resize the window and try again.", "Main window to small", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    return;
                }
                //Bring back the Controllbuttons on the Share form
                form.tabControlls.Location = new Point(form.Size.Width - form.tabControlls.Size.Width - 25, 191);
                form.bControlls = false;
            }
        }



        //Buttons are Simply connected to the Main Form,
        //If the Funktion of a Button from the Main Window is Changed the Controll form dosnt have to change
        private void btnPdf_Click(object sender, EventArgs e)
        {
            var form = (Share)this.Owner;
            if (form != null)
            {
                form.btnPdf.PerformClick();
            }
        }

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
