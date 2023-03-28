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
    public partial class frmPersonel : Form
    {
        public frmPersonel()
        {
            InitializeComponent();
        }

        sqlbaglantisi bgl = new sqlbaglantisi();

        void listele()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select * from TBLPERSONELLER", bgl.baglanti());
            da.Fill(dt);
            gridControl1.DataSource = dt;
        }


        void sehirlistesi()
        {
            SqlCommand komut = new SqlCommand("select SEHIR from TBLILLER", bgl.baglanti());
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                cmbIL.Items.Add(dr[0]);
            }
            bgl.baglanti().Close();
        }



        private void frmPersonel_Load(object sender, EventArgs e)
        {
            listele();
            sehirlistesi();
            temizle();
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("insert into TBLPERSONELLER " +
                "(AD,SOYAD,TELEFON,TC,MAIL,IL,ILCE,ADRES,GOREV) values " +
                "(@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8,@p9)", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", txtAd.Text);
            komut.Parameters.AddWithValue("@p2", txtSoyad.Text);
            komut.Parameters.AddWithValue("@p3", mskTel1.Text);
            komut.Parameters.AddWithValue("@p4", mskTC.Text);
            komut.Parameters.AddWithValue("@p5", txtMail.Text);
            komut.Parameters.AddWithValue("@p6", cmbIL.Text);
            komut.Parameters.AddWithValue("@p7", cmbILCE.Text);
            komut.Parameters.AddWithValue("@p8", rchAdres.Text);
            komut.Parameters.AddWithValue("@p9", txtGorev.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            listele();
            temizle();
            MessageBox.Show("Personel Bilgileri Kaydedildi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        void temizle()
        {
            txtAd.Text = "";
            txtID.Text = "";
            txtMail.Text = "";
            txtSoyad.Text = "";
            cmbIL.Text = "";
            cmbILCE.Text = "";
            rchAdres.Text = "";
            txtGorev.Text = "";
            mskTel1.Text = "";
            mskTC.Text = "";
            txtAd.Focus();
        }


        private void cmbIL_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbILCE.Items.Clear();
            SqlCommand komut = new SqlCommand("select ILCE from TBLILCELER where SEHIR=@p1", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", cmbIL.SelectedIndex + 1);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                cmbILCE.Items.Add(dr[0]);
            }
            bgl.baglanti().Close();
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);

            if (dr != null)
            {
                txtID.Text = dr["ID"].ToString();
                txtAd.Text = dr["AD"].ToString();
                txtSoyad.Text = dr["SOYAD"].ToString();
                mskTel1.Text = dr["TELEFON"].ToString();
                mskTC.Text = dr["TC"].ToString();
                txtMail.Text = dr["MAIL"].ToString();
                cmbIL.Text = dr["IL"].ToString();
                cmbILCE.Text = dr["ILCE"].ToString();
                rchAdres.Text = dr["ADRES"].ToString();
                txtGorev.Text = dr["GOREV"].ToString();
            }
        }

        private void btnTemizle_Click(object sender, EventArgs e)
        {
            temizle();
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("delete from TBLPERSONELLER where ID=@p1", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", txtID.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            listele();
            temizle();
            MessageBox.Show("Personel Listeden Silindi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.None);
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("update TBLPERSONELLER set AD=@p1,SOYAD=@p2,TELEFON=@p3,TC=@p4,MAIL=@p5,IL=@p6,ILCE=@p7,ADRES=@p8,GOREV=@p9 where ID=@p10", bgl.baglanti());
            komut.Parameters.AddWithValue("@p10", txtID.Text);
            komut.Parameters.AddWithValue("@p1", txtAd.Text);
            komut.Parameters.AddWithValue("@p2", txtSoyad.Text);
            komut.Parameters.AddWithValue("@p3", mskTel1.Text);
            komut.Parameters.AddWithValue("@p4", mskTC.Text);
            komut.Parameters.AddWithValue("@p5", txtMail.Text);
            komut.Parameters.AddWithValue("@p6", cmbIL.Text);
            komut.Parameters.AddWithValue("@p7", cmbILCE.Text);
            komut.Parameters.AddWithValue("@p8", rchAdres.Text);
            komut.Parameters.AddWithValue("@p9", txtGorev.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Personel Bilgileri Güncellendi!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            listele();
            temizle();
        }
    }
}
