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
    public partial class frmPersonel : Form
    {
        public frmPersonel()
        {
            InitializeComponent();
        }

        private void frmPersonel_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dbYurtOtomasyonuDataSet6.TBLPERSONEL' table. You can move, or remove it, as needed.
            this.tBLPERSONELTableAdapter.Fill(this.dbYurtOtomasyonuDataSet6.TBLPERSONEL);

        }

        SqlBaglantisi bgl = new SqlBaglantisi();

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("insert into TBLPERSONEL (PERSONELADSOYAD,PERSONELDEPARTMAN) values (@p1,@p2)", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", txtPersonelAdi.Text);
            komut.Parameters.AddWithValue("@p2", txtPersonelGorev.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Personel Kaydı Eklendi!");
            this.tBLPERSONELTableAdapter.Fill(this.dbYurtOtomasyonuDataSet6.TBLPERSONEL);


        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("delete from TBLPERSONEL where PERSONELID=@p1", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", txtPersonelID.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Personel kaydı silindi!");
            this.tBLPERSONELTableAdapter.Fill(this.dbYurtOtomasyonuDataSet6.TBLPERSONEL);

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;
            txtPersonelID.Text = dataGridView1.Rows[secilen].Cells[0].Value.ToString();
            txtPersonelAdi.Text = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
            txtPersonelGorev.Text = dataGridView1.Rows[secilen].Cells[2].Value.ToString();
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("update TBLPERSONEL set PERSONELADSOYAD=@p1,PERSONELDEPARTMAN=@p2 where PERSONELID=@p3", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", txtPersonelAdi.Text);
            komut.Parameters.AddWithValue("@p2",txtPersonelGorev.Text);
            komut.Parameters.AddWithValue("@p3",txtPersonelID.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Personel kaydı güncellendi!");
            this.tBLPERSONELTableAdapter.Fill(this.dbYurtOtomasyonuDataSet6.TBLPERSONEL);


        }
    }
}
