using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace _03_Ogrenci_Yurt_Kayit_Otomasyonu
{
    public partial class frmOgrKayit : Form
    {
        public frmOgrKayit()
        {
            InitializeComponent();
        }

        SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-HKL3D7O\SQLEXPRESS;Initial Catalog=dbYurtOtomasyonu;Integrated Security=True");



        private void frmOgrKayit_Load(object sender, EventArgs e)
        {

            //Bölümleri Listeleme
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select bolumad from tblbolumler", baglanti);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                cmbBolum.Items.Add(dr[0].ToString());
            }
            baglanti.Close();



            //Boş Odaları Listeleme
            baglanti.Open();
            SqlCommand komut2 = new SqlCommand("select odano from tblodalar where odakapasıte != odaaktıf", baglanti);
            SqlDataReader dr2 = komut2.ExecuteReader();
            while (dr2.Read())
            {
                cmbOdaNo.Items.Add(dr2[0].ToString());
            }
            baglanti.Close();
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("insert into tblogrencı (ograd, ogrsoyad,ogrtc,ogrtelefon,ogrdogum,ogrbolum,ogrmaıl,ogrodano,ogrvelıadsoyad,ogrvelıtelefon,ogrvelıadres) values (@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8,@p9,@p10,@p11)", baglanti);
            komut.Parameters.AddWithValue("@p1", txtOgrenciAd.Text);
            komut.Parameters.AddWithValue("@p2", txtOgrenciSoyad.Text);
            komut.Parameters.AddWithValue("@p3", mskTC.Text);
            komut.Parameters.AddWithValue("@p4", mskOgrenciTelefon.Text);
            komut.Parameters.AddWithValue("@p5", mskDogumTarihi.Text);
            komut.Parameters.AddWithValue("@p6", cmbBolum.Text);
            komut.Parameters.AddWithValue("@p7", txtMail.Text);
            komut.Parameters.AddWithValue("@p8", cmbOdaNo.Text);
            komut.Parameters.AddWithValue("@p9", txtVeliAdSoyad.Text);
            komut.Parameters.AddWithValue("@p10", mskVeliTelefon.Text);
            komut.Parameters.AddWithValue("@p11", rchAdres.Text);
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Öğrenci kaydı yapıldı!");



            //Öğrenci ID'yi Label12'ye çekme
            baglanti.Open();
            SqlCommand komut2 = new SqlCommand("select OGRID from TBLOGRENCI", baglanti);
            SqlDataReader dr = komut2.ExecuteReader();
            while (dr.Read())
            {
                label12.Text = dr[0].ToString();
            }
            baglanti.Close();



            //Öğrenci Borç Alanı Oluşturma
            baglanti.Open();
            SqlCommand komut3 = new SqlCommand("insert into TBLBORCLAR (OGRID,OGRAD,OGRSOYAD) values (@b1,@b2,@b3)", baglanti);
            komut3.Parameters.AddWithValue("@b1", label12.Text);
            komut3.Parameters.AddWithValue("@b2", txtOgrenciAd.Text);
            komut3.Parameters.AddWithValue("@b3", txtOgrenciSoyad.Text);
            komut3.ExecuteNonQuery();
            baglanti.Close();



            //Öğrenci Oda Kontenjanı Arttırma
            baglanti.Open();
            SqlCommand komutoda = new SqlCommand("update TBLODALAR set ODAAKTIF+=1 where ODANO=@q1", baglanti);
            komutoda.Parameters.AddWithValue("@q1", cmbOdaNo.Text);
            komutoda.ExecuteNonQuery();
            baglanti.Close();


        }
    }
}
