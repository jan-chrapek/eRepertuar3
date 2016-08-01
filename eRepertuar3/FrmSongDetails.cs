using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace eRepertuar3
{
    public partial class FrmSongDetails : Form
    {
        Form1 form1;
        public FrmSongDetails(Form1 f)
        {
            InitializeComponent();
            songDetails.frmSongDetails = this;
            form1 = f;
            songDetails.form1 = f;
            songDetails.frmTekst.form1 = f;            
        }

        private void FrmSongDetails_Load(object sender, EventArgs e)
        {

        }

        private void FrmSongDetails_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true; //DEBUG
        }

        private void songDetails_Load(object sender, EventArgs e)
        {

        }

        private void tsbUp_Click(object sender, EventArgs e)
        {
            form1.currentLayout = false;
            form1.SetWindowsLayout(form1.currentLayout, false);
            
        }

        private void tsbDown_Click(object sender, EventArgs e)
        {
            form1.currentLayout = true;
            form1.SetWindowsLayout(form1.currentLayout, false);
        }

        private void tsbRestore_Click(object sender, EventArgs e)
        {
            form1.SetWindowsLayout(form1.currentLayout, true);
        }

        private void tsbForm1_Click(object sender, EventArgs e)
        {
            form1.WindowState = FormWindowState.Normal;
            form1.BringToFront();
        }

        private void tsbWybranePiesni_Click(object sender, EventArgs e)
        {
            form1.btnWybrane_Click(sender, e);
        }
    }
}
