using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace eRepertuar3
{
    public partial class SongDetails : UserControl
    {
        public FrmText frmTekst;
        public Form1 form1;
        public FrmSongDetails frmSongDetails;
        public BazaDataSet.PiesniRow p;

        public SongDetails()
        {
            InitializeComponent();
            frmTekst = new FrmText();
        }

        private void txtRefren_TextChanged(object sender, EventArgs e)
        {
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Dictionary<CheckState, int> checkStateToInt = new Dictionary<CheckState, int>();
            checkStateToInt.Add(CheckState.Unchecked, 0);
            checkStateToInt.Add(CheckState.Indeterminate, 1);
            checkStateToInt.Add(CheckState.Checked, 2);

            int l = checkStateToInt[cbL.CheckState];
            int b = checkStateToInt[cbB.CheckState];
            int d = checkStateToInt[cbD.CheckState];
            p.p_Kto_umie_BIN = 100*l+10*b+d;

            if (txtCzasMin.Text == "--:--"||txtCzasMin.Text == "")
                p.Setp_Czas_trwania_minNull();
            else
                p.p_Czas_trwania_min = TimeSpan.Parse("0:" + txtCzasMin.Text);

            if (txtCzasMax.Text == "--:--" || txtCzasMax.Text == "")
                p.Setp_Czas_trwania_maxNull();
            else
                p.p_Czas_trwania_max = TimeSpan.Parse("0:" + txtCzasMax.Text);

            if (txtTrans.Text == "?")
                p.Setp_TransNull();
            else
                p.p_Trans = Int32.Parse(txtTrans.Text);

            p.p_Zakres=txtZakres.Text;
            p.p_Przygrywka_ak=txtPrzygrywkaAk.Text;
            p.p_Przygrywka_dzw=txtPrzygrywkaDzw.Text;
            p.p_Piesn_ak=txtPiesnAk.Text;
            p.p_Piesn_dzw = txtPiesnDzw.Text;

            if (cbFiles.SelectedIndex == -1)
            {
                if (cbFiles.Text == "")
                {
                    p.Setp_PlikNull();
                    llPlik.Enabled = false;
                }
                else
                    p.p_Plik = cbFiles.Text;
            }
            else
                p.p_Plik = form1.songFiles[cbFiles.SelectedIndex];

            p.p_Tekst = frmTekst.txtTekst.Text;
            p.p_Wersja_papierowa=txtWersjaPapierowa.Text;
            p.p_Refren=txtRefren.Text;
            p.p_Ilosc_zwrotek= txtIloscZwrotek.Text;
            p.p_Komentarz=txtKomentarz.Text;
            p.p_Tytul = txtTytul.Text;

            form1.saveData();

            form1.gridViewsSetEnabled(true);
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
        }

        private void label16_Click(object sender, EventArgs e)
        {
        }

        private void txtIloscZwrotek_TextChanged(object sender, EventArgs e)
        {
        }

        private void txtZakres_TextChanged(object sender, EventArgs e)
        {
        }

        private void btnTekst_Click(object sender, EventArgs e)
        {
            if(!frmTekst.Visible) frmTekst.Show(frmSongDetails);
        }

        private void llPlik_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmSongDetails.WindowState = FormWindowState.Minimized;
            form1.frmWybranePiesni.WindowState = FormWindowState.Minimized;

            string defaultFolder = FrmChoosePeriod.HomeDir+FrmChoosePeriod.SongsDir;

            if (p != null)
            {
                string str = p.p_Plik;
                if (str != "" && str != null)
                {
                    if (!File.Exists(str)) str = defaultFolder + str;
                    System.Diagnostics.Process.Start(str);
                }
            }
        }

        private void label15_Click(object sender, EventArgs e)
        {
        }

        private void cbL_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void btnAnuluj_Click(object sender, EventArgs e)
        {
            form1.gridViewsSetEnabled(true);
        }

        private void cbL_Click(object sender, EventArgs e)
        {
            form1.gridViewsSetEnabled(false);
        }

        private void txtKomentarz_KeyPress(object sender, KeyPressEventArgs e)
        {
            form1.gridViewsSetEnabled(false);
        }

        private void cbSelected_SelectedIndexChanged(object sender, EventArgs e)
        {
            int ind =cbSelected.SelectedIndex;
            if (ind > -1)
            {
                var sp = form1.selectedSongs[ind].PiesniRow;
                p = sp;
                form1.DisplaySongDetails(this, p);
                form1.RefreshFrmSelectedSongs();
            }
        }

        private void cbFiles_KeyPress(object sender, KeyPressEventArgs e)
        {
            form1.gridViewsSetEnabled(false);
        }

        private void cbFiles_Click(object sender, EventArgs e)
        {
            form1.gridViewsSetEnabled(false);
        }
    }
}