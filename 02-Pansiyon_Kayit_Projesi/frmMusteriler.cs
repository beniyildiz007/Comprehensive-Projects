using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlClient;

namespace _02_Pansiyon_Kayit_Projesi
{
    public partial class frmMusteriler : Form
    {
        public frmMusteriler()
        {
            InitializeComponent();
        }

        SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-HKL3D7O\SQLEXPRESS;Initial Catalog=dbPansiyonKayit;Integrated Security=True");

        void listele()
        {

            listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);

            listView1.Items.Clear();

            baglanti.Open();
            SqlCommand komut = new SqlCommand("select * from TBLMUSTERIEKLE", baglanti);
            SqlDataReader dr = komut.ExecuteReader();

            while (dr.Read())
            {
                ListViewItem ekle = new ListViewItem();
                ekle.Text = dr["MUSTERIID"].ToString();
                ekle.SubItems.Add(dr["ADI"].ToString());
                ekle.SubItems.Add(dr["SOYADI"].ToString());
                ekle.SubItems.Add(dr["CINSIYET"].ToString());
                ekle.SubItems.Add(dr["TELEFON"].ToString());
                ekle.SubItems.Add(dr["MAIL"].ToString());
                ekle.SubItems.Add(dr["TC"].ToString());
                ekle.SubItems.Add(dr["ODANO"].ToString());
                ekle.SubItems.Add(dr["UCRET"].ToString());
                ekle.SubItems.Add(dr["GIRISTARIHI"].ToString());
                ekle.SubItems.Add(dr["CIKISTARIHI"].ToString());

                listView1.Items.Add(ekle);
            }
            baglanti.Close();
        }

        void ara()
        {
            listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);

            listView1.Items.Clear();

            baglanti.Open();
            SqlCommand komut = new SqlCommand("select * from TBLMUSTERIEKLE where ADI like '%" + txtAra.Text + "%'", baglanti);
            //komut.Parameters.AddWithValue("@p1", txtAra.Text);
            SqlDataReader dr = komut.ExecuteReader();

            while (dr.Read())
            {
                ListViewItem ekle = new ListViewItem();
                ekle.Text = dr["MUSTERIID"].ToString();
                ekle.SubItems.Add(dr["ADI"].ToString());
                ekle.SubItems.Add(dr["SOYADI"].ToString());
                ekle.SubItems.Add(dr["CINSIYET"].ToString());
                ekle.SubItems.Add(dr["TELEFON"].ToString());
                ekle.SubItems.Add(dr["MAIL"].ToString());
                ekle.SubItems.Add(dr["TC"].ToString());
                ekle.SubItems.Add(dr["ODANO"].ToString());
                ekle.SubItems.Add(dr["UCRET"].ToString());
                ekle.SubItems.Add(dr["GIRISTARIHI"].ToString());
                ekle.SubItems.Add(dr["CIKISTARIHI"].ToString());

                listView1.Items.Add(ekle);
            }
            baglanti.Close();

        }



        private void btnListele_Click(object sender, EventArgs e)
        {
            listele();
        }

        private void frmMusteriler_Load(object sender, EventArgs e)
        {
            listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        }

        int id = 0;
        private void listView1_DoubleClick(object sender, EventArgs e)
        {
            id = int.Parse(listView1.SelectedItems[0].SubItems[0].Text);
            txtAdi.Text = listView1.SelectedItems[0].SubItems[1].Text;
            txtSoyadi.Text = listView1.SelectedItems[0].SubItems[2].Text;
            comboBox1.Text = listView1.SelectedItems[0].SubItems[3].Text;
            mskTelefon.Text = listView1.SelectedItems[0].SubItems[4].Text;
            txtMail.Text = listView1.SelectedItems[0].SubItems[5].Text;
            mskTC.Text = listView1.SelectedItems[0].SubItems[6].Text;
            txtOdaNo.Text = listView1.SelectedItems[0].SubItems[7].Text;
            txtUcret.Text = listView1.SelectedItems[0].SubItems[8].Text;
            dateGiris.Text = listView1.SelectedItems[0].SubItems[9].Text;
            dateCikis.Text = listView1.SelectedItems[0].SubItems[10].Text;
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("update TBLMUSTERIEKLE set ADI=@p1,SOYADI=@p2,CINSIYET=@p3,TELEFON=@p4,MAIL=@p5,TC=@p6,ODANO=@p7,UCRET=@p8,GIRISTARIHI=@p9,CIKISTARIHI=@p10 where MUSTERIID=@p11", baglanti);
            komut.Parameters.AddWithValue("@p1", txtAdi.Text);
            komut.Parameters.AddWithValue("@p2", txtSoyadi.Text);
            komut.Parameters.AddWithValue("@p3", comboBox1.Text);
            komut.Parameters.AddWithValue("@p4", mskTelefon.Text);
            komut.Parameters.AddWithValue("@p5", txtMail.Text);
            komut.Parameters.AddWithValue("@p6", mskTC.Text);
            komut.Parameters.AddWithValue("@p7", txtOdaNo.Text);
            komut.Parameters.AddWithValue("@p8", txtUcret.Text);
            komut.Parameters.AddWithValue("@p9", dateGiris.Value.ToString("yyyy-MM-dd"));
            komut.Parameters.AddWithValue("@p10", dateCikis.Value.ToString("yyyy-MM-dd"));
            komut.Parameters.AddWithValue("@p11", id);

            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Güncelleme işlemi başarılı!");

            listele();
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("delete from TBLMUSTERIEKLE where MUSTERIID=@p1", baglanti);
            komut.Parameters.AddWithValue("@p1", id);
            komut.ExecuteNonQuery();
            baglanti.Close();
            listele();

            txtAdi.Clear();
            txtSoyadi.Clear();
            comboBox1.Text = "";
            mskTelefon.Clear();
            txtMail.Clear();
            mskTC.Clear();
            txtOdaNo.Clear();
            txtUcret.Clear();
            dateGiris.Text = "";
            dateCikis.Text = "";
        }

        private void btnAra_Click(object sender, EventArgs e)
        {
            ara();
        }
    }
}
