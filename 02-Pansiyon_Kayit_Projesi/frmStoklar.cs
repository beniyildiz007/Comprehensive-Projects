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
    public partial class frmStoklar : Form
    {
        public frmStoklar()
        {
            InitializeComponent();
        }

        SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-HKL3D7O\SQLEXPRESS;Initial Catalog=dbPansiyonKayit;Integrated Security=True");


        private void frmStoklar_Load(object sender, EventArgs e)
        {
            listele();
        }

        void listele()
        {
            listView1.Items.Clear();

            baglanti.Open();
            SqlCommand komut = new SqlCommand("select * from TBLSTOKLAR", baglanti);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                ListViewItem ekle = new ListViewItem();
                ekle.Text = dr["GIDA"].ToString();
                ekle.SubItems.Add(dr["ICECEK"].ToString());
                ekle.SubItems.Add(dr["CEREZLER"].ToString());
                listView1.Items.Add(ekle);
            }
            baglanti.Close();
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("insert into TBLSTOKLAR (GIDA,ICECEK,CEREZLER) values(@p1,@p2,@p3)", baglanti);
            komut.Parameters.AddWithValue("@p1", txtGidaTutar.Text);
            komut.Parameters.AddWithValue("@p2", txtİcecekTutar.Text);
            komut.Parameters.AddWithValue("@p3", txtAtistirmaliklar.Text);
            komut.ExecuteNonQuery();
            baglanti.Close();

            listele();
        }
    }
}
