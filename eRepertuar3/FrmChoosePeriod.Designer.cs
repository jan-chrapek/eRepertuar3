namespace eRepertuar3
{
    partial class FrmChoosePeriod
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Shortcut = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Checkboxes = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Priority = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PeriodName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.linkLabel3 = new System.Windows.Forms.LinkLabel();
            this.label1 = new System.Windows.Forms.Label();
            this.llMass = new System.Windows.Forms.LinkLabel();
            this.llFolder = new System.Windows.Forms.LinkLabel();
            this.llTODO = new System.Windows.Forms.LinkLabel();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Shortcut,
            this.Checkboxes,
            this.Priority,
            this.PeriodName});
            this.dataGridView1.Location = new System.Drawing.Point(289, 31);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(461, 302);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.Tag = "1";
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            this.dataGridView1.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellEndEdit);
            // 
            // Shortcut
            // 
            this.Shortcut.HeaderText = "";
            this.Shortcut.Name = "Shortcut";
            this.Shortcut.ReadOnly = true;
            this.Shortcut.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Shortcut.Visible = false;
            this.Shortcut.Width = 20;
            // 
            // Checkboxes
            // 
            this.Checkboxes.HeaderText = "Wybierz";
            this.Checkboxes.Name = "Checkboxes";
            this.Checkboxes.Width = 50;
            // 
            // Priority
            // 
            this.Priority.HeaderText = "Priorytet";
            this.Priority.Name = "Priority";
            this.Priority.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Priority.Width = 50;
            // 
            // PeriodName
            // 
            this.PeriodName.HeaderText = "Nazwa okresu";
            this.PeriodName.Name = "PeriodName";
            this.PeriodName.ReadOnly = true;
            this.PeriodName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.PeriodName.Width = 600;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Location = new System.Drawing.Point(370, 339);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(380, 23);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Pokaż pieśni + otwórz części stałe";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnOK.Location = new System.Drawing.Point(289, 339);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 5;
            this.btnOK.Text = "Pokaż pieśni";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // linkLabel3
            // 
            this.linkLabel3.AutoSize = true;
            this.linkLabel3.Location = new System.Drawing.Point(286, 9);
            this.linkLabel3.Name = "linkLabel3";
            this.linkLabel3.Size = new System.Drawing.Size(47, 13);
            this.linkLabel3.TabIndex = 8;
            this.linkLabel3.TabStop = true;
            this.linkLabel3.Text = "Czytania";
            this.linkLabel3.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel3_LinkClicked);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Wyłączyć dźwięk!";
            // 
            // llMass
            // 
            this.llMass.AutoSize = true;
            this.llMass.Location = new System.Drawing.Point(12, 111);
            this.llMass.Name = "llMass";
            this.llMass.Size = new System.Drawing.Size(65, 13);
            this.llMass.TabIndex = 10;
            this.llMass.TabStop = true;
            this.llMass.Text = "Części stałe";
            this.llMass.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel4_LinkClicked);
            // 
            // llFolder
            // 
            this.llFolder.AutoSize = true;
            this.llFolder.Location = new System.Drawing.Point(12, 132);
            this.llFolder.Name = "llFolder";
            this.llFolder.Size = new System.Drawing.Size(272, 13);
            this.llFolder.TabIndex = 13;
            this.llFolder.TabStop = true;
            this.llFolder.Text = "Msza św. nabożeństwa, teksty pieśni, spisy świąt - folder";
            this.llFolder.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel6_LinkClicked);
            // 
            // llTODO
            // 
            this.llTODO.AutoSize = true;
            this.llTODO.Location = new System.Drawing.Point(13, 153);
            this.llTODO.Name = "llTODO";
            this.llTODO.Size = new System.Drawing.Size(38, 13);
            this.llTODO.TabIndex = 14;
            this.llTODO.TabStop = true;
            this.llTODO.Text = "TODO";
            this.llTODO.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llTODO_LinkClicked);
            // 
            // FrmChoosePeriod
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(762, 392);
            this.Controls.Add(this.llTODO);
            this.Controls.Add(this.llFolder);
            this.Controls.Add(this.llMass);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.linkLabel3);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.dataGridView1);
            this.Name = "WyborOkresu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Start";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.WyborOkresu_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.LinkLabel linkLabel3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.LinkLabel llMass;
        private System.Windows.Forms.LinkLabel llFolder;
        private System.Windows.Forms.DataGridViewTextBoxColumn Shortcut;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Checkboxes;
        private System.Windows.Forms.DataGridViewTextBoxColumn Priority;
        private System.Windows.Forms.DataGridViewTextBoxColumn PeriodName;
        private System.Windows.Forms.LinkLabel llTODO;
    }
}