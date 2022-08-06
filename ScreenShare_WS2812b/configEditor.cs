using System;
using System.Configuration;
using System.Net;
using System.Net.Sockets;
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
    public partial class configEditor : Form
    {

        public configEditor()
        {
            InitializeComponent();
        }



        private void configEditor_Load(object sender, EventArgs e)
        {
            if (Convert.ToBoolean(ConfigurationManager.AppSettings["config"]))
            {
                //Load the informations from the Config file. If they where already changed you can see what you tiped in
                tbIP.Text = ConfigurationManager.AppSettings["ip-adress"];
                nrPort.Value = Convert.ToInt32(ConfigurationManager.AppSettings["port"]);
                nrRefresh.Value = Convert.ToInt32(ConfigurationManager.AppSettings["refresh"]);
                chbTop.Checked = Convert.ToBoolean(ConfigurationManager.AppSettings["top"]);
                tbBright.Value = Convert.ToInt32(ConfigurationManager.AppSettings["brightness"]);
                labBrightness.Text = "Maximum matrix brightness: " + tbBright.Value.ToString();
                //If there is already a Configuration Hide the Information Text
                Size = new Size(206, 361);
            }
        }



        private void tbBright_Scroll(object sender, EventArgs e)
        {
            //Show the Value of the Slider in the label
            labBrightness.Text = "Maximum matrix brightness: " + tbBright.Value.ToString();
        }



        private void btnCancle_Click(object sender, EventArgs e)
        {
            //All Changes ar discarded and the Configwindow closes
            DialogResult = DialogResult.Cancel;
            Close();
        }



        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                //To Verify the input the IP Address is parsed, if there is something wrong the Values wont be saved
                IPAddress parseTest = IPAddress.Parse(tbIP.Text);
            }
            catch (Exception)
            {
                MessageBox.Show("The IP Address you entered is not a valid address..\nPlease correct the entry and try again.", "invalid IP Address", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //Save the Userinput in the configuration file and close the Window
            Configuration config = ConfigurationManager.OpenExeConfiguration(Application.ExecutablePath);
            config.AppSettings.Settings["config"].Value = "True";
            config.AppSettings.Settings["ip-adress"].Value = tbIP.Text;
            config.AppSettings.Settings["port"].Value = nrPort.Value.ToString();
            config.AppSettings.Settings["refresh"].Value = nrRefresh.Value.ToString();
            config.AppSettings.Settings["top"].Value = chbTop.Checked.ToString();
            config.AppSettings.Settings["brightness"].Value = tbBright.Value.ToString();
            config.Save(ConfigurationSaveMode.Modified);
            DialogResult = DialogResult.OK;
            Close();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/fabe1999/ScreenShare-WS2812b/");
        }

    }
}
