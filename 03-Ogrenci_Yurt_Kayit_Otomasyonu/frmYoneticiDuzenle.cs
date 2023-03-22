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
    public partial class frmYoneticiDuzenle : Form
    {
        public frmYoneticiDuzenle()
        {
            InitializeComponent();
        }

        SqlBaglantisi bgl = new SqlBaglantisi();

        private void frmYoneticiDuzenle_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dbYurtOtomasyonuDataSet5.TBLADMIN' table. You can move, or remove it, as needed.
            this.tBLADMINTableAdapter.Fill(this.dbYurtOtomasyonuDataSet5.TBLADMIN);

        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("insert into TBLADMIN (YONETICIAD,YONETICISIFRE) values (@p1,@p2)", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", txtKullaniciAdi.Text);
            komut.Parameters.AddWithValue("@p2", txtSifre.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Kayıt işlemi gerçekleştirildi!");
            this.tBLADMINTableAdapter.Fill(this.dbYurtOtomasyonuDataSet5.TBLADMIN);

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;
            txtYoneticiID.Text = dataGridView1.Rows[secilen].Cells[0].Value.ToString();
            txtKullaniciAdi.Text = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
            txtSifre.Text = dataGridView1.Rows[secilen].Cells[2].Value.ToString();
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("delete from TBLADMIN where YONETICIID=@p1", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", txtYoneticiID.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Silme işlemi başarıyla gerçekleşti!");
            this.tBLADMINTableAdapter.Fill(this.dbYurtOtomasyonuDataSet5.TBLADMIN);

            txtYoneticiID.Text = "";
            txtKullaniciAdi.Text = "";
            txtSifre.Text = "";

        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("update TBLADMIN set YONETICIAD=@p1, YONETICISIFRE=@p2 where YONETICIID=@p3", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", txtKullaniciAdi.Text);
            komut.Parameters.AddWithValue("@p2", txtSifre.Text);
            komut.Parameters.AddWithValue("@p3", txtYoneticiID.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Güncelleme işlemi başarılı!");
            this.tBLADMINTableAdapter.Fill(this.dbYurtOtomasyonuDataSet5.TBLADMIN);

        }
    }
}
