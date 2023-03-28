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
    public partial class frmGiderler : Form
    {
        public frmGiderler()
        {
            InitializeComponent();
        }

        sqlbaglantisi bgl = new sqlbaglantisi();


        void listele()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select * from TBLGIDERLER", bgl.baglanti());
            da.Fill(dt);
            gridControl1.DataSource = dt;
        }


        void temizle()
        {
            txtDogalgaz.Text = "";
            txtID.Text = "";
            txtEkstra.Text = "";
            txtElektrik.Text = "";
            txtInternet.Text = "";
            txtMaaslar.Text = "";
            txtSu.Text = "";
            cmbAY.Text = "";
            cmbYIL.Text = "";
            txtNotlar.Text = "";
        }

        private void frmGiderler_Load(object sender, EventArgs e)
        {
            listele();
            temizle();
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("insert into TBLGIDERLER " +
                "(AY,YIL,ELEKTRIK,SU,DOGALGAZ,INTERNET,MAASLAR,EKSTRA,NOTLAR) values " +
                "(@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8,@p9)", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", cmbAY.Text);
            komut.Parameters.AddWithValue("@p2", cmbYIL.Text);
            komut.Parameters.AddWithValue("@p3", decimal.Parse(txtElektrik.Text));
            komut.Parameters.AddWithValue("@p4", decimal.Parse(txtSu.Text));
            komut.Parameters.AddWithValue("@p5", decimal.Parse(txtDogalgaz.Text));
            komut.Parameters.AddWithValue("@p6", decimal.Parse(txtInternet.Text));
            komut.Parameters.AddWithValue("@p7", decimal.Parse(txtMaaslar.Text));
            komut.Parameters.AddWithValue("@p8", decimal.Parse(txtEkstra.Text));
            komut.Parameters.AddWithValue("@p9", txtNotlar.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Giderler Tabloya Eklendi!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            listele();
            //temizle();
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            if (dr != null)
            {
                txtID.Text = dr["ID"].ToString();
                cmbAY.Text = dr["AY"].ToString();
                cmbYIL.Text = dr["YIL"].ToString();
                txtElektrik.Text = dr["ELEKTRIK"].ToString();
                txtSu.Text = dr["SU"].ToString();
                txtDogalgaz.Text = dr["DOGALGAZ"].ToString();
                txtInternet.Text = dr["INTERNET"].ToString();
                txtMaaslar.Text = dr["MAASLAR"].ToString();
                txtEkstra.Text = dr["EKSTRA"].ToString();
                txtNotlar.Text = dr["NOTLAR"].ToString();
            }
        }

        private void btnTemizle_Click(object sender, EventArgs e)
        {
            temizle();
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("delete from TBLGIDERLER where ID=@p1", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", txtID.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            listele();
            MessageBox.Show("Seçili Gider Listeden Silindi", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            temizle();
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("update TBLGIDERLER set AY=@p1, YIL=@p2,ELEKTRIK=@p3,SU=@p4,DOGALGAZ=@p5,INTERNET=@p6,MAASLAR=@p7,EKSTRA=@p8,NOTLAR=@p9 where ID=@p10", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", cmbAY.Text);
            komut.Parameters.AddWithValue("@p2", cmbYIL.Text);
            komut.Parameters.AddWithValue("@p3", decimal.Parse(txtElektrik.Text));
            komut.Parameters.AddWithValue("@p4", decimal.Parse(txtSu.Text));
            komut.Parameters.AddWithValue("@p5", decimal.Parse(txtDogalgaz.Text));
            komut.Parameters.AddWithValue("@p6", decimal.Parse(txtInternet.Text));
            komut.Parameters.AddWithValue("@p7", decimal.Parse(txtMaaslar.Text));
            komut.Parameters.AddWithValue("@p8", decimal.Parse(txtEkstra.Text));
            komut.Parameters.AddWithValue("@p9", txtNotlar.Text);
            komut.Parameters.AddWithValue("@p10", txtID.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Giderler Bilgisi Güncellendi!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            listele();
            temizle();

        }
    }
}
