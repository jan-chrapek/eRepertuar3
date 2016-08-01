namespace eRepertuar3
{
    partial class FrmText
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
            this.txtTekst = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // txtTekst
            // 
            this.txtTekst.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtTekst.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.txtTekst.Location = new System.Drawing.Point(0, 0);
            this.txtTekst.Multiline = true;
            this.txtTekst.Name = "txtTekst";
            this.txtTekst.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtTekst.Size = new System.Drawing.Size(284, 392);
            this.txtTekst.TabIndex = 0;
            this.txtTekst.TabStop = false;
            this.txtTekst.TextChanged += new System.EventHandler(this.txtTekst_TextChanged);
            this.txtTekst.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtTekst_KeyDown);
            this.txtTekst.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTekst_KeyPress);
            // 
            // FrmTekst
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 392);
            this.Controls.Add(this.txtTekst);
            this.Location = new System.Drawing.Point(1041, 0);
            this.MinimizeBox = false;
            this.Name = "FrmTekst";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Tekst";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmTekst_FormClosing);
            this.Load += new System.EventHandler(this.FrmTekst_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.TextBox txtTekst;
    }
}