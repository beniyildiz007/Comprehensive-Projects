
namespace _03_Ogrenci_Yurt_Kayit_Otomasyonu
{
    partial class frmPersonel
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPersonel));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnGuncelle = new System.Windows.Forms.Button();
            this.btnSil = new System.Windows.Forms.Button();
            this.btnKaydet = new System.Windows.Forms.Button();
            this.txtPersonelGorev = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtPersonelAdi = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtPersonelID = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dbYurtOtomasyonuDataSet6 = new _03_Ogrenci_Yurt_Kayit_Otomasyonu.dbYurtOtomasyonuDataSet6();
            this.tBLPERSONELBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tBLPERSONELTableAdapter = new _03_Ogrenci_Yurt_Kayit_Otomasyonu.dbYurtOtomasyonuDataSet6TableAdapters.TBLPERSONELTableAdapter();
            this.pERSONELIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pERSONELADSOYADDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pERSONELDEPARTMANDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbYurtOtomasyonuDataSet6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tBLPERSONELBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.pERSONELIDDataGridViewTextBoxColumn,
            this.pERSONELADSOYADDataGridViewTextBoxColumn,
            this.pERSONELDEPARTMANDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.tBLPERSONELBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(12, 235);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(626, 290);
            this.dataGridView1.TabIndex = 19;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // btnGuncelle
            // 
            this.btnGuncelle.Location = new System.Drawing.Point(417, 171);
            this.btnGuncelle.Name = "btnGuncelle";
            this.btnGuncelle.Size = new System.Drawing.Size(139, 49);
            this.btnGuncelle.TabIndex = 18;
            this.btnGuncelle.Text = "Güncelle";
            this.btnGuncelle.UseVisualStyleBackColor = true;
            this.btnGuncelle.Click += new System.EventHandler(this.btnGuncelle_Click);
            // 
            // btnSil
            // 
            this.btnSil.Location = new System.Drawing.Point(247, 171);
            this.btnSil.Name = "btnSil";
            this.btnSil.Size = new System.Drawing.Size(139, 49);
            this.btnSil.TabIndex = 17;
            this.btnSil.Text = "Sil";
            this.btnSil.UseVisualStyleBackColor = true;
            this.btnSil.Click += new System.EventHandler(this.btnSil_Click);
            // 
            // btnKaydet
            // 
            this.btnKaydet.Location = new System.Drawing.Point(83, 171);
            this.btnKaydet.Name = "btnKaydet";
            this.btnKaydet.Size = new System.Drawing.Size(139, 49);
            this.btnKaydet.TabIndex = 16;
            this.btnKaydet.Text = "Kaydet";
            this.btnKaydet.UseVisualStyleBackColor = true;
            this.btnKaydet.Click += new System.EventHandler(this.btnKaydet_Click);
            // 
            // txtPersonelGorev
            // 
            this.txtPersonelGorev.Location = new System.Drawing.Point(228, 116);
            this.txtPersonelGorev.Name = "txtPersonelGorev";
            this.txtPersonelGorev.Size = new System.Drawing.Size(237, 26);
            this.txtPersonelGorev.TabIndex = 15;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(100, 119);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(122, 18);
            this.label3.TabIndex = 14;
            this.label3.Text = "Personel Görev:";
            // 
            // txtPersonelAdi
            // 
            this.txtPersonelAdi.Location = new System.Drawing.Point(228, 84);
            this.txtPersonelAdi.Name = "txtPersonelAdi";
            this.txtPersonelAdi.Size = new System.Drawing.Size(237, 26);
            this.txtPersonelAdi.TabIndex = 13;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(124, 87);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 18);
            this.label2.TabIndex = 12;
            this.label2.Text = "Personel Ad:";
            // 
            // txtPersonelID
            // 
            this.txtPersonelID.Enabled = false;
            this.txtPersonelID.Location = new System.Drawing.Point(228, 52);
            this.txtPersonelID.Name = "txtPersonelID";
            this.txtPersonelID.Size = new System.Drawing.Size(237, 26);
            this.txtPersonelID.TabIndex = 11;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(126, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 18);
            this.label1.TabIndex = 10;
            this.label1.Text = "Personel ID:";
            // 
            // dbYurtOtomasyonuDataSet6
            // 
            this.dbYurtOtomasyonuDataSet6.DataSetName = "dbYurtOtomasyonuDataSet6";
            this.dbYurtOtomasyonuDataSet6.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // tBLPERSONELBindingSource
            // 
            this.tBLPERSONELBindingSource.DataMember = "TBLPERSONEL";
            this.tBLPERSONELBindingSource.DataSource = this.dbYurtOtomasyonuDataSet6;
            // 
            // tBLPERSONELTableAdapter
            // 
            this.tBLPERSONELTableAdapter.ClearBeforeFill = true;
            // 
            // pERSONELIDDataGridViewTextBoxColumn
            // 
            this.pERSONELIDDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.pERSONELIDDataGridViewTextBoxColumn.DataPropertyName = "PERSONELID";
            this.pERSONELIDDataGridViewTextBoxColumn.HeaderText = "id";
            this.pERSONELIDDataGridViewTextBoxColumn.Name = "pERSONELIDDataGridViewTextBoxColumn";
            this.pERSONELIDDataGridViewTextBoxColumn.ReadOnly = true;
            this.pERSONELIDDataGridViewTextBoxColumn.Width = 194;
            // 
            // pERSONELADSOYADDataGridViewTextBoxColumn
            // 
            this.pERSONELADSOYADDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.pERSONELADSOYADDataGridViewTextBoxColumn.DataPropertyName = "PERSONELADSOYAD";
            this.pERSONELADSOYADDataGridViewTextBoxColumn.HeaderText = "PERSONELADSOYAD";
            this.pERSONELADSOYADDataGridViewTextBoxColumn.Name = "pERSONELADSOYADDataGridViewTextBoxColumn";
            // 
            // pERSONELDEPARTMANDataGridViewTextBoxColumn
            // 
            this.pERSONELDEPARTMANDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.pERSONELDEPARTMANDataGridViewTextBoxColumn.DataPropertyName = "PERSONELDEPARTMAN";
            this.pERSONELDEPARTMANDataGridViewTextBoxColumn.HeaderText = "PERSONELDEPARTMAN";
            this.pERSONELDEPARTMANDataGridViewTextBoxColumn.Name = "pERSONELDEPARTMANDataGridViewTextBoxColumn";
            // 
            // frmPersonel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(650, 537);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btnGuncelle);
            this.Controls.Add(this.btnSil);
            this.Controls.Add(this.btnKaydet);
            this.Controls.Add(this.txtPersonelGorev);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtPersonelAdi);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtPersonelID);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Georgia", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmPersonel";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmPersonel";
            this.Load += new System.EventHandler(this.frmPersonel_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbYurtOtomasyonuDataSet6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tBLPERSONELBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnGuncelle;
        private System.Windows.Forms.Button btnSil;
        private System.Windows.Forms.Button btnKaydet;
        private System.Windows.Forms.TextBox txtPersonelGorev;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtPersonelAdi;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtPersonelID;
        private System.Windows.Forms.Label label1;
        private dbYurtOtomasyonuDataSet6 dbYurtOtomasyonuDataSet6;
        private System.Windows.Forms.BindingSource tBLPERSONELBindingSource;
        private dbYurtOtomasyonuDataSet6TableAdapters.TBLPERSONELTableAdapter tBLPERSONELTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn pERSONELIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn pERSONELADSOYADDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn pERSONELDEPARTMANDataGridViewTextBoxColumn;
    }
}