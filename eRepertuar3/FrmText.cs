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
    public partial class FrmText : Form
    {
        public Form1 form1;

        public FrmText()
        {
            InitializeComponent();
        }

        private void FrmTekst_FormClosing(object sender, FormClosingEventArgs e)
        {
            Hide();
            e.Cancel = true;
        }

        private void FrmTekst_Load(object sender, EventArgs e)
        {

        }

        private void txtTekst_KeyPress(object sender, KeyPressEventArgs e)
        {
            form1.gridViewsSetEnabled(false);
        }

        private void txtTekst_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && !e.Alt && e.KeyCode == Keys.A) txtTekst.SelectAll();
        }

        private void txtTekst_TextChanged(object sender, EventArgs e)
        {
            
        }
    }
}
