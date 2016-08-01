using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using MyNameSpace;

namespace eRepertuar3
{
    public struct ChoosenPeriodsInfo
    {
        public int ID;
        public int Priority;
    }

    public partial class Form1 : Form
    {
        public FrmChoosePeriod frmWyborOkresu;
        public FrmChoosenSongs frmWybranePiesni;
        private FrmSongDetails frmSongDetails1;

        private IEnumerable<BazaDataSet.CzesciRow> parts;
        private IEnumerable<BazaDataSet.Piesni_OkresyRow>[] chosen;
        private DataGridView[] dataGridViews;

        public List<BazaDataSet.Piesni_OkresyRow> selectedSongs, selectedSongsCopy;
        public List<String> songFiles;

        public bool currentLayout;

        public Form1()
        {
            InitializeComponent();

            selectedSongs = new List<BazaDataSet.Piesni_OkresyRow>();
            frmWyborOkresu = new FrmChoosePeriod(this);
            frmWybranePiesni = new FrmChoosenSongs();

            frmSongDetails1 = new FrmSongDetails(this);
            DirectoryInfo d = new DirectoryInfo(FrmChoosePeriod.HomeDir+FrmChoosePeriod.SongsDir);
            FileInfo[] Files = d.GetFiles();
            songFiles = new List<string>();
            foreach (FileInfo file in Files)
            {
                songFiles.Add(file.Name);
                frmSongDetails1.songDetails.cbFiles.Items.Add(file.Name);
            }

            modifiedDV = -1;
        }

        public void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'bazaDataSet.Czesci' table. You can move, or remove it, as needed.
            this.czesciTableAdapter.Fill(this.bazaDataSet.Czesci);
            // TODO: This line of code loads data into the 'bazaDataSet.Piesni' table. You can move, or remove it, as needed.
            this.piesniTableAdapter.Fill(this.bazaDataSet.Piesni);
            // TODO: This line of code loads data into the 'bazaDataSet.Okresy' table. You can move, or remove it, as needed.
            this.okresyTableAdapter.Fill(this.bazaDataSet.Okresy);
            // TODO: This line of code loads data into the 'bazaDataSet.Piesni' table. You can move, or remove it, as needed.
            this.piesni_OkresyTableAdapter.Fill(this.bazaDataSet.Piesni_Okresy);//to musi znaleźć się na końcu ze względu na FOREIGN KEY CONSTRAINT

            frmWyborOkresu.buildList();
            WybierzOkresy(true);
        }

        public void buildSongsLists(IEnumerable<ChoosenPeriodsInfo> cp)
        {
            choosenPeriodsInfo = cp;

            string[] KEYS = { "1", "2", "3", "4", "5", "6", "7", "8", "9", "0", "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z" };

            //o LINQ: http://msdn.microsoft.com/en-us/library/bb397676%28v=vs.110%29.aspx
            //LINQ to DataSet: http://msdn.microsoft.com/en-us/library/bb399401%28v=vs.110%29.aspx
            /*var czesci = from record in dt.AsEnumerable()
                         group record by record.Field<string>("c_Nazwa") into recordGroup
                         orderby recordGroup.Max(record => record.Field<int>("c_Chronologia"))//równie dobrze mogło być Min()
                         select recordGroup.Key;*/

            parts =   (from po in bazaDataSet.Piesni_Okresy
                          join p in cp on po.Okresy_ID equals p.ID
                          orderby po.CzesciRow.c_Chronologia
                          select po.CzesciRow).Distinct<BazaDataSet.CzesciRow>().ToList();

            chosen = new IEnumerable<BazaDataSet.Piesni_OkresyRow>[parts.Count()];

            if (parts.Count() == 0)
            {
                MessageBox.Show("Brak pieśni z wybranych okresów.");
                return;
            }

            tableLayoutPanel1.Controls.Clear();

            dataGridViews = new DataGridView[parts.Count()];

            int i = -1;
            foreach(BazaDataSet.CzesciRow part in parts)
            {
                i++;
                int tmp_i = i; //Dawniej: gdyby nie to, po zakończeniu metody LINQ użyłby ostatniej wartości "i" dla każdego elementu tablicy choosen
                chosen[i] = (from po in bazaDataSet.Piesni_Okresy
                             join cpi in cp on po.Okresy_ID equals cpi.ID
                            let sortCol = po.PiesniRow.Isp_Ostatnio_zagraneNull() ? new DateTime(0) : po.PiesniRow.p_Ostatnio_zagrane //DEBUG
                             where po.Czesci_ID == parts.ElementAt(tmp_i).c_ID
                             orderby cpi.Priority, po.Priorytet,
                             sortCol, po.PiesniRow.p_Liczba_zagr_ten_rok, po.PiesniRow.p_Liczba_zagr_total
                             select po).ToList();

                DataGridView dv = new DataGridView();
                dataGridViews[i] = dv;

                //
                // dv
                //
                dv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
                foreach (DataGridViewColumn dgvCol in dataGridView2.Columns)
                {
                    DataGridViewColumn dgvNewCol = new DataGridViewColumn();
                    dgvNewCol = (DataGridViewColumn)dgvCol.Clone();

                    dv.Columns.Add(dgvNewCol);
                }
                dv.Dock = dataGridView2.Dock;
                dv.Location = dataGridView2.Location;
                dv.RowHeadersVisible = dataGridView2.RowHeadersVisible;
                dv.Size = dataGridView2.Size;
                dv.Anchor = dataGridView2.Anchor;
                dv.SelectionChanged += new System.EventHandler(this.dataGridView2_SelectionChanged);
                dv.CellEndEdit += new DataGridViewCellEventHandler(this.dataGridView2_CellEndEdit);
                dv.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView2_CellContentClick);

                tableLayoutPanel1.Controls.Add(dv, i, 1);
                dv.Visible = true;
                dv.Tag = i;

                dv.Rows.Clear();
                dv.Rows.Add(chosen[i].Count());

                int ind = -1;
                foreach (var po in chosen[i])
                {
                    ind++;

                    var p = po.PiesniRow;

                    dv.Rows[ind].Cells[Shortcut.Index].Value = KEYS[ind];
                    dv.Rows[ind].Cells[Checkboxes.Index].Value = false;

                    string titleText;
                    switch (po.Priorytet)
                    {
                        case 1:
                            titleText = p.p_Tytul;
                            break;

                        case 2:
                            titleText = "["+p.p_Tytul+"]";
                            break;

                        case 3:
                            titleText = "[[" + p.p_Tytul + "]]";
                            break;

                        default:
                            titleText = "[[[" + p.p_Tytul + "]]]";
                            break;
                    }
                    dv.Rows[ind].Cells[SongName.Index].Value = titleText;

                    //dv.Rows[ind].Cells[Priority.Index].Value = po.Priorytet;
                    dv.Rows[ind].Cells[NumberPlayed.Index].Value = p.Field<int?>(bazaDataSet.Piesni.p_Liczba_zagr_ten_rokColumn).ToString();
                    dv.Rows[ind].Cells[LastPlayed.Index].Value = p.Isp_Ostatnio_zagraneNull() ? "" : ""+(DateTime.Now - p.p_Ostatnio_zagrane).Days;
                    dv.Rows[ind].Cells[Time.Index].Value = p.Isp_Czas_trwania_minNull() ? "" : p.p_Czas_trwania_min.ToString(@"m\:ss");
                    dv.Rows[ind].Cells[PeriodName.Index].Value = po.OkresyRow.o_Krotka_nazwa;
                }

                Label label = new Label();
                label.AutoSize = templateLabel.AutoSize;
                label.Font = templateLabel.Font;
                label.Location = templateLabel.Location;

                label.Text = part.c_Nazwa;
                label.Visible = true;

                tableLayoutPanel1.Controls.Add(label, i, 0);
            }
            currentLayout = true;
            SetWindowsLayout(currentLayout, true);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="p">true - dół, false - góra</param>
        public void SetWindowsLayout(bool p, bool show)
        {
            Form[] forms = { this, frmSongDetails1.songDetails.frmTekst, frmSongDetails1, frmWybranePiesni };
            Form[] owners = {null, frmSongDetails1, null, null};
            Point[] locationsDown = { new Point(0, 0), new Point(800, 0), new Point(0,517), new Point(685,517)};
            Point[] locationsUp = { new Point(0, 250), new Point(800, 250), new Point(0, 0), new Point(685, 0) };
            Size[] sizes = { new Size(796, 517), new Size(466, 520), new Size(678, 229), new Size(594, 248) };
            for(int i=0; i<forms.Length; i++)
            {
                var f = forms[i];
                if (!f.Visible && show)
                    if (owners[i] == null)
                        f.Show();
                    else
                        f.Show(owners[i]);
                if (show)
                {
                    f.WindowState = FormWindowState.Normal;
                    f.BringToFront();
                }
                if (p) f.Location = locationsDown[i];
                else f.Location = locationsUp[i];
                f.Size = sizes[i];
            }
        }

        private IEnumerable<ChoosenPeriodsInfo> choosenPeriodsInfo;
        private int modifiedDV;

        private void button1_Click(object sender, EventArgs e)
        {
        }

        private void dataGridView2_SelectionChanged(object sender, EventArgs e)
        {
            var dv = (DataGridView)sender;
            int i = (int) dv.Tag;
            var dt = chosen[i];

            var activeSongDetails = frmSongDetails1.songDetails; //DEBUG
            if (dv.CurrentRow != null)
            {
                int ind = dv.CurrentRow.Index;
                if (ind < dt.Count())
                {
                    var p = dt.ElementAt(ind).PiesniRow;

                    DisplaySongDetails(activeSongDetails, p);
                    activeSongDetails.cbSelected.SelectedIndex = -1;
                }
            }
        }

        public void DisplaySongDetails(SongDetails activeSongDetails, BazaDataSet.PiesniRow p)
        {
            activeSongDetails.p = p;

            CheckState[] ktoUmie = { CheckState.Unchecked, CheckState.Indeterminate, CheckState.Checked };
            int d = p.p_Kto_umie_BIN % 10;
            int b = ((p.p_Kto_umie_BIN - d) / 10) % 10;
            int l = ((p.p_Kto_umie_BIN - d - 10 * b) / 100) % 10;
            activeSongDetails.cbL.CheckState = ktoUmie[l];
            activeSongDetails.cbB.CheckState = ktoUmie[b];
            activeSongDetails.cbD.CheckState = ktoUmie[d];

            string okresy = "";

            var otherPartsPriority1 = (from po in p.GetPiesni_OkresyRows()
                                       join cpi in choosenPeriodsInfo on po.Okresy_ID equals cpi.ID
                                       where po.Priorytet == 1
                                       orderby po.CzesciRow.c_Chronologia
                                       select po.CzesciRow).Distinct<BazaDataSet.CzesciRow>();

            foreach (var c in otherPartsPriority1)
                okresy += c.c_Nazwa + ", ";

            okresy += "[";
            var otherParts = (from po in p.GetPiesni_OkresyRows()
                              join cpi in choosenPeriodsInfo on po.Okresy_ID equals cpi.ID
                              orderby po.CzesciRow.c_Chronologia
                              select po.CzesciRow).Distinct<BazaDataSet.CzesciRow>();
            var otherPartsLowerPriority = otherParts.Except<BazaDataSet.CzesciRow>(otherPartsPriority1);
            foreach (var c in otherPartsLowerPriority)
                okresy += c.c_Nazwa + ", ";
            okresy += "]; ";

            var otherPeriodsPriority1 = (from po in p.GetPiesni_OkresyRows()
                                         where po.Priorytet == 1
                                         orderby po.OkresyRow.o_Chronologia
                                         select po.OkresyRow).Distinct<BazaDataSet.OkresyRow>();

            foreach (var o in otherPeriodsPriority1)
                okresy += o.o_Krotka_nazwa + ", ";

            okresy += "[";
            var otherPeriods = (from po in p.GetPiesni_OkresyRows()
                                orderby po.OkresyRow.o_Chronologia
                                select po.OkresyRow).Distinct<BazaDataSet.OkresyRow>();

            var otherPeriodsLowerPriority = otherPeriods.Except<BazaDataSet.OkresyRow>(otherPeriodsPriority1);
            foreach (var o in otherPeriodsLowerPriority)
                okresy += o.o_Krotka_nazwa + ", ";
            okresy += "]";

            activeSongDetails.txtOkresy.Text = okresy;

            activeSongDetails.lblTenRok.Text = "" + p.p_Liczba_zagr_ten_rok;
            activeSongDetails.lblPoprzRok.Text = "" + p.p_Liczba_zagr_poprz_rok;
            activeSongDetails.lblTotal.Text = "" + p.p_Liczba_zagr_total;
            activeSongDetails.lblOstatnioZagr.Text = p.Isp_Ostatnio_zagraneNull() ? "Brak danych" :
                p.p_Ostatnio_zagrane.ToShortDateString()+(p.IsOstatnio_zagr_Czesci_IDNull()?"":
                " na \""+p.CzesciRow.c_Nazwa+"\"");
            activeSongDetails.txtCzasMin.Text = p.Isp_Czas_trwania_minNull() ? "--:--" : p.p_Czas_trwania_min.ToString(@"%m\:ss");
            activeSongDetails.txtCzasMax.Text = p.Isp_Czas_trwania_maxNull() ? "--:--" : p.p_Czas_trwania_max.ToString(@"%m\:ss");
            String trans = "";
            Color color = Color.Black;
            if (p.Isp_TransNull())
            {
                trans = "?";
            }
            else
            {
                trans = (p.p_Trans > 0 ? "+" : "") + p.p_Trans;
                if (p.p_Trans != 0) color = Color.Red;
            }
            activeSongDetails.txtTrans.Text = trans;
            activeSongDetails.txtTrans.ForeColor = color;

            activeSongDetails.txtZakres.Text = p.p_Zakres;
            activeSongDetails.txtPrzygrywkaAk.Text = p.p_Przygrywka_ak;
            activeSongDetails.txtPrzygrywkaDzw.Text = p.p_Przygrywka_dzw;
            activeSongDetails.txtPiesnAk.Text = p.p_Piesn_ak;
            activeSongDetails.txtPiesnDzw.Text = p.p_Piesn_dzw;
            activeSongDetails.llPlik.Enabled = !p.Isp_PlikNull();

            if (p.Isp_PlikNull())
            {
                activeSongDetails.cbFiles.SelectedIndex = -1;
                activeSongDetails.cbFiles.Text = "";
            }
            else
            {
                activeSongDetails.cbFiles.SelectedIndex = songFiles.IndexOf(p.p_Plik);
            }

            activeSongDetails.txtTekst.Text = p.p_Tekst;
            activeSongDetails.frmTekst.txtTekst.Text = p.p_Tekst;
            activeSongDetails.txtWersjaPapierowa.Text = p.p_Wersja_papierowa;
            activeSongDetails.txtRefren.Text = p.p_Refren;
            activeSongDetails.txtIloscZwrotek.Text = p.p_Ilosc_zwrotek;
            activeSongDetails.txtKomentarz.Text = p.p_Komentarz;
            activeSongDetails.txtTytul.Text = p.p_Tytul;
        }

        private void llPlik_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
        }

        private void piesniBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.piesniBindingSource.EndEdit();
            this.okresyBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.bazaDataSet);
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            string backupFolder = @"Kopie zapasowe\";
            string fileName=String.Format("{0}Kopia_{1}.xml",backupFolder,DateTime.Now.ToString().Replace(':','.'));
            bazaDataSet.WriteXml(fileName, XmlWriteMode.WriteSchema);
            MessageBox.Show(String.Format("Zapisano do pliku {0}.",fileName));
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            //Nie działa:
            //ofdBackup.InitialDirectory = @".\Kopie zapasowe\";
            ofdBackup.InitialDirectory = @"C:\Users\netbook\Documents\Visual Studio 2010\Projects\eRepertuar3\eRepertuar3\bin\Debug\Kopie zapasowe\";
            if (ofdBackup.ShowDialog() == DialogResult.OK)
            {
                //baza1DataSet.ReadXmlSchema("Struktura.xml");
                //baza1DataSet.ReadXml("Dane.xml");
                //trzeba najpierw skasować dane, w przeciwnym wypadku dodawałby dane z pliku XML
                //baza1DataSet.Clear(); - to nie działa; kasuje dane z pamięci, zamiast ustawić RowState=Deleted, więc zmiany nie są odzwierciedlone w bazie
                bazaDataSet.DeleteAllRows();

                bazaDataSet.ReadXml(ofdBackup.FileName, XmlReadMode.IgnoreSchema);
            }
        }

        private void btnChoose_Click(object sender, EventArgs e)
        {
            WybierzOkresy();
        }

        private void WybierzOkresy(bool messageBox = false)
        {
            SetTopmost(false);
            frmWyborOkresu.Show();
            if (messageBox)
            {
                frmWyborOkresu.AskOpenReadings();
                Hide();//nie działa
            }
        }

        public void SetTopmost(bool p)
        {
            frmWybranePiesni.TopMost = p;
            frmSongDetails1.TopMost = p;
            frmSongDetails1.songDetails.frmTekst.TopMost = p;
            frmSongDetails1.Text = (p ? "":"[TopMost=false] ") + "Szczegóły";
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            this.Validate();
            saveData();
        }

        public void saveData()
        {
            tableAdapterManager.UpdateAll(this.bazaDataSet);
        }

        private void dataGridView2_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            const int AfterMassID = 13;

            var dv1 = (DataGridView)sender;
            int partIndex = (int)dv1.Tag;
            var dt = chosen[partIndex];

            var activeSongDetails = frmSongDetails1.songDetails; //DEBUG

            if (dv1.CurrentRow != null)
            {
                int ind = dv1.CurrentRow.Index;
                var p1 = dt.ElementAt(ind).PiesniRow;

                if (e.ColumnIndex == Checkboxes.Index && modifiedDV == partIndex )
                {
                    modifiedDV = -1;

                    //Aktualizacja listy wybranych
                    selectedSongs.Clear();
                    for (int i = 0; i < parts.Count(); i++)
                    {
                        BazaDataSet.CzesciRow c = parts.ElementAt(i);
                        var dv = dataGridViews[i];
                        for (int j = 0; j < chosen[i].Count(); j++)
                        {
                            DataGridViewCheckBoxCell cb = (DataGridViewCheckBoxCell)dv.Rows[j].Cells[Checkboxes.Index];
                            if ((bool)cb.Value == true)
                            {
                                selectedSongs.Add(chosen[i].ElementAt(j));
                            }
                        }
                    }
                    RefreshSelectedSongsList();
                    RefreshFrmSelectedSongs();

                    //Odznaczenie pieśni

                    DataGridViewCheckBoxCell cb1 = (DataGridViewCheckBoxCell)dv1.CurrentCell;

                    if ((bool)cb1.Value == false)
                    {
                        frmWybranePiesni.TopMost = false;
                        frmSongDetails1.songDetails.frmTekst.TopMost = false;

                        DialogResult dialogResult = MessageBox.Show("Czy pieśń \"" + p1.p_Tytul + "\" została dzisiaj zagrana na \"" + parts.ElementAt(partIndex).c_Nazwa + "\" (Anuluj=na nabożeństwie)?", "eRepertuar",
                            MessageBoxButtons.YesNoCancel);
                        if (dialogResult == DialogResult.Yes || dialogResult == DialogResult.Cancel)
                        {
                            p1.p_Ostatnio_zagrane = DateTime.Now;
                            p1.Ostatnio_zagr_Czesci_ID = dialogResult == DialogResult.Yes?
                                parts.ElementAt(partIndex).c_ID:
                                AfterMassID;
                            p1.p_Liczba_zagr_ten_rok++;
                            p1.p_Liczba_zagr_total++;
                            saveData();

                            dv1.Rows[ind].Cells[NumberPlayed.Index].Value = p1.Field<int?>(bazaDataSet.Piesni.p_Liczba_zagr_ten_rokColumn).ToString();
                            dv1.Rows[ind].Cells[LastPlayed.Index].Value = "0";
                        }
                        frmWybranePiesni.TopMost = true;
                        frmSongDetails1.songDetails.frmTekst.TopMost = true;
                        //songDetails2
                    }
                }
            }
        }

        public void RefreshFrmSelectedSongs()
        {
            var ind = frmSongDetails1.songDetails.cbSelected.SelectedIndex;
            var groups =
                from o in selectedSongs.Skip(ind)
                group o by o.CzesciRow into g
                select g;
            var result = "";
            foreach (var g in groups)
            {
                result += g.Key.c_Nazwa + Environment.NewLine;
                var q = (from o in g let p=o.PiesniRow select $"{ p.p_Tytul} ({p.p_Wersja_papierowa})");
                result += string.Join(Environment.NewLine, q) + Environment.NewLine;
            }
            frmWybranePiesni.textBox1.Text = result;
        }

        private void RefreshSelectedSongsList()
        {
            var activeSongDetails = frmSongDetails1.songDetails;
            activeSongDetails.cbSelected.Items.Clear();
            foreach (BazaDataSet.Piesni_OkresyRow po in selectedSongs)
            {
                activeSongDetails.cbSelected.Items.Add(po.PiesniRow.p_Tytul);
            }
        }

        private void piesniBindingNavigatorSaveItem_Click_1(object sender, EventArgs e)
        {
            this.Validate();
            this.piesniBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.bazaDataSet);
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (txtTODO.Text != "")
            {
                MessageBox.Show("TODO!");
                e.Cancel = true;
                return;
            }
            if (dataGridViews != null)
            {
                foreach (DataGridView dv in dataGridViews)
                {
                    if (dv.Enabled == false)
                    {
                        MessageBox.Show("Wprowadzono niezapisane zmiany!");
                        e.Cancel = true;
                        return;
                    }
                    for (int i = 0; i < dv.RowCount - 1; i++)//ostatni wiersz jest pusty
                    {
                        DataGridViewCheckBoxCell cb = (DataGridViewCheckBoxCell)dv.Rows[i].Cells[Checkboxes.Index];
                        if ((bool)cb.Value == true)
                        {
                            MessageBox.Show("Nie odznaczono wszystkich pieśni!");
                            e.Cancel = true;
                            return;
                        }
                    }
                }
            }
            this.Validate();
            saveData();
            e.Cancel = false;
        }

        public void btnWybrane_Click(object sender, EventArgs e)
        {
            frmWybranePiesni.Show();
        }

        internal void gridViewsSetEnabled(bool b)
        {
            frmSongDetails1.songDetails.cbSelected.Enabled = b;
            frmSongDetails1.songDetails.panel1.BackColor = b ? Color.LightGreen : Color.LightSalmon;
            foreach (var dv in dataGridViews)
                dv.Enabled = b;
        }

        internal void NewLiturgicalYear()
        {
            foreach (BazaDataSet.PiesniRow p in bazaDataSet.Piesni)
            {
                p.p_Liczba_zagr_poprz_rok = p.p_Liczba_zagr_ten_rok;
                p.p_Liczba_zagr_ten_rok = 0; //Nietestowane! - 1.10.2015
                saveData();
            }
        }

        private void btnSaveChosen_Click(object sender, EventArgs e)
        {
            selectedSongsCopy = new List<BazaDataSet.Piesni_OkresyRow>();
            selectedSongsCopy.AddRange(selectedSongs);
        }

        private void btnRestoreChosen_Click(object sender, EventArgs e)
        {
            String s = "";
            selectedSongs.Clear();
            for (int i = 0; i < parts.Count(); i++)
            {
                BazaDataSet.CzesciRow c = parts.ElementAt(i);
                s += c.c_Nazwa + ":\r\n";
                var dv = dataGridViews[i];
                for (int j = 0; j < chosen[i].Count(); j++)
                {
                    DataGridViewCheckBoxCell cb = (DataGridViewCheckBoxCell)dv.Rows[j].Cells[Checkboxes.Index];
                    if (selectedSongsCopy.IndexOf(chosen[i].ElementAt(j))>-1)
                    {
                        cb.Value = true;
                        selectedSongs.Add(chosen[i].ElementAt(j));
                        var p = chosen[i].ElementAt(j).PiesniRow;
                        s += p.p_Tytul + " (" + p.p_Wersja_papierowa + ")\r\n";
                    }
                }
            }
            RefreshSelectedSongsList();
            frmWybranePiesni.textBox1.Text = s;
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var s = (DataGridView)sender;
            int partIndex = (int)s.Tag;

            if (s.CurrentRow != null)
            {
                if (e.ColumnIndex == Checkboxes.Index)
                {
                    if (s.IsCurrentCellDirty)
                    {
                        modifiedDV = partIndex;
                        s.EndEdit();
                    }
                }
            }
        }

        private void llTodo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(FrmChoosePeriod.TodoFile);
        }
    }
}