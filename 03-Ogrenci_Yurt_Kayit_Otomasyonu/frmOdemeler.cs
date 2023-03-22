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
    public partial class frmOdemeler : Form
    {
        public frmOdemeler()
        {
            InitializeComponent();
        }

        SqlBaglantisi bgl = new SqlBaglantisi();


        void listele()
        {
            this.tBLBORCLARTableAdapter.Fill(this.dbYurtOtomasyonuDataSet2.TBLBORCLAR);
        }
        private void frmOdemeler_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dbYurtOtomasyonuDataSet2.TBLBORCLAR' table. You can move, or remove it, as needed.
            this.tBLBORCLARTableAdapter.Fill(this.dbYurtOtomasyonuDataSet2.TBLBORCLAR);

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;
            txtID.Text = dataGridView1.Rows[secilen].Cells[0].Value.ToString();
            txtKalan.Text = dataGridView1.Rows[secilen].Cells[3].Value.ToString();
        }

        private void btnOdemeAl_Click(object sender, EventArgs e)
        {
            //Ödenen Tutarı Kalan Tutardan Düşme:↓↓
            int borc = Convert.ToInt32(txtKalan.Text) - Convert.ToInt32(txtOdenen.Text);
            txtKalan.Text = borc.ToString();


            //Yeni Tutarı veri tabanında güncelleme
            SqlCommand komut = new SqlCommand("update TBLBORCLAR set OGRKALANBORC=@p1 where OGRID=@p2", bgl.baglanti());
            komut.Parameters.AddWithValue("@p2", txtID.Text);
            komut.Parameters.AddWithValue("@p1", txtKalan.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            listele();
            MessageBox.Show("Borçlar güncellendi");



            //Kasa Tablosuna Ekleme Yapma
            SqlCommand komut2 = new SqlCommand("insert into TBLKASA (ODEMEAY, ODEMEMIKTAR) values (@k1,@k2)", bgl.baglanti());
            komut2.Parameters.AddWithValue("@k1", txtOdenenAy.Text);
            komut2.Parameters.AddWithValue("@k2", txtOdenen.Text);
            komut2.ExecuteNonQuery();
            bgl.baglanti().Close();
        }
    }
}
