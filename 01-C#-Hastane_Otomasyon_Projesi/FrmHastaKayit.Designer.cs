
namespace _02_Hastane_Proejesi
{
    partial class FrmHastaKayit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmHastaKayit));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtAd = new System.Windows.Forms.TextBox();
            this.txtSoyad = new System.Windows.Forms.TextBox();
            this.txtSifre = new System.Windows.Forms.TextBox();
            this.mskKimlik = new System.Windows.Forms.MaskedTextBox();
            this.mskTelefon = new System.Windows.Forms.MaskedTextBox();
            this.btnKayit = new System.Windows.Forms.Button();
            this.cmbCinsiyet = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(103, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Ad:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(77, 81);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 23);
            this.label2.TabIndex = 1;
            this.label2.Text = "Soyad:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(67, 157);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 23);
            this.label3.TabIndex = 3;
            this.label3.Text = "Telefon:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(23, 121);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(117, 23);
            this.label4.TabIndex = 2;
            this.label4.Text = "TC Kimlik No:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(63, 233);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(77, 23);
            this.label5.TabIndex = 5;
            this.label5.Text = "Cinsiyet:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(90, 197);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(50, 23);
            this.label6.TabIndex = 4;
            this.label6.Text = "Şifre:";
            // 
            // txtAd
            // 
            this.txtAd.Location = new System.Drawing.Point(146, 42);
            this.txtAd.Name = "txtAd";
            this.txtAd.Size = new System.Drawing.Size(213, 31);
            this.txtAd.TabIndex = 1;
            // 
            // txtSoyad
            // 
            this.txtSoyad.Location = new System.Drawing.Point(146, 81);
            this.txtSoyad.Name = "txtSoyad";
            this.txtSoyad.Size = new System.Drawing.Size(213, 31);
            this.txtSoyad.TabIndex = 2;
            // 
            // txtSifre
            // 
            this.txtSifre.Location = new System.Drawing.Point(146, 194);
            this.txtSifre.Name = "txtSifre";
            this.txtSifre.Size = new System.Drawing.Size(213, 31);
            this.txtSifre.TabIndex = 5;
            // 
            // mskKimlik
            // 
            this.mskKimlik.Location = new System.Drawing.Point(146, 118);
            this.mskKimlik.Mask = "00000000000";
            this.mskKimlik.Name = "mskKimlik";
            this.mskKimlik.Size = new System.Drawing.Size(213, 31);
            this.mskKimlik.TabIndex = 3;
            this.mskKimlik.ValidatingType = typeof(int);
            // 
            // mskTelefon
            // 
            this.mskTelefon.Location = new System.Drawing.Point(146, 154);
            this.mskTelefon.Mask = "(999) 000-0000";
            this.mskTelefon.Name = "mskTelefon";
            this.mskTelefon.Size = new System.Drawing.Size(213, 31);
            this.mskTelefon.TabIndex = 4;
            // 
            // btnKayit
            // 
            this.btnKayit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnKayit.Location = new System.Drawing.Point(146, 270);
            this.btnKayit.Name = "btnKayit";
            this.btnKayit.Size = new System.Drawing.Size(213, 47);
            this.btnKayit.TabIndex = 12;
            this.btnKayit.Text = "Kayıt Yap";
            this.btnKayit.UseVisualStyleBackColor = false;
            this.btnKayit.Click += new System.EventHandler(this.btnKayit_Click);
            // 
            // cmbCinsiyet
            // 
            this.cmbCinsiyet.FormattingEnabled = true;
            this.cmbCinsiyet.Items.AddRange(new object[] {
            "Erkek",
            "Kadın"});
            this.cmbCinsiyet.Location = new System.Drawing.Point(146, 230);
            this.cmbCinsiyet.Name = "cmbCinsiyet";
            this.cmbCinsiyet.Size = new System.Drawing.Size(213, 31);
            this.cmbCinsiyet.TabIndex = 6;
            // 
            // FrmHastaKayit
            // 
            this.AcceptButton = this.btnKayit;
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.ClientSize = new System.Drawing.Size(419, 357);
            this.Controls.Add(this.cmbCinsiyet);
            this.Controls.Add(this.btnKayit);
            this.Controls.Add(this.mskTelefon);
            this.Controls.Add(this.mskKimlik);
            this.Controls.Add(this.txtSifre);
            this.Controls.Add(this.txtSoyad);
            this.Controls.Add(this.txtAd);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Corbel", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.MaximizeBox = false;
            this.Name = "FrmHastaKayit";
            this.Text = "Hasta Kayıt";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtAd;
        private System.Windows.Forms.TextBox txtSoyad;
        private System.Windows.Forms.TextBox txtSifre;
        private System.Windows.Forms.MaskedTextBox mskKimlik;
        private System.Windows.Forms.MaskedTextBox mskTelefon;
        private System.Windows.Forms.Button btnKayit;
        private System.Windows.Forms.ComboBox cmbCinsiyet;
    }
}