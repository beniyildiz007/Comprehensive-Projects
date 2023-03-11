
namespace _02_Hastane_Proejesi
{
    partial class FrmGirisler
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmGirisler));
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnHastaGiris = new System.Windows.Forms.Button();
            this.btnDoktorGiris = new System.Windows.Forms.Button();
            this.btnSekreterGiris = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe Script", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(12, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(534, 80);
            this.label1.TabIndex = 0;
            this.label1.Text = "Memleket Hastanesi";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(561, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(195, 147);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // btnHastaGiris
            // 
            this.btnHastaGiris.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnHastaGiris.BackgroundImage")));
            this.btnHastaGiris.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnHastaGiris.Location = new System.Drawing.Point(41, 210);
            this.btnHastaGiris.Name = "btnHastaGiris";
            this.btnHastaGiris.Size = new System.Drawing.Size(163, 140);
            this.btnHastaGiris.TabIndex = 2;
            this.btnHastaGiris.UseVisualStyleBackColor = true;
            this.btnHastaGiris.Click += new System.EventHandler(this.btnHastaGiris_Click);
            // 
            // btnDoktorGiris
            // 
            this.btnDoktorGiris.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnDoktorGiris.BackgroundImage")));
            this.btnDoktorGiris.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnDoktorGiris.Location = new System.Drawing.Point(292, 210);
            this.btnDoktorGiris.Name = "btnDoktorGiris";
            this.btnDoktorGiris.Size = new System.Drawing.Size(184, 140);
            this.btnDoktorGiris.TabIndex = 3;
            this.btnDoktorGiris.UseVisualStyleBackColor = true;
            this.btnDoktorGiris.Click += new System.EventHandler(this.btnDoktorGiris_Click);
            // 
            // btnSekreterGiris
            // 
            this.btnSekreterGiris.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSekreterGiris.BackgroundImage")));
            this.btnSekreterGiris.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSekreterGiris.Location = new System.Drawing.Point(556, 210);
            this.btnSekreterGiris.Name = "btnSekreterGiris";
            this.btnSekreterGiris.Size = new System.Drawing.Size(187, 140);
            this.btnSekreterGiris.TabIndex = 4;
            this.btnSekreterGiris.UseVisualStyleBackColor = true;
            this.btnSekreterGiris.Click += new System.EventHandler(this.btnSekreterGiris_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(88, 353);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 23);
            this.label2.TabIndex = 5;
            this.label2.Text = "Hasta";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(355, 353);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 23);
            this.label3.TabIndex = 6;
            this.label3.Text = "Doktor";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(610, 353);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(81, 23);
            this.label4.TabIndex = 7;
            this.label4.Text = "Sekreter";
            // 
            // FrmGirisler
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.Aqua;
            this.ClientSize = new System.Drawing.Size(796, 405);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnSekreterGiris);
            this.Controls.Add(this.btnDoktorGiris);
            this.Controls.Add(this.btnHastaGiris);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Georgia", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.MaximizeBox = false;
            this.Name = "FrmGirisler";
            this.Text = "Memleket Hastanesi Giriş";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnHastaGiris;
        private System.Windows.Forms.Button btnDoktorGiris;
        private System.Windows.Forms.Button btnSekreterGiris;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
}

