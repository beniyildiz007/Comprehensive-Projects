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
    public partial class frmGelirIstatistik : Form
    {
        public frmGelirIstatistik()
        {
            InitializeComponent();
        }

        SqlBaglantisi bgl = new SqlBaglantisi();

        private void frmGelirIstatistik_Load(object sender, EventArgs e)
        {
            //Kasadaki Toplam Tutar
            SqlCommand komut = new SqlCommand("select sum(ODEMEMIKTAR) from TBLKASA", bgl.baglanti());
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                lblKasadakiPara.Text = dr[0] + " TL";
            }
            bgl.baglanti().Close();



            //Tekrarsız olarak ayları listeleme
            SqlCommand komut2 = new SqlCommand("select distinct(ODEMEAY) from TBLKASA",bgl.baglanti());
            SqlDataReader dr2 = komut2.ExecuteReader();
            while (dr2.Read())
            {
                comboBox1.Items.Add(dr2[0].ToString());
            }
            bgl.baglanti().Close();



            //Grafiklere Veritabanından Veri Çekme
            SqlCommand k3 = new SqlCommand("select ODEMEAY,sum(ODEMEMIKTAR) from TBLKASA group by ODEMEAY", bgl.baglanti());
            SqlDataReader dr3 = k3.ExecuteReader();
            while (dr3.Read())
            {
                this.chart1.Series["Aylık"].Points.AddXY(dr3[0], dr3[1]);
            }
            bgl.baglanti().Close();
            
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("select sum(ODEMEMIKTAR) from TBLKASA where ODEMEAY=@p1", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", comboBox1.SelectedItem);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                lblAyKazanc.Text = dr[0].ToString();
            }
            bgl.baglanti().Close();
        }
    }
}
