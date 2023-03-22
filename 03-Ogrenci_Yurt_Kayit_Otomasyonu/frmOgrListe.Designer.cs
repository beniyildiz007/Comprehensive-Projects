
namespace _03_Ogrenci_Yurt_Kayit_Otomasyonu
{
    partial class frmOgrListe
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmOgrListe));
            this.dbYurtOtomasyonuDataSet1 = new _03_Ogrenci_Yurt_Kayit_Otomasyonu.dbYurtOtomasyonuDataSet();
            this.dbYurtOtomasyonuDataSet2 = new _03_Ogrenci_Yurt_Kayit_Otomasyonu.dbYurtOtomasyonuDataSet();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.dbYurtOtomasyonuDataSet3 = new _03_Ogrenci_Yurt_Kayit_Otomasyonu.dbYurtOtomasyonuDataSet3();
            this.tBLOGRENCIBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tBLOGRENCITableAdapter = new _03_Ogrenci_Yurt_Kayit_Otomasyonu.dbYurtOtomasyonuDataSet3TableAdapters.TBLOGRENCITableAdapter();
            this.oGRIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.oGRADDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.oGRSOYADDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.oGRTCDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.oGRTELEFONDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.oGRDOGUMDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.oGRBOLUMDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.oGRMAILDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.oGRODANODataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.oGRVELIADSOYADDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.oGRVELITELEFONDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.oGRVELIADRESDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dbYurtOtomasyonuDataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbYurtOtomasyonuDataSet2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbYurtOtomasyonuDataSet3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tBLOGRENCIBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // dbYurtOtomasyonuDataSet1
            // 
            this.dbYurtOtomasyonuDataSet1.DataSetName = "dbYurtOtomasyonuDataSet";
            this.dbYurtOtomasyonuDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // dbYurtOtomasyonuDataSet2
            // 
            this.dbYurtOtomasyonuDataSet2.DataSetName = "dbYurtOtomasyonuDataSet";
            this.dbYurtOtomasyonuDataSet2.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.oGRIDDataGridViewTextBoxColumn,
            this.oGRADDataGridViewTextBoxColumn,
            this.oGRSOYADDataGridViewTextBoxColumn,
            this.oGRTCDataGridViewTextBoxColumn,
            this.oGRTELEFONDataGridViewTextBoxColumn,
            this.oGRDOGUMDataGridViewTextBoxColumn,
            this.oGRBOLUMDataGridViewTextBoxColumn,
            this.oGRMAILDataGridViewTextBoxColumn,
            this.oGRODANODataGridViewTextBoxColumn,
            this.oGRVELIADSOYADDataGridViewTextBoxColumn,
            this.oGRVELITELEFONDataGridViewTextBoxColumn,
            this.oGRVELIADRESDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.tBLOGRENCIBindingSource;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(1593, 587);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);
            // 
            // dbYurtOtomasyonuDataSet3
            // 
            this.dbYurtOtomasyonuDataSet3.DataSetName = "dbYurtOtomasyonuDataSet3";
            this.dbYurtOtomasyonuDataSet3.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // tBLOGRENCIBindingSource
            // 
            this.tBLOGRENCIBindingSource.DataMember = "TBLOGRENCI";
            this.tBLOGRENCIBindingSource.DataSource = this.dbYurtOtomasyonuDataSet3;
            // 
            // tBLOGRENCITableAdapter
            // 
            this.tBLOGRENCITableAdapter.ClearBeforeFill = true;
            // 
            // oGRIDDataGridViewTextBoxColumn
            // 
            this.oGRIDDataGridViewTextBoxColumn.DataPropertyName = "OGRID";
            this.oGRIDDataGridViewTextBoxColumn.HeaderText = "OGRID";
            this.oGRIDDataGridViewTextBoxColumn.Name = "oGRIDDataGridViewTextBoxColumn";
            this.oGRIDDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // oGRADDataGridViewTextBoxColumn
            // 
            this.oGRADDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.oGRADDataGridViewTextBoxColumn.DataPropertyName = "OGRAD";
            this.oGRADDataGridViewTextBoxColumn.HeaderText = "OGRAD";
            this.oGRADDataGridViewTextBoxColumn.Name = "oGRADDataGridViewTextBoxColumn";
            // 
            // oGRSOYADDataGridViewTextBoxColumn
            // 
            this.oGRSOYADDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.oGRSOYADDataGridViewTextBoxColumn.DataPropertyName = "OGRSOYAD";
            this.oGRSOYADDataGridViewTextBoxColumn.HeaderText = "OGRSOYAD";
            this.oGRSOYADDataGridViewTextBoxColumn.Name = "oGRSOYADDataGridViewTextBoxColumn";
            // 
            // oGRTCDataGridViewTextBoxColumn
            // 
            this.oGRTCDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.oGRTCDataGridViewTextBoxColumn.DataPropertyName = "OGRTC";
            this.oGRTCDataGridViewTextBoxColumn.HeaderText = "OGRTC";
            this.oGRTCDataGridViewTextBoxColumn.Name = "oGRTCDataGridViewTextBoxColumn";
            // 
            // oGRTELEFONDataGridViewTextBoxColumn
            // 
            this.oGRTELEFONDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.oGRTELEFONDataGridViewTextBoxColumn.DataPropertyName = "OGRTELEFON";
            this.oGRTELEFONDataGridViewTextBoxColumn.HeaderText = "OGRTELEFON";
            this.oGRTELEFONDataGridViewTextBoxColumn.Name = "oGRTELEFONDataGridViewTextBoxColumn";
            // 
            // oGRDOGUMDataGridViewTextBoxColumn
            // 
            this.oGRDOGUMDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.oGRDOGUMDataGridViewTextBoxColumn.DataPropertyName = "OGRDOGUM";
            this.oGRDOGUMDataGridViewTextBoxColumn.HeaderText = "OGRDOGUM";
            this.oGRDOGUMDataGridViewTextBoxColumn.Name = "oGRDOGUMDataGridViewTextBoxColumn";
            // 
            // oGRBOLUMDataGridViewTextBoxColumn
            // 
            this.oGRBOLUMDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.oGRBOLUMDataGridViewTextBoxColumn.DataPropertyName = "OGRBOLUM";
            this.oGRBOLUMDataGridViewTextBoxColumn.HeaderText = "OGRBOLUM";
            this.oGRBOLUMDataGridViewTextBoxColumn.Name = "oGRBOLUMDataGridViewTextBoxColumn";
            // 
            // oGRMAILDataGridViewTextBoxColumn
            // 
            this.oGRMAILDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.oGRMAILDataGridViewTextBoxColumn.DataPropertyName = "OGRMAIL";
            this.oGRMAILDataGridViewTextBoxColumn.HeaderText = "OGRMAIL";
            this.oGRMAILDataGridViewTextBoxColumn.Name = "oGRMAILDataGridViewTextBoxColumn";
            // 
            // oGRODANODataGridViewTextBoxColumn
            // 
            this.oGRODANODataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.oGRODANODataGridViewTextBoxColumn.DataPropertyName = "OGRODANO";
            this.oGRODANODataGridViewTextBoxColumn.HeaderText = "OGRODANO";
            this.oGRODANODataGridViewTextBoxColumn.Name = "oGRODANODataGridViewTextBoxColumn";
            // 
            // oGRVELIADSOYADDataGridViewTextBoxColumn
            // 
            this.oGRVELIADSOYADDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.oGRVELIADSOYADDataGridViewTextBoxColumn.DataPropertyName = "OGRVELIADSOYAD";
            this.oGRVELIADSOYADDataGridViewTextBoxColumn.HeaderText = "OGRVELIADSOYAD";
            this.oGRVELIADSOYADDataGridViewTextBoxColumn.Name = "oGRVELIADSOYADDataGridViewTextBoxColumn";
            // 
            // oGRVELITELEFONDataGridViewTextBoxColumn
            // 
            this.oGRVELITELEFONDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.oGRVELITELEFONDataGridViewTextBoxColumn.DataPropertyName = "OGRVELITELEFON";
            this.oGRVELITELEFONDataGridViewTextBoxColumn.HeaderText = "OGRVELITELEFON";
            this.oGRVELITELEFONDataGridViewTextBoxColumn.Name = "oGRVELITELEFONDataGridViewTextBoxColumn";
            // 
            // oGRVELIADRESDataGridViewTextBoxColumn
            // 
            this.oGRVELIADRESDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.oGRVELIADRESDataGridViewTextBoxColumn.DataPropertyName = "OGRVELIADRES";
            this.oGRVELIADRESDataGridViewTextBoxColumn.HeaderText = "OGRVELIADRES";
            this.oGRVELIADRESDataGridViewTextBoxColumn.Name = "oGRVELIADRESDataGridViewTextBoxColumn";
            // 
            // frmOgrListe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(1593, 587);
            this.Controls.Add(this.dataGridView1);
            this.Font = new System.Drawing.Font("Georgia", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmOgrListe";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Öğrenci Listesi";
            this.Load += new System.EventHandler(this.frmOgrListe_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dbYurtOtomasyonuDataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbYurtOtomasyonuDataSet2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbYurtOtomasyonuDataSet3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tBLOGRENCIBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private dbYurtOtomasyonuDataSet dbYurtOtomasyonuDataSet1;
        private dbYurtOtomasyonuDataSet dbYurtOtomasyonuDataSet2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private dbYurtOtomasyonuDataSet3 dbYurtOtomasyonuDataSet3;
        private System.Windows.Forms.BindingSource tBLOGRENCIBindingSource;
        private dbYurtOtomasyonuDataSet3TableAdapters.TBLOGRENCITableAdapter tBLOGRENCITableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn oGRIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn oGRADDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn oGRSOYADDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn oGRTCDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn oGRTELEFONDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn oGRDOGUMDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn oGRBOLUMDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn oGRMAILDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn oGRODANODataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn oGRVELIADSOYADDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn oGRVELITELEFONDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn oGRVELIADRESDataGridViewTextBoxColumn;
    }
}