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
    public partial class frmFaturalar : Form
    {
        public frmFaturalar()
        {
            InitializeComponent();
        }


        sqlbaglantisi bgl = new sqlbaglantisi();


        void listele()
        {
            SqlDataAdapter da = new SqlDataAdapter("select * from TBLFATURABILGI", bgl.baglanti());
            DataTable dt = new DataTable();
            da.Fill(dt);
            gridControl1.DataSource = dt;
        }


        void temizle()
        {
            txtAlici.Text = "";
            txtID.Text = "";
            txtSeri.Text = "";
            txtSiraNo.Text = "";
            txtTeslimAlan.Text = "";
            txtTeslimEden.Text = "";
            txtVergiDaire.Text = "";
            mskSaat.Text = "";
            mskTarih.Text = "";
            txtSeri.Focus();
        }

        private void frmFaturalar_Load(object sender, EventArgs e)
        {
            listele();
            temizle();
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            if (txtFaturaID.Text == "")
            {
                SqlCommand komut = new SqlCommand("insert into TBLFATURABILGI " +
                    "(SERI,SIRANO,TARIH,SAAT,VERGIDAIRE,ALICI,TESLIMEDEN,TESLIMALAN) values " +
                    "(@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8)", bgl.baglanti());

                komut.Parameters.AddWithValue("@p1", txtSeri.Text);
                komut.Parameters.AddWithValue("@p2", txtSiraNo.Text);
                komut.Parameters.AddWithValue("@p3", mskTarih.Text);
                komut.Parameters.AddWithValue("@p4", mskSaat.Text);
                komut.Parameters.AddWithValue("@p5", txtVergiDaire.Text);
                komut.Parameters.AddWithValue("@p6", txtAlici.Text);
                komut.Parameters.AddWithValue("@p7", txtTeslimEden.Text);
                komut.Parameters.AddWithValue("@p8", txtTeslimAlan.Text);
                komut.ExecuteNonQuery();
                bgl.baglanti().Close();
                MessageBox.Show("Fatura Bilgisi Sisteme Kaydedildi!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                listele();
            }
            if (txtFaturaID.Text != "")
            {
                double miktar, tutar, fiyat;
                fiyat = Convert.ToDouble(txtFiyat.Text);
                miktar = Convert.ToDouble(txtMiktar.Text);
                tutar = miktar * fiyat;
                txtTutar.Text = tutar.ToString();

                SqlCommand komut2 = new SqlCommand("insert into TBLFATURADETAY " +
                    "(URUNAD,MIKTAR,FIYAT,TUTAR,FATURAID) values " +
                    "(@p1,@p2,@p3,@p4,@p5)", bgl.baglanti());
                komut2.Parameters.AddWithValue("@p1", txtUrunAd.Text);
                komut2.Parameters.AddWithValue("@p2", txtMiktar.Text);
                komut2.Parameters.AddWithValue("@p3", txtFiyat.Text);
                komut2.Parameters.AddWithValue("@p4", txtTutar.Text);
                komut2.Parameters.AddWithValue("@p5", txtFaturaID.Text);
                komut2.ExecuteNonQuery();
                bgl.baglanti().Close();
                MessageBox.Show("Faturaya Ait Ürün Kaydedildi!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                listele();
            }
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            if (dr != null)
            {
                txtID.Text = dr["FATURABILGIID"].ToString();
                txtSiraNo.Text = dr["SIRANO"].ToString();
                txtSeri.Text = dr["SERI"].ToString();
                mskTarih.Text = dr["TARIH"].ToString();
                mskSaat.Text = dr["SAAT"].ToString();
                txtAlici.Text = dr["ALICI"].ToString();
                txtTeslimEden.Text = dr["TESLIMEDEN"].ToString();
                txtTeslimAlan.Text = dr["TESLIMALAN"].ToString();
                txtVergiDaire.Text = dr["VERGIDAIRE"].ToString();

            }
        }

        private void btnTemizel_Click(object sender, EventArgs e)
        {
            temizle();
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("delete from TBLFATURABILGI where FATURABILGIID=@p1", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", txtID.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Fatura Silindi!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Question);
            listele();
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("update TBLFATURABILGI set " +
                "SERI=@p1,SIRANO=@p2,TARIH=@p3,SAAT=@p4,VERGIDAIRE=@p5,ALICI=@p6,TESLIMEDEN=@p7,TESLIMALAN=@p8 " +
                "where FATURABILGIID=@p9", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", txtSeri.Text);
            komut.Parameters.AddWithValue("@p2", txtSiraNo.Text);
            komut.Parameters.AddWithValue("@p3", mskTarih.Text);
            komut.Parameters.AddWithValue("@p4", mskSaat.Text);
            komut.Parameters.AddWithValue("@p5", txtVergiDaire.Text);
            komut.Parameters.AddWithValue("@p6", txtAlici.Text);
            komut.Parameters.AddWithValue("@p7", txtTeslimEden.Text);
            komut.Parameters.AddWithValue("@p8", txtTeslimAlan.Text);
            komut.Parameters.AddWithValue("@p9", txtID.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Fatura Bilgisi Güncellendi!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            listele();

        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            frmFaturaUrunDetay fr = new frmFaturaUrunDetay();
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);

            if (dr != null)
            {
                fr.id = dr["FATURABILGIID"].ToString();
            }
            fr.Show();
        }
    }
}
