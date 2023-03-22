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
    public partial class frmGider : Form
    {
        public frmGider()
        {
            InitializeComponent();
        }

        SqlBaglantisi bgl = new SqlBaglantisi();

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("insert into TBLGIDERLER (ELEKTRIK,SU,DOGALGAZ,INTERNET,GIDA,PERSONEL,DIGER) values (@p1,@p2,@p3,@p4,@p5,@p6,@p7)", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", txtElektrik.Text);
            komut.Parameters.AddWithValue("@p2", txtSu.Text);
            komut.Parameters.AddWithValue("@p3", txtDogalGaz.Text);
            komut.Parameters.AddWithValue("@p4", txtInternet.Text);
            komut.Parameters.AddWithValue("@p5", txtGida.Text);
            komut.Parameters.AddWithValue("@p6", txtPersonel.Text);
            komut.Parameters.AddWithValue("@p7", txtDiger.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Kayıtlar Eklendi!");
        }
    }
}
