namespace ScreenShare_WS2812b
{
    partial class Share
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Share));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.pbPrevOrig = new System.Windows.Forms.PictureBox();
            this.pbPrevMatrix = new System.Windows.Forms.PictureBox();
            this.btnConnect = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.labCapture = new System.Windows.Forms.Label();
            this.pnlShot = new System.Windows.Forms.Panel();
            this.btnStart = new System.Windows.Forms.Button();
            this.labConnected = new System.Windows.Forms.Label();
            this.labPreview = new System.Windows.Forms.Label();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.btnResize = new System.Windows.Forms.Button();
            this.btnConfig = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbPrevOrig)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPrevMatrix)).BeginInit();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.pbPrevOrig, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.pbPrevMatrix, 0, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(518, 29);
            this.tableLayoutPanel1.MaximumSize = new System.Drawing.Size(250, 500);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(250, 500);
            this.tableLayoutPanel1.TabIndex = 29;
            // 
            // pbPrevOrig
            // 
            this.pbPrevOrig.BackColor = System.Drawing.Color.Transparent;
            this.pbPrevOrig.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pbPrevOrig.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbPrevOrig.Location = new System.Drawing.Point(3, 3);
            this.pbPrevOrig.Name = "pbPrevOrig";
            this.pbPrevOrig.Size = new System.Drawing.Size(244, 244);
            this.pbPrevOrig.TabIndex = 2;
            this.pbPrevOrig.TabStop = false;
            // 
            // pbPrevMatrix
            // 
            this.pbPrevMatrix.BackColor = System.Drawing.Color.Transparent;
            this.pbPrevMatrix.Location = new System.Drawing.Point(3, 253);
            this.pbPrevMatrix.Name = "pbPrevMatrix";
            this.pbPrevMatrix.Size = new System.Drawing.Size(244, 244);
            this.pbPrevMatrix.TabIndex = 4;
            this.pbPrevMatrix.TabStop = false;
            this.toolTip1.SetToolTip(this.pbPrevMatrix, "Preview of the Pixels send to the Matrix");
            // 
            // btnConnect
            // 
            this.btnConnect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnConnect.BackColor = System.Drawing.Color.Red;
            this.btnConnect.FlatAppearance.BorderColor = System.Drawing.Color.WhiteSmoke;
            this.btnConnect.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnConnect.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnConnect.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConnect.Location = new System.Drawing.Point(777, 32);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(119, 23);
            this.btnConnect.TabIndex = 24;
            this.btnConnect.Text = "Connect to ESP";
            this.btnConnect.UseVisualStyleBackColor = false;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // btnStop
            // 
            this.btnStop.BackColor = System.Drawing.Color.Transparent;
            this.btnStop.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnStop.BackgroundImage")));
            this.btnStop.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnStop.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnStop.FlatAppearance.BorderSize = 0;
            this.btnStop.FlatAppearance.CheckedBackColor = System.Drawing.Color.Black;
            this.btnStop.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black;
            this.btnStop.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.btnStop.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStop.ForeColor = System.Drawing.Color.White;
            this.btnStop.Location = new System.Drawing.Point(3, 90);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(116, 81);
            this.btnStop.TabIndex = 23;
            this.toolTip1.SetToolTip(this.btnStop, "Pause the Screensharing");
            this.btnStop.UseVisualStyleBackColor = false;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // labCapture
            // 
            this.labCapture.AutoSize = true;
            this.labCapture.BackColor = System.Drawing.Color.Transparent;
            this.labCapture.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labCapture.ForeColor = System.Drawing.Color.White;
            this.labCapture.Location = new System.Drawing.Point(12, 10);
            this.labCapture.Name = "labCapture";
            this.labCapture.Size = new System.Drawing.Size(86, 16);
            this.labCapture.TabIndex = 22;
            this.labCapture.Text = "Capture area";
            // 
            // pnlShot
            // 
            this.pnlShot.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlShot.BackColor = System.Drawing.Color.LimeGreen;
            this.pnlShot.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlShot.Location = new System.Drawing.Point(12, 29);
            this.pnlShot.Name = "pnlShot";
            this.pnlShot.Size = new System.Drawing.Size(500, 500);
            this.pnlShot.TabIndex = 21;
            // 
            // btnStart
            // 
            this.btnStart.BackColor = System.Drawing.Color.Transparent;
            this.btnStart.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnStart.BackgroundImage")));
            this.btnStart.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnStart.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnStart.FlatAppearance.BorderSize = 0;
            this.btnStart.FlatAppearance.CheckedBackColor = System.Drawing.Color.Black;
            this.btnStart.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black;
            this.btnStart.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.btnStart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStart.ForeColor = System.Drawing.Color.White;
            this.btnStart.Location = new System.Drawing.Point(3, 3);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(116, 81);
            this.btnStart.TabIndex = 20;
            this.toolTip1.SetToolTip(this.btnStart, "Start the Screensharing");
            this.btnStart.UseVisualStyleBackColor = false;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // labConnected
            // 
            this.labConnected.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labConnected.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labConnected.Location = new System.Drawing.Point(774, 58);
            this.labConnected.Name = "labConnected";
            this.labConnected.Size = new System.Drawing.Size(132, 116);
            this.labConnected.TabIndex = 30;
            this.labConnected.Text = " not connected";
            // 
            // labPreview
            // 
            this.labPreview.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labPreview.AutoSize = true;
            this.labPreview.BackColor = System.Drawing.Color.Transparent;
            this.labPreview.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labPreview.ForeColor = System.Drawing.Color.White;
            this.labPreview.Location = new System.Drawing.Point(518, 10);
            this.labPreview.Name = "labPreview";
            this.labPreview.Size = new System.Drawing.Size(56, 16);
            this.labPreview.TabIndex = 31;
            this.labPreview.Text = "Preview";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.btnStart, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.btnStop, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.btnResize, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.btnConfig, 0, 3);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(777, 177);
            this.tableLayoutPanel2.MaximumSize = new System.Drawing.Size(122, 430);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 4;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(122, 349);
            this.tableLayoutPanel2.TabIndex = 32;
            // 
            // btnResize
            // 
            this.btnResize.BackColor = System.Drawing.Color.Transparent;
            this.btnResize.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnResize.BackgroundImage")));
            this.btnResize.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnResize.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnResize.FlatAppearance.BorderSize = 0;
            this.btnResize.FlatAppearance.CheckedBackColor = System.Drawing.Color.Black;
            this.btnResize.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black;
            this.btnResize.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.btnResize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnResize.ForeColor = System.Drawing.Color.White;
            this.btnResize.Location = new System.Drawing.Point(3, 177);
            this.btnResize.Name = "btnResize";
            this.btnResize.Size = new System.Drawing.Size(116, 81);
            this.btnResize.TabIndex = 24;
            this.toolTip1.SetToolTip(this.btnResize, "Resize the Window to its Original size");
            this.btnResize.UseVisualStyleBackColor = false;
            this.btnResize.Click += new System.EventHandler(this.btnResize_Click);
            // 
            // btnConfig
            // 
            this.btnConfig.BackColor = System.Drawing.Color.Transparent;
            this.btnConfig.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnConfig.BackgroundImage")));
            this.btnConfig.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnConfig.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnConfig.FlatAppearance.BorderSize = 0;
            this.btnConfig.FlatAppearance.CheckedBackColor = System.Drawing.Color.Black;
            this.btnConfig.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black;
            this.btnConfig.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.btnConfig.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConfig.ForeColor = System.Drawing.Color.White;
            this.btnConfig.Location = new System.Drawing.Point(3, 264);
            this.btnConfig.Name = "btnConfig";
            this.btnConfig.Size = new System.Drawing.Size(116, 82);
            this.btnConfig.TabIndex = 25;
            this.toolTip1.SetToolTip(this.btnConfig, "Change the settings");
            this.btnConfig.UseVisualStyleBackColor = false;
            this.btnConfig.Click += new System.EventHandler(this.btnConfig_Click);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // toolTip1
            // 
            this.toolTip1.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.toolTip1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            // 
            // Share
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.ClientSize = new System.Drawing.Size(911, 539);
            this.Controls.Add(this.tableLayoutPanel2);
            this.Controls.Add(this.labConnected);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.btnConnect);
            this.Controls.Add(this.labCapture);
            this.Controls.Add(this.pnlShot);
            this.Controls.Add(this.labPreview);
            this.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(500, 100);
            this.Name = "Share";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.Text = "Screen-Share";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Share_FormClosing);
            this.Load += new System.EventHandler(this.Share_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbPrevOrig)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPrevMatrix)).EndInit();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.PictureBox pbPrevOrig;
        private System.Windows.Forms.PictureBox pbPrevMatrix;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Label labCapture;
        private System.Windows.Forms.Panel pnlShot;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Label labConnected;
        private System.Windows.Forms.Label labPreview;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Button btnResize;
        private System.Windows.Forms.Button btnConfig;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}

