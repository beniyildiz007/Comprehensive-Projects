using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlClient;

namespace _02_Pansiyon_Kayit_Projesi
{
    public partial class frmYeniMusteri : Form
    {
        public frmYeniMusteri()
        {
            InitializeComponent();
        }

        private void btnDolu_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Kırmızı renkli butonlar dolu odaları gösterir.");
        }

        private void btnBos_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Yeşil renkli butonlar boş odaları gösterir.");
        }

        private void btn101_Click(object sender, EventArgs e)
        {
            txtOdaNo.Text = "101";
        }

        private void btn102_Click(object sender, EventArgs e)
        {
            txtOdaNo.Text = "102";

        }

        private void btn103_Click(object sender, EventArgs e)
        {
            txtOdaNo.Text = "103";

        }

        private void btn104_Click(object sender, EventArgs e)
        {
            txtOdaNo.Text = "104";

        }

        private void btn105_Click(object sender, EventArgs e)
        {
            txtOdaNo.Text = "105";

        }

        private void btn106_Click(object sender, EventArgs e)
        {
            txtOdaNo.Text = "106";

        }

        private void btn107_Click(object sender, EventArgs e)
        {
            txtOdaNo.Text = "107";

        }

        private void btn108_Click(object sender, EventArgs e)
        {
            txtOdaNo.Text = "108";

        }

        private void btn109_Click(object sender, EventArgs e)
        {
            txtOdaNo.Text = "109";

        }

        private void dateCikis_ValueChanged(object sender, EventArgs e)
        {
            DateTime giris = Convert.ToDateTime(dateGiris.Text);
            DateTime cikis = Convert.ToDateTime(dateCikis.Text);

            TimeSpan fark = cikis - giris;

            lblFark.Text = fark.TotalDays.ToString();

            int ucret = Convert.ToInt32(lblFark.Text) * 150;
            txtUcret.Text = ucret.ToString();
        }

        SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-HKL3D7O\SQLEXPRESS;Initial Catalog=dbPansiyonKayit;Integrated Security=True");

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("insert into TBLMUSTERIEKLE (ADI,SOYADI,CINSIYET,TELEFON,MAIL,TC,ODANO,UCRET,GIRISTARIHI,CIKISTARIHI) values (@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8,@p9,@p10)", baglanti);
            komut.Parameters.AddWithValue("@p1", txtAdi.Text);
            komut.Parameters.AddWithValue("@p2", txtSoyadi.Text);
            komut.Parameters.AddWithValue("@p3", comboBox1.Text);
            komut.Parameters.AddWithValue("@p4", mskTelefon.Text);
            komut.Parameters.AddWithValue("@p5", txtMail.Text);
            komut.Parameters.AddWithValue("@p6", mskTC.Text);
            komut.Parameters.AddWithValue("@p7", txtOdaNo.Text);
            komut.Parameters.AddWithValue("@p8", txtUcret.Text);
            komut.Parameters.AddWithValue("@p9", dateGiris.Value.ToString("yyyy-MM-dd"));
            komut.Parameters.AddWithValue("@p10", dateCikis.Value.ToString("yyyy-MM-dd"));
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Müşteri Kaydı Yapıldı!");
        }
    }
}
