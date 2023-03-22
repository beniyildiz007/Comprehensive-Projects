
namespace _03_Ogrenci_Yurt_Kayit_Otomasyonu
{
    partial class frmBolumler
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBolumler));
            this.label1 = new System.Windows.Forms.Label();
            this.txtBolumID = new System.Windows.Forms.TextBox();
            this.txtBolumAD = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.pcEkle = new System.Windows.Forms.PictureBox();
            this.pcSil = new System.Windows.Forms.PictureBox();
            this.pcDuzenle = new System.Windows.Forms.PictureBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.dbYurtOtomasyonuDataSet = new _03_Ogrenci_Yurt_Kayit_Otomasyonu.dbYurtOtomasyonuDataSet();
            this.tBLBOLUMLERBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tBLBOLUMLERTableAdapter = new _03_Ogrenci_Yurt_Kayit_Otomasyonu.dbYurtOtomasyonuDataSetTableAdapters.TBLBOLUMLERTableAdapter();
            this.bOLUMIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bOLUMADDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pcEkle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcSil)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcDuzenle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbYurtOtomasyonuDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tBLBOLUMLERBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(103, 92);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "Bölüm ID:";
            // 
            // txtBolumID
            // 
            this.txtBolumID.Enabled = false;
            this.txtBolumID.Location = new System.Drawing.Point(189, 89);
            this.txtBolumID.Name = "txtBolumID";
            this.txtBolumID.Size = new System.Drawing.Size(230, 26);
            this.txtBolumID.TabIndex = 1;
            // 
            // txtBolumAD
            // 
            this.txtBolumAD.Location = new System.Drawing.Point(189, 131);
            this.txtBolumAD.Name = "txtBolumAD";
            this.txtBolumAD.Size = new System.Drawing.Size(230, 26);
            this.txtBolumAD.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(97, 134);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 18);
            this.label2.TabIndex = 2;
            this.label2.Text = "Bölüm Adı:";
            // 
            // pcEkle
            // 
            this.pcEkle.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pcEkle.Image = ((System.Drawing.Image)(resources.GetObject("pcEkle.Image")));
            this.pcEkle.Location = new System.Drawing.Point(496, 57);
            this.pcEkle.Name = "pcEkle";
            this.pcEkle.Size = new System.Drawing.Size(139, 70);
            this.pcEkle.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pcEkle.TabIndex = 4;
            this.pcEkle.TabStop = false;
            this.toolTip1.SetToolTip(this.pcEkle, "Bölüm Ekle");
            this.pcEkle.Click += new System.EventHandler(this.pcEkle_Click);
            // 
            // pcSil
            // 
            this.pcSil.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pcSil.Image = ((System.Drawing.Image)(resources.GetObject("pcSil.Image")));
            this.pcSil.Location = new System.Drawing.Point(641, 57);
            this.pcSil.Name = "pcSil";
            this.pcSil.Size = new System.Drawing.Size(139, 70);
            this.pcSil.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pcSil.TabIndex = 5;
            this.pcSil.TabStop = false;
            this.toolTip1.SetToolTip(this.pcSil, "Bölüm Sil");
            this.pcSil.Click += new System.EventHandler(this.pcSil_Click);
            // 
            // pcDuzenle
            // 
            this.pcDuzenle.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pcDuzenle.Image = ((System.Drawing.Image)(resources.GetObject("pcDuzenle.Image")));
            this.pcDuzenle.Location = new System.Drawing.Point(569, 133);
            this.pcDuzenle.Name = "pcDuzenle";
            this.pcDuzenle.Size = new System.Drawing.Size(139, 70);
            this.pcDuzenle.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pcDuzenle.TabIndex = 6;
            this.pcDuzenle.TabStop = false;
            this.toolTip1.SetToolTip(this.pcDuzenle, "Bölüm Düzenle");
            this.pcDuzenle.Click += new System.EventHandler(this.pcDuzenle_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.bOLUMIDDataGridViewTextBoxColumn,
            this.bOLUMADDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.tBLBOLUMLERBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(12, 269);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(826, 273);
            this.dataGridView1.TabIndex = 7;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // dbYurtOtomasyonuDataSet
            // 
            this.dbYurtOtomasyonuDataSet.DataSetName = "dbYurtOtomasyonuDataSet";
            this.dbYurtOtomasyonuDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // tBLBOLUMLERBindingSource
            // 
            this.tBLBOLUMLERBindingSource.DataMember = "TBLBOLUMLER";
            this.tBLBOLUMLERBindingSource.DataSource = this.dbYurtOtomasyonuDataSet;
            // 
            // tBLBOLUMLERTableAdapter
            // 
            this.tBLBOLUMLERTableAdapter.ClearBeforeFill = true;
            // 
            // bOLUMIDDataGridViewTextBoxColumn
            // 
            this.bOLUMIDDataGridViewTextBoxColumn.DataPropertyName = "BOLUMID";
            this.bOLUMIDDataGridViewTextBoxColumn.HeaderText = "BOLUMID";
            this.bOLUMIDDataGridViewTextBoxColumn.Name = "bOLUMIDDataGridViewTextBoxColumn";
            this.bOLUMIDDataGridViewTextBoxColumn.ReadOnly = true;
            this.bOLUMIDDataGridViewTextBoxColumn.Width = 110;
            // 
            // bOLUMADDataGridViewTextBoxColumn
            // 
            this.bOLUMADDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.bOLUMADDataGridViewTextBoxColumn.DataPropertyName = "BOLUMAD";
            this.bOLUMADDataGridViewTextBoxColumn.HeaderText = "BOLUMAD";
            this.bOLUMADDataGridViewTextBoxColumn.Name = "bOLUMADDataGridViewTextBoxColumn";
            // 
            // frmBolumler
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(850, 554);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.pcDuzenle);
            this.Controls.Add(this.pcSil);
            this.Controls.Add(this.pcEkle);
            this.Controls.Add(this.txtBolumAD);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtBolumID);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Georgia", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmBolumler";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Bölümler";
            this.Load += new System.EventHandler(this.frmBolumler_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pcEkle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcSil)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcDuzenle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbYurtOtomasyonuDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tBLBOLUMLERBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtBolumID;
        private System.Windows.Forms.TextBox txtBolumAD;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pcEkle;
        private System.Windows.Forms.PictureBox pcSil;
        private System.Windows.Forms.PictureBox pcDuzenle;
        private System.Windows.Forms.DataGridView dataGridView1;
        private dbYurtOtomasyonuDataSet dbYurtOtomasyonuDataSet;
        private System.Windows.Forms.BindingSource tBLBOLUMLERBindingSource;
        private dbYurtOtomasyonuDataSetTableAdapters.TBLBOLUMLERTableAdapter tBLBOLUMLERTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn bOLUMIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn bOLUMADDataGridViewTextBoxColumn;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}