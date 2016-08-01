namespace eRepertuar3
{
    partial class FrmSongDetails
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmSongDetails));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbUp = new System.Windows.Forms.ToolStripButton();
            this.tsbDown = new System.Windows.Forms.ToolStripButton();
            this.tsbRestore = new System.Windows.Forms.ToolStripButton();
            this.tsbForm1 = new System.Windows.Forms.ToolStripButton();
            this.tsbWybranePiesni = new System.Windows.Forms.ToolStripButton();
            this.songDetails = new eRepertuar3.SongDetails();
            this.tsbStayOnTop = new System.Windows.Forms.ToolStripButton();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Left;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbUp,
            this.tsbDown,
            this.tsbRestore,
            this.tsbForm1,
            this.tsbWybranePiesni,
            this.tsbStayOnTop});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStrip1.Size = new System.Drawing.Size(33, 201);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsbUp
            // 
            this.tsbUp.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbUp.Font = new System.Drawing.Font("Wingdings", 13F);
            this.tsbUp.Image = ((System.Drawing.Image)(resources.GetObject("tsbUp.Image")));
            this.tsbUp.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbUp.Name = "tsbUp";
            this.tsbUp.Size = new System.Drawing.Size(30, 24);
            this.tsbUp.Text = "";
            this.tsbUp.Click += new System.EventHandler(this.tsbUp_Click);
            // 
            // tsbDown
            // 
            this.tsbDown.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbDown.Font = new System.Drawing.Font("Wingdings", 13F);
            this.tsbDown.Image = ((System.Drawing.Image)(resources.GetObject("tsbDown.Image")));
            this.tsbDown.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbDown.Name = "tsbDown";
            this.tsbDown.Size = new System.Drawing.Size(30, 24);
            this.tsbDown.Text = "";
            this.tsbDown.Click += new System.EventHandler(this.tsbDown_Click);
            // 
            // tsbRestore
            // 
            this.tsbRestore.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbRestore.Font = new System.Drawing.Font("Webdings", 13F);
            this.tsbRestore.Image = ((System.Drawing.Image)(resources.GetObject("tsbRestore.Image")));
            this.tsbRestore.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbRestore.Name = "tsbRestore";
            this.tsbRestore.Size = new System.Drawing.Size(30, 25);
            this.tsbRestore.Text = "";
            this.tsbRestore.Click += new System.EventHandler(this.tsbRestore_Click);
            // 
            // tsbForm1
            // 
            this.tsbForm1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbForm1.Font = new System.Drawing.Font("Wingdings", 13F);
            this.tsbForm1.Image = ((System.Drawing.Image)(resources.GetObject("tsbForm1.Image")));
            this.tsbForm1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbForm1.Name = "tsbForm1";
            this.tsbForm1.Size = new System.Drawing.Size(30, 24);
            this.tsbForm1.Text = "";
            this.tsbForm1.Click += new System.EventHandler(this.tsbForm1_Click);
            // 
            // tsbWybranePiesni
            // 
            this.tsbWybranePiesni.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbWybranePiesni.Font = new System.Drawing.Font("Webdings", 13F);
            this.tsbWybranePiesni.Image = ((System.Drawing.Image)(resources.GetObject("tsbWybranePiesni.Image")));
            this.tsbWybranePiesni.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbWybranePiesni.Name = "tsbWybranePiesni";
            this.tsbWybranePiesni.Size = new System.Drawing.Size(30, 25);
            this.tsbWybranePiesni.Text = "";
            this.tsbWybranePiesni.Click += new System.EventHandler(this.tsbWybranePiesni_Click);
            // 
            // songDetails
            // 
            this.songDetails.Location = new System.Drawing.Point(36, 1);
            this.songDetails.Name = "songDetails";
            this.songDetails.Size = new System.Drawing.Size(650, 200);
            this.songDetails.TabIndex = 0;
            this.songDetails.Load += new System.EventHandler(this.songDetails_Load);
            // 
            // tsbStayOnTop
            // 
            this.tsbStayOnTop.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbStayOnTop.Image = ((System.Drawing.Image)(resources.GetObject("tsbStayOnTop.Image")));
            this.tsbStayOnTop.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbStayOnTop.Name = "tsbStayOnTop";
            this.tsbStayOnTop.Size = new System.Drawing.Size(30, 19);
            this.tsbStayOnTop.Text = "*";
            // 
            // FrmSongDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(672, 201);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.songDetails);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Location = new System.Drawing.Point(0, 497);
            this.MaximizeBox = false;
            this.Name = "FrmSongDetails";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Szczegóły";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmSongDetails_FormClosing);
            this.Load += new System.EventHandler(this.FrmSongDetails_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public SongDetails songDetails;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsbUp;
        private System.Windows.Forms.ToolStripButton tsbForm1;
        private System.Windows.Forms.ToolStripButton tsbRestore;
        private System.Windows.Forms.ToolStripButton tsbWybranePiesni;
        private System.Windows.Forms.ToolStripButton tsbDown;
        private System.Windows.Forms.ToolStripButton tsbStayOnTop;

    }
}