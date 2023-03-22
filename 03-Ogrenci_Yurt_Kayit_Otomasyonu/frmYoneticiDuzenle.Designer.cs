
namespace _03_Ogrenci_Yurt_Kayit_Otomasyonu
{
    partial class frmYoneticiDuzenle
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmYoneticiDuzenle));
            this.label1 = new System.Windows.Forms.Label();
            this.txtYoneticiID = new System.Windows.Forms.TextBox();
            this.txtKullaniciAdi = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtSifre = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnKaydet = new System.Windows.Forms.Button();
            this.btnSil = new System.Windows.Forms.Button();
            this.btnGuncelle = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.dbYurtOtomasyonuDataSet5 = new _03_Ogrenci_Yurt_Kayit_Otomasyonu.dbYurtOtomasyonuDataSet5();
            this.tBLADMINBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tBLADMINTableAdapter = new _03_Ogrenci_Yurt_Kayit_Otomasyonu.dbYurtOtomasyonuDataSet5TableAdapters.TBLADMINTableAdapter();
            this.yONETICIIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.yONETICIADDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.yONETICISIFREDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbYurtOtomasyonuDataSet5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tBLADMINBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(99, 57);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "Yönetici ID:";
            // 
            // txtYoneticiID
            // 
            this.txtYoneticiID.Enabled = false;
            this.txtYoneticiID.Location = new System.Drawing.Point(197, 54);
            this.txtYoneticiID.Name = "txtYoneticiID";
            this.txtYoneticiID.Size = new System.Drawing.Size(237, 26);
            this.txtYoneticiID.TabIndex = 1;
            // 
            // txtKullaniciAdi
            // 
            this.txtKullaniciAdi.Location = new System.Drawing.Point(197, 86);
            this.txtKullaniciAdi.Name = "txtKullaniciAdi";
            this.txtKullaniciAdi.Size = new System.Drawing.Size(237, 26);
            this.txtKullaniciAdi.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(90, 89);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 18);
            this.label2.TabIndex = 2;
            this.label2.Text = "Kullanıcı Adı:";
            // 
            // txtSifre
            // 
            this.txtSifre.Location = new System.Drawing.Point(197, 118);
            this.txtSifre.Name = "txtSifre";
            this.txtSifre.Size = new System.Drawing.Size(237, 26);
            this.txtSifre.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(145, 121);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 18);
            this.label3.TabIndex = 4;
            this.label3.Text = "Şifre:";
            // 
            // btnKaydet
            // 
            this.btnKaydet.Location = new System.Drawing.Point(52, 173);
            this.btnKaydet.Name = "btnKaydet";
            this.btnKaydet.Size = new System.Drawing.Size(139, 49);
            this.btnKaydet.TabIndex = 6;
            this.btnKaydet.Text = "Kaydet";
            this.btnKaydet.UseVisualStyleBackColor = true;
            this.btnKaydet.Click += new System.EventHandler(this.btnKaydet_Click);
            // 
            // btnSil
            // 
            this.btnSil.Location = new System.Drawing.Point(216, 173);
            this.btnSil.Name = "btnSil";
            this.btnSil.Size = new System.Drawing.Size(139, 49);
            this.btnSil.TabIndex = 7;
            this.btnSil.Text = "Sil";
            this.btnSil.UseVisualStyleBackColor = true;
            this.btnSil.Click += new System.EventHandler(this.btnSil_Click);
            // 
            // btnGuncelle
            // 
            this.btnGuncelle.Location = new System.Drawing.Point(386, 173);
            this.btnGuncelle.Name = "btnGuncelle";
            this.btnGuncelle.Size = new System.Drawing.Size(139, 49);
            this.btnGuncelle.TabIndex = 8;
            this.btnGuncelle.Text = "Güncelle";
            this.btnGuncelle.UseVisualStyleBackColor = true;
            this.btnGuncelle.Click += new System.EventHandler(this.btnGuncelle_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.yONETICIIDDataGridViewTextBoxColumn,
            this.yONETICIADDataGridViewTextBoxColumn,
            this.yONETICISIFREDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.tBLADMINBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(12, 237);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(573, 275);
            this.dataGridView1.TabIndex = 9;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // dbYurtOtomasyonuDataSet5
            // 
            this.dbYurtOtomasyonuDataSet5.DataSetName = "dbYurtOtomasyonuDataSet5";
            this.dbYurtOtomasyonuDataSet5.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // tBLADMINBindingSource
            // 
            this.tBLADMINBindingSource.DataMember = "TBLADMIN";
            this.tBLADMINBindingSource.DataSource = this.dbYurtOtomasyonuDataSet5;
            // 
            // tBLADMINTableAdapter
            // 
            this.tBLADMINTableAdapter.ClearBeforeFill = true;
            // 
            // yONETICIIDDataGridViewTextBoxColumn
            // 
            this.yONETICIIDDataGridViewTextBoxColumn.DataPropertyName = "YONETICIID";
            this.yONETICIIDDataGridViewTextBoxColumn.HeaderText = "YONETICIID";
            this.yONETICIIDDataGridViewTextBoxColumn.Name = "yONETICIIDDataGridViewTextBoxColumn";
            this.yONETICIIDDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // yONETICIADDataGridViewTextBoxColumn
            // 
            this.yONETICIADDataGridViewTextBoxColumn.DataPropertyName = "YONETICIAD";
            this.yONETICIADDataGridViewTextBoxColumn.HeaderText = "YONETICIAD";
            this.yONETICIADDataGridViewTextBoxColumn.Name = "yONETICIADDataGridViewTextBoxColumn";
            // 
            // yONETICISIFREDataGridViewTextBoxColumn
            // 
            this.yONETICISIFREDataGridViewTextBoxColumn.DataPropertyName = "YONETICISIFRE";
            this.yONETICISIFREDataGridViewTextBoxColumn.HeaderText = "YONETICISIFRE";
            this.yONETICISIFREDataGridViewTextBoxColumn.Name = "yONETICISIFREDataGridViewTextBoxColumn";
            // 
            // frmYoneticiDuzenle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(597, 528);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btnGuncelle);
            this.Controls.Add(this.btnSil);
            this.Controls.Add(this.btnKaydet);
            this.Controls.Add(this.txtSifre);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtKullaniciAdi);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtYoneticiID);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Georgia", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmYoneticiDuzenle";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Yönetici İşlemleri";
            this.Load += new System.EventHandler(this.frmYoneticiDuzenle_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbYurtOtomasyonuDataSet5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tBLADMINBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtYoneticiID;
        private System.Windows.Forms.TextBox txtKullaniciAdi;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtSifre;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnKaydet;
        private System.Windows.Forms.Button btnSil;
        private System.Windows.Forms.Button btnGuncelle;
        private System.Windows.Forms.DataGridView dataGridView1;
        private dbYurtOtomasyonuDataSet5 dbYurtOtomasyonuDataSet5;
        private System.Windows.Forms.BindingSource tBLADMINBindingSource;
        private dbYurtOtomasyonuDataSet5TableAdapters.TBLADMINTableAdapter tBLADMINTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn yONETICIIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn yONETICIADDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn yONETICISIFREDataGridViewTextBoxColumn;
    }
}