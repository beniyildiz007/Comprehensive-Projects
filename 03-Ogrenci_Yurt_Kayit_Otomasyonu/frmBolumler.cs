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
    public partial class frmBolumler : Form
    {
        public frmBolumler()
        {
            InitializeComponent();
        }

        SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-HKL3D7O\SQLEXPRESS;Initial Catalog=dbYurtOtomasyonu;Integrated Security=True");


        void listele()
        {
            // TODO: This line of code loads data into the 'dbYurtOtomasyonuDataSet.TBLBOLUMLER' table. You can move, or remove it, as needed.
            this.tBLBOLUMLERTableAdapter.Fill(this.dbYurtOtomasyonuDataSet.TBLBOLUMLER);

        }

        private void frmBolumler_Load(object sender, EventArgs e)
        {
            listele();
        }

        private void pcEkle_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("insert into TBLBOLUMLER (BOLUMAD) values (@p1)", baglanti);
            komut.Parameters.AddWithValue("@p1", txtBolumAD.Text);
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Bölüm listeye eklendi!");
            listele();

        }

        private void pcSil_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("delete from TBLBOLUMLER where BOLUMID=@p1", baglanti);
            komut.Parameters.AddWithValue("@p1", txtBolumID.Text);
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Silme işlemi gerçekleştirildi!");
            listele();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;
            txtBolumID.Text = dataGridView1.Rows[secilen].Cells[0].Value.ToString();
            txtBolumAD.Text = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
        }

        private void pcDuzenle_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("update TBLBOLUMLER set BOLUMAD=@p1 where BOLUMID=@p2", baglanti);
            komut.Parameters.AddWithValue("@p1", txtBolumAD.Text);
            komut.Parameters.AddWithValue("@p2", txtBolumID.Text);
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Düzenleme işlemi yapıldı");
            listele();
        }
    }
}
