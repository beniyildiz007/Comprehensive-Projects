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
    public partial class frmAdminGiris : Form
    {
        public frmAdminGiris()
        {
            InitializeComponent();
        }

        SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-HKL3D7O\SQLEXPRESS;Initial Catalog=dbPansiyonKayit;Integrated Security=True");


        private void btnGiris_Click(object sender, EventArgs e)
        {

            baglanti.Open();
            SqlCommand komut = new SqlCommand("select * from TBLADMINGIRIS where KULLANICIADI=@p1 and SIFRE=@p2", baglanti);
            komut.Parameters.AddWithValue("@p1", txtKullaniciAdi.Text);
            komut.Parameters.AddWithValue("@p2", txtSifre.Text);
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);

            if (dt.Rows.Count > 0)
            {
                frmAnaForm fr = new frmAnaForm();
                fr.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Hatalı Giriş!", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning); ;

            }
            baglanti.Close();


            //try
            //{
            //    if (dt.Rows.Count > 0)
            //    {
            //        frmAnaForm fr = new frmAnaForm();
            //        fr.Show();
            //        this.Hide();
            //    }
            //}
            //catch (Exception)
            //{
            //    MessageBox.Show("Hatalı Giriş!", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning); ;
            //}
            //baglanti.Close();

        }
    }
}
