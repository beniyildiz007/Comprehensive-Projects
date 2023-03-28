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
    public partial class frmBankalar : Form
    {
        public frmBankalar()
        {
            InitializeComponent();
        }

        sqlbaglantisi bgl = new sqlbaglantisi();


        void listele()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("execute BankaBilgileri", bgl.baglanti());
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


        void firmalistesi()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select ID,AD from TBLFIRMALAR", bgl.baglanti());
            da.Fill(dt);
            lkpFirmalar.Properties.ValueMember = "ID";
            lkpFirmalar.Properties.DisplayMember = "AD";
            lkpFirmalar.Properties.DataSource = dt;
        }


        void temizle()
        {
            txtBankaAdi.Text = "";
            mskHesapNo.Text = "";
            txtHesapTuru.Text = "";
            mskIBAN.Text = "";
            txtID.Text = "";
            txtSube.Text = "";
            txtYetkili.Text = "";
            mskTarih.Text = "";
            mskTEL.Text = "";
            lkpFirmalar.Text = "";
            txtBankaAdi.Focus();
        }


        private void frmBankalar_Load(object sender, EventArgs e)
        {
            listele();
            sehirlistesi();
            firmalistesi();
            temizle();
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("insert into TBLBANKALAR (BANKAADI," +
                "IL,ILCE,SUBE,IBAN,HESAPNO,YETKILI,TELEFON,TARIH,HESAPTURU,FIRMAID) values " +
                "(@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8,@p9,@p10,@p11)", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", txtBankaAdi.Text);
            komut.Parameters.AddWithValue("@p2", cmbIL.Text);
            komut.Parameters.AddWithValue("@p3", cmbILCE.Text);
            komut.Parameters.AddWithValue("@p4", txtSube.Text);
            komut.Parameters.AddWithValue("@p5", mskIBAN.Text);
            komut.Parameters.AddWithValue("@p6", mskHesapNo.Text);
            komut.Parameters.AddWithValue("@p7", txtYetkili.Text);
            komut.Parameters.AddWithValue("@p8", mskTEL.Text);
            komut.Parameters.AddWithValue("@p9", mskTarih.Text);
            komut.Parameters.AddWithValue("@p10", txtHesapTuru.Text);
            komut.Parameters.AddWithValue("@p11", lkpFirmalar.EditValue);
            komut.ExecuteNonQuery();
            listele();
            bgl.baglanti().Close();
            MessageBox.Show("Banka Bilgisi Sisteme Kaydedildi!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                txtBankaAdi.Text = dr["BANKAADI"].ToString();
                cmbIL.Text = dr["IL"].ToString();
                cmbILCE.Text = dr["ILCE"].ToString();
                txtSube.Text = dr["SUBE"].ToString();
                mskIBAN.Text = dr["IBAN"].ToString();
                mskHesapNo.Text = dr["HESAPNO"].ToString();
                txtYetkili.Text = dr["YETKILI"].ToString();
                mskTEL.Text = dr["TELEFON"].ToString();
                mskTarih.Text = dr["TARIH"].ToString();
                txtHesapTuru.Text = dr["HESAPTURU"].ToString();
                lkpFirmalar.Text = dr["AD"].ToString();
            }

        }

        private void btnTemizle_Click(object sender, EventArgs e)
        {
            temizle();
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("delete from TBLBANKALAR where ID=@p1", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", txtID.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            temizle();
            MessageBox.Show("Banka Bilgisi Sistemden Silindi!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            listele();
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("update TBLBANKALAR set BANKAADI=@p1,IL=@p2,ILCE=@p3," +
                "SUBE=@p4,IBAN=@p5,HESAPNO=@p6,YETKILI=@p7,TELEFON=@p8,TARIH=@p9,HESAPTURU=@p10,FIRMAID=@p11 where ID=@p12", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", txtBankaAdi.Text);
            komut.Parameters.AddWithValue("@p2", cmbIL.Text);
            komut.Parameters.AddWithValue("@p3", cmbILCE.Text);
            komut.Parameters.AddWithValue("@p4", txtSube.Text);
            komut.Parameters.AddWithValue("@p5", mskIBAN.Text);
            komut.Parameters.AddWithValue("@p6", mskHesapNo.Text);
            komut.Parameters.AddWithValue("@p7", txtYetkili.Text);
            komut.Parameters.AddWithValue("@p8", mskTEL.Text);
            komut.Parameters.AddWithValue("@p9", mskTarih.Text);
            komut.Parameters.AddWithValue("@p10", txtHesapTuru.Text);
            komut.Parameters.AddWithValue("@p11", lkpFirmalar.EditValue);
            komut.Parameters.AddWithValue("@p12", txtID.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Banka Bilgisi Güncellendi!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            listele();
        }
    }
}
