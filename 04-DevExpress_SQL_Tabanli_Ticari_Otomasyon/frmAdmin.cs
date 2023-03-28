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
    public partial class frmAdmin : Form
    {
        public frmAdmin()
        {
            InitializeComponent();
        }

        sqlbaglantisi bgl = new sqlbaglantisi();

        private void simpleButton1_MouseHover(object sender, EventArgs e)
        {
            btnGiris.BackColor = Color.Yellow;
        }

        private void simpleButton1_MouseLeave(object sender, EventArgs e)
        {
            btnGiris.BackColor = Color.White;
        }

        
        private void btnGiris_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("select * from TBLADMIN where KULLANICIAD=@p1 and SIFRE=@p2", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", txtKullaniciAd.Text);
            komut.Parameters.AddWithValue("@p2", txtSifre.Text);
            SqlDataReader dr = komut.ExecuteReader();
            if (dr.Read())
            {
                frmAnaForm fr = new frmAnaForm();
                fr.kullanici = txtKullaniciAd.Text;
                fr.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Hatalı Kullanıcı Adı ya da Şifre!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            bgl.baglanti().Close();

        }

        private void frmAdmin_Load(object sender, EventArgs e)
        {

        }
    }
}
