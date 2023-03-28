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
    public partial class frmStoklar : Form
    {
        public frmStoklar()
        {
            InitializeComponent();
        }

        sqlbaglantisi bgl = new sqlbaglantisi();

        private void frmStoklar_Load(object sender, EventArgs e)
        {

            SqlDataAdapter da = new SqlDataAdapter("select URUNAD,Sum(ADET) as 'Miktar' from TBLURUNLER group by URUNAD", bgl.baglanti());
            DataTable dt = new DataTable();
            da.Fill(dt);
            gridControl1.DataSource = dt;


            //Chart Üzerinde Stok Miktarı Listeleme
            SqlCommand komut = new SqlCommand("select URUNAD,sum(ADET) as 'Miktar' from TBLURUNLER group by URUNAD", bgl.baglanti());
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                chartControl1.Series["Series 1"].Points.AddPoint(Convert.ToString(dr[0]), Convert.ToInt32(dr[1].ToString()));
            }
            bgl.baglanti().Close();
        }
    }
}
