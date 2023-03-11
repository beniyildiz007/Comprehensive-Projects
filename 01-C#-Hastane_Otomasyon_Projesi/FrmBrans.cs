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

namespace _02_Hastane_Proejesi
{
    public partial class FrmBrans : Form
    {
        public FrmBrans()
        {
            InitializeComponent();
        }

        sqlBaglantisi bgl = new sqlBaglantisi();

        private void FrmBrans_Load(object sender, EventArgs e)
        {

            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select * from Tbl_Branslar", bgl.baglanti());
            da.Fill(dt);
            dataGridView1.DataSource = dt;

        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("insert into Tbl_Branslar (BransAd) values (@b1)", bgl.baglanti());
            komut.Parameters.AddWithValue("@b1", txtBransAd.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Branş Eklendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;
            txtBransID.Text = dataGridView1.Rows[secilen].Cells[0].Value.ToString();
            txtBransAd.Text = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("delete from Tbl_Branslar where Bransid=@b1", bgl.baglanti());
            komut.Parameters.AddWithValue("@b1", txtBransID.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Branş Silindi!");
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("update Tbl_Branslar set Bransad=@b1 where Bransid=@b2", bgl.baglanti());
            komut.Parameters.AddWithValue("@b1", txtBransAd.Text);
            komut.Parameters.AddWithValue("@b2", txtBransID.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Branşlar Güncellendi!");
        }
    }
}
