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
    public partial class frmGiderGuncelle : Form
    {
        public frmGiderGuncelle()
        {
            InitializeComponent();
        }

        public string id, elektrik, su, dogalgaz, gida, diger, internet, personel;

        SqlBaglantisi bgl = new SqlBaglantisi();

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("update TBLGIDERLER set ELEKTRIK=@p1, SU=@p2, DOGALGAZ=@p3, INTERNET=@p4, GIDA=@p5, PERSONEL=@p6, DIGER=@p7 where ODEMEID=@p8", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", txtElektrik.Text);
            komut.Parameters.AddWithValue("@p2", txtSu.Text);
            komut.Parameters.AddWithValue("@p3", txtDogalGaz.Text);
            komut.Parameters.AddWithValue("@p4", txtInternet.Text);
            komut.Parameters.AddWithValue("@p5", txtGida.Text);
            komut.Parameters.AddWithValue("@p6", txtPersonel.Text);
            komut.Parameters.AddWithValue("@p7", txtDiger.Text);
            komut.Parameters.AddWithValue("@p8", txtGiderID.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Gider Bilgileri Güncellendi!");

        }

        private void frmGiderGuncelle_Load(object sender, EventArgs e)
        {
            txtGiderID.Text = id;
            txtElektrik.Text = elektrik;
            txtSu.Text = su;
            txtDogalGaz.Text = dogalgaz;
            txtGida.Text = gida;
            txtDiger.Text = diger;
            txtInternet.Text = internet;
            txtPersonel.Text = personel;
        }
    }
}
