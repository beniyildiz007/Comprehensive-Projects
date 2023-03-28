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
using DevExpress.Charts;

namespace _04_DevExpress_SQL_Tabanli_Ticari_Otomasyon
{
    public partial class frmKasa : Form
    {
        public frmKasa()
        {
            InitializeComponent();
        }

        sqlbaglantisi bgl = new sqlbaglantisi();


        void musteriHareket()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("execute MusteriHareketler", bgl.baglanti());
            da.Fill(dt);
            gridControl1.DataSource = dt;
        }
        void firmaHareket()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("execute FirmaHareketler", bgl.baglanti());
            da.Fill(dt);
            gridControl3.DataSource = dt;
        }

        public string ad;

        private void frmKasa_Load(object sender, EventArgs e)
        {

            lblAktifKullanici.Text = ad;

            musteriHareket();
            firmaHareket();


            //Toplam Tutarı Hesaplama
            SqlCommand komut = new SqlCommand("select sum(TUTAR) from TBLFATURADETAY", bgl.baglanti());
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                lblToplamTutar.Text = dr[0] + " ₺";
            }
            bgl.baglanti().Close();



            //Son ayın faturaları
            SqlCommand komut2 = new SqlCommand("select (ELEKTRIK+SU+DOGALGAZ) from TBLGIDERLER order by ID asc", bgl.baglanti());
            SqlDataReader dr2 = komut2.ExecuteReader();
            while (dr2.Read())
            {
                lblOdemeler.Text = dr2[0] + " ₺";
            }
            bgl.baglanti().Close();



            //Son ayın personel maaşları
            SqlCommand komut3 = new SqlCommand("select maaslar from TBLGIDERLER order by ID asc", bgl.baglanti());
            SqlDataReader dr3 = komut3.ExecuteReader();
            while (dr3.Read())
            {
                lblPersonelMaaslari.Text = dr3[0] + " ₺";
            }
            bgl.baglanti().Close();



            //Toplam müşteri sayısı
            SqlCommand komut4 = new SqlCommand("select count(*) from TBLMUSTERILER", bgl.baglanti());
            SqlDataReader dr4 = komut4.ExecuteReader();
            while (dr4.Read())
            {
                lblMusteriSayisi.Text = dr4[0].ToString();
            }
            bgl.baglanti().Close();



            //Toplam firma sayısı
            SqlCommand komut5 = new SqlCommand("select count(*) from TBLFIRMALAR", bgl.baglanti());
            SqlDataReader dr5 = komut5.ExecuteReader();
            while (dr5.Read())
            {
                lblFirmaSayisi.Text = dr5[0].ToString();
            }
            bgl.baglanti().Close();



            //Toplam firma şehir sayısı
            SqlCommand komut6 = new SqlCommand("select count(distinct(IL)) from TBLFIRMALAR", bgl.baglanti());
            SqlDataReader dr6 = komut6.ExecuteReader();
            while (dr6.Read())
            {
                lblFirmaSehir.Text = dr6[0].ToString();
            }
            bgl.baglanti().Close();



            //Toplam müşteri şehir sayısı
            SqlCommand komut7 = new SqlCommand("select count(*) from TBLMUSTERILER", bgl.baglanti());
            SqlDataReader dr7 = komut7.ExecuteReader();
            while (dr7.Read())
            {
                lblMusteriSehir.Text = dr7[0].ToString();
            }
            bgl.baglanti().Close();



            //Toplam personel sayısı
            SqlCommand komut8 = new SqlCommand("select count(*) from TBLPERSONELLER", bgl.baglanti());
            SqlDataReader dr8 = komut8.ExecuteReader();
            while (dr8.Read())
            {
                lblPersonelSayisi.Text = dr8[0].ToString();
            }
            bgl.baglanti().Close();



            //Toplam ürün sayısı
            SqlCommand komut9 = new SqlCommand("select sum(ADET) from TBLURUNLER", bgl.baglanti());
            SqlDataReader dr9 = komut9.ExecuteReader();
            while (dr9.Read())
            {
                lblStokSayisi.Text = dr9[0].ToString();
            }
            bgl.baglanti().Close();



            //1. Chart Control'e Elektrik Faturası son 4 ay ekleme
            SqlCommand komut10 = new SqlCommand("select top 4 AY,ELEKTRIK from TBLGIDERLER order by ID desc", bgl.baglanti());
            SqlDataReader dr10 = komut10.ExecuteReader();
            while (dr10.Read())
            {
                chartControl1.Series["Aylar"].Points.Add(new DevExpress.XtraCharts.SeriesPoint(dr10[0], dr10[1]));
            }
            bgl.baglanti().Close();



            //2. Chart Control'e Su Faturası son 4 ay ekleme
            SqlCommand komut11 = new SqlCommand("select top 4 AY,SU from TBLGIDERLER order by ID desc", bgl.baglanti());
            SqlDataReader dr11 = komut11.ExecuteReader();
            while (dr11.Read())
            {
                chartControl1.Series["Aylar"].Points.Add(new DevExpress.XtraCharts.SeriesPoint(dr11[0], dr11[1]));
            }
            bgl.baglanti().Close();


        }
    }
}
