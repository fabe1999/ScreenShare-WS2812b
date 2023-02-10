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
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;

namespace ScreenShare_WS2812b
{
    public partial class Share : Form
    {
        public Share()
        {
            InitializeComponent();
        }



        //Variables
        int iLEDwidth = 0;
        int iLEDheight = 0;
        int iNumberPackages = 0;
        int iLines = 0;
        int iYIndex = 0;
        bool bConnected = false;
        bool bInterlace = false;
        public bool bControlls = false;
        byte[] bySendRGB565;
        int iMaxUDPSize = 0;

        Socket udpSock;
        IPAddress ipESP;
        IPEndPoint ipESPendpoint;

        //Create an Array, Every LED-Pixel gets a Colorspace
        Color[,] ledPixCol;



        private void Share_Load(object sender, EventArgs e)
        {
            //Make the Window transparent so the Screenshot can be taken
            this.TransparencyKey = Color.LimeGreen;

            //If there is no saved Config open the Configuration Editor
            if (!Convert.ToBoolean(ConfigurationManager.AppSettings["config"]))
            {
                this.Hide();
                using (var form = new configEditor())
                {
                    var result = form.ShowDialog();
                    while (result == DialogResult.Cancel)
                    {
                        //If the User tries to start the Program without saving a Config an error Message is displayed
                        var retry = MessageBox.Show("You can´t use this Program without a Configuration.\nIf you press Cancel the Program will be closed.", "Please create a Configuration", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
                        if (retry == DialogResult.Retry)
                        {
                            result = form.ShowDialog();
                        }
                        else
                        {
                            this.Close();
                            return;
                        }
                    }
                }
            }
            readConfig();
        }



        private void btnConfig_Click(object sender, EventArgs e)
        {
            //Open the Configuration Editor
            using (var form = new configEditor())
            {
                var result = form.ShowDialog();
                if (result == DialogResult.OK)
                {
                    //If the Configuration is Changed reload all the variables
                    readConfig();
                    //If the Configuration has changed the Connection to the ESP has to be reetablished so the Changes can take effect.
                    btnConnect.PerformClick();
                }
            }
        }



        //Every time the Configuration is changed the Variables have to be updated
        public void readConfig()
        {
            //Try to set the Variables to the Saved Config
            ConfigurationManager.RefreshSection("appSettings");
            try
            {
                ipESP = IPAddress.Parse(ConfigurationManager.AppSettings["ip-adress"]);
                ipESPendpoint = new IPEndPoint(ipESP, Convert.ToInt16(ConfigurationManager.AppSettings["port"]));
                bInterlace = Convert.ToBoolean(ConfigurationManager.AppSettings["interlace"]);
                timer1.Interval = Convert.ToInt32(ConfigurationManager.AppSettings["refresh"]);
                this.TopMost = Convert.ToBoolean(ConfigurationManager.AppSettings["top"]);
            }
            catch (Exception)
            {
                MessageBox.Show("There is a problem with the Configuration.\nPlease set a new Configuration and try again", "Config Problem", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }



        private void btnConnect_Click(object sender, EventArgs e)
        {
            try
            {
                //Use a Random Port to recive the answer
                Random rnd = new Random();
                int rePort = rnd.Next(0, 254);

                //Save the Socket to send Pictures during Capturing
                udpSock = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);

                //Test the Connection to the ESP (Timeout = 5 Seconds)
                var task = Task.Run(() => espConnect(rePort));
                if (task.Wait(TimeSpan.FromSeconds(5)))
                {
                    //If the Connection was successfull show to the User
                    bConnected = true;
                    btnConnect.BackColor = Color.Green;
                    btnConnect.FlatAppearance.MouseOverBackColor = Color.LightGreen;
                    btnConnect.Text = "Connected";

                    //Create an Array of Pixels with the Mesurements from the Matrix
                    ledPixCol = new Color[iLEDwidth, iLEDheight];

                    //Calculate how many UDP Packages are needet to display a whole Picture with Regards to the Max UDP Package Size
                    iNumberPackages = Convert.ToInt32(Math.Round(((iLEDheight * iLEDwidth * 2.0 / iMaxUDPSize) + 0.5), MidpointRounding.AwayFromZero));
                    iLines = Convert.ToInt32(Math.Round((iLEDheight * 1.0) / iNumberPackages + 0.5));
                    bySendRGB565 = new byte[(((iLines * iLEDwidth) * 2) + 1)];
                    if (iNumberPackages == 1)
                    {
                        bInterlace = false;
                    }

                    //If the Packages are split evenly throughout the refresh time the animation will be more fluent
                    //and the ESP wont be overloaded with to many Packages at the same time
                    if (bInterlace)
                    {
                        timer1.Interval = (Convert.ToInt32(ConfigurationManager.AppSettings["refresh"])) / iNumberPackages;
                    }
                    else
                    {
                        timer1.Interval = Convert.ToInt32(ConfigurationManager.AppSettings["refresh"]);
                    }

                    //The Matrix Size is displayed to verify the correct configuration
                    updateInfo();
                    return;
                }
                else
                {
                    MessageBox.Show("The answer has taken to long.\nPlease verify the configured IP-Address and port.\nTry again after changing the Config", "Time out", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("The answer has taken to long.\nPlease verify the configured IP-Address and port.\nTry again after changing the Config", "Time out", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        public void espConnect(int inPort)
        {
            //send the used Port to the ESP so it can send an answer back on the same port.
            //Also the brightness will be transmitted
            byte[] bySend = new byte[3];
            bySend[0] = (byte)'C';
            bySend[1] = Convert.ToByte(ConfigurationManager.AppSettings["brightness"]);
            bySend[2] = Convert.ToByte(inPort);
            udpSock.SendTo(bySend, ipESPendpoint);

            //Wait for the Answer of the ESP
            UdpClient receivingUdpClient = new UdpClient(inPort);
            IPEndPoint RemoteIpEndPoint = new IPEndPoint(IPAddress.Any, 0);
            try
            {
                //Recive the Answer from the ESP
                //The ESP Sends the Mesurements of the Matrix so the PC Version is automatically set to the correct size
                Byte[] receiveBytes = receivingUdpClient.Receive(ref RemoteIpEndPoint);
                string returnData = Encoding.ASCII.GetString(receiveBytes);
                string[] buffer = returnData.Split(';');
                iLEDwidth = Convert.ToInt32(buffer[0]);
                iLEDheight = Convert.ToInt32(buffer[1]);
                iMaxUDPSize = (Convert.ToInt32(buffer[2]));
            }
            catch (Exception)
            {
                MessageBox.Show("An unexpected Error occurred.\nPlease try Again.\n\nIf the Error still exists please report a bug on GitHub", "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void btnStart_Click(object sender, EventArgs e)
        {
            timer1.Enabled = true;
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false;
        }



        private async void timer1_Tick(object sender, EventArgs e)
        {
            //If the ESP isnt connected the Capture doesnt start
            //The Connection is important to know the Size of the Matrix so the Program can properly resize the Captured image
            if (!bConnected)
            {
                timer1.Enabled = false;
                MessageBox.Show("The ESP is not Connected,\nPlease establish a connection before you start to share the Screen.", "No Connection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            //take a Screenshot of all monitors and crop it to the Size of the Transparent panel
            Graphics myGraphics = CreateGraphics();
            Size s = new Size(pnlShot.Size.Width - 3, pnlShot.Size.Height - 3);
            var cropScreen = new Bitmap(s.Width, s.Height, myGraphics);
            Graphics memoryGraphics = Graphics.FromImage(cropScreen);
            memoryGraphics.CopyFromScreen((Location.X + 21), (Location.Y + 61), 0, 0, s);
            pbPrevOrig.BackgroundImage = cropScreen;


            //Set Variables to resize the Image
            int originalWidth = pbPrevOrig.BackgroundImage.Width;
            int originalHeight = pbPrevOrig.BackgroundImage.Height;


            //Display the Cropped Screenshot in the Preview-window
            var thumbnail = new Bitmap(iLEDwidth, iLEDheight);
            var graphic = Graphics.FromImage(thumbnail);

            //Calculate the ratio so the resized Image wont be stretched.
            double ratioX = (double)iLEDwidth / (double)originalWidth;
            double ratioY = (double)iLEDheight / (double)originalHeight;
            double ratio = ratioX < ratioY ? ratioX : ratioY;
            int newHeight = Convert.ToInt32(originalHeight * ratio);
            int newWidth = Convert.ToInt32(originalWidth * ratio);
            int posX = Convert.ToInt32((iLEDwidth - (originalWidth * ratio)) / 2);
            int posY = Convert.ToInt32((iLEDheight - (originalHeight * ratio)) / 2);

            //If the Image dosnt fit on the Matrix make a black border
            graphic.Clear(Color.Black);
            graphic.DrawImage(cropScreen, posX, posY, newWidth, newHeight);


            //Draw an Pixelated Matrix preview in the Preview-window
            //If you just put the low res Image in the Picturebox it will try to upscale it and smooth out the edges.
            Bitmap pixPrev = new Bitmap(pbPrevMatrix.Size.Width, pbPrevMatrix.Size.Height);
            using (Graphics gr = Graphics.FromImage(pixPrev))
            {
                for (int x = 0; x < iLEDwidth; x++)
                {
                    for (int y = 0; y < iLEDheight; y++)
                    {
                        //Create a Previewimage from the Colors of the Pixels, Every LED will be displayed as a Square in the Preview-window
                        Rectangle rect = new Rectangle((pbPrevMatrix.Size.Width / iLEDwidth) * x, (pbPrevMatrix.Size.Height / iLEDheight) * y, (pbPrevMatrix.Size.Width / iLEDwidth), (pbPrevMatrix.Size.Height / iLEDheight));
                        Brush brCol = new SolidBrush(thumbnail.GetPixel(x, y));
                        gr.FillRectangle(brCol, rect);

                        //Save The Color to the Array so it can be send to the ESP later
                        ledPixCol[x, y] = thumbnail.GetPixel(x, y);
                    }
                }
                pbPrevMatrix.Image = pixPrev;
            }


            //Reset the Y Variable acording to the Display-mode, 
            //If the Packages wont be split throughout the refresh Time it has to be Reseted every time.
            if (!bInterlace)
            {
                iYIndex = 0;
            }
            if (iYIndex >= iLEDheight)
            {
                iYIndex = 0;
            }

            //One Single Package is created and send to the ESP,
            //The other Parts will be Send the next Time the Timer_tick happens
            if (bInterlace)
            {
                int iIndex = 0;
                //The first byte is used to signal the ESP at what Y Value the current Color-Informations start.
                //each LED Uses 16 Bits for its Colors, so 2 Bytes.
                bySendRGB565[iIndex++] = (byte)iYIndex;
                int iloop = Convert.ToInt32(Math.Round((iLEDheight * 1.0) / (iNumberPackages * 1.0) + 0.5));
                for (int y = 0; y < iLines; y++)
                {
                    //If the Number of Packages is uneven the last Package has less Information than the first two
                    //Stop the Program from overfilling the Last Package
                    if (iYIndex < iLEDheight)
                    {
                        for (int x = 0; x < iLEDwidth; x++)
                        {
                            //The colors are convertet to RGB565 (16 Bit) so the ESP dosnt have to do the Conversion
                            UInt16 uiRGB565 = 0;
                            uiRGB565 = Convert.ToUInt16(ledPixCol[x, iYIndex].B >> 3);
                            uiRGB565 |= Convert.ToUInt16((ledPixCol[x, iYIndex].G >> 2) << 5);
                            uiRGB565 |= Convert.ToUInt16((ledPixCol[x, iYIndex].R >> 3) << 11);

                            //The 16 Bit has to be split into two different byte so it can be transmitted via UDP
                            bySendRGB565[iIndex++] = (byte)((uiRGB565 & 0xFF00) >> 8);
                            bySendRGB565[iIndex++] = (byte)(uiRGB565 & 0x00FF);
                        }
                        iYIndex++;
                    }
                }
                //Send the String as UDP Package
                udpSock.SendTo(bySendRGB565, ipESPendpoint);
                Array.Clear(bySendRGB565, 0, bySendRGB565.Length);
            }

            //If the Picture isnt split all the Color Information is send in one go
            //Its still split up according to the Package Size but all of the Packages are send as fast as possible.
            //This is usefull for Displaying Pictures or if the Refreshtime is really slow.
            else
            {
                for (int p = 0; p < iNumberPackages; p++)
                {
                    int iIndex = 0;
                    //The first byte is used to signal the ESP where the current Color-Informations start.
                    //each LED Uses 16 Bits for its Colors so 2 Bytes.
                    bySendRGB565[iIndex++] = (byte)iYIndex;
                    for (int y = 0; y < (iLEDheight / iNumberPackages); y++)
                    {
                        for (int x = 0; x < iLEDwidth; x++)
                        {
                            //The colors are convertet to RGB565 (16 Bit) so the ESP dosnt have to do the Conversion
                            UInt16 uiRGB565 = 0;
                            uiRGB565 = Convert.ToUInt16(ledPixCol[x, iYIndex].B >> 3);
                            uiRGB565 |= Convert.ToUInt16((ledPixCol[x, iYIndex].G >> 2) << 5);
                            uiRGB565 |= Convert.ToUInt16((ledPixCol[x, iYIndex].R >> 3) << 11);

                            //The 16 Bit has to be split into two different byte so it can be transmitted via TCP
                            bySendRGB565[iIndex++] = (byte)((uiRGB565 & 0xFF00) >> 8);
                            bySendRGB565[iIndex++] = (byte)(uiRGB565 & 0x00FF);
                        }
                        iYIndex++;
                    }
                    //Send the String as UDP Package
                    udpSock.SendTo(bySendRGB565, ipESPendpoint);
                    Array.Clear(bySendRGB565, 0, bySendRGB565.Length);
                }
            }
        }



        void updateInfo()
        {
            labConnected.Text = "Connected to\n" + ipESPendpoint + "\n\nMatrix size: " + iLEDwidth + "*" + iLEDheight + "\nMax brightness = " + ConfigurationManager.AppSettings["brightness"] + "\nRefresh: " + ConfigurationManager.AppSettings["refresh"] + "ms\nPackages: " + iNumberPackages + "\nInteraced: " + bInterlace;
        }



        private void btnPopout_Click(object sender, EventArgs e)
        {
            //popout the controlls
            var form = new control();
            form.Location = new Point(this.Right + 10, this.Bottom - form.Height);
            form.Show(this);
        }



        private void Share_SizeChanged(object sender, EventArgs e)
        {
            //if the Main window is to smal for the Controlls they will be poped our automaticaly.
            if (this.Height < 578 && !bControlls)
            {
                btnPopout.PerformClick();
            }
        }



        private void btnResize_Click(object sender, EventArgs e)
        {
            //Reset the Size to the Original window Size
            Size = new Size(927, 578);
        }



        private void btnPdf_Click(object sender, EventArgs e)
        {
            //Open the Userguide on GitHub
            //This ensures its always the newest version.
            System.Diagnostics.Process.Start("https://github.com/fabe1999/ScreenShare-WS2812b/blob/master/User%20guide/User-guide.pdf");
        }



        private void Share_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (bConnected)
            {
                try
                {
                    //Send the command to clear the Matrix before closing the program
                    byte[] bytesToSend = new byte[1];
                    bytesToSend[0] = (byte)'X';
                    udpSock.SendTo(bytesToSend, ipESPendpoint);
                }
                catch (Exception)
                {
                    //if the Matrix is already offline just close the program
                }
            }
        }
    }
}
