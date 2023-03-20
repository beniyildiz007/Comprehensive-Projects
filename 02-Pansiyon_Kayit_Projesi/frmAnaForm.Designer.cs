
namespace _02_Pansiyon_Kayit_Projesi
{
    partial class frmAnaForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAnaForm));
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.btnMusteriler = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.btnRadyo = new System.Windows.Forms.Button();
            this.btnMusteriMesaj = new System.Windows.Forms.Button();
            this.btnStoklar = new System.Windows.Forms.Button();
            this.btnGelirGider = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.button1.Location = new System.Drawing.Point(95, 48);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(215, 146);
            this.button1.TabIndex = 0;
            this.button1.Text = "ADMİN GİRİŞ";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.button2.Location = new System.Drawing.Point(405, 48);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(215, 146);
            this.button2.TabIndex = 1;
            this.button2.Text = "YENİ MÜŞTERİ";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.button3.Location = new System.Drawing.Point(719, 48);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(215, 146);
            this.button3.TabIndex = 2;
            this.button3.Text = "ODALAR";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // btnMusteriler
            // 
            this.btnMusteriler.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btnMusteriler.Location = new System.Drawing.Point(95, 260);
            this.btnMusteriler.Name = "btnMusteriler";
            this.btnMusteriler.Size = new System.Drawing.Size(215, 146);
            this.btnMusteriler.TabIndex = 3;
            this.btnMusteriler.Text = "MÜŞTERİLER";
            this.btnMusteriler.UseVisualStyleBackColor = false;
            this.btnMusteriler.Click += new System.EventHandler(this.btnMusteriler_Click);
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.Silver;
            this.button4.Location = new System.Drawing.Point(405, 476);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(215, 146);
            this.button4.TabIndex = 6;
            this.button4.Text = "HAKKIMIZDA";
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // btnRadyo
            // 
            this.btnRadyo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btnRadyo.Location = new System.Drawing.Point(719, 476);
            this.btnRadyo.Name = "btnRadyo";
            this.btnRadyo.Size = new System.Drawing.Size(215, 146);
            this.btnRadyo.TabIndex = 5;
            this.btnRadyo.Text = "RADYO DİNLE";
            this.btnRadyo.UseVisualStyleBackColor = false;
            this.btnRadyo.Visible = false;
            // 
            // btnMusteriMesaj
            // 
            this.btnMusteriMesaj.BackColor = System.Drawing.Color.Plum;
            this.btnMusteriMesaj.Location = new System.Drawing.Point(95, 476);
            this.btnMusteriMesaj.Name = "btnMusteriMesaj";
            this.btnMusteriMesaj.Size = new System.Drawing.Size(215, 146);
            this.btnMusteriMesaj.TabIndex = 4;
            this.btnMusteriMesaj.Text = "MÜŞTERİ MESAJLARI";
            this.btnMusteriMesaj.UseVisualStyleBackColor = false;
            this.btnMusteriMesaj.Visible = false;
            // 
            // btnStoklar
            // 
            this.btnStoklar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnStoklar.Location = new System.Drawing.Point(719, 260);
            this.btnStoklar.Name = "btnStoklar";
            this.btnStoklar.Size = new System.Drawing.Size(215, 146);
            this.btnStoklar.TabIndex = 8;
            this.btnStoklar.Text = "STOKLAR";
            this.btnStoklar.UseVisualStyleBackColor = false;
            this.btnStoklar.Click += new System.EventHandler(this.btnStoklar_Click);
            // 
            // btnGelirGider
            // 
            this.btnGelirGider.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnGelirGider.Location = new System.Drawing.Point(405, 260);
            this.btnGelirGider.Name = "btnGelirGider";
            this.btnGelirGider.Size = new System.Drawing.Size(215, 146);
            this.btnGelirGider.TabIndex = 7;
            this.btnGelirGider.Text = "GELİR-GİDER FORMU";
            this.btnGelirGider.UseVisualStyleBackColor = false;
            this.btnGelirGider.Click += new System.EventHandler(this.btnGelirGider_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(986, 69);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 18);
            this.label1.TabIndex = 9;
            this.label1.Text = "label1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(1039, 116);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 18);
            this.label2.TabIndex = 10;
            this.label2.Text = "label2";
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // frmAnaForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(1187, 674);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnStoklar);
            this.Controls.Add(this.btnGelirGider);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.btnRadyo);
            this.Controls.Add(this.btnMusteriMesaj);
            this.Controls.Add(this.btnMusteriler);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Font = new System.Drawing.Font("Georgia", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmAnaForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Anasayfa";
            this.Load += new System.EventHandler(this.frmAnaForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button btnMusteriler;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button btnRadyo;
        private System.Windows.Forms.Button btnMusteriMesaj;
        private System.Windows.Forms.Button btnStoklar;
        private System.Windows.Forms.Button btnGelirGider;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Timer timer1;
    }
}