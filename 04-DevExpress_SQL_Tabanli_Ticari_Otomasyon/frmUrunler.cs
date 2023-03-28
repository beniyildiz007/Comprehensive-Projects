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
    public partial class frmUrunler : Form
    {
        public frmUrunler()
        {
            InitializeComponent();
        }

        private void groupControl1_Paint(object sender, PaintEventArgs e)
        {

        }

        sqlbaglantisi bgl = new sqlbaglantisi();


        void listele()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select * from TBLURUNLER", bgl.baglanti());
            da.Fill(dt);
            gridControl1.DataSource = dt;
        }


        void temizle()
        {
            txtAd.Text = "";
            txtAlisFiyat.Text = "";
            txtID.Text = "";
            txtMarka.Text = "";
            txtModel.Text = "";
            txtSatisFiyat.Text = "";
            mskYil.Text = "";
            nudAdet.Text = "";
            rchDetay.Text = "";
            txtAd.Focus();

        }

        private void frmUrunler_Load(object sender, EventArgs e)
        {
            listele();
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            //Verileri Kaydetme
            SqlCommand komut = new SqlCommand("insert into TBLURUNLER (URUNAD,MARKA,MODEL,YIL,ADET,ALISFIYAT,SATISFIYAT,DETAY) values (@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8)", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", txtAd.Text);
            komut.Parameters.AddWithValue("@p2", txtMarka.Text);
            komut.Parameters.AddWithValue("@p3", txtModel.Text);
            komut.Parameters.AddWithValue("@p4", mskYil.Text);
            komut.Parameters.AddWithValue("@p5", int.Parse((nudAdet.Value).ToString()));
            komut.Parameters.AddWithValue("@p6", decimal.Parse(txtAlisFiyat.Text));
            komut.Parameters.AddWithValue("@p7", decimal.Parse(txtSatisFiyat.Text));
            komut.Parameters.AddWithValue("@p8", rchDetay.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Ürün sisteme eklendi!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            listele();
            temizle();
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("delete from TBLURUNLER where ID=@p1", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", txtID.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Ürün silindi!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            listele();
            temizle();
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            txtID.Text = dr["ID"].ToString();
            txtAd.Text = dr["URUNAD"].ToString();
            txtMarka.Text = dr["MARKA"].ToString();
            txtModel.Text = dr["MODEL"].ToString();
            mskYil.Text = dr["YIL"].ToString();
            nudAdet.Value = decimal.Parse(dr["ADET"].ToString());
            txtAlisFiyat.Text = dr["ALISFIYAT"].ToString();
            txtSatisFiyat.Text = dr["SATISFIYAT"].ToString();
            rchDetay.Text = dr["DETAY"].ToString();

        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("update TBLURUNLER set URUNAD=@p1, MARKA=@p2, MODEL=@p3, YIL=@p4,ADET=@p5,ALISFIYAT=@p6,SATISFIYAT=@p7,DETAY=@p8 where ID=@p9", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", txtAd.Text);
            komut.Parameters.AddWithValue("@p2", txtMarka.Text);
            komut.Parameters.AddWithValue("@p3", txtModel.Text);
            komut.Parameters.AddWithValue("@p4", mskYil.Text);
            komut.Parameters.AddWithValue("@p5", int.Parse((nudAdet.Value).ToString()));
            komut.Parameters.AddWithValue("@p6", decimal.Parse(txtAlisFiyat.Text));
            komut.Parameters.AddWithValue("@p7", decimal.Parse(txtSatisFiyat.Text));
            komut.Parameters.AddWithValue("@p8", rchDetay.Text);
            komut.Parameters.AddWithValue("@p9", txtID.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Ürün bilgileri güncellendi!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            listele();
            temizle();

        }

        private void btnTemizle_Click(object sender, EventArgs e)
        {
            temizle();
        }
    }
}
