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
    public partial class frmAyarlar : Form
    {
        public frmAyarlar()
        {
            InitializeComponent();
        }

        sqlbaglantisi bgl = new sqlbaglantisi();


        void listele()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select * from TBLADMIN", bgl.baglanti());
            da.Fill(dt);
            gridControl1.DataSource = dt;
        }

        private void frmAyarlar_Load(object sender, EventArgs e)
        {
            listele();
            txtKullaniciAdi.Text = "";
            txtSifre.Text = "";
            txtKullaniciAdi.Focus();

        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            if (btnKaydet.Text == "Kaydet")
            {
                SqlCommand komut = new SqlCommand("insert into TBLADMIN values (@p1,@p2)", bgl.baglanti());
                komut.Parameters.AddWithValue("@p1", txtKullaniciAdi.Text);
                komut.Parameters.AddWithValue("@p2", txtSifre.Text);
                komut.ExecuteNonQuery();
                bgl.baglanti().Close();
                MessageBox.Show("Yeni Admin Sisteme Kaydedildi!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                listele();

                txtKullaniciAdi.Text = "";
                txtSifre.Text = "";
                txtKullaniciAdi.Focus();
            }
            if (btnKaydet.Text == "Güncelle")
            {
                SqlCommand komut1 = new SqlCommand("update TBLADMIN set SIFRE=@p2 where KULLANICIAD=@p1", bgl.baglanti());
                komut1.Parameters.AddWithValue("@p1", txtSifre.Text);
                komut1.Parameters.AddWithValue("@p2", txtKullaniciAdi.Text);
                komut1.ExecuteNonQuery();
                bgl.baglanti().Close();
                MessageBox.Show("Kayıt Güncellendi!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                listele();

                txtKullaniciAdi.Text = "";
                txtSifre.Text = "";
                txtKullaniciAdi.Focus();
            }
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);

            if (dr != null)
            {
                txtKullaniciAdi.Text = dr["KULLANICIAD"].ToString();
                txtSifre.Text = dr["SIFRE"].ToString();
            }
        }

        private void txtKullaniciAdi_TextChanged(object sender, EventArgs e)
        {
            if (txtKullaniciAdi.Text != "")
            {
                btnKaydet.Text = "Güncelle";
            }
            else
            {
                btnKaydet.Text = "Kaydet";
            }
        }
    }
}
