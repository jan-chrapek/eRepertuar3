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
    public partial class FrmChoosenSongs : Form
    {
        public FrmChoosenSongs()
        {
            InitializeComponent();
        }

        private void FrmWybranePiesni_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void FrmWybranePiesni_FormClosing(object sender, FormClosingEventArgs e)
        {
            Hide();
            e.Cancel = true;
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            //e.Handled = true; //Zamiast ustawienia właściwości ReadOnly = true, co nie pozwoliłoby zmienić koloru czcionki
        }

        private void FrmWybranePiesni_MouseEnter(object sender, EventArgs e)
        {
            Opacity = 0.25;
        }

        private void FrmWybranePiesni_MouseLeave(object sender, EventArgs e)
        {
            Opacity = 1;
        }
    }
}
