
namespace _03_Ogrenci_Yurt_Kayit_Otomasyonu
{
    partial class frmOdemeler
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmOdemeler));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.oGRIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.oGRADDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.oGRSOYADDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.oGRKALANBORCDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tBLBORCLARBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dbYurtOtomasyonuDataSet2 = new _03_Ogrenci_Yurt_Kayit_Otomasyonu.dbYurtOtomasyonuDataSet2();
            this.label1 = new System.Windows.Forms.Label();
            this.txtID = new System.Windows.Forms.TextBox();
            this.txtOdenen = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtKalan = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnOdemeAl = new System.Windows.Forms.Button();
            this.tBLBORCLARTableAdapter = new _03_Ogrenci_Yurt_Kayit_Otomasyonu.dbYurtOtomasyonuDataSet2TableAdapters.TBLBORCLARTableAdapter();
            this.txtOdenenAy = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tBLBORCLARBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbYurtOtomasyonuDataSet2)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.oGRIDDataGridViewTextBoxColumn,
            this.oGRADDataGridViewTextBoxColumn,
            this.oGRSOYADDataGridViewTextBoxColumn,
            this.oGRKALANBORCDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.tBLBORCLARBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(518, 12);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(895, 333);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // oGRIDDataGridViewTextBoxColumn
            // 
            this.oGRIDDataGridViewTextBoxColumn.DataPropertyName = "OGRID";
            this.oGRIDDataGridViewTextBoxColumn.HeaderText = "OGRID";
            this.oGRIDDataGridViewTextBoxColumn.Name = "oGRIDDataGridViewTextBoxColumn";
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
            // oGRKALANBORCDataGridViewTextBoxColumn
            // 
            this.oGRKALANBORCDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.oGRKALANBORCDataGridViewTextBoxColumn.DataPropertyName = "OGRKALANBORC";
            this.oGRKALANBORCDataGridViewTextBoxColumn.HeaderText = "OGRKALANBORC";
            this.oGRKALANBORCDataGridViewTextBoxColumn.Name = "oGRKALANBORCDataGridViewTextBoxColumn";
            // 
            // tBLBORCLARBindingSource
            // 
            this.tBLBORCLARBindingSource.DataMember = "TBLBORCLAR";
            this.tBLBORCLARBindingSource.DataSource = this.dbYurtOtomasyonuDataSet2;
            // 
            // dbYurtOtomasyonuDataSet2
            // 
            this.dbYurtOtomasyonuDataSet2.DataSetName = "dbYurtOtomasyonuDataSet2";
            this.dbYurtOtomasyonuDataSet2.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(58, 117);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 18);
            this.label1.TabIndex = 1;
            this.label1.Text = "Öğrenci ID:";
            // 
            // txtID
            // 
            this.txtID.Location = new System.Drawing.Point(154, 114);
            this.txtID.Name = "txtID";
            this.txtID.Size = new System.Drawing.Size(289, 26);
            this.txtID.TabIndex = 2;
            // 
            // txtOdenen
            // 
            this.txtOdenen.Location = new System.Drawing.Point(154, 146);
            this.txtOdenen.Name = "txtOdenen";
            this.txtOdenen.Size = new System.Drawing.Size(289, 26);
            this.txtOdenen.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(80, 149);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 18);
            this.label2.TabIndex = 3;
            this.label2.Text = "Ödenen:";
            // 
            // txtKalan
            // 
            this.txtKalan.Location = new System.Drawing.Point(154, 178);
            this.txtKalan.Name = "txtKalan";
            this.txtKalan.Size = new System.Drawing.Size(289, 26);
            this.txtKalan.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(59, 181);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 18);
            this.label3.TabIndex = 5;
            this.label3.Text = "Kalan Borç:";
            // 
            // btnOdemeAl
            // 
            this.btnOdemeAl.Location = new System.Drawing.Point(179, 253);
            this.btnOdemeAl.Name = "btnOdemeAl";
            this.btnOdemeAl.Size = new System.Drawing.Size(226, 42);
            this.btnOdemeAl.TabIndex = 7;
            this.btnOdemeAl.Text = "Ödeme Al";
            this.btnOdemeAl.UseVisualStyleBackColor = true;
            this.btnOdemeAl.Click += new System.EventHandler(this.btnOdemeAl_Click);
            // 
            // tBLBORCLARTableAdapter
            // 
            this.tBLBORCLARTableAdapter.ClearBeforeFill = true;
            // 
            // txtOdenenAy
            // 
            this.txtOdenenAy.Location = new System.Drawing.Point(154, 210);
            this.txtOdenenAy.Name = "txtOdenenAy";
            this.txtOdenenAy.Size = new System.Drawing.Size(289, 26);
            this.txtOdenenAy.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(56, 213);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(92, 18);
            this.label4.TabIndex = 8;
            this.label4.Text = "Ödenen Ay:";
            // 
            // frmOdemeler
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(1425, 357);
            this.Controls.Add(this.txtOdenenAy);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnOdemeAl);
            this.Controls.Add(this.txtKalan);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtOdenen);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtID);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView1);
            this.Font = new System.Drawing.Font("Georgia", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmOdemeler";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ödemeler";
            this.Load += new System.EventHandler(this.frmOdemeler_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tBLBORCLARBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbYurtOtomasyonuDataSet2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.TextBox txtOdenen;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtKalan;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnOdemeAl;
        private dbYurtOtomasyonuDataSet2 dbYurtOtomasyonuDataSet2;
        private System.Windows.Forms.BindingSource tBLBORCLARBindingSource;
        private dbYurtOtomasyonuDataSet2TableAdapters.TBLBORCLARTableAdapter tBLBORCLARTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn oGRIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn oGRADDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn oGRSOYADDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn oGRKALANBORCDataGridViewTextBoxColumn;
        private System.Windows.Forms.TextBox txtOdenenAy;
        private System.Windows.Forms.Label label4;
    }
}