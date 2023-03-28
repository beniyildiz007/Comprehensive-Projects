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
    public partial class frmAnaSayfa : Form
    {
        public frmAnaSayfa()
        {
            InitializeComponent();
        }

        sqlbaglantisi bgl = new sqlbaglantisi();


        void stoklar()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select URUNAD,sum(ADET) as 'Adet' from TBLURUNLER" +
                " group by URUNAD having sum(ADET)<=20 order by sum(ADET)", bgl.baglanti());
            da.Fill(dt);
            gridControl1.DataSource = dt;
        }


        void ajanda()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select top 10 TARIH,SAAT,BASLIK from TBLNOTLAR order by ID desc", bgl.baglanti());
            da.Fill(dt);
            gridControl2.DataSource = dt;
        }


        void FirmaHareketleri()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("execute FirmaHareketler", bgl.baglanti());
            da.Fill(dt);
            gridControl3.DataSource = dt;
        }



        void fihrist()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select AD,TELEFON1 from TBLFIRMALAR", bgl.baglanti());
            da.Fill(dt);
            gridControl4.DataSource = dt;
        }


        private void frmAnaSayfa_Load(object sender, EventArgs e)
        {
            stoklar();
            ajanda();
            FirmaHareketleri();
            fihrist();

            webBrowser1.Navigate("http://www.tcmb.gov.tr/kurlar/today.xml");
        }
    }
}
