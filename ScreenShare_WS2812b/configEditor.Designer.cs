namespace ScreenShare_WS2812b
{
    partial class configEditor
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(configEditor));
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancle = new System.Windows.Forms.Button();
            this.labIP = new System.Windows.Forms.Label();
            this.labPort = new System.Windows.Forms.Label();
            this.tbIP = new System.Windows.Forms.TextBox();
            this.nrPort = new System.Windows.Forms.NumericUpDown();
            this.nrRefresh = new System.Windows.Forms.NumericUpDown();
            this.labRefresh = new System.Windows.Forms.Label();
            this.labInfo = new System.Windows.Forms.Label();
            this.labHead = new System.Windows.Forms.Label();
            this.labVer = new System.Windows.Forms.Label();
            this.chbTop = new System.Windows.Forms.CheckBox();
            this.llabGuide = new System.Windows.Forms.LinkLabel();
            this.labBrightness = new System.Windows.Forms.Label();
            this.tbBright = new System.Windows.Forms.TrackBar();
            this.chbInterlace = new System.Windows.Forms.CheckBox();
            this.llabInterHelp = new System.Windows.Forms.LinkLabel();
            this.labFPS = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.nrPort)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nrRefresh)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbBright)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnSave.Location = new System.Drawing.Point(15, 299);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(193, 23);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancle
            // 
            this.btnCancle.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancle.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnCancle.Location = new System.Drawing.Point(15, 270);
            this.btnCancle.Name = "btnCancle";
            this.btnCancle.Size = new System.Drawing.Size(193, 23);
            this.btnCancle.TabIndex = 1;
            this.btnCancle.Text = "Cancel";
            this.btnCancle.UseVisualStyleBackColor = true;
            this.btnCancle.Click += new System.EventHandler(this.btnCancle_Click);
            // 
            // labIP
            // 
            this.labIP.AutoSize = true;
            this.labIP.Location = new System.Drawing.Point(12, 9);
            this.labIP.Name = "labIP";
            this.labIP.Size = new System.Drawing.Size(58, 13);
            this.labIP.TabIndex = 2;
            this.labIP.Text = "IP-Address";
            // 
            // labPort
            // 
            this.labPort.AutoSize = true;
            this.labPort.Location = new System.Drawing.Point(12, 58);
            this.labPort.Name = "labPort";
            this.labPort.Size = new System.Drawing.Size(26, 13);
            this.labPort.TabIndex = 3;
            this.labPort.Text = "Port";
            // 
            // tbIP
            // 
            this.tbIP.Location = new System.Drawing.Point(15, 25);
            this.tbIP.Name = "tbIP";
            this.tbIP.Size = new System.Drawing.Size(193, 20);
            this.tbIP.TabIndex = 6;
            // 
            // nrPort
            // 
            this.nrPort.Location = new System.Drawing.Point(15, 74);
            this.nrPort.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.nrPort.Minimum = new decimal(new int[] {
            1024,
            0,
            0,
            0});
            this.nrPort.Name = "nrPort";
            this.nrPort.Size = new System.Drawing.Size(193, 20);
            this.nrPort.TabIndex = 7;
            this.nrPort.Value = new decimal(new int[] {
            4210,
            0,
            0,
            0});
            // 
            // nrRefresh
            // 
            this.nrRefresh.Location = new System.Drawing.Point(15, 123);
            this.nrRefresh.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.nrRefresh.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.nrRefresh.Name = "nrRefresh";
            this.nrRefresh.Size = new System.Drawing.Size(193, 20);
            this.nrRefresh.TabIndex = 11;
            this.nrRefresh.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.nrRefresh.ValueChanged += new System.EventHandler(this.nrRefresh_ValueChanged);
            // 
            // labRefresh
            // 
            this.labRefresh.AutoSize = true;
            this.labRefresh.Location = new System.Drawing.Point(12, 107);
            this.labRefresh.Name = "labRefresh";
            this.labRefresh.Size = new System.Drawing.Size(121, 13);
            this.labRefresh.TabIndex = 10;
            this.labRefresh.Text = "Picture refreshtime in ms";
            // 
            // labInfo
            // 
            this.labInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labInfo.Location = new System.Drawing.Point(262, 58);
            this.labInfo.Name = "labInfo";
            this.labInfo.Size = new System.Drawing.Size(469, 218);
            this.labInfo.TabIndex = 12;
            this.labInfo.Text = resources.GetString("labInfo.Text");
            // 
            // labHead
            // 
            this.labHead.AutoSize = true;
            this.labHead.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labHead.Location = new System.Drawing.Point(260, 19);
            this.labHead.Name = "labHead";
            this.labHead.Size = new System.Drawing.Size(324, 25);
            this.labHead.TabIndex = 13;
            this.labHead.Text = "There is no saved Configuration.";
            // 
            // labVer
            // 
            this.labVer.AutoSize = true;
            this.labVer.Location = new System.Drawing.Point(262, 296);
            this.labVer.Name = "labVer";
            this.labVer.Size = new System.Drawing.Size(122, 26);
            this.labVer.TabIndex = 14;
            this.labVer.Text = "created by fabe1999\r\nlast updated 10.02.2023";
            // 
            // chbTop
            // 
            this.chbTop.AutoSize = true;
            this.chbTop.Checked = true;
            this.chbTop.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chbTop.Location = new System.Drawing.Point(15, 232);
            this.chbTop.Name = "chbTop";
            this.chbTop.Size = new System.Drawing.Size(163, 17);
            this.chbTop.TabIndex = 15;
            this.chbTop.Text = "Show Window always on top";
            this.chbTop.UseVisualStyleBackColor = true;
            // 
            // llabGuide
            // 
            this.llabGuide.ActiveLinkColor = System.Drawing.Color.Red;
            this.llabGuide.AutoSize = true;
            this.llabGuide.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.llabGuide.LinkColor = System.Drawing.Color.Cyan;
            this.llabGuide.Location = new System.Drawing.Point(491, 249);
            this.llabGuide.Name = "llabGuide";
            this.llabGuide.Size = new System.Drawing.Size(73, 16);
            this.llabGuide.TabIndex = 16;
            this.llabGuide.TabStop = true;
            this.llabGuide.Text = "user guide.";
            this.llabGuide.VisitedLinkColor = System.Drawing.Color.Magenta;
            this.llabGuide.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // labBrightness
            // 
            this.labBrightness.AutoSize = true;
            this.labBrightness.Location = new System.Drawing.Point(12, 156);
            this.labBrightness.Name = "labBrightness";
            this.labBrightness.Size = new System.Drawing.Size(156, 13);
            this.labBrightness.TabIndex = 17;
            this.labBrightness.Text = "Maximum matrix brightness: 255";
            // 
            // tbBright
            // 
            this.tbBright.Location = new System.Drawing.Point(15, 172);
            this.tbBright.Maximum = 255;
            this.tbBright.Name = "tbBright";
            this.tbBright.Size = new System.Drawing.Size(193, 45);
            this.tbBright.TabIndex = 18;
            this.tbBright.TickStyle = System.Windows.Forms.TickStyle.None;
            this.tbBright.Value = 255;
            this.tbBright.Scroll += new System.EventHandler(this.tbBright_Scroll);
            // 
            // chbInterlace
            // 
            this.chbInterlace.AutoSize = true;
            this.chbInterlace.Checked = true;
            this.chbInterlace.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chbInterlace.Location = new System.Drawing.Point(15, 206);
            this.chbInterlace.Name = "chbInterlace";
            this.chbInterlace.Size = new System.Drawing.Size(129, 17);
            this.chbInterlace.TabIndex = 19;
            this.chbInterlace.Text = "Interlace Picture-Data";
            this.chbInterlace.UseVisualStyleBackColor = true;
            // 
            // llabInterHelp
            // 
            this.llabInterHelp.ActiveLinkColor = System.Drawing.Color.Red;
            this.llabInterHelp.AutoSize = true;
            this.llabInterHelp.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.llabInterHelp.LinkColor = System.Drawing.Color.Cyan;
            this.llabInterHelp.Location = new System.Drawing.Point(138, 205);
            this.llabInterHelp.Name = "llabInterHelp";
            this.llabInterHelp.Size = new System.Drawing.Size(14, 16);
            this.llabInterHelp.TabIndex = 21;
            this.llabInterHelp.TabStop = true;
            this.llabInterHelp.Text = "?";
            this.llabInterHelp.VisitedLinkColor = System.Drawing.Color.Magenta;
            this.llabInterHelp.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llabInterHelp_LinkClicked);
            // 
            // labFPS
            // 
            this.labFPS.Location = new System.Drawing.Point(130, 107);
            this.labFPS.Name = "labFPS";
            this.labFPS.Size = new System.Drawing.Size(78, 13);
            this.labFPS.TabIndex = 22;
            this.labFPS.Text = "ca. 20 FPS";
            this.labFPS.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // configEditor
            // 
            this.AcceptButton = this.btnSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.CancelButton = this.btnCancle;
            this.ClientSize = new System.Drawing.Size(736, 334);
            this.Controls.Add(this.llabInterHelp);
            this.Controls.Add(this.chbInterlace);
            this.Controls.Add(this.tbBright);
            this.Controls.Add(this.labBrightness);
            this.Controls.Add(this.llabGuide);
            this.Controls.Add(this.chbTop);
            this.Controls.Add(this.labVer);
            this.Controls.Add(this.labHead);
            this.Controls.Add(this.labInfo);
            this.Controls.Add(this.nrRefresh);
            this.Controls.Add(this.labRefresh);
            this.Controls.Add(this.nrPort);
            this.Controls.Add(this.tbIP);
            this.Controls.Add(this.labPort);
            this.Controls.Add(this.labIP);
            this.Controls.Add(this.btnCancle);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.labFPS);
            this.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "configEditor";
            this.ShowIcon = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Configuration";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.configEditor_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nrPort)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nrRefresh)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbBright)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancle;
        private System.Windows.Forms.Label labIP;
        private System.Windows.Forms.Label labPort;
        private System.Windows.Forms.TextBox tbIP;
        private System.Windows.Forms.NumericUpDown nrPort;
        private System.Windows.Forms.NumericUpDown nrRefresh;
        private System.Windows.Forms.Label labRefresh;
        private System.Windows.Forms.Label labInfo;
        private System.Windows.Forms.Label labHead;
        private System.Windows.Forms.Label labVer;
        private System.Windows.Forms.CheckBox chbTop;
        private System.Windows.Forms.LinkLabel llabGuide;
        private System.Windows.Forms.Label labBrightness;
        private System.Windows.Forms.TrackBar tbBright;
        private System.Windows.Forms.CheckBox chbInterlace;
        private System.Windows.Forms.LinkLabel llabInterHelp;
        private System.Windows.Forms.Label labFPS;
    }
}