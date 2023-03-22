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
    public partial class frmOgrDuzenle : Form
    {
        public frmOgrDuzenle()
        {
            InitializeComponent();
        }

        SqlBaglantisi bgl = new SqlBaglantisi();

        public string id, ad, soyad, TC, telefon, dogum, bolum, mail, odano, veliad, velitel, adres;

        private void button1_Click(object sender, EventArgs e)
        {

            //Öğrenci Silme
            SqlCommand komut = new SqlCommand("delete from TBLOGRENCI where OGRID=@p1", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", txtOgrID.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Kayıt Silindi!");



            //Oda Kontenjanı Arttırma
            SqlCommand k2 = new SqlCommand("update TBLODALAR set ODAAKTIF-=1 where ODANO=@o1", bgl.baglanti());
            k2.Parameters.AddWithValue("o1", cmbOdaNo.Text);
            k2.ExecuteNonQuery();
            bgl.baglanti().Close();
        }

        private void btnGüncelle_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("update tblogrencı set ograd=@p1, ogrsoyad=@p2,ogrtc=@p3,ogrtelefon=@p4,ogrdogum=@p5,ogrbolum=@p6,ogrmaıl=@p7,ogrodano=@p8,ogrvelıadsoyad=@p9,ogrvelıtelefon=@p10,ogrvelıadres=@p11 where OGRID=@p12", bgl.baglanti());
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
            komut.Parameters.AddWithValue("@p12", txtOgrID.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Öğrenci Bilgileri Güncellendi!");

        }

        private void frmOgrDuzenle_Load(object sender, EventArgs e)
        {

            //Bölümleri Combobox'a getirme:↓
            SqlCommand komut = new SqlCommand("select BOLUMAD from TBLBOLUMLER", bgl.baglanti());
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                cmbBolum.Items.Add(dr[0].ToString());
            }
            bgl.baglanti().Close();


            //Oda Numaralarını Combobox'a getirme:↓
            SqlCommand komut2 = new SqlCommand("select ODANO from TBLODALAR", bgl.baglanti());
            SqlDataReader dr2 = komut2.ExecuteReader();
            while (dr2.Read())
            {
                cmbOdaNo.Items.Add(dr2[0].ToString());
            }
            bgl.baglanti().Close();



            //Öğrenci Listesi Formundan gelen bilgileri bu forma yerleştirme:↓
            txtOgrID.Text = id;
            txtOgrenciAd.Text = ad;
            txtOgrenciSoyad.Text = soyad;
            mskTC.Text = TC;
            mskOgrenciTelefon.Text = telefon;
            mskDogumTarihi.Text = dogum;
            cmbBolum.SelectedItem = bolum;
            txtMail.Text = mail;
            cmbOdaNo.Text = odano;
            txtVeliAdSoyad.Text = veliad;
            mskVeliTelefon.Text = velitel;
            rchAdres.Text = adres;
        }
    }
}
