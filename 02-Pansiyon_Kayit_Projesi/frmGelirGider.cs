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
    public partial class frmGelirGider : Form
    {
        public frmGelirGider()
        {
            InitializeComponent();
        }

        SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-HKL3D7O\SQLEXPRESS;Initial Catalog=dbPansiyonKayit;Integrated Security=True");

        private void frmGelirGider_Load(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select sum(ucret) as 'TOPLAM' from TBLMUSTERIEKLE", baglanti);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                lblToplamTutar.Text = dr["TOPLAM"].ToString();
            }
            baglanti.Close();

            int personel = Convert.ToInt32(txtPersonelSayisi.Text);
            lblMaas.Text = (personel * 8500).ToString();



            //Gıdalar
            baglanti.Open();
            SqlCommand komut2 = new SqlCommand("select sum(GIDA) as 'TOPLAM' from TBLSTOKLAR", baglanti);
            SqlDataReader dr2 = komut2.ExecuteReader();
            while (dr2.Read())
            {
                lblUrunTutar1.Text = dr2["TOPLAM"].ToString();
            }
            baglanti.Close();


            //İçecekler
            baglanti.Open();
            SqlCommand komut3 = new SqlCommand("select sum(ICECEK) as 'TOPLAM' from TBLSTOKLAR", baglanti);
            SqlDataReader dr3 = komut3.ExecuteReader();
            while (dr3.Read())
            {
                lblUrunTutar2.Text = dr3["TOPLAM"].ToString();
            }
            baglanti.Close();


            //Çerezler
            baglanti.Open();
            SqlCommand komut4 = new SqlCommand("select sum(CEREZLER) as 'TOPLAM' from TBLSTOKLAR", baglanti);
            SqlDataReader dr4 = komut4.ExecuteReader();
            while (dr4.Read())
            {
                lblUrunTutar3.Text = dr4["TOPLAM"].ToString();
            }
            baglanti.Close();




        }

        private void btnHesapla_Click(object sender, EventArgs e)
        {
            int sonuc = Convert.ToInt32(lblToplamTutar.Text) - (Convert.ToInt32(lblMaas.Text) + Convert.ToInt32(lblUrunTutar1.Text) + Convert.ToInt32(lblUrunTutar2.Text) + Convert.ToInt32(lblUrunTutar3.Text));
            lblSonuc.Text = sonuc.ToString();
        }

        private void txtPersonelSayisi_TextChanged(object sender, EventArgs e)
        {
            int personel = Convert.ToInt32(txtPersonelSayisi.Text);
            lblMaas.Text = (personel * 8500).ToString();

        }
    }
}
