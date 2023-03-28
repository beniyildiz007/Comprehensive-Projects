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

namespace _04_DevExpress_SQL_Tabanli_Ticari_Otomasyon
{
    public partial class frmFaturaUrunDuzenleme : Form
    {
        public frmFaturaUrunDuzenleme()
        {
            InitializeComponent();
        }

        sqlbaglantisi bgl = new sqlbaglantisi();


        public string urunid;
        private void frmFaturaUrunDuzenleme_Load(object sender, EventArgs e)
        {
            txtUrunID.Text = urunid;

            SqlCommand komut = new SqlCommand("select * from TBLFATURADETAY where FATURAURUNID=@p1", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", urunid);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                txtFiyat.Text = dr[3].ToString();
                txtMiktar.Text = dr[2].ToString();
                txtTutar.Text = dr[4].ToString();
                txtUrunAd.Text = dr[1].ToString();
            }
            bgl.baglanti().Close();
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("update TBLFATURADETAY set URUNAD=@p1, MIKTAR=@p2, FIYAT=@p3, TUTAR=@p4" +
                " where FATURAURUNID=@p5", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", txtUrunAd.Text);
            komut.Parameters.AddWithValue("@p2", txtMiktar.Text);
            komut.Parameters.AddWithValue("@p3",decimal.Parse(txtFiyat.Text));
            komut.Parameters.AddWithValue("@p4",decimal.Parse(txtTutar.Text));
            komut.Parameters.AddWithValue("@p5", txtUrunID.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Değişiklikler Kaydedildi!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("delete from TBLFATURADETAY where FATURAURUNID=@p1", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", txtUrunID.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Ürün Silindi!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Hand);
        }
    }
}
