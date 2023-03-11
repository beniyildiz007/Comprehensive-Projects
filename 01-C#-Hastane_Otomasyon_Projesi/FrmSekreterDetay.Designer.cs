
namespace _02_Hastane_Proejesi
{
    partial class FrmSekreterDetay
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmSekreterDetay));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblAdSoyad = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblTC = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnOlustur = new System.Windows.Forms.Button();
            this.rchDuyuru = new System.Windows.Forms.RichTextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnKaydet = new System.Windows.Forms.Button();
            this.chkDurum = new System.Windows.Forms.CheckBox();
            this.cmbDoktor = new System.Windows.Forms.ComboBox();
            this.cmbBrans = new System.Windows.Forms.ComboBox();
            this.mskTC = new System.Windows.Forms.MaskedTextBox();
            this.mskSaat = new System.Windows.Forms.MaskedTextBox();
            this.mskTarih = new System.Windows.Forms.MaskedTextBox();
            this.txtID = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.dataGridView3 = new System.Windows.Forms.DataGridView();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.btnRandevuListe = new System.Windows.Forms.Button();
            this.btnBransPaneli = new System.Windows.Forms.Button();
            this.btnDoktorPaneli = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).BeginInit();
            this.groupBox6.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblAdSoyad);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.lblTC);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(326, 148);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Sekreter Bilgileri";
            // 
            // lblAdSoyad
            // 
            this.lblAdSoyad.AutoSize = true;
            this.lblAdSoyad.Location = new System.Drawing.Point(124, 89);
            this.lblAdSoyad.Name = "lblAdSoyad";
            this.lblAdSoyad.Size = new System.Drawing.Size(76, 23);
            this.lblAdSoyad.TabIndex = 3;
            this.lblAdSoyad.Text = "Null Null";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(29, 89);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 23);
            this.label3.TabIndex = 2;
            this.label3.Text = "Ad Soyad:";
            // 
            // lblTC
            // 
            this.lblTC.AutoSize = true;
            this.lblTC.Location = new System.Drawing.Point(124, 49);
            this.lblTC.Name = "lblTC";
            this.lblTC.Size = new System.Drawing.Size(120, 23);
            this.lblTC.TabIndex = 1;
            this.lblTC.Text = "00000000000";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(50, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "TC NO:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnOlustur);
            this.groupBox2.Controls.Add(this.rchDuyuru);
            this.groupBox2.Location = new System.Drawing.Point(12, 166);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(326, 305);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Duyuru Oluştur";
            // 
            // btnOlustur
            // 
            this.btnOlustur.Location = new System.Drawing.Point(6, 245);
            this.btnOlustur.Name = "btnOlustur";
            this.btnOlustur.Size = new System.Drawing.Size(314, 48);
            this.btnOlustur.TabIndex = 1;
            this.btnOlustur.Text = "Oluştur";
            this.btnOlustur.UseVisualStyleBackColor = true;
            this.btnOlustur.Click += new System.EventHandler(this.btnOlustur_Click);
            // 
            // rchDuyuru
            // 
            this.rchDuyuru.Location = new System.Drawing.Point(6, 30);
            this.rchDuyuru.Name = "rchDuyuru";
            this.rchDuyuru.Size = new System.Drawing.Size(314, 209);
            this.rchDuyuru.TabIndex = 0;
            this.rchDuyuru.Text = "";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnKaydet);
            this.groupBox3.Controls.Add(this.chkDurum);
            this.groupBox3.Controls.Add(this.cmbDoktor);
            this.groupBox3.Controls.Add(this.cmbBrans);
            this.groupBox3.Controls.Add(this.mskTC);
            this.groupBox3.Controls.Add(this.mskSaat);
            this.groupBox3.Controls.Add(this.mskTarih);
            this.groupBox3.Controls.Add(this.txtID);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Location = new System.Drawing.Point(344, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(320, 459);
            this.groupBox3.TabIndex = 5;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Randevu Paneli";
            // 
            // btnKaydet
            // 
            this.btnKaydet.Location = new System.Drawing.Point(95, 328);
            this.btnKaydet.Name = "btnKaydet";
            this.btnKaydet.Size = new System.Drawing.Size(200, 48);
            this.btnKaydet.TabIndex = 3;
            this.btnKaydet.Text = "Kaydet";
            this.btnKaydet.UseVisualStyleBackColor = true;
            this.btnKaydet.Click += new System.EventHandler(this.btnKaydet_Click);
            // 
            // chkDurum
            // 
            this.chkDurum.AutoSize = true;
            this.chkDurum.Location = new System.Drawing.Point(95, 291);
            this.chkDurum.Name = "chkDurum";
            this.chkDurum.Size = new System.Drawing.Size(84, 27);
            this.chkDurum.TabIndex = 6;
            this.chkDurum.Text = "Durum";
            this.chkDurum.UseVisualStyleBackColor = true;
            // 
            // cmbDoktor
            // 
            this.cmbDoktor.FormattingEnabled = true;
            this.cmbDoktor.Location = new System.Drawing.Point(95, 208);
            this.cmbDoktor.Name = "cmbDoktor";
            this.cmbDoktor.Size = new System.Drawing.Size(200, 31);
            this.cmbDoktor.TabIndex = 15;
            // 
            // cmbBrans
            // 
            this.cmbBrans.FormattingEnabled = true;
            this.cmbBrans.Location = new System.Drawing.Point(95, 170);
            this.cmbBrans.Name = "cmbBrans";
            this.cmbBrans.Size = new System.Drawing.Size(200, 31);
            this.cmbBrans.TabIndex = 14;
            this.cmbBrans.SelectedIndexChanged += new System.EventHandler(this.cmbBrans_SelectedIndexChanged);
            // 
            // mskTC
            // 
            this.mskTC.Location = new System.Drawing.Point(95, 246);
            this.mskTC.Mask = "00000000000";
            this.mskTC.Name = "mskTC";
            this.mskTC.Size = new System.Drawing.Size(200, 31);
            this.mskTC.TabIndex = 13;
            this.mskTC.ValidatingType = typeof(int);
            // 
            // mskSaat
            // 
            this.mskSaat.Location = new System.Drawing.Point(95, 132);
            this.mskSaat.Mask = "00:00";
            this.mskSaat.Name = "mskSaat";
            this.mskSaat.Size = new System.Drawing.Size(200, 31);
            this.mskSaat.TabIndex = 12;
            this.mskSaat.ValidatingType = typeof(System.DateTime);
            // 
            // mskTarih
            // 
            this.mskTarih.Location = new System.Drawing.Point(95, 94);
            this.mskTarih.Mask = "00/00/0000";
            this.mskTarih.Name = "mskTarih";
            this.mskTarih.Size = new System.Drawing.Size(200, 31);
            this.mskTarih.TabIndex = 11;
            this.mskTarih.ValidatingType = typeof(System.DateTime);
            // 
            // txtID
            // 
            this.txtID.Location = new System.Drawing.Point(95, 55);
            this.txtID.Name = "txtID";
            this.txtID.Size = new System.Drawing.Size(200, 31);
            this.txtID.TabIndex = 10;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(30, 173);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(59, 23);
            this.label7.TabIndex = 9;
            this.label7.Text = "Branş:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(39, 137);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(50, 23);
            this.label8.TabIndex = 8;
            this.label8.Text = "Saat:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(52, 249);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(37, 23);
            this.label5.TabIndex = 7;
            this.label5.Text = "TC:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(19, 213);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(70, 23);
            this.label6.TabIndex = 6;
            this.label6.Text = "Doktor:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(35, 97);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 23);
            this.label2.TabIndex = 5;
            this.label2.Text = "Tarih:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(60, 58);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 23);
            this.label4.TabIndex = 4;
            this.label4.Text = "id:";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.dataGridView1);
            this.groupBox4.Location = new System.Drawing.Point(670, 12);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(509, 256);
            this.groupBox4.TabIndex = 6;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Branşlar";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(3, 27);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(503, 226);
            this.dataGridView1.TabIndex = 19;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.dataGridView3);
            this.groupBox5.Location = new System.Drawing.Point(670, 274);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(509, 343);
            this.groupBox5.TabIndex = 7;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Doktorlar";
            // 
            // dataGridView3
            // 
            this.dataGridView3.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView3.Location = new System.Drawing.Point(3, 27);
            this.dataGridView3.Name = "dataGridView3";
            this.dataGridView3.Size = new System.Drawing.Size(503, 313);
            this.dataGridView3.TabIndex = 20;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.button1);
            this.groupBox6.Controls.Add(this.btnRandevuListe);
            this.groupBox6.Controls.Add(this.btnBransPaneli);
            this.groupBox6.Controls.Add(this.btnDoktorPaneli);
            this.groupBox6.Location = new System.Drawing.Point(12, 477);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(652, 140);
            this.groupBox6.TabIndex = 7;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Hızlı Erişim";
            // 
            // btnRandevuListe
            // 
            this.btnRandevuListe.Location = new System.Drawing.Point(327, 54);
            this.btnRandevuListe.Name = "btnRandevuListe";
            this.btnRandevuListe.Size = new System.Drawing.Size(145, 48);
            this.btnRandevuListe.TabIndex = 16;
            this.btnRandevuListe.Text = "Randevu Listesi";
            this.btnRandevuListe.UseVisualStyleBackColor = true;
            this.btnRandevuListe.Click += new System.EventHandler(this.btnRandevuListe_Click);
            // 
            // btnBransPaneli
            // 
            this.btnBransPaneli.Location = new System.Drawing.Point(176, 54);
            this.btnBransPaneli.Name = "btnBransPaneli";
            this.btnBransPaneli.Size = new System.Drawing.Size(145, 48);
            this.btnBransPaneli.TabIndex = 17;
            this.btnBransPaneli.Text = "Branş Paneli";
            this.btnBransPaneli.UseVisualStyleBackColor = true;
            this.btnBransPaneli.Click += new System.EventHandler(this.btnBransPaneli_Click);
            // 
            // btnDoktorPaneli
            // 
            this.btnDoktorPaneli.Location = new System.Drawing.Point(25, 54);
            this.btnDoktorPaneli.Name = "btnDoktorPaneli";
            this.btnDoktorPaneli.Size = new System.Drawing.Size(145, 48);
            this.btnDoktorPaneli.TabIndex = 18;
            this.btnDoktorPaneli.Text = "Doktor Paneli";
            this.btnDoktorPaneli.UseVisualStyleBackColor = true;
            this.btnDoktorPaneli.Click += new System.EventHandler(this.btnDoktorPaneli_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(478, 54);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(145, 48);
            this.button1.TabIndex = 19;
            this.button1.Text = "Duyurular";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // FrmSekreterDetay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.LightSeaGreen;
            this.ClientSize = new System.Drawing.Size(1191, 629);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Corbel", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.MaximizeBox = false;
            this.Name = "FrmSekreterDetay";
            this.Text = "Sekreter Detayları";
            this.Load += new System.EventHandler(this.FrmSekreterDetay_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).EndInit();
            this.groupBox6.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblAdSoyad;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblTC;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnOlustur;
        private System.Windows.Forms.RichTextBox rchDuyuru;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnKaydet;
        private System.Windows.Forms.CheckBox chkDurum;
        private System.Windows.Forms.ComboBox cmbDoktor;
        private System.Windows.Forms.ComboBox cmbBrans;
        private System.Windows.Forms.MaskedTextBox mskTC;
        private System.Windows.Forms.MaskedTextBox mskSaat;
        private System.Windows.Forms.MaskedTextBox mskTarih;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.DataGridView dataGridView3;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Button btnRandevuListe;
        private System.Windows.Forms.Button btnBransPaneli;
        private System.Windows.Forms.Button btnDoktorPaneli;
        private System.Windows.Forms.Button button1;
    }
}