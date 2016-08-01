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
    public partial class FrmChoosePeriod : Form
    {
        private Form1 form1;
        private int[] periodIDs;

        public const string
            HomeDir = @"C:\Users\netbook\Documents\eRepertuar\",
            SongsDir = @"Pieśni\",
            MassFile = @"Msza św., nabożeństwa\Msza św. - ks. Jarosław Ciszek.odt",
            ReadingsFile = @"file:///C:/Users/netbook/WinHTTrack/Czytania/liturgia.niedziela.pl/spis_liturgia3b5b.html?p=201508",
            TodoFile = @"C:\Users\netbook\Documents\Visual Studio 2010\Projects\eRepertuar3\eRepertuar3\TODO.txt";

        private int modifiedDV;
        private int currentPriority;

        public FrmChoosePeriod(Form1 f)
        {
            InitializeComponent();
            form1 = f;

            modifiedDV = -1;
            currentPriority = 1;
        }

        public void buildList()
        {
            //string[] KEYS = { "1", "2", "3", "4", "5", "6", "7", "8", "9", "0", "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z" };

            var o=form1.bazaDataSet.Okresy;
            periodIDs = new int[o.Count+1];
            dataGridView1.Rows.Clear();
            dataGridView1.Rows.Add(o.Count+1);

            var main = from record in o
                       where record.o_Glowny==1
                       orderby record.o_Chronologia
                       select record;

            int ind = -1;
            foreach (var period in main)
            {
                ind++;
                periodIDs[ind] = period.o_ID;

                //dataGridView1.Rows[ind].Cells[Shortcut.Index].Value = KEYS[ind];
                dataGridView1.Rows[ind].Cells[Checkboxes.Index].Value = false;
                dataGridView1.Rows[ind].Cells[PeriodName.Index].Value = period.o_Nazwa;

                var sub = from record in period.GetOkresyRows()
                          orderby record.o_Chronologia
                          select record;

                foreach (var s in sub)
                {
                    ind++;

                    periodIDs[ind] = s.o_ID;

                    //dataGridView1.Rows[ind].Cells[Shortcut.Index].Value = KEYS[ind];
                    dataGridView1.Rows[ind].Cells[Checkboxes.Index].Value = false;
                    dataGridView1.Rows[ind].Cells[PeriodName.Index].Value = "    " + s.o_Nazwa;
                }
            }

            //dataGridView1.Rows[o.Count].Cells[Shortcut.Index].Value = KEYS[o.Count];
            dataGridView1.Rows[o.Count].Cells[Checkboxes.Index].Value = false;
            dataGridView1.Rows[o.Count].Cells[PeriodName.Index].Value = "<nieprzypisane do okresu>";
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            btnOK_Click(sender, e);
            linkLabel4_LinkClicked(sender, null);
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            DataGridViewCheckBoxCell cb1 = (DataGridViewCheckBoxCell)dataGridView1[Checkboxes.Index,0];

            if ((bool)cb1.Value == true)
            {
                DialogResult dialogResult = MessageBox.Show("Czy rozpoczął się nowy rok liturgiczny?", "eRepertuar",
                                MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    form1.NewLiturgicalYear();
                }
            }
            var selected = from r in dataGridView1.Rows.Cast<DataGridViewRow>()
                           where (bool)r.Cells[Checkboxes.Index].Value == true
                           let pVal = r.Cells[Priority.Index].Value
                           let priority = (pVal == null ? (int?)null : (int?) Int32.Parse((string)pVal))
                           orderby priority
                           select new ChoosenPeriodsInfo { ID = periodIDs[r.Index], Priority = (int) priority };

            form1.buildSongsLists(selected);
            form1.Show();
            CloseForm();
        }

        private void CloseForm()
        {
            Hide();
            form1.SetTopmost(true);
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(ReadingsFile);
        }

        private void linkLabel6_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(HomeDir);
        }

        private void linkLabel4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(HomeDir+MassFile);
        }

        private void WyborOkresu_FormClosing(object sender, FormClosingEventArgs e)
        {
            CloseForm();
            e.Cancel = true;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var s = (DataGridView)sender;
            int tag = 1;
            if (s.CurrentRow != null && e.ColumnIndex == Checkboxes.Index)
            {
                if (s.IsCurrentCellDirty)
                {
                    modifiedDV = tag;
                    s.EndEdit();
                }
            }
        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            var s = (DataGridView)sender;
            int tag = 1;
            if (s.CurrentRow != null && e.ColumnIndex == Checkboxes.Index && modifiedDV == tag)
            {
                modifiedDV = -1;
                if ((bool)s.CurrentCell.Value == true)
                {
                    s.CurrentRow.Cells[Priority.Index].Value = ""+currentPriority;
                    //s.Rows[<nr wiersza nadokresu>].Cells[Priority.Index].Value = currentPriority+1;
                    currentPriority++;
                }
                else
                {
                    int result;
                    if(Int32.TryParse((string)s.CurrentRow.Cells[Priority.Index].Value, out result))
                    {
                        currentPriority = result;
                    }
                    s.CurrentRow.Cells[Priority.Index].Value = null;
                }
            }
        }

        private void llTODO_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(TodoFile);
        }

        internal void AskOpenReadings()
        {
            if(MessageBox.Show("Czy otworzyć czytania?","eRepertuar",MessageBoxButtons.YesNo)==DialogResult.Yes)
                System.Diagnostics.Process.Start(FrmChoosePeriod.ReadingsFile);
            BringToFront();
        }
    }
}