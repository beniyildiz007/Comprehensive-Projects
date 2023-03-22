
namespace _03_Ogrenci_Yurt_Kayit_Otomasyonu
{
    partial class frmGiderListesi
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmGiderListesi));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.dbYurtOtomasyonuDataSet4 = new _03_Ogrenci_Yurt_Kayit_Otomasyonu.dbYurtOtomasyonuDataSet4();
            this.tBLGIDERLERBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tBLGIDERLERTableAdapter = new _03_Ogrenci_Yurt_Kayit_Otomasyonu.dbYurtOtomasyonuDataSet4TableAdapters.TBLGIDERLERTableAdapter();
            this.oDEMEIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.eLEKTRIKDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sUDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dOGALGAZDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ıNTERNETDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gIDADataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pERSONELDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dIGERDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbYurtOtomasyonuDataSet4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tBLGIDERLERBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.oDEMEIDDataGridViewTextBoxColumn,
            this.eLEKTRIKDataGridViewTextBoxColumn,
            this.sUDataGridViewTextBoxColumn,
            this.dOGALGAZDataGridViewTextBoxColumn,
            this.ıNTERNETDataGridViewTextBoxColumn,
            this.gIDADataGridViewTextBoxColumn,
            this.pERSONELDataGridViewTextBoxColumn,
            this.dIGERDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.tBLGIDERLERBindingSource;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(1086, 356);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);
            // 
            // dbYurtOtomasyonuDataSet4
            // 
            this.dbYurtOtomasyonuDataSet4.DataSetName = "dbYurtOtomasyonuDataSet4";
            this.dbYurtOtomasyonuDataSet4.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // tBLGIDERLERBindingSource
            // 
            this.tBLGIDERLERBindingSource.DataMember = "TBLGIDERLER";
            this.tBLGIDERLERBindingSource.DataSource = this.dbYurtOtomasyonuDataSet4;
            // 
            // tBLGIDERLERTableAdapter
            // 
            this.tBLGIDERLERTableAdapter.ClearBeforeFill = true;
            // 
            // oDEMEIDDataGridViewTextBoxColumn
            // 
            this.oDEMEIDDataGridViewTextBoxColumn.DataPropertyName = "ODEMEID";
            this.oDEMEIDDataGridViewTextBoxColumn.HeaderText = "ODEMEID";
            this.oDEMEIDDataGridViewTextBoxColumn.Name = "oDEMEIDDataGridViewTextBoxColumn";
            this.oDEMEIDDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // eLEKTRIKDataGridViewTextBoxColumn
            // 
            this.eLEKTRIKDataGridViewTextBoxColumn.DataPropertyName = "ELEKTRIK";
            this.eLEKTRIKDataGridViewTextBoxColumn.HeaderText = "ELEKTRIK";
            this.eLEKTRIKDataGridViewTextBoxColumn.Name = "eLEKTRIKDataGridViewTextBoxColumn";
            // 
            // sUDataGridViewTextBoxColumn
            // 
            this.sUDataGridViewTextBoxColumn.DataPropertyName = "SU";
            this.sUDataGridViewTextBoxColumn.HeaderText = "SU";
            this.sUDataGridViewTextBoxColumn.Name = "sUDataGridViewTextBoxColumn";
            // 
            // dOGALGAZDataGridViewTextBoxColumn
            // 
            this.dOGALGAZDataGridViewTextBoxColumn.DataPropertyName = "DOGALGAZ";
            this.dOGALGAZDataGridViewTextBoxColumn.HeaderText = "DOGALGAZ";
            this.dOGALGAZDataGridViewTextBoxColumn.Name = "dOGALGAZDataGridViewTextBoxColumn";
            // 
            // ıNTERNETDataGridViewTextBoxColumn
            // 
            this.ıNTERNETDataGridViewTextBoxColumn.DataPropertyName = "INTERNET";
            this.ıNTERNETDataGridViewTextBoxColumn.HeaderText = "INTERNET";
            this.ıNTERNETDataGridViewTextBoxColumn.Name = "ıNTERNETDataGridViewTextBoxColumn";
            // 
            // gIDADataGridViewTextBoxColumn
            // 
            this.gIDADataGridViewTextBoxColumn.DataPropertyName = "GIDA";
            this.gIDADataGridViewTextBoxColumn.HeaderText = "GIDA";
            this.gIDADataGridViewTextBoxColumn.Name = "gIDADataGridViewTextBoxColumn";
            // 
            // pERSONELDataGridViewTextBoxColumn
            // 
            this.pERSONELDataGridViewTextBoxColumn.DataPropertyName = "PERSONEL";
            this.pERSONELDataGridViewTextBoxColumn.HeaderText = "PERSONEL";
            this.pERSONELDataGridViewTextBoxColumn.Name = "pERSONELDataGridViewTextBoxColumn";
            // 
            // dIGERDataGridViewTextBoxColumn
            // 
            this.dIGERDataGridViewTextBoxColumn.DataPropertyName = "DIGER";
            this.dIGERDataGridViewTextBoxColumn.HeaderText = "DIGER";
            this.dIGERDataGridViewTextBoxColumn.Name = "dIGERDataGridViewTextBoxColumn";
            // 
            // frmGiderListesi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(1086, 356);
            this.Controls.Add(this.dataGridView1);
            this.Font = new System.Drawing.Font("Georgia", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmGiderListesi";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Gider Listesi";
            this.Load += new System.EventHandler(this.frmGiderListesi_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbYurtOtomasyonuDataSet4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tBLGIDERLERBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private dbYurtOtomasyonuDataSet4 dbYurtOtomasyonuDataSet4;
        private System.Windows.Forms.BindingSource tBLGIDERLERBindingSource;
        private dbYurtOtomasyonuDataSet4TableAdapters.TBLGIDERLERTableAdapter tBLGIDERLERTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn oDEMEIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn eLEKTRIKDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn sUDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dOGALGAZDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ıNTERNETDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn gIDADataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn pERSONELDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dIGERDataGridViewTextBoxColumn;
    }
}