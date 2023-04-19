

>_Büyük fikirler büyük başarılar getirmez, küçük başarılar büyük başarıları inşa eder._


<a name="i1"></a>
## İçindekiler (Contents)
1. [C# Hastane Otomasyon Projesi](#project1)
2. [C# Pansiyon Kayıt Otomasyon Projesi](#project2)
3. [C# Öğrenci Yurdu Kayıt Otomasyon Projesi](#project3)
4. [C# ile DevExpress'te SQL Tabanlı Ticari Otomasyon](#project4)
5. [ASP.NET Bootstrap ile SQL Tabanlı Web Projesi](#project5)
6. [ASP.NET Entity Framework ile Dinamik Admin Panelli CV Sitesi](#project6)
7. [ASP.NET Bootstrap Login & Admin Panelli Dinamik CV Sitesi](#project7)
8. [ASP.NET Bootstrap Entity Framework ile Blog Sitesi](#project8)
9. [ASP.NET Katmanli Mimari'de Mini Yaz Okulu Projesi](#project9)
10. [Mvc5 Ürün Takip Projesi](#project10)




# 01- C# Hastane Otomasyon Projesi <a name="project1"></a>
### Başlangıç [Başa Dön ↑](#i1)
[![Berkan Nihat Yıldız](https://i.hizliresim.com/p3x5eo3.png)](https://www.linkedin.com/in/berkan-nihat-yildiz/)
```C#
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _02_Hastane_Proejesi
{
    public partial class FrmGirisler : Form
    {
        public FrmGirisler()
        {
            InitializeComponent();
        }

        private void btnHastaGiris_Click(object sender, EventArgs e)
        {
            FrmHastaGiris fr = new FrmHastaGiris();
            fr.Show();
            this.Hide();
        }

        private void btnDoktorGiris_Click(object sender, EventArgs e)
        {
            FrmDoktorGiris fr = new FrmDoktorGiris();
            fr.Show();
            this.Hide();
        }

        private void btnSekreterGiris_Click(object sender, EventArgs e)
        {
            FrmSekreterGiris fr = new FrmSekreterGiris();
            fr.Show();
            this.Hide();
        }
    }
}
```
### Hasta Girişi [Başa Dön ↑](#i1)

[![Berkan Nihat Yıldız](https://i.hizliresim.com/cuhss4g.jpg)](https://www.linkedin.com/in/berkan-nihat-yildiz/)
```c#
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
    public partial class FrmHastaGiris : Form
    {
        public FrmHastaGiris()
        {
            InitializeComponent();
        }

        sqlBaglantisi bgl = new sqlBaglantisi();

        private void lnkUyeOl_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmHastaKayit fr = new FrmHastaKayit();
            fr.Show();
        }

        private void btnGirisYap_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("select * from Tbl_Hastalar where HastaTC=@p1 and HastaSifre=@p2", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", mskTcNo.Text);
            komut.Parameters.AddWithValue("@p2", txtSifre.Text);
            SqlDataReader dr = komut.ExecuteReader();

            if (dr.Read())
            {
                FrmHastaDetay fr = new FrmHastaDetay();
                fr.tc = mskTcNo.Text;
                fr.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Hatalı TC & Şifre!");
            }
        }
    }
}
```
### Hasta Üye Olma Paneli [Başa Dön ↑](#i1)
[![Berkan Nihat Yıldız](https://i.hizliresim.com/17vij7d.jpg)](https://www.linkedin.com/in/berkan-nihat-yildiz/)
```c#
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
    public partial class FrmHastaKayit : Form
    {
        public FrmHastaKayit()
        {
            InitializeComponent();
        }

        sqlBaglantisi bgl = new sqlBaglantisi();

        private void btnKayit_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("insert into Tbl_Hastalar (HastaAd, HastaSoyad, HastaTC, HastaTelefon, HastaSifre, HastaCinsiyet) Values (@p1,@p2,@p3,@p4,@p5,@p6)", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", txtAd.Text);
            komut.Parameters.AddWithValue("@p2", txtSoyad.Text);
            komut.Parameters.AddWithValue("@p3", mskKimlik.Text);
            komut.Parameters.AddWithValue("@p4", mskTelefon.Text);
            komut.Parameters.AddWithValue("@p5", txtSifre.Text);
            komut.Parameters.AddWithValue("@p6", cmbCinsiyet.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Hasta Kaydınız Gerçekleşmiştir, Şifreniz: " + txtSifre.Text, "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
```
### Hasta Detay Paneli [Başa Dön ↑](#i1)
[![Berkan Nihat Yıldız](https://i.hizliresim.com/ge3oeiq.jpg)](https://www.linkedin.com/in/berkan-nihat-yildiz/)
```c#
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
    public partial class FrmHastaDetay : Form
    {
        public FrmHastaDetay()
        {
            InitializeComponent();
        }

        public string tc;

        sqlBaglantisi bgl = new sqlBaglantisi();

        private void FrmHastaDetay_Load(object sender, EventArgs e)
        {
            lblTC.Text = tc;

            //Ad Soyad Çekme İşlemi
            SqlCommand komut = new SqlCommand("select HastaAd, HastaSoyad from Tbl_Hastalar where HastaTC=@p1", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", lblTC.Text);
            SqlDataReader dr = komut.ExecuteReader();

            while (dr.Read())
            {
                lblAdSoyad.Text = dr[0] + " " + dr[1];
            }
            bgl.baglanti().Close();



            //Randevu Geçmişi
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select * from Tbl_Randevular where HastaTC=" + tc, bgl.baglanti());
            da.Fill(dt);
            dataGridView1.DataSource = dt;



            //Branşları Çekme İşlemi
            SqlCommand komut2 = new SqlCommand("select BransAd from Tbl_Branslar", bgl.baglanti());
            SqlDataReader dr2 = komut2.ExecuteReader();

            while (dr2.Read())
            {
                cmbBrans.Items.Add(dr2[0]);
            }
            bgl.baglanti().Close();
        }

        private void cmbBrans_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Branşa Göre Doktorları Getirme İşlemi
            cmbDoktor.Items.Clear(); //Her yeni branşta doktor combobox'ını temizler

            SqlCommand komut3 = new SqlCommand("select DoktorAd, DoktorSoyad from Tbl_Doktorlar where DoktorBrans=@p1", bgl.baglanti());
            komut3.Parameters.AddWithValue("@p1", cmbBrans.Text);
            SqlDataReader dr = komut3.ExecuteReader();

            while (dr.Read())
            {
                cmbDoktor.Items.Add(dr[0] + " " + dr[1]);
            }
            bgl.baglanti().Close();
        }

        private void cmbDoktor_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select * from Tbl_Randevular where RandevuBrans='" + cmbBrans.Text+"'"+" and RandevuDoktor='"+cmbDoktor.Text+"' and RandevuDurum=0", bgl.baglanti());
            da.Fill(dt);
            dataGridView2.DataSource = dt;
        }

        private void lnkBilgiDuzenle_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmBilgiDuzenle fr = new FrmBilgiDuzenle();
            fr.TCno = lblTC.Text;
            fr.Show();
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView2.SelectedCells[0].RowIndex;
            txtid.Text = dataGridView2.Rows[secilen].Cells[0].Value.ToString();
        }

        private void btnRandevu_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("Update Tbl_Randevular set RandevuDurum=1, HastaTC=@p1, HastaSikayet=@p2 where Randevuid=@p3", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", lblTC.Text);
            komut.Parameters.AddWithValue("@p2", richSikayet.Text);
            komut.Parameters.AddWithValue("@p3", txtid.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Randevu Alındı", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
}
```
### Hasta Bilgi Güncelleme [Başa Dön ↑](#i1)
[![Berkan Nihat Yıldız](https://i.hizliresim.com/f97pp7n.jpg)](https://www.linkedin.com/in/berkan-nihat-yildiz/)
```c#
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
    public partial class FrmBilgiDuzenle : Form
    {
        public FrmBilgiDuzenle()
        {
            InitializeComponent();
        }

        public string TCno;
        sqlBaglantisi bgl = new sqlBaglantisi();

        private void FrmBilgiDuzenle_Load(object sender, EventArgs e)
        {
            mskKimlik.Text = TCno;
            SqlCommand komut = new SqlCommand("select * from Tbl_Hastalar where HastaTC=" + TCno, bgl.baglanti());
            SqlDataReader dr = komut.ExecuteReader();

            while (dr.Read())
            {
                txtAd.Text = dr[1].ToString(); //1'den başlattık çünkü 0. indexte id kolonu bulunmakta
                txtSoyad.Text = dr[2].ToString();
                mskTelefon.Text = dr[4].ToString();
                txtSifre.Text = dr[5].ToString();
                cmbCinsiyet.Text = dr[6].ToString();
            }
            bgl.baglanti().Close();
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            SqlCommand komut2 = new SqlCommand("update Tbl_Hastalar set HastaAd=@p1, HastaSoyad=@p2, HastaTelefon=@p3, HastaSifre=@p4, HastaCinsiyet=@p5 where HastaTC=@p6", bgl.baglanti());
            komut2.Parameters.AddWithValue("@p1", txtAd.Text);
            komut2.Parameters.AddWithValue("@p2", txtSoyad.Text);
            komut2.Parameters.AddWithValue("@p3", mskTelefon.Text);
            komut2.Parameters.AddWithValue("@p4", txtSifre.Text);
            komut2.Parameters.AddWithValue("@p5", cmbCinsiyet.Text);
            komut2.Parameters.AddWithValue("@p6", mskKimlik.Text);
            komut2.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Bilgileriniz Güncellenmiştir!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);

        }
    }
}
```
### Doktor Girişi
[![Berkan Nihat Yıldız](https://i.hizliresim.com/c4fb5vt.jpg)](https://www.linkedin.com/in/berkan-nihat-yildiz/)
```c#
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
    public partial class FrmDoktorGiris : Form
    {
        public FrmDoktorGiris()
        {
            InitializeComponent();
        }

        sqlBaglantisi bgl = new sqlBaglantisi();

        private void btnGirisYap_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("select * from Tbl_Doktorlar where DoktorTC=@p1 and DoktorSifre=@p2", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", mskTcNo.Text);
            komut.Parameters.AddWithValue("@p2", txtSifre.Text);
            SqlDataReader dr = komut.ExecuteReader();
            if (dr.Read())
            {
                FrmDoktorDetay frd = new FrmDoktorDetay();
                frd.TC = mskTcNo.Text;
                frd.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Hatalı kullanıcı adı veya şifre!!");
            }
            bgl.baglanti().Close();
        }
    }
}
```
### Doktor Detay Paneli
[![Berkan Nihat Yıldız](https://user-images.githubusercontent.com/95151751/224477255-4dbe4247-38f3-4e4d-ab36-c6f7eb1d48cf.png)](https://www.linkedin.com/in/berkan-nihat-yildiz/)
```c#
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
    public partial class FrmDoktorDetay : Form
    {
        public FrmDoktorDetay()
        {
            InitializeComponent();
        }

        sqlBaglantisi bgl = new sqlBaglantisi();
        public string TC;

        private void FrmDoktorDetay_Load(object sender, EventArgs e)
        {
            lblTC.Text = TC;


            //Doktor Ad Soyad
            SqlCommand komut = new SqlCommand("select DoktorAd, DoktorSoyad from Tbl_Doktorlar where DoktorTC=@p1", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", lblTC.Text);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                lblAdSoyad.Text = dr[0] + " " + dr[1];
            }
            bgl.baglanti().Close();


            //Randevular
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select * from Tbl_Randevular where RandevuDoktor='" + lblAdSoyad.Text + "'", bgl.baglanti());
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void btnBilgiDuzenle_Click(object sender, EventArgs e)
        {
            FrmDoktorBilgiDuzenle fr = new FrmDoktorBilgiDuzenle();
            fr.TCNO = lblTC.Text;
            fr.Show();
        }

        private void btnDuyurular_Click(object sender, EventArgs e)
        {
            FrmDuyurular frd = new FrmDuyurular();
            frd.Show();
        }

        private void btnCikis_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;
            richTextBox1.Text = dataGridView1.Rows[secilen].Cells[7].Value.ToString();
        }
    }
}
```
### Doktor Bilgi Düzenleme
[![image](https://user-images.githubusercontent.com/95151751/224477337-a3525c9c-2f69-4a9b-af64-41a577fb9a66.png)](https://www.linkedin.com/in/berkan-nihat-yildiz/)
```c#
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
    public partial class FrmDoktorBilgiDuzenle : Form
    {
        public FrmDoktorBilgiDuzenle()
        {
            InitializeComponent();
        }

        sqlBaglantisi bgl = new sqlBaglantisi();
        public string TCNO;

        private void FrmDoktorBilgiDuzenle_Load(object sender, EventArgs e)
        {
            mskKimlik.Text = TCNO;

            SqlCommand komut = new SqlCommand("select * from Tbl_Doktorlar where DoktorTC=@p1", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", mskKimlik.Text);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                txtAd.Text = dr[1].ToString();
                txtSoyad.Text = dr[2].ToString();
                cmbBrans.Text = dr[3].ToString();
                txtSifre.Text = dr[5].ToString();
            }
            bgl.baglanti().Close();
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("update Tbl_Doktorlar set DoktorAd=@p1, DoktorSoyad=@p2, DoktorBrans=@p3, DoktorSifre=@p4 where DoktorTC=@p5", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", txtAd.Text);
            komut.Parameters.AddWithValue("@p2", txtSoyad.Text);
            komut.Parameters.AddWithValue("@p3", cmbBrans.Text);
            komut.Parameters.AddWithValue("@p4", txtSifre.Text);
            komut.Parameters.AddWithValue("@p5", mskKimlik.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Kayıt Güncellendi!");
            
        }
    }
}
```
### Duyurular
[![image](https://user-images.githubusercontent.com/95151751/224477381-cdc78352-aa15-44b9-9c4e-b38f555002ae.png)](https://www.linkedin.com/in/berkan-nihat-yildiz/)
```c#
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
    public partial class FrmDuyurular : Form
    {
        public FrmDuyurular()
        {
            InitializeComponent();
        }

        sqlBaglantisi bgl = new sqlBaglantisi();

        private void FrmDuyurular_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select * from Tbl_Duyurular", bgl.baglanti());
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }
    }
}
```
### Sekreter Girişi
[![image](https://user-images.githubusercontent.com/95151751/224477430-1e559b05-f109-42b2-b50f-da8a16509105.png)](https://www.linkedin.com/in/berkan-nihat-yildiz/)
```c#
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
    public partial class FrmSekreterGiris : Form
    {
        public FrmSekreterGiris()
        {
            InitializeComponent();
        }


        sqlBaglantisi bgl = new sqlBaglantisi();

        private void btnGirisYap_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("select * from Tbl_Sekreter where SekreterTC=@p1 and SekreterSifre=@p2", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", mskTcNo.Text);
            komut.Parameters.AddWithValue("@p2", txtSifre.Text);
            SqlDataReader dr = komut.ExecuteReader();
            if (dr.Read())
            {
                FrmSekreterDetay frs = new FrmSekreterDetay();
                frs.Tcs = mskTcNo.Text;
                frs.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Hatalı TC & Şifre!", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}
```
### Sekreter Detay Paneli
[![image](https://user-images.githubusercontent.com/95151751/224477465-47882ef2-433e-4901-830f-6807d05d5e19.png)](https://www.linkedin.com/in/berkan-nihat-yildiz/)
```c#
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
    public partial class FrmSekreterDetay : Form
    {
        public FrmSekreterDetay()
        {
            InitializeComponent();
        }

        private void btnOlustur_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("insert into Tbl_Duyurular (duyuru) values(@d1)", bgl.baglanti());
            komut.Parameters.AddWithValue("@d1", rchDuyuru.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Duyuru Oluşturuldu!");
            rchDuyuru.Clear();
        }

        public string Tcs;

        sqlBaglantisi bgl = new sqlBaglantisi();

        private void FrmSekreterDetay_Load(object sender, EventArgs e)
        {

            lblTC.Text = Tcs;

            //Ad Soyad Getirme
            SqlCommand komut1 = new SqlCommand("select SekreterAdSoyad from Tbl_Sekreter where SekreterTC=@p1", bgl.baglanti());
            komut1.Parameters.AddWithValue("@p1", lblTC.Text);
            SqlDataReader dr1 = komut1.ExecuteReader();
            while (dr1.Read())
            {
                lblAdSoyad.Text = dr1[0].ToString();
            }
            bgl.baglanti().Close();


            //Branşları DataGrid'e Aktarma
            DataTable dt1 = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select * from Tbl_Branslar", bgl.baglanti());
            da.Fill(dt1);
            dataGridView1.DataSource = dt1;


            //Doktorları Listeye Aktarma
            DataTable dt2 = new DataTable();
            SqlDataAdapter da2 = new SqlDataAdapter("select (DoktorAd+' '+DoktorSoyad) as 'Doktorlar',DoktorBrans from Tbl_Doktorlar", bgl.baglanti());
            da2.Fill(dt2);
            dataGridView3.DataSource = dt2;


            //Branşları Combobox'a Aktarma
            SqlCommand komut2 = new SqlCommand("select BransAd from Tbl_Branslar", bgl.baglanti());
            SqlDataReader dr2 = komut2.ExecuteReader();
            while (dr2.Read())
            {
                cmbBrans.Items.Add(dr2[0]);
            }
            bgl.baglanti().Close();
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            SqlCommand komutKaydet = new SqlCommand("insert into Tbl_Randevular (RandevuTarih, RandevuSaat, RandevuBrans, RandevuDoktor) values (@r1,@r2,@r3,@r4)", bgl.baglanti());
            komutKaydet.Parameters.AddWithValue("@r1", mskTarih.Text);
            komutKaydet.Parameters.AddWithValue("@r2", mskSaat.Text);
            komutKaydet.Parameters.AddWithValue("@r3", cmbBrans.Text);
            komutKaydet.Parameters.AddWithValue("@r4", cmbDoktor.Text);
            komutKaydet.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Randevu Oluşturuldu!");
        }

        private void cmbBrans_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbDoktor.Items.Clear();

            SqlCommand komut = new SqlCommand("select DoktorAd, DoktorSoyad from Tbl_Doktorlar where DoktorBrans=@p1", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", cmbBrans.Text);
            SqlDataReader dr = komut.ExecuteReader();

            while (dr.Read())
            {
                cmbDoktor.Items.Add(dr[0] + " " + dr[1]);
            }
            bgl.baglanti().Close();
        }

        private void btnDoktorPaneli_Click(object sender, EventArgs e)
        {
            FrmDoktorPaneli drp = new FrmDoktorPaneli();
            drp.Show();
        }

        private void btnBransPaneli_Click(object sender, EventArgs e)
        {
            FrmBrans frb = new FrmBrans();
            frb.Show();
        }

        private void btnRandevuListe_Click(object sender, EventArgs e)
        {
            FrmRandevuListesi frl = new FrmRandevuListesi();
            frl.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FrmDuyurular frd = new FrmDuyurular();
            frd.Show();
        }
    }
}
```
### Doktor paneli
[![image](https://user-images.githubusercontent.com/95151751/224477518-c64e304c-f3ca-4f86-b25f-c17688568254.png)](https://www.linkedin.com/in/berkan-nihat-yildiz/)
```c#
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
    public partial class FrmDoktorBilgiDuzenle : Form
    {
        public FrmDoktorBilgiDuzenle()
        {
            InitializeComponent();
        }

        sqlBaglantisi bgl = new sqlBaglantisi();
        public string TCNO;

        private void FrmDoktorBilgiDuzenle_Load(object sender, EventArgs e)
        {
            mskKimlik.Text = TCNO;

            SqlCommand komut = new SqlCommand("select * from Tbl_Doktorlar where DoktorTC=@p1", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", mskKimlik.Text);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                txtAd.Text = dr[1].ToString();
                txtSoyad.Text = dr[2].ToString();
                cmbBrans.Text = dr[3].ToString();
                txtSifre.Text = dr[5].ToString();
            }
            bgl.baglanti().Close();
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("update Tbl_Doktorlar set DoktorAd=@p1, DoktorSoyad=@p2, DoktorBrans=@p3, DoktorSifre=@p4 where DoktorTC=@p5", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", txtAd.Text);
            komut.Parameters.AddWithValue("@p2", txtSoyad.Text);
            komut.Parameters.AddWithValue("@p3", cmbBrans.Text);
            komut.Parameters.AddWithValue("@p4", txtSifre.Text);
            komut.Parameters.AddWithValue("@p5", mskKimlik.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Kayıt Güncellendi!");
            
        }
    }
}
```
### Branş Paneli
[![image](https://user-images.githubusercontent.com/95151751/224477567-6c20776a-6fe5-45b4-9561-3935a2984568.png)](https://www.linkedin.com/in/berkan-nihat-yildiz/)
```c#
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
```
### Randevu Listesi
[![image](https://user-images.githubusercontent.com/95151751/224477587-85deecaa-e7d1-441b-8e76-1ca60de25edf.png)](https://www.linkedin.com/in/berkan-nihat-yildiz/)
```c#
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
    public partial class FrmRandevuListesi : Form
    {
        public FrmRandevuListesi()
        {
            InitializeComponent();
        }

        sqlBaglantisi bgl = new sqlBaglantisi();

        private void FrmRandevuListesi_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select * from Tbl_Randevular", bgl.baglanti());
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }


        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
```

# 02- C# Pansiyon Kayıt Otomasyon Projesi <a name="project2"></a>

### Admin Girişi
[![image](https://user-images.githubusercontent.com/95151751/226797637-0837d15b-96a0-46a4-802c-c9966f1ddb25.png)](https://www.linkedin.com/in/berkan-nihat-yildiz/)
```c#
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
    public partial class frmAdminGiris : Form
    {
        public frmAdminGiris()
        {
            InitializeComponent();
        }

        SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-HKL3D7O\SQLEXPRESS;Initial Catalog=dbPansiyonKayit;Integrated Security=True");


        private void btnGiris_Click(object sender, EventArgs e)
        {

            baglanti.Open();
            SqlCommand komut = new SqlCommand("select * from TBLADMINGIRIS where KULLANICIADI=@p1 and SIFRE=@p2", baglanti);
            komut.Parameters.AddWithValue("@p1", txtKullaniciAdi.Text);
            komut.Parameters.AddWithValue("@p2", txtSifre.Text);
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);

            if (dt.Rows.Count > 0)
            {
                frmAnaForm fr = new frmAnaForm();
                fr.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Hatalı Giriş!", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning); ;

            }
            baglanti.Close();


            //try
            //{
            //    if (dt.Rows.Count > 0)
            //    {
            //        frmAnaForm fr = new frmAnaForm();
            //        fr.Show();
            //        this.Hide();
            //    }
            //}
            //catch (Exception)
            //{
            //    MessageBox.Show("Hatalı Giriş!", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning); ;
            //}
            //baglanti.Close();

        }
    }
}
```

### Anasayfa
[![image](https://user-images.githubusercontent.com/95151751/226797769-eb020630-bb10-4a05-9cea-630a55da49de.png)](https://www.linkedin.com/in/berkan-nihat-yildiz/)
```c#
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _02_Pansiyon_Kayit_Projesi
{
    public partial class frmAnaForm : Form
    {
        public frmAnaForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmAdminGiris fr = new frmAdminGiris();
            fr.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            frmYeniMusteri fr = new frmYeniMusteri();
            fr.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            frmOdalar fr = new frmOdalar();
            fr.Show();
        }

        private void btnMusteriler_Click(object sender, EventArgs e)
        {
            frmMusteriler fr = new frmMusteriler();
            fr.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Bu proje Berkan Nihat YILDIZ tarafından 20 Mart 2023 tarihinde yapılmıştır.","Hakkımızda",MessageBoxButtons.OK,MessageBoxIcon.Information);
        }

        private void frmAnaForm_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label1.Text = DateTime.Now.ToLongDateString();
            label2.Text = DateTime.Now.ToLongTimeString();
        }

        private void btnGelirGider_Click(object sender, EventArgs e)
        {
            frmGelirGider fr = new frmGelirGider();
            fr.Show();
        }

        private void btnStoklar_Click(object sender, EventArgs e)
        {
            frmStoklar fr = new frmStoklar();
            fr.Show();
        }
    }
}
```

### Yeni Müşteri
[![image](https://user-images.githubusercontent.com/95151751/226797918-e19587be-d530-490b-b5b2-eed6dcca82c7.png)](https://www.linkedin.com/in/berkan-nihat-yildiz/)
```c#
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
    public partial class frmYeniMusteri : Form
    {
        public frmYeniMusteri()
        {
            InitializeComponent();
        }

        private void btnDolu_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Kırmızı renkli butonlar dolu odaları gösterir.");
        }

        private void btnBos_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Yeşil renkli butonlar boş odaları gösterir.");
        }

        private void btn101_Click(object sender, EventArgs e)
        {
            txtOdaNo.Text = "101";
        }

        private void btn102_Click(object sender, EventArgs e)
        {
            txtOdaNo.Text = "102";

        }

        private void btn103_Click(object sender, EventArgs e)
        {
            txtOdaNo.Text = "103";

        }

        private void btn104_Click(object sender, EventArgs e)
        {
            txtOdaNo.Text = "104";

        }

        private void btn105_Click(object sender, EventArgs e)
        {
            txtOdaNo.Text = "105";

        }

        private void btn106_Click(object sender, EventArgs e)
        {
            txtOdaNo.Text = "106";

        }

        private void btn107_Click(object sender, EventArgs e)
        {
            txtOdaNo.Text = "107";

        }

        private void btn108_Click(object sender, EventArgs e)
        {
            txtOdaNo.Text = "108";

        }

        private void btn109_Click(object sender, EventArgs e)
        {
            txtOdaNo.Text = "109";

        }

        private void dateCikis_ValueChanged(object sender, EventArgs e)
        {
            DateTime giris = Convert.ToDateTime(dateGiris.Text);
            DateTime cikis = Convert.ToDateTime(dateCikis.Text);

            TimeSpan fark = cikis - giris;

            lblFark.Text = fark.TotalDays.ToString();

            int ucret = Convert.ToInt32(lblFark.Text) * 150;
            txtUcret.Text = ucret.ToString();
        }

        SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-HKL3D7O\SQLEXPRESS;Initial Catalog=dbPansiyonKayit;Integrated Security=True");

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("insert into TBLMUSTERIEKLE (ADI,SOYADI,CINSIYET,TELEFON,MAIL,TC,ODANO,UCRET,GIRISTARIHI,CIKISTARIHI) values (@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8,@p9,@p10)", baglanti);
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
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Müşteri Kaydı Yapıldı!");
        }
    }
}
```

### Odalar
[![image](https://user-images.githubusercontent.com/95151751/226797995-75d4034c-fdbc-4f45-92ff-98424eb4457d.png)](https://www.linkedin.com/in/berkan-nihat-yildiz/)
```c#
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _02_Pansiyon_Kayit_Projesi
{
    public partial class frmOdalar : Form
    {
        public frmOdalar()
        {
            InitializeComponent();
        }
    }
}
```

### Müşteriler
[![image](https://user-images.githubusercontent.com/95151751/226798080-8804c5c5-4d1b-4fbc-9f65-fcab07e14004.png)](https://www.linkedin.com/in/berkan-nihat-yildiz/)
```c#
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
```

### Gelir-Gider Formu
[![image](https://user-images.githubusercontent.com/95151751/226798145-e39137b5-cbb8-4201-a350-8b8b213204d4.png)](https://www.linkedin.com/in/berkan-nihat-yildiz/)
```c#
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
    public partial class frmGelirGider : Form
    {
        public frmGelirGider()
        {
            InitializeComponent();
        }

        SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-HKL3D7O\SQLEXPRESS;Initial Catalog=dbPansiyonKayit;Integrated Security=True");

        private void frmGelirGider_Load(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select sum(ucret) as 'TOPLAM' from TBLMUSTERIEKLE", baglanti);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                lblToplamTutar.Text = dr["TOPLAM"].ToString();
            }
            baglanti.Close();

            int personel = Convert.ToInt32(txtPersonelSayisi.Text);
            lblMaas.Text = (personel * 8500).ToString();



            //Gıdalar
            baglanti.Open();
            SqlCommand komut2 = new SqlCommand("select sum(GIDA) as 'TOPLAM' from TBLSTOKLAR", baglanti);
            SqlDataReader dr2 = komut2.ExecuteReader();
            while (dr2.Read())
            {
                lblUrunTutar1.Text = dr2["TOPLAM"].ToString();
            }
            baglanti.Close();


            //İçecekler
            baglanti.Open();
            SqlCommand komut3 = new SqlCommand("select sum(ICECEK) as 'TOPLAM' from TBLSTOKLAR", baglanti);
            SqlDataReader dr3 = komut3.ExecuteReader();
            while (dr3.Read())
            {
                lblUrunTutar2.Text = dr3["TOPLAM"].ToString();
            }
            baglanti.Close();


            //Çerezler
            baglanti.Open();
            SqlCommand komut4 = new SqlCommand("select sum(CEREZLER) as 'TOPLAM' from TBLSTOKLAR", baglanti);
            SqlDataReader dr4 = komut4.ExecuteReader();
            while (dr4.Read())
            {
                lblUrunTutar3.Text = dr4["TOPLAM"].ToString();
            }
            baglanti.Close();




        }

        private void btnHesapla_Click(object sender, EventArgs e)
        {
            int sonuc = Convert.ToInt32(lblToplamTutar.Text) - (Convert.ToInt32(lblMaas.Text) + Convert.ToInt32(lblUrunTutar1.Text) + Convert.ToInt32(lblUrunTutar2.Text) + Convert.ToInt32(lblUrunTutar3.Text));
            lblSonuc.Text = sonuc.ToString();
        }

        private void txtPersonelSayisi_TextChanged(object sender, EventArgs e)
        {
            int personel = Convert.ToInt32(txtPersonelSayisi.Text);
            lblMaas.Text = (personel * 8500).ToString();

        }
    }
}
```

### Stoklar
[![image](https://user-images.githubusercontent.com/95151751/226798207-bae777f7-02dc-410f-8a44-ee5cc5003f36.png)](https://www.linkedin.com/in/berkan-nihat-yildiz/)
```c#
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
    public partial class frmStoklar : Form
    {
        public frmStoklar()
        {
            InitializeComponent();
        }

        SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-HKL3D7O\SQLEXPRESS;Initial Catalog=dbPansiyonKayit;Integrated Security=True");


        private void frmStoklar_Load(object sender, EventArgs e)
        {
            listele();
        }

        void listele()
        {
            listView1.Items.Clear();

            baglanti.Open();
            SqlCommand komut = new SqlCommand("select * from TBLSTOKLAR", baglanti);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                ListViewItem ekle = new ListViewItem();
                ekle.Text = dr["GIDA"].ToString();
                ekle.SubItems.Add(dr["ICECEK"].ToString());
                ekle.SubItems.Add(dr["CEREZLER"].ToString());
                listView1.Items.Add(ekle);
            }
            baglanti.Close();
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("insert into TBLSTOKLAR (GIDA,ICECEK,CEREZLER) values(@p1,@p2,@p3)", baglanti);
            komut.Parameters.AddWithValue("@p1", txtGidaTutar.Text);
            komut.Parameters.AddWithValue("@p2", txtİcecekTutar.Text);
            komut.Parameters.AddWithValue("@p3", txtAtistirmaliklar.Text);
            komut.ExecuteNonQuery();
            baglanti.Close();

            listele();
        }
    }
}
```

### Hakkımızda
[![image](https://user-images.githubusercontent.com/95151751/226798259-c71ab6c5-c136-430d-ac86-ca394e779cba.png)](https://www.linkedin.com/in/berkan-nihat-yildiz/)


# 03- C# Öğrenci Yurdu Kayıt Otomasyon Projesi <a name="project3"></a>

### Admin Girişi
[![image](https://user-images.githubusercontent.com/95151751/226799085-35696fc5-2141-4d02-ac39-4ef44e198571.png)](https://www.linkedin.com/in/berkan-nihat-yildiz/)
```c#
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
    public partial class frmAdminGiris : Form
    {
        public frmAdminGiris()
        {
            InitializeComponent();
        }

        SqlBaglantisi bgl = new SqlBaglantisi();

        private void btnGiris_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("select * from TBLADMIN where YONETICIAD=@p1 and YONETICISIFRE=@p2", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", txtKullaniciAdi.Text);
            komut.Parameters.AddWithValue("@p2", txtSifre.Text);
            SqlDataReader dr = komut.ExecuteReader();
            if (dr.Read())
            {
                frmAnaForm fr = new frmAnaForm();
                fr.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Hatalı kullanıcı adı ya da şifre!");
                txtKullaniciAdi.Clear();
                txtSifre.Clear();
                txtKullaniciAdi.Focus();
            }
            bgl.baglanti().Close();
        }
    }
}
```

### Anasayfa
[![image](https://user-images.githubusercontent.com/95151751/226799122-3bdffbeb-b544-4f44-ba07-999c6bacdbcf.png)](https://www.linkedin.com/in/berkan-nihat-yildiz/)
```c#
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _03_Ogrenci_Yurt_Kayit_Otomasyonu
{
    public partial class frmAnaForm : Form
    {
        public frmAnaForm()
        {
            InitializeComponent();
        }

        private void frmAnaForm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dbYurtOtomasyonuDataSet1.TBLOGRENCI' table. You can move, or remove it, as needed.
            this.tBLOGRENCITableAdapter.Fill(this.dbYurtOtomasyonuDataSet1.TBLOGRENCI);

            timer1.Start();

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblTarih.Text = DateTime.Now.ToLongDateString();
            lblSaat.Text = DateTime.Now.ToLongTimeString();
        }

        private void hesapMakinesiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("calc.exe");
        }

        private void paintToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("mspaint.exe");
        }

        private void radyo1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.URL = "http://37.247.98.8/stream/30/";
        }

        private void radyo2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.URL = "http://37.247.98.8/stream/25/";
        }

        private void radyo3ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.URL = "http://46.20.7.126/;stream.mp3";
        }

        private void öğrenciEkleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmOgrKayit fr = new frmOgrKayit();
            fr.Show();
        }

        private void öğrenciListesiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmOgrListe fr = new frmOgrListe();
            fr.Show();
        }

        private void öğrenciDüzenleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmOgrListe fr = new frmOgrListe();
            fr.Show();
        }

        private void bölümEkleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmBolumler fr = new frmBolumler();
            fr.Show();
        }

        private void bölümDüzenleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmBolumler fr = new frmBolumler();
            fr.Show();
        }

        private void ödemeAlToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmOdemeler fr = new frmOdemeler();
            fr.Show();
        }

        private void giderEkleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmGider fr = new frmGider();
            fr.Show();
        }

        private void giderListesiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmGiderListesi fr = new frmGiderListesi();
            fr.Show();
        }

        private void gelirİstatistikleriToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmGelirIstatistik fr = new frmGelirIstatistik();
            fr.Show();
        }

        private void giderİstatistikleriToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void şifreİşlemleriToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmYoneticiDuzenle fr = new frmYoneticiDuzenle();
            fr.Show();
        }

        private void personelDüzenleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPersonel fr = new frmPersonel();
            fr.Show();
        }

        private void notEkleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmNotEkle fr = new frmNotEkle();
            fr.Show();
        }

        private void hakkımızdaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Bu proje 22 Mart 2023 gece saat 03:23'te tamamlanmıştır.", "Öğrenci Yurt Otomasyonu", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void çıkışToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
```

### Öğrenci Kayıt
[![image](https://user-images.githubusercontent.com/95151751/226799232-86e4777e-b650-4b8e-9fd7-95af913ce015.png)](https://www.linkedin.com/in/berkan-nihat-yildiz/)
```c#
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
    public partial class frmOgrKayit : Form
    {
        public frmOgrKayit()
        {
            InitializeComponent();
        }

        SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-HKL3D7O\SQLEXPRESS;Initial Catalog=dbYurtOtomasyonu;Integrated Security=True");



        private void frmOgrKayit_Load(object sender, EventArgs e)
        {

            //Bölümleri Listeleme
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select bolumad from tblbolumler", baglanti);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                cmbBolum.Items.Add(dr[0].ToString());
            }
            baglanti.Close();



            //Boş Odaları Listeleme
            baglanti.Open();
            SqlCommand komut2 = new SqlCommand("select odano from tblodalar where odakapasıte != odaaktıf", baglanti);
            SqlDataReader dr2 = komut2.ExecuteReader();
            while (dr2.Read())
            {
                cmbOdaNo.Items.Add(dr2[0].ToString());
            }
            baglanti.Close();
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("insert into tblogrencı (ograd, ogrsoyad,ogrtc,ogrtelefon,ogrdogum,ogrbolum,ogrmaıl,ogrodano,ogrvelıadsoyad,ogrvelıtelefon,ogrvelıadres) values (@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8,@p9,@p10,@p11)", baglanti);
            komut.Parameters.AddWithValue("@p1", txtOgrenciAd.Text);
            komut.Parameters.AddWithValue("@p2", txtOgrenciSoyad.Text);
            komut.Parameters.AddWithValue("@p3", mskTC.Text);
            komut.Parameters.AddWithValue("@p4", mskOgrenciTelefon.Text);
            komut.Parameters.AddWithValue("@p5", mskDogumTarihi.Text);
            komut.Parameters.AddWithValue("@p6", cmbBolum.Text);
            komut.Parameters.AddWithValue("@p7", txtMail.Text);
            komut.Parameters.AddWithValue("@p8", cmbOdaNo.Text);
            komut.Parameters.AddWithValue("@p9", txtVeliAdSoyad.Text);
            komut.Parameters.AddWithValue("@p10", mskVeliTelefon.Text);
            komut.Parameters.AddWithValue("@p11", rchAdres.Text);
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Öğrenci kaydı yapıldı!");



            //Öğrenci ID'yi Label12'ye çekme
            baglanti.Open();
            SqlCommand komut2 = new SqlCommand("select OGRID from TBLOGRENCI", baglanti);
            SqlDataReader dr = komut2.ExecuteReader();
            while (dr.Read())
            {
                label12.Text = dr[0].ToString();
            }
            baglanti.Close();



            //Öğrenci Borç Alanı Oluşturma
            baglanti.Open();
            SqlCommand komut3 = new SqlCommand("insert into TBLBORCLAR (OGRID,OGRAD,OGRSOYAD) values (@b1,@b2,@b3)", baglanti);
            komut3.Parameters.AddWithValue("@b1", label12.Text);
            komut3.Parameters.AddWithValue("@b2", txtOgrenciAd.Text);
            komut3.Parameters.AddWithValue("@b3", txtOgrenciSoyad.Text);
            komut3.ExecuteNonQuery();
            baglanti.Close();



            //Öğrenci Oda Kontenjanı Arttırma
            baglanti.Open();
            SqlCommand komutoda = new SqlCommand("update TBLODALAR set ODAAKTIF+=1 where ODANO=@q1", baglanti);
            komutoda.Parameters.AddWithValue("@q1", cmbOdaNo.Text);
            komutoda.ExecuteNonQuery();
            baglanti.Close();


        }
    }
}
```

### Öğrenci Listesi
[![image](https://user-images.githubusercontent.com/95151751/226799281-b36f264f-e8f8-4894-b7ee-4015c12b76a5.png)](https://www.linkedin.com/in/berkan-nihat-yildiz/)
```c#
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _03_Ogrenci_Yurt_Kayit_Otomasyonu
{
    public partial class frmOgrListe : Form
    {
        public frmOgrListe()
        {
            InitializeComponent();
        }

        private void frmOgrListe_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dbYurtOtomasyonuDataSet3.TBLOGRENCI' table. You can move, or remove it, as needed.
            this.tBLOGRENCITableAdapter.Fill(this.dbYurtOtomasyonuDataSet3.TBLOGRENCI);

        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;
            frmOgrDuzenle fr = new frmOgrDuzenle();
            fr.id = dataGridView1.Rows[secilen].Cells[0].Value.ToString();
            fr.ad = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
            fr.soyad = dataGridView1.Rows[secilen].Cells[2].Value.ToString();
            fr.TC = dataGridView1.Rows[secilen].Cells[3].Value.ToString();
            fr.telefon = dataGridView1.Rows[secilen].Cells[4].Value.ToString();
            fr.dogum = dataGridView1.Rows[secilen].Cells[5].Value.ToString();
            fr.bolum = dataGridView1.Rows[secilen].Cells[6].Value.ToString();
            fr.mail = dataGridView1.Rows[secilen].Cells[7].Value.ToString();
            fr.odano = dataGridView1.Rows[secilen].Cells[8].Value.ToString();
            fr.veliad = dataGridView1.Rows[secilen].Cells[9].Value.ToString();
            fr.velitel = dataGridView1.Rows[secilen].Cells[10].Value.ToString();
            fr.adres = dataGridView1.Rows[secilen].Cells[11].Value.ToString();
            fr.Show();
        }
    }
}
```

### Öğrenci Bilgileri Düzenle
[![image](https://user-images.githubusercontent.com/95151751/226799411-7531874b-84a4-4f2b-bce1-1e28f93087a7.png)](https://www.linkedin.com/in/berkan-nihat-yildiz/)
```c#
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
    public partial class frmOgrDuzenle : Form
    {
        public frmOgrDuzenle()
        {
            InitializeComponent();
        }

        SqlBaglantisi bgl = new SqlBaglantisi();

        public string id, ad, soyad, TC, telefon, dogum, bolum, mail, odano, veliad, velitel, adres;

        private void button1_Click(object sender, EventArgs e)
        {

            //Öğrenci Silme
            SqlCommand komut = new SqlCommand("delete from TBLOGRENCI where OGRID=@p1", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", txtOgrID.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Kayıt Silindi!");



            //Oda Kontenjanı Arttırma
            SqlCommand k2 = new SqlCommand("update TBLODALAR set ODAAKTIF-=1 where ODANO=@o1", bgl.baglanti());
            k2.Parameters.AddWithValue("o1", cmbOdaNo.Text);
            k2.ExecuteNonQuery();
            bgl.baglanti().Close();
        }

        private void btnGüncelle_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("update tblogrencı set ograd=@p1, ogrsoyad=@p2,ogrtc=@p3,ogrtelefon=@p4,ogrdogum=@p5,ogrbolum=@p6,ogrmaıl=@p7,ogrodano=@p8,ogrvelıadsoyad=@p9,ogrvelıtelefon=@p10,ogrvelıadres=@p11 where OGRID=@p12", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", txtOgrenciAd.Text);
            komut.Parameters.AddWithValue("@p2", txtOgrenciSoyad.Text);
            komut.Parameters.AddWithValue("@p3", mskTC.Text);
            komut.Parameters.AddWithValue("@p4", mskOgrenciTelefon.Text);
            komut.Parameters.AddWithValue("@p5", mskDogumTarihi.Text);
            komut.Parameters.AddWithValue("@p6", cmbBolum.Text);
            komut.Parameters.AddWithValue("@p7", txtMail.Text);
            komut.Parameters.AddWithValue("@p8", cmbOdaNo.Text);
            komut.Parameters.AddWithValue("@p9", txtVeliAdSoyad.Text);
            komut.Parameters.AddWithValue("@p10", mskVeliTelefon.Text);
            komut.Parameters.AddWithValue("@p11", rchAdres.Text);
            komut.Parameters.AddWithValue("@p12", txtOgrID.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Öğrenci Bilgileri Güncellendi!");

        }

        private void frmOgrDuzenle_Load(object sender, EventArgs e)
        {

            //Bölümleri Combobox'a getirme:↓
            SqlCommand komut = new SqlCommand("select BOLUMAD from TBLBOLUMLER", bgl.baglanti());
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                cmbBolum.Items.Add(dr[0].ToString());
            }
            bgl.baglanti().Close();


            //Oda Numaralarını Combobox'a getirme:↓
            SqlCommand komut2 = new SqlCommand("select ODANO from TBLODALAR", bgl.baglanti());
            SqlDataReader dr2 = komut2.ExecuteReader();
            while (dr2.Read())
            {
                cmbOdaNo.Items.Add(dr2[0].ToString());
            }
            bgl.baglanti().Close();



            //Öğrenci Listesi Formundan gelen bilgileri bu forma yerleştirme:↓
            txtOgrID.Text = id;
            txtOgrenciAd.Text = ad;
            txtOgrenciSoyad.Text = soyad;
            mskTC.Text = TC;
            mskOgrenciTelefon.Text = telefon;
            mskDogumTarihi.Text = dogum;
            cmbBolum.SelectedItem = bolum;
            txtMail.Text = mail;
            cmbOdaNo.Text = odano;
            txtVeliAdSoyad.Text = veliad;
            mskVeliTelefon.Text = velitel;
            rchAdres.Text = adres;
        }
    }
}
```

### Bölümler
[![image](https://user-images.githubusercontent.com/95151751/226799468-efddc08a-ea8e-434b-8d05-cfefb281abbd.png)](https://www.linkedin.com/in/berkan-nihat-yildiz/)
```c#
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
```

### Ödemeler
[![image](https://user-images.githubusercontent.com/95151751/226799588-66e49e73-cd21-42ec-8e8d-65d0cc1cbe5f.png)](https://www.linkedin.com/in/berkan-nihat-yildiz/)
```c#
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
```

### Gider Ekle
[![image](https://user-images.githubusercontent.com/95151751/226799665-4a958e4d-182b-4f64-bea4-9da765e0b583.png)](https://www.linkedin.com/in/berkan-nihat-yildiz/)
```c#
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
    public partial class frmGider : Form
    {
        public frmGider()
        {
            InitializeComponent();
        }

        SqlBaglantisi bgl = new SqlBaglantisi();

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("insert into TBLGIDERLER (ELEKTRIK,SU,DOGALGAZ,INTERNET,GIDA,PERSONEL,DIGER) values (@p1,@p2,@p3,@p4,@p5,@p6,@p7)", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", txtElektrik.Text);
            komut.Parameters.AddWithValue("@p2", txtSu.Text);
            komut.Parameters.AddWithValue("@p3", txtDogalGaz.Text);
            komut.Parameters.AddWithValue("@p4", txtInternet.Text);
            komut.Parameters.AddWithValue("@p5", txtGida.Text);
            komut.Parameters.AddWithValue("@p6", txtPersonel.Text);
            komut.Parameters.AddWithValue("@p7", txtDiger.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Kayıtlar Eklendi!");
        }
    }
}
```

### Gider Listesi
[![image](https://user-images.githubusercontent.com/95151751/226799711-6266178b-ecd0-47bc-a70b-f672b355d5f5.png)](https://www.linkedin.com/in/berkan-nihat-yildiz/)
```c#
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _03_Ogrenci_Yurt_Kayit_Otomasyonu
{
    public partial class frmGiderListesi : Form
    {
        public frmGiderListesi()
        {
            InitializeComponent();
        }

        private void frmGiderListesi_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dbYurtOtomasyonuDataSet4.TBLGIDERLER' table. You can move, or remove it, as needed.
            this.tBLGIDERLERTableAdapter.Fill(this.dbYurtOtomasyonuDataSet4.TBLGIDERLER);

        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;
            frmGiderGuncelle fr = new frmGiderGuncelle();
            fr.id = dataGridView1.Rows[secilen].Cells[0].Value.ToString();
            fr.elektrik = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
            fr.su = dataGridView1.Rows[secilen].Cells[2].Value.ToString();
            fr.dogalgaz = dataGridView1.Rows[secilen].Cells[3].Value.ToString();
            fr.internet = dataGridView1.Rows[secilen].Cells[4].Value.ToString();
            fr.gida = dataGridView1.Rows[secilen].Cells[5].Value.ToString();
            fr.personel = dataGridView1.Rows[secilen].Cells[6].Value.ToString();
            fr.diger = dataGridView1.Rows[secilen].Cells[7].Value.ToString();
            fr.Show();
        }
    }
}
```

### Giderleri Güncelle
[![image](https://user-images.githubusercontent.com/95151751/226799765-234cffa1-c13d-4285-b74c-e2e9ec8caa4e.png)](https://www.linkedin.com/in/berkan-nihat-yildiz/)
```c#
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
    public partial class frmGiderGuncelle : Form
    {
        public frmGiderGuncelle()
        {
            InitializeComponent();
        }

        public string id, elektrik, su, dogalgaz, gida, diger, internet, personel;

        SqlBaglantisi bgl = new SqlBaglantisi();

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("update TBLGIDERLER set ELEKTRIK=@p1, SU=@p2, DOGALGAZ=@p3, INTERNET=@p4, GIDA=@p5, PERSONEL=@p6, DIGER=@p7 where ODEMEID=@p8", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", txtElektrik.Text);
            komut.Parameters.AddWithValue("@p2", txtSu.Text);
            komut.Parameters.AddWithValue("@p3", txtDogalGaz.Text);
            komut.Parameters.AddWithValue("@p4", txtInternet.Text);
            komut.Parameters.AddWithValue("@p5", txtGida.Text);
            komut.Parameters.AddWithValue("@p6", txtPersonel.Text);
            komut.Parameters.AddWithValue("@p7", txtDiger.Text);
            komut.Parameters.AddWithValue("@p8", txtGiderID.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Gider Bilgileri Güncellendi!");

        }

        private void frmGiderGuncelle_Load(object sender, EventArgs e)
        {
            txtGiderID.Text = id;
            txtElektrik.Text = elektrik;
            txtSu.Text = su;
            txtDogalGaz.Text = dogalgaz;
            txtGida.Text = gida;
            txtDiger.Text = diger;
            txtInternet.Text = internet;
            txtPersonel.Text = personel;
        }
    }
}
```

### Gelir İstatistikleri
[![image](https://user-images.githubusercontent.com/95151751/226799822-9346dae0-3819-44c2-b410-ed0027fae62d.png)](https://www.linkedin.com/in/berkan-nihat-yildiz/)
```c#
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
    public partial class frmGelirIstatistik : Form
    {
        public frmGelirIstatistik()
        {
            InitializeComponent();
        }

        SqlBaglantisi bgl = new SqlBaglantisi();

        private void frmGelirIstatistik_Load(object sender, EventArgs e)
        {
            //Kasadaki Toplam Tutar
            SqlCommand komut = new SqlCommand("select sum(ODEMEMIKTAR) from TBLKASA", bgl.baglanti());
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                lblKasadakiPara.Text = dr[0] + " TL";
            }
            bgl.baglanti().Close();



            //Tekrarsız olarak ayları listeleme
            SqlCommand komut2 = new SqlCommand("select distinct(ODEMEAY) from TBLKASA",bgl.baglanti());
            SqlDataReader dr2 = komut2.ExecuteReader();
            while (dr2.Read())
            {
                comboBox1.Items.Add(dr2[0].ToString());
            }
            bgl.baglanti().Close();



            //Grafiklere Veritabanından Veri Çekme
            SqlCommand k3 = new SqlCommand("select ODEMEAY,sum(ODEMEMIKTAR) from TBLKASA group by ODEMEAY", bgl.baglanti());
            SqlDataReader dr3 = k3.ExecuteReader();
            while (dr3.Read())
            {
                this.chart1.Series["Aylık"].Points.AddXY(dr3[0], dr3[1]);
            }
            bgl.baglanti().Close();
            
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("select sum(ODEMEMIKTAR) from TBLKASA where ODEMEAY=@p1", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", comboBox1.SelectedItem);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                lblAyKazanc.Text = dr[0].ToString();
            }
            bgl.baglanti().Close();
        }
    }
}
```

### Yönetici İşlemleri
[![image](https://user-images.githubusercontent.com/95151751/226800008-1a148e1c-96bd-4c0d-9c0f-e7aa01d6829a.png)](https://www.linkedin.com/in/berkan-nihat-yildiz/)
```c#
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
```

### Personel İşlemleri
[![image](https://user-images.githubusercontent.com/95151751/226800049-d1e34149-8a35-4d75-8228-8c89f5a1a2db.png)](https://www.linkedin.com/in/berkan-nihat-yildiz/)
```c#
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
```

### Not Oluştur
[![image](https://user-images.githubusercontent.com/95151751/226800087-58029af7-f61e-4062-a0b0-e249bdef3e39.png)](https://www.linkedin.com/in/berkan-nihat-yildiz/)
```c#
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace _03_Ogrenci_Yurt_Kayit_Otomasyonu
{
    public partial class frmNotEkle : Form
    {
        public frmNotEkle()
        {
            InitializeComponent();
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Title = "Kayıt Yeri Seçiniz";
            saveFileDialog1.Filter = "Metin Dosyası | *.txt";
            saveFileDialog1.InitialDirectory = @"C:\Users\nihat\OneDrive\Masaüstü";
            saveFileDialog1.ShowDialog();
            StreamWriter kaydet = new StreamWriter(saveFileDialog1.FileName);
            kaydet.WriteLine(richTextBox1.Text);
            kaydet.Close();
            MessageBox.Show("Notunuz Kaydedildi!");
        }
    }
}
```

### Not Kaydet (saveFileDialog)
[![image](https://user-images.githubusercontent.com/95151751/226800191-a9c7c66a-159f-4469-b73b-639823deb78f.png)](https://www.linkedin.com/in/berkan-nihat-yildiz/)


### Erişim Kolaylığı (calc.exe && mspaint.exe)
[![image](https://user-images.githubusercontent.com/95151751/226800258-96241647-1430-4ec1-94ae-f7d660350ea6.png)](https://www.linkedin.com/in/berkan-nihat-yildiz/)


### Erişim Kolaylığı (Radyolar)
[![image](https://user-images.githubusercontent.com/95151751/226800318-deb108e4-7408-4b3f-a5ba-51b3f22b5973.png)](https://www.linkedin.com/in/berkan-nihat-yildiz/)


### Erişim Kolaylığı (Hakkımızda)
[![image](https://user-images.githubusercontent.com/95151751/226800413-b0da36c4-fdab-429f-9393-571f51099be4.png)](https://www.linkedin.com/in/berkan-nihat-yildiz/)


# 04- C# ile DevExpress'te SQL Tabanlı Ticari Otomasyon <a name="project4"></a>

### Admin Girişi
[![image](https://user-images.githubusercontent.com/95151751/228115446-8e420c36-1ba4-4532-b68f-0145ad9e6046.png)](https://www.linkedin.com/in/berkan-nihat-yildiz/)
```c#
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
    public partial class frmAdmin : Form
    {
        public frmAdmin()
        {
            InitializeComponent();
        }

        sqlbaglantisi bgl = new sqlbaglantisi();

        private void simpleButton1_MouseHover(object sender, EventArgs e)
        {
            btnGiris.BackColor = Color.Yellow;
        }

        private void simpleButton1_MouseLeave(object sender, EventArgs e)
        {
            btnGiris.BackColor = Color.White;
        }

        
        private void btnGiris_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("select * from TBLADMIN where KULLANICIAD=@p1 and SIFRE=@p2", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", txtKullaniciAd.Text);
            komut.Parameters.AddWithValue("@p2", txtSifre.Text);
            SqlDataReader dr = komut.ExecuteReader();
            if (dr.Read())
            {
                frmAnaForm fr = new frmAnaForm();
                fr.kullanici = txtKullaniciAd.Text;
                fr.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Hatalı Kullanıcı Adı ya da Şifre!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            bgl.baglanti().Close();

        }

        private void frmAdmin_Load(object sender, EventArgs e)
        {

        }
    }
}
```
### Ana Form
[![image](https://user-images.githubusercontent.com/95151751/228115554-10fc1990-f44b-4ed9-bf1f-9ceb1370c70f.png)](https://www.linkedin.com/in/berkan-nihat-yildiz/)
```c#
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _04_DevExpress_SQL_Tabanli_Ticari_Otomasyon
{
    public partial class frmAnaForm : Form
    {
        public frmAnaForm()
        {
            InitializeComponent();
        }

        frmUrunler fr;
        private void btnUrunler_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fr == null || fr.IsDisposed)
            {
                fr = new frmUrunler();
                fr.MdiParent = this;
                fr.Show();
            }
        }


        frmMusteriler fr2;
        private void btnMusteriler_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fr2 == null || fr2.IsDisposed)
            {
                fr2 = new frmMusteriler();
                fr2.MdiParent = this;
                fr2.Show();
            }
        }

        frmFirmalar fr3;
        private void btnFirmalar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fr3 == null || fr3.IsDisposed)
            {
                fr3 = new frmFirmalar();
                fr3.MdiParent = this;
                fr3.Show();
            }
        }


        frmPersonel fr4;
        private void btnPersoneller_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fr4 == null || fr4.IsDisposed)
            {
                fr4 = new frmPersonel();
                fr4.MdiParent = this;
                fr4.Show();
            }
        }


        frmRehber fr5;
        private void btnRehber_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fr5 == null || fr5.IsDisposed)
            {
                fr5 = new frmRehber();
                fr5.MdiParent = this;
                fr5.Show();
            }
        }


        frmGiderler fr6;
        private void btnGiderler_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fr6 == null || fr6.IsDisposed)
            {
                fr6 = new frmGiderler();
                fr6.MdiParent = this;
                fr6.Show();
            }
        }

        frmBankalar fr7;
        private void btnBankalar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fr7 == null || fr7.IsDisposed)
            {
                fr7 = new frmBankalar();
                fr7.MdiParent = this;
                fr7.Show();
            }

        }

        frmFaturalar fr8;
        private void btnFaturalar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fr8 == null || fr8.IsDisposed)
            {
                fr8 = new frmFaturalar();
                fr8.MdiParent = this;
                fr8.Show();
            }

        }


        frmNotlar fr9;
        private void btnNotlar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fr9 == null || fr9.IsDisposed)
            {
                fr9 = new frmNotlar();
                fr9.MdiParent = this;
                fr9.Show();
            }

        }

        frmHareketler fr10;
        private void btnHareketler_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if(fr10==null || fr10.IsDisposed)
            {
                fr10 = new frmHareketler();
                fr10.MdiParent = this;
                fr10.Show();
            }
        }


        frmStoklar fr11;
        private void btnStoklar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fr11 == null || fr11.IsDisposed)
            {
                fr11 = new frmStoklar();
                fr11.MdiParent = this;
                fr11.Show();
            }
        }

        frmAyarlar fr12;
        private void btnAyarlar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fr12 == null || fr12.IsDisposed)
            {
                fr12 = new frmAyarlar();
                fr12.Show();
            }
        }


        public string kullanici;
        frmKasa fr13;
        private void btnKasa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fr13 == null || fr13.IsDisposed)
            {
                fr13 = new frmKasa();
                fr13.ad = kullanici;
                fr13.MdiParent = this;
                fr13.Show();
            }

        }

        frmAnaSayfa fr14;
        private void btnAnasayfa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fr14 == null || fr14.IsDisposed)
            {
                fr14 = new frmAnaSayfa();
                fr14.MdiParent = this;
                fr14.Show();
            }

        }

        private void frmAnaForm_Load(object sender, EventArgs e)
        {
            if (fr14 == null || fr14.IsDisposed)
            {
                fr14 = new frmAnaSayfa();
                fr14.MdiParent = this;
                fr14.Show();
            }
        }
    }
}
```
### Anasayfa
[![image](https://user-images.githubusercontent.com/95151751/228115554-10fc1990-f44b-4ed9-bf1f-9ceb1370c70f.png)](https://www.linkedin.com/in/berkan-nihat-yildiz/)
```c#
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
    public partial class frmAnaSayfa : Form
    {
        public frmAnaSayfa()
        {
            InitializeComponent();
        }

        sqlbaglantisi bgl = new sqlbaglantisi();


        void stoklar()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select URUNAD,sum(ADET) as 'Adet' from TBLURUNLER" +
                " group by URUNAD having sum(ADET)<=20 order by sum(ADET)", bgl.baglanti());
            da.Fill(dt);
            gridControl1.DataSource = dt;
        }


        void ajanda()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select top 10 TARIH,SAAT,BASLIK from TBLNOTLAR order by ID desc", bgl.baglanti());
            da.Fill(dt);
            gridControl2.DataSource = dt;
        }


        void FirmaHareketleri()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("execute FirmaHareketler", bgl.baglanti());
            da.Fill(dt);
            gridControl3.DataSource = dt;
        }



        void fihrist()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select AD,TELEFON1 from TBLFIRMALAR", bgl.baglanti());
            da.Fill(dt);
            gridControl4.DataSource = dt;
        }


        private void frmAnaSayfa_Load(object sender, EventArgs e)
        {
            stoklar();
            ajanda();
            FirmaHareketleri();
            fihrist();

            webBrowser1.Navigate("http://www.tcmb.gov.tr/kurlar/today.xml");
        }
    }
}
```
### Ürünler
[![image](https://user-images.githubusercontent.com/95151751/228115663-199e6596-9f2c-4b8e-a094-7e2be75d460c.png)](https://www.linkedin.com/in/berkan-nihat-yildiz/)
```c#
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
```
### Stoklar
[![image](https://user-images.githubusercontent.com/95151751/228115719-b305022b-8212-4b72-8af7-fe4306fa377b.png)](https://www.linkedin.com/in/berkan-nihat-yildiz/)
```c#
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
    public partial class frmStoklar : Form
    {
        public frmStoklar()
        {
            InitializeComponent();
        }

        sqlbaglantisi bgl = new sqlbaglantisi();

        private void frmStoklar_Load(object sender, EventArgs e)
        {

            SqlDataAdapter da = new SqlDataAdapter("select URUNAD,Sum(ADET) as 'Miktar' from TBLURUNLER group by URUNAD", bgl.baglanti());
            DataTable dt = new DataTable();
            da.Fill(dt);
            gridControl1.DataSource = dt;


            //Chart Üzerinde Stok Miktarı Listeleme
            SqlCommand komut = new SqlCommand("select URUNAD,sum(ADET) as 'Miktar' from TBLURUNLER group by URUNAD", bgl.baglanti());
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                chartControl1.Series["Series 1"].Points.AddPoint(Convert.ToString(dr[0]), Convert.ToInt32(dr[1].ToString()));
            }
            bgl.baglanti().Close();
        }
    }
}
```
### Müşteriler
[![image](https://user-images.githubusercontent.com/95151751/228115774-5b0554bc-395a-41f8-8f24-5313d9d51e6f.png)](https://www.linkedin.com/in/berkan-nihat-yildiz/)
```c#
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
    public partial class frmMusteriler : Form
    {
        public frmMusteriler()
        {
            InitializeComponent();
        }

        sqlbaglantisi bgl = new sqlbaglantisi();

        void listele()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select * from TBLMUSTERILER", bgl.baglanti());
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


        void temizle()
        {
            txtAd.Text = "";
            txtID.Text = "";
            txtMail.Text = "";
            txtSoyad.Text = "";
            txtVergi.Text = "";
            mskTC.Text = "";
            mskTel1.Text = "";
            mskTel2.Text = "";
            cmbIL.Text = "";
            cmbILCE.Text = "";
            rchAdres.Text = "";
            txtAd.Focus();
        }

        private void frmMusteriler_Load(object sender, EventArgs e)
        {
            listele();
            sehirlistesi();
            temizle();
        }

        private void cmbIL_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbILCE.Items.Clear();
            SqlCommand komut = new SqlCommand("select ILCE from TBLILCELER where SEHIR=@p1", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", cmbIL.SelectedIndex+1);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                cmbILCE.Items.Add(dr[0]);
            }
            bgl.baglanti().Close();

        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("insert into TBLMUSTERILER (AD,SOYAD,TELEFON,TELEFON2,TC,MAIL,IL,ILCE,ADRES,VERGIDAIRE) values (@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8,@p9,@p10)", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", txtAd.Text);
            komut.Parameters.AddWithValue("@p2", txtSoyad.Text);
            komut.Parameters.AddWithValue("@p3", mskTel1.Text);
            komut.Parameters.AddWithValue("@p4", mskTel2.Text);
            komut.Parameters.AddWithValue("@p5", mskTC.Text);
            komut.Parameters.AddWithValue("@p6", txtMail.Text);
            komut.Parameters.AddWithValue("@p7", cmbIL.Text);
            komut.Parameters.AddWithValue("@p8", cmbILCE.Text);
            komut.Parameters.AddWithValue("@p9", rchAdres.Text);
            komut.Parameters.AddWithValue("@p10", txtVergi.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Müşteri sisteme eklendi!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            listele();
            temizle();
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            if (dr != null)
            {
                txtID.Text = dr["ID"].ToString();
                txtAd.Text = dr["AD"].ToString();
                txtSoyad.Text = dr["SOYAD"].ToString();
                mskTel1.Text = dr["TELEFON"].ToString();
                mskTel2.Text = dr["TELEFON2"].ToString();
                mskTC.Text = dr["TC"].ToString();
                txtMail.Text = dr["MAIL"].ToString();
                cmbIL.Text = dr["IL"].ToString();
                cmbILCE.Text = dr["ILCE"].ToString();
                txtVergi.Text = dr["VERGIDAIRE"].ToString();
                rchAdres.Text = dr["ADRES"].ToString();
            }
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("delete from TBLMUSTERILER where ID=@p1", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", txtID.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Müşteri Silindi!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            listele();
            temizle();
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("update TBLMUSTERILER set AD=@p1,SOYAD=@p2,TELEFON=@p3,TELEFON2=@p4,TC=@p5,MAIL=@p6,IL=@p7,ILCE=@p8,VERGIDAIRE=@p9,ADRES=@p10 where ID=@p11", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", txtAd.Text);
            komut.Parameters.AddWithValue("@p2", txtSoyad.Text);
            komut.Parameters.AddWithValue("@p3", mskTel1.Text);
            komut.Parameters.AddWithValue("@p4", mskTel2.Text);
            komut.Parameters.AddWithValue("@p5", mskTC.Text);
            komut.Parameters.AddWithValue("@p6", txtMail.Text);
            komut.Parameters.AddWithValue("@p7", cmbIL.Text);
            komut.Parameters.AddWithValue("@p8", cmbILCE.Text);
            komut.Parameters.AddWithValue("@p9", rchAdres.Text);
            komut.Parameters.AddWithValue("@p10", txtVergi.Text);
            komut.Parameters.AddWithValue("@p11", txtID.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Müşteri bilgileri güncellendi!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            listele();
            temizle();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            temizle();
        }
    }
}
```
### Firmalar
[![image](https://user-images.githubusercontent.com/95151751/228115857-24d1bd2b-6fab-4a45-91fe-081d2375672d.png)](https://www.linkedin.com/in/berkan-nihat-yildiz/)

[![image](https://user-images.githubusercontent.com/95151751/228115951-b2a1f246-5840-4e6b-941b-2d50bfa2cac5.png)](https://www.linkedin.com/in/berkan-nihat-yildiz/)

[![image](https://user-images.githubusercontent.com/95151751/228115977-11841d42-bfa9-4f86-b875-cc01ec3ed94f.png)](https://www.linkedin.com/in/berkan-nihat-yildiz/)
```c#
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
    public partial class frmFirmalar : Form
    {
        public frmFirmalar()
        {
            InitializeComponent();
        }

        sqlbaglantisi bgl = new sqlbaglantisi();

        void listele()
        {
            SqlDataAdapter da = new SqlDataAdapter("select * from TBLFIRMALAR", bgl.baglanti());
            DataTable dt = new DataTable();
            da.Fill(dt);
            gridControl1.DataSource = dt;
        }

        void temizle()
        {
            txtAd.Text = "";
            txtID.Text = "";
            txtKod1.Text = "";
            txtKod2.Text = "";
            txtKod3.Text = "";
            txtMail.Text = "";
            txtSektor.Text = "";
            txtVergiDairesi.Text = "";
            txtYetkiliAdSoyad.Text = "";
            txtYetkiliGorev.Text = "";
            mskFax.Text = "";
            mskTel1.Text = "";
            mskTel2.Text = "";
            mskTel3.Text = "";
            mskTC.Text = "";
            rchAdres.Text = "";
            cmbIL.Text = "";
            cmbILCE.Text = "";
            txtAd.Focus();
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

        void carikodaciklamalar()
        {
            SqlCommand komut = new SqlCommand("select FIRMAKOD1 from TBLKODLAR", bgl.baglanti());
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                rchKod1.Text = dr[0].ToString();
            }
            bgl.baglanti().Close();
        }


        private void frmFirmalar_Load(object sender, EventArgs e)
        {
            listele();
            temizle();
            sehirlistesi();
            carikodaciklamalar();
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            if (dr != null)
            {
                txtID.Text = dr["ID"].ToString();
                txtAd.Text = dr["AD"].ToString();
                txtYetkiliGorev.Text = dr["YETKILISTATU"].ToString();
                txtYetkiliAdSoyad.Text = dr["YETKILIADSOYAD"].ToString();
                mskTC.Text = dr["YETKILITC"].ToString();
                txtSektor.Text = dr["SEKTOR"].ToString();
                mskTel1.Text = dr["TELEFON1"].ToString();
                mskTel2.Text = dr["TELEFON2"].ToString();
                mskTel3.Text = dr["TELEFON3"].ToString();
                txtMail.Text = dr["MAIL"].ToString();
                mskFax.Text = dr["FAX"].ToString();
                cmbIL.Text = dr["IL"].ToString();
                cmbILCE.Text = dr["ILCE"].ToString();
                txtVergiDairesi.Text = dr["VERGIDAIRE"].ToString();
                rchAdres.Text = dr["ADRES"].ToString();
                txtKod1.Text = dr["OZELKOD1"].ToString();
                txtKod2.Text = dr["OZELKOD2"].ToString();
                txtKod3.Text = dr["OZELKOD3"].ToString();
            }
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("insert into TBLFIRMALAR (AD,YETKILISTATU,YETKILIADSOYAD,YETKILITC,SEKTOR,TELEFON1,TELEFON2,TELEFON3,MAIL,FAX,IL,ILCE,VERGIDAIRE,ADRES,OZELKOD1,OZELKOD2,OZELKOD3) values (@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8,@p9,@p10,@p11,@p12,@p13,@p14,@p15,@p16,@p17)", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", txtAd.Text);
            komut.Parameters.AddWithValue("@p2", txtYetkiliGorev.Text);
            komut.Parameters.AddWithValue("@p3", txtYetkiliAdSoyad.Text);
            komut.Parameters.AddWithValue("@p4", mskTC.Text);
            komut.Parameters.AddWithValue("@p5", txtSektor.Text);
            komut.Parameters.AddWithValue("@p6", mskTel1.Text);
            komut.Parameters.AddWithValue("@p7", mskTel2.Text);
            komut.Parameters.AddWithValue("@p8", mskTel3.Text);
            komut.Parameters.AddWithValue("@p9", txtMail.Text);
            komut.Parameters.AddWithValue("@p10", mskFax.Text);
            komut.Parameters.AddWithValue("@p11", cmbIL.Text);
            komut.Parameters.AddWithValue("@p12", cmbILCE.Text);
            komut.Parameters.AddWithValue("@p13", txtVergiDairesi.Text);
            komut.Parameters.AddWithValue("@p14", rchAdres.Text);
            komut.Parameters.AddWithValue("@p15", txtKod1.Text);
            komut.Parameters.AddWithValue("@p16", txtKod2.Text);
            komut.Parameters.AddWithValue("@p17", txtKod3.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Firma Sisteme Kaydedildi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            listele();
            temizle();
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

        private void btnSil_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("delete from TBLFIRMALAR where ID=@p1", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", txtID.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            listele();
            MessageBox.Show("Firma Listeden Silindi!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            temizle();
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("update TBLFIRMALAR set AD=@p1,YETKILISTATU=@p2,YETKILIADSOYAD=@p3,YETKILITC=@p4," +
                "SEKTOR=@p5,TELEFON1=@p6,TELEFON2=@p7,TELEFON3=@p8,MAIL=@p9,FAX=@p10,IL=@p11,ILCE=@p12,VERGIDAIRE=@p13,ADRES=@p14," +
                "OZELKOD1=@p15,OZELKOD2=@p16,OZELKOD3=@p17 where ID=@p18", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", txtAd.Text);
            komut.Parameters.AddWithValue("@p2", txtYetkiliGorev.Text);
            komut.Parameters.AddWithValue("@p3", txtYetkiliAdSoyad.Text);
            komut.Parameters.AddWithValue("@p4", mskTC.Text);
            komut.Parameters.AddWithValue("@p5", txtSektor.Text);
            komut.Parameters.AddWithValue("@p6", mskTel1.Text);
            komut.Parameters.AddWithValue("@p7", mskTel2.Text);
            komut.Parameters.AddWithValue("@p8", mskTel3.Text);
            komut.Parameters.AddWithValue("@p9", txtMail.Text);
            komut.Parameters.AddWithValue("@p10", mskFax.Text);
            komut.Parameters.AddWithValue("@p11", cmbIL.Text);
            komut.Parameters.AddWithValue("@p12", cmbILCE.Text);
            komut.Parameters.AddWithValue("@p13", txtVergiDairesi.Text);
            komut.Parameters.AddWithValue("@p14", rchAdres.Text);
            komut.Parameters.AddWithValue("@p15", txtKod1.Text);
            komut.Parameters.AddWithValue("@p16", txtKod2.Text);
            komut.Parameters.AddWithValue("@p17", txtKod3.Text);
            komut.Parameters.AddWithValue("@p18", txtID.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            listele();
            temizle();
            MessageBox.Show("Firma Bilgileri Güncellendi!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnTemizel_Click(object sender, EventArgs e)
        {
            temizle();
        }
    }
}
```
### Personeller
[![image](https://user-images.githubusercontent.com/95151751/228116019-25dfe47f-733a-4676-accc-b68d39c25c89.png)](https://www.linkedin.com/in/berkan-nihat-yildiz/)
```c#
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
    public partial class frmPersonel : Form
    {
        public frmPersonel()
        {
            InitializeComponent();
        }

        sqlbaglantisi bgl = new sqlbaglantisi();

        void listele()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select * from TBLPERSONELLER", bgl.baglanti());
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



        private void frmPersonel_Load(object sender, EventArgs e)
        {
            listele();
            sehirlistesi();
            temizle();
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("insert into TBLPERSONELLER " +
                "(AD,SOYAD,TELEFON,TC,MAIL,IL,ILCE,ADRES,GOREV) values " +
                "(@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8,@p9)", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", txtAd.Text);
            komut.Parameters.AddWithValue("@p2", txtSoyad.Text);
            komut.Parameters.AddWithValue("@p3", mskTel1.Text);
            komut.Parameters.AddWithValue("@p4", mskTC.Text);
            komut.Parameters.AddWithValue("@p5", txtMail.Text);
            komut.Parameters.AddWithValue("@p6", cmbIL.Text);
            komut.Parameters.AddWithValue("@p7", cmbILCE.Text);
            komut.Parameters.AddWithValue("@p8", rchAdres.Text);
            komut.Parameters.AddWithValue("@p9", txtGorev.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            listele();
            temizle();
            MessageBox.Show("Personel Bilgileri Kaydedildi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        void temizle()
        {
            txtAd.Text = "";
            txtID.Text = "";
            txtMail.Text = "";
            txtSoyad.Text = "";
            cmbIL.Text = "";
            cmbILCE.Text = "";
            rchAdres.Text = "";
            txtGorev.Text = "";
            mskTel1.Text = "";
            mskTC.Text = "";
            txtAd.Focus();
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
                txtAd.Text = dr["AD"].ToString();
                txtSoyad.Text = dr["SOYAD"].ToString();
                mskTel1.Text = dr["TELEFON"].ToString();
                mskTC.Text = dr["TC"].ToString();
                txtMail.Text = dr["MAIL"].ToString();
                cmbIL.Text = dr["IL"].ToString();
                cmbILCE.Text = dr["ILCE"].ToString();
                rchAdres.Text = dr["ADRES"].ToString();
                txtGorev.Text = dr["GOREV"].ToString();
            }
        }

        private void btnTemizle_Click(object sender, EventArgs e)
        {
            temizle();
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("delete from TBLPERSONELLER where ID=@p1", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", txtID.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            listele();
            temizle();
            MessageBox.Show("Personel Listeden Silindi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.None);
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("update TBLPERSONELLER set AD=@p1,SOYAD=@p2,TELEFON=@p3,TC=@p4,MAIL=@p5,IL=@p6,ILCE=@p7,ADRES=@p8,GOREV=@p9 where ID=@p10", bgl.baglanti());
            komut.Parameters.AddWithValue("@p10", txtID.Text);
            komut.Parameters.AddWithValue("@p1", txtAd.Text);
            komut.Parameters.AddWithValue("@p2", txtSoyad.Text);
            komut.Parameters.AddWithValue("@p3", mskTel1.Text);
            komut.Parameters.AddWithValue("@p4", mskTC.Text);
            komut.Parameters.AddWithValue("@p5", txtMail.Text);
            komut.Parameters.AddWithValue("@p6", cmbIL.Text);
            komut.Parameters.AddWithValue("@p7", cmbILCE.Text);
            komut.Parameters.AddWithValue("@p8", rchAdres.Text);
            komut.Parameters.AddWithValue("@p9", txtGorev.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Personel Bilgileri Güncellendi!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            listele();
            temizle();
        }
    }
}
```
### Giderler
[![image](https://user-images.githubusercontent.com/95151751/228116065-488ed382-73e2-4969-ab9a-aa80e165fbc1.png)](https://www.linkedin.com/in/berkan-nihat-yildiz/)
```c#
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
```
### Kasa
[![image](https://user-images.githubusercontent.com/95151751/228116170-997c5914-5ac6-45e6-9026-2855e8997886.png)](https://www.linkedin.com/in/berkan-nihat-yildiz/)
```c#
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
using DevExpress.Charts;

namespace _04_DevExpress_SQL_Tabanli_Ticari_Otomasyon
{
    public partial class frmKasa : Form
    {
        public frmKasa()
        {
            InitializeComponent();
        }

        sqlbaglantisi bgl = new sqlbaglantisi();


        void musteriHareket()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("execute MusteriHareketler", bgl.baglanti());
            da.Fill(dt);
            gridControl1.DataSource = dt;
        }
        void firmaHareket()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("execute FirmaHareketler", bgl.baglanti());
            da.Fill(dt);
            gridControl3.DataSource = dt;
        }

        public string ad;

        private void frmKasa_Load(object sender, EventArgs e)
        {

            lblAktifKullanici.Text = ad;

            musteriHareket();
            firmaHareket();


            //Toplam Tutarı Hesaplama
            SqlCommand komut = new SqlCommand("select sum(TUTAR) from TBLFATURADETAY", bgl.baglanti());
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                lblToplamTutar.Text = dr[0] + " ₺";
            }
            bgl.baglanti().Close();



            //Son ayın faturaları
            SqlCommand komut2 = new SqlCommand("select (ELEKTRIK+SU+DOGALGAZ) from TBLGIDERLER order by ID asc", bgl.baglanti());
            SqlDataReader dr2 = komut2.ExecuteReader();
            while (dr2.Read())
            {
                lblOdemeler.Text = dr2[0] + " ₺";
            }
            bgl.baglanti().Close();



            //Son ayın personel maaşları
            SqlCommand komut3 = new SqlCommand("select maaslar from TBLGIDERLER order by ID asc", bgl.baglanti());
            SqlDataReader dr3 = komut3.ExecuteReader();
            while (dr3.Read())
            {
                lblPersonelMaaslari.Text = dr3[0] + " ₺";
            }
            bgl.baglanti().Close();



            //Toplam müşteri sayısı
            SqlCommand komut4 = new SqlCommand("select count(*) from TBLMUSTERILER", bgl.baglanti());
            SqlDataReader dr4 = komut4.ExecuteReader();
            while (dr4.Read())
            {
                lblMusteriSayisi.Text = dr4[0].ToString();
            }
            bgl.baglanti().Close();



            //Toplam firma sayısı
            SqlCommand komut5 = new SqlCommand("select count(*) from TBLFIRMALAR", bgl.baglanti());
            SqlDataReader dr5 = komut5.ExecuteReader();
            while (dr5.Read())
            {
                lblFirmaSayisi.Text = dr5[0].ToString();
            }
            bgl.baglanti().Close();



            //Toplam firma şehir sayısı
            SqlCommand komut6 = new SqlCommand("select count(distinct(IL)) from TBLFIRMALAR", bgl.baglanti());
            SqlDataReader dr6 = komut6.ExecuteReader();
            while (dr6.Read())
            {
                lblFirmaSehir.Text = dr6[0].ToString();
            }
            bgl.baglanti().Close();



            //Toplam müşteri şehir sayısı
            SqlCommand komut7 = new SqlCommand("select count(*) from TBLMUSTERILER", bgl.baglanti());
            SqlDataReader dr7 = komut7.ExecuteReader();
            while (dr7.Read())
            {
                lblMusteriSehir.Text = dr7[0].ToString();
            }
            bgl.baglanti().Close();



            //Toplam personel sayısı
            SqlCommand komut8 = new SqlCommand("select count(*) from TBLPERSONELLER", bgl.baglanti());
            SqlDataReader dr8 = komut8.ExecuteReader();
            while (dr8.Read())
            {
                lblPersonelSayisi.Text = dr8[0].ToString();
            }
            bgl.baglanti().Close();



            //Toplam ürün sayısı
            SqlCommand komut9 = new SqlCommand("select sum(ADET) from TBLURUNLER", bgl.baglanti());
            SqlDataReader dr9 = komut9.ExecuteReader();
            while (dr9.Read())
            {
                lblStokSayisi.Text = dr9[0].ToString();
            }
            bgl.baglanti().Close();



            //1. Chart Control'e Elektrik Faturası son 4 ay ekleme
            SqlCommand komut10 = new SqlCommand("select top 4 AY,ELEKTRIK from TBLGIDERLER order by ID desc", bgl.baglanti());
            SqlDataReader dr10 = komut10.ExecuteReader();
            while (dr10.Read())
            {
                chartControl1.Series["Aylar"].Points.Add(new DevExpress.XtraCharts.SeriesPoint(dr10[0], dr10[1]));
            }
            bgl.baglanti().Close();



            //2. Chart Control'e Su Faturası son 4 ay ekleme
            SqlCommand komut11 = new SqlCommand("select top 4 AY,SU from TBLGIDERLER order by ID desc", bgl.baglanti());
            SqlDataReader dr11 = komut11.ExecuteReader();
            while (dr11.Read())
            {
                chartControl1.Series["Aylar"].Points.Add(new DevExpress.XtraCharts.SeriesPoint(dr11[0], dr11[1]));
            }
            bgl.baglanti().Close();


        }
    }
}
```
### Notlar
[![image](https://user-images.githubusercontent.com/95151751/228116215-6cbc0b72-a2fc-4a65-974b-743da08542f0.png)](https://www.linkedin.com/in/berkan-nihat-yildiz/)
```c#
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
    public partial class frmNotlar : Form
    {
        public frmNotlar()
        {
            InitializeComponent();
        }

        sqlbaglantisi bgl = new sqlbaglantisi();


        void listele()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select * from TBLNOTLAR", bgl.baglanti());
            da.Fill(dt);
            gridControl1.DataSource = dt;
        }

        
        void temizle()
        {
            txtBaslik.Text = "";
            txtHitap.Text = "";
            txtID.Text = "";
            txtOlusturan.Text = "";
            txtDetay.Text = "";
            mskSaat.Text = "";
            mskTarih.Text = "";
            mskTarih.Focus();
        }

        private void frmNotlar_Load(object sender, EventArgs e)
        {
            listele();
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("insert into TBLNOTLAR (TARIH,SAAT,BASLIK,DETAY,OLUSTURAN,HITAP) " +
                "values (@p1,@p2,@p3,@p4,@p5,@p6)", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", mskTarih.Text);
            komut.Parameters.AddWithValue("@p2", mskSaat.Text);
            komut.Parameters.AddWithValue("@p3", txtBaslik.Text);
            komut.Parameters.AddWithValue("@p4", txtDetay.Text);
            komut.Parameters.AddWithValue("@p5", txtOlusturan.Text);
            komut.Parameters.AddWithValue("@p6", txtHitap.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            listele();
            MessageBox.Show("Not Bilgisi Sisteme Eklendi!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);

            if (dr != null)
            {
                txtID.Text = dr["ID"].ToString();
                txtBaslik.Text = dr["BASLIK"].ToString();
                txtDetay.Text = dr["DETAY"].ToString();
                txtOlusturan.Text = dr["OLUSTURAN"].ToString();
                txtHitap.Text = dr["HITAP"].ToString();
                mskTarih.Text = dr["TARIH"].ToString();
                mskSaat.Text = dr["SAAT"].ToString();
            }
        }

        private void btnTemizle_Click(object sender, EventArgs e)
        {
            temizle();
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("delete from TBLNOTLAR where ID=@p1", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", txtID.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Not Sistemden Silindi!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            listele();
            temizle();
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("update TBLNOTLAR set " +
                "TARIH=@p1,SAAT=@p2,BASLIK=@p3,DETAY=@p4,OLUSTURAN=@p5,HITAP=@p6 where ID=@p7", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", mskTarih.Text);
            komut.Parameters.AddWithValue("@p2", mskSaat.Text);
            komut.Parameters.AddWithValue("@p3", txtBaslik.Text);
            komut.Parameters.AddWithValue("@p4", txtDetay.Text);
            komut.Parameters.AddWithValue("@p5", txtOlusturan.Text);
            komut.Parameters.AddWithValue("@p6", txtHitap.Text);
            komut.Parameters.AddWithValue("@p7", txtID.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            listele();
            MessageBox.Show("Not Bilgisi Güncellendi!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            frmNotDetay fr = new frmNotDetay();

            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);

            if (dr != null)
            {
                fr.metin = dr["DETAY"].ToString();
            }
            fr.Show();
        }
    }
}
```
### Not Detay
[![image](https://user-images.githubusercontent.com/95151751/228116309-988c8057-28b7-40ec-a786-5444ae9ca0c0.png)](https://www.linkedin.com/in/berkan-nihat-yildiz/)
```c#
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _04_DevExpress_SQL_Tabanli_Ticari_Otomasyon
{
    public partial class frmNotDetay : Form
    {
        public frmNotDetay()
        {
            InitializeComponent();
        }

        public string metin;

        private void frmNotDetay_Load(object sender, EventArgs e)
        {
            richTextBox1.Text = metin;
        }
    }
}
```
### Bankalar
[![image](https://user-images.githubusercontent.com/95151751/228116373-3b871930-49c0-41b5-9292-6a1b9e1d3a53.png)](https://www.linkedin.com/in/berkan-nihat-yildiz/)
```c#
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
```
### Rehber
[![image](https://user-images.githubusercontent.com/95151751/228116446-17b61e92-f456-449f-9cfa-533daa9a255b.png)](https://www.linkedin.com/in/berkan-nihat-yildiz/)
```c#
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
    public partial class frmRehber : Form
    {
        public frmRehber()
        {
            InitializeComponent();
        }

        sqlbaglantisi bgl = new sqlbaglantisi();

        private void frmRehber_Load(object sender, EventArgs e)
        {

            //Müşteri Bilgileri
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select AD,SOYAD,TELEFON,TELEFON2,MAIL from TBLMUSTERILER", bgl.baglanti());
            da.Fill(dt);
            gridControl1.DataSource = dt;


            //Firma Bilgileri
            DataTable dt2 = new DataTable();
            SqlDataAdapter da2 = new SqlDataAdapter("select AD,YETKILIADSOYAD,TELEFON1,TELEFON2,TELEFON3,MAIL,FAX from TBLFIRMALAR", bgl.baglanti());
            da2.Fill(dt2);
            gridControl2.DataSource = dt2;
        }

        private void gridView1_DoubleClick_1(object sender, EventArgs e)
        {
            frmMail fr = new frmMail();
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            if (dr != null)
            {
                fr.mail = dr["MAIL"].ToString();
            }
            fr.Show();
        }

        private void gridView2_DoubleClick_1(object sender, EventArgs e)
        {
            frmMail fr = new frmMail();
            DataRow dr = gridView2.GetDataRow(gridView2.FocusedRowHandle);
            if (dr != null)
            {
                fr.mail = dr["MAIL"].ToString();
            }
            fr.Show();
        }
    }
}
```
### Mail Gönder
[![image](https://user-images.githubusercontent.com/95151751/228116517-f0049b1e-9722-44ec-996f-0bc993031c99.png)](https://www.linkedin.com/in/berkan-nihat-yildiz/)
```c#
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Mail;

namespace _04_DevExpress_SQL_Tabanli_Ticari_Otomasyon
{
    public partial class frmMail : Form
    {
        public frmMail()
        {
            InitializeComponent();
        }

        public string mail;
        private void frmMail_Load(object sender, EventArgs e)
        {
            txtMail.Text = mail;
        }

        private void btnGonder_Click(object sender, EventArgs e)
        {
            MailMessage mesajim = new MailMessage();
            SmtpClient istemci = new SmtpClient();
            istemci.Credentials = new System.Net.NetworkCredential("Mail", "Şifre"); //Mesaj kimden gönderilecekse onun mail bilgileri buraya girilecek
            istemci.Port = 587; //Türkiye mail port numarası
            istemci.Host = "smtp.live.com"; //Windows host adresi (live yerine gmail de yazılabilir)
            istemci.EnableSsl = true;
            mesajim.To.Add(txtMesaj.Text);
            mesajim.From = new MailAddress("Mail"); //Mesaj kimden gönderilecekse onun mail adresi yazılacak
            mesajim.Subject = txtKonu.Text; //Mesajımızın konusu
            mesajim.Body = txtMesaj.Text; //Mesajımız
            istemci.Send(mesajim); //Mesajımızı gönderme komutu
        }
    }
}
```
### Faturalar
[![image](https://user-images.githubusercontent.com/95151751/228116606-014fe2b9-4bad-49fd-ab3d-35af1458d498.png)](https://www.linkedin.com/in/berkan-nihat-yildiz/)
```c#
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
```
### Fatura Ürün Detayı
[![image](https://user-images.githubusercontent.com/95151751/228116680-50cf2df5-fe99-44d4-9a09-aee1644c9f17.png)](https://www.linkedin.com/in/berkan-nihat-yildiz/)
```c#
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
    public partial class frmFaturaUrunDetay : Form
    {
        public frmFaturaUrunDetay()
        {
            InitializeComponent();
        }

        sqlbaglantisi bgl = new sqlbaglantisi();



        void listele()
        {
            SqlDataAdapter da = new SqlDataAdapter("select * from TBLFATURADETAY where FATURAID='" + id + "'", bgl.baglanti());
            DataTable dt = new DataTable();
            da.Fill(dt);
            gridControl1.DataSource = dt;
        }



        public string id;
        private void frmFaturaUrunDetay_Load(object sender, EventArgs e)
        {
            listele();
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            frmFaturaUrunDuzenleme fr = new frmFaturaUrunDuzenleme();
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            if (dr != null)
            {
                fr.urunid = dr["FATURAURUNID"].ToString();
            }
            fr.Show();
        }
    }
}
```
### Fatura Ürün Düzenleme
[![image](https://user-images.githubusercontent.com/95151751/228116764-2a2f5203-bbd8-4f67-bb7b-f95fc72d1b68.png)](https://www.linkedin.com/in/berkan-nihat-yildiz/)
```c#
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
    public partial class frmFaturaUrunDuzenleme : Form
    {
        public frmFaturaUrunDuzenleme()
        {
            InitializeComponent();
        }

        sqlbaglantisi bgl = new sqlbaglantisi();


        public string urunid;
        private void frmFaturaUrunDuzenleme_Load(object sender, EventArgs e)
        {
            txtUrunID.Text = urunid;

            SqlCommand komut = new SqlCommand("select * from TBLFATURADETAY where FATURAURUNID=@p1", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", urunid);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                txtFiyat.Text = dr[3].ToString();
                txtMiktar.Text = dr[2].ToString();
                txtTutar.Text = dr[4].ToString();
                txtUrunAd.Text = dr[1].ToString();
            }
            bgl.baglanti().Close();
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("update TBLFATURADETAY set URUNAD=@p1, MIKTAR=@p2, FIYAT=@p3, TUTAR=@p4" +
                " where FATURAURUNID=@p5", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", txtUrunAd.Text);
            komut.Parameters.AddWithValue("@p2", txtMiktar.Text);
            komut.Parameters.AddWithValue("@p3",decimal.Parse(txtFiyat.Text));
            komut.Parameters.AddWithValue("@p4",decimal.Parse(txtTutar.Text));
            komut.Parameters.AddWithValue("@p5", txtUrunID.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Değişiklikler Kaydedildi!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("delete from TBLFATURADETAY where FATURAURUNID=@p1", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", txtUrunID.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Ürün Silindi!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Hand);
        }
    }
}
```
### Hareketler (Müşteri Hareketleri)
[![image](https://user-images.githubusercontent.com/95151751/228116838-a3c5fd23-2550-4624-8529-424c13a16af6.png)](https://www.linkedin.com/in/berkan-nihat-yildiz/)

### Hareketler (Firma Hareketleri)
[![image](https://user-images.githubusercontent.com/95151751/228116878-992cf87f-7674-4183-a277-d49050490bd9.png)](https://www.linkedin.com/in/berkan-nihat-yildiz/)
```c#
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
    public partial class frmHareketler : Form
    {
        public frmHareketler()
        {
            InitializeComponent();
        }

        sqlbaglantisi bgl = new sqlbaglantisi();


        void FirmaHareketleri()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("execute FirmaHareketler", bgl.baglanti());
            da.Fill(dt);
            gridControl2.DataSource = dt;
        }


        void MusteriHareketleri()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("execute MusteriHareketler", bgl.baglanti());
            da.Fill(dt);
            gridControl1.DataSource = dt;
        }

        private void frmHareketler_Load(object sender, EventArgs e)
        {
            FirmaHareketleri();
            MusteriHareketleri();
        }
    }
}
```
### Ayarlar
[![image](https://user-images.githubusercontent.com/95151751/228117031-529a034f-9bde-4e16-91ad-c71c5e739db0.png)](https://www.linkedin.com/in/berkan-nihat-yildiz/)
```c#
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
    public partial class frmAyarlar : Form
    {
        public frmAyarlar()
        {
            InitializeComponent();
        }

        sqlbaglantisi bgl = new sqlbaglantisi();


        void listele()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select * from TBLADMIN", bgl.baglanti());
            da.Fill(dt);
            gridControl1.DataSource = dt;
        }

        private void frmAyarlar_Load(object sender, EventArgs e)
        {
            listele();
            txtKullaniciAdi.Text = "";
            txtSifre.Text = "";
            txtKullaniciAdi.Focus();

        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            if (btnKaydet.Text == "Kaydet")
            {
                SqlCommand komut = new SqlCommand("insert into TBLADMIN values (@p1,@p2)", bgl.baglanti());
                komut.Parameters.AddWithValue("@p1", txtKullaniciAdi.Text);
                komut.Parameters.AddWithValue("@p2", txtSifre.Text);
                komut.ExecuteNonQuery();
                bgl.baglanti().Close();
                MessageBox.Show("Yeni Admin Sisteme Kaydedildi!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                listele();

                txtKullaniciAdi.Text = "";
                txtSifre.Text = "";
                txtKullaniciAdi.Focus();
            }
            if (btnKaydet.Text == "Güncelle")
            {
                SqlCommand komut1 = new SqlCommand("update TBLADMIN set SIFRE=@p2 where KULLANICIAD=@p1", bgl.baglanti());
                komut1.Parameters.AddWithValue("@p1", txtSifre.Text);
                komut1.Parameters.AddWithValue("@p2", txtKullaniciAdi.Text);
                komut1.ExecuteNonQuery();
                bgl.baglanti().Close();
                MessageBox.Show("Kayıt Güncellendi!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                listele();

                txtKullaniciAdi.Text = "";
                txtSifre.Text = "";
                txtKullaniciAdi.Focus();
            }
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);

            if (dr != null)
            {
                txtKullaniciAdi.Text = dr["KULLANICIAD"].ToString();
                txtSifre.Text = dr["SIFRE"].ToString();
            }
        }

        private void txtKullaniciAdi_TextChanged(object sender, EventArgs e)
        {
            if (txtKullaniciAdi.Text != "")
            {
                btnKaydet.Text = "Güncelle";
            }
            else
            {
                btnKaydet.Text = "Kaydet";
            }
        }
    }
}
```

# ASP.NET Bootstrap ile SQL Tabanlı Web Projesi <a name="project5"></a>

### Login Paneli
![image](https://user-images.githubusercontent.com/95151751/230774885-61872aa9-91ba-4187-97f0-ad5be8f3cdc8.png)

```c#
<%@ Page Language="C#" AutoEventWireup="true" CodeFile="LoginPanel.aspx.cs" Inherits="LoginPanel" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="Dosyalar1/bootstrap.min.css" rel="stylesheet" />
    <style type="text/css">
        .auto-style1 {
            width: 843px;
            margin: auto;
        }

        .auto-style2 {
            margin-bottom: 15px;
            width: 650px;
            margin: auto;
            margin-top: 150px;
        }
        .auto-style3 {
            font-size: large;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server" class="auto-style1">
        <div class="auto-style2">
            <h1 class="text-center"><strong>Udemy Web Not Giriş Paneli</strong></h1>
            <br />
            <br />
            <div>
                <em>
                <asp:Label for="txtKullaniciAdi" runat="server" CssClass="auto-style3">Kullanıcı Adı</asp:Label>
                </em>
                <asp:TextBox ID="txtKullaniciAdi" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            <br />
            <div>
                <em>
                <asp:Label for="txtSifre" runat="server" CssClass="auto-style3">Şifre</asp:Label>
                </em>
                <asp:TextBox ID="txtSifre" runat="server" CssClass="form-control" TextMode="Password"></asp:TextBox>
            </div>
            <br />
            <strong>
            <asp:Button runat="server" Text="Giriş Yap" ID="girisYap" class="btn btn-warning" Width="650px" Height="50px" Font-Bold="True" OnClick="girisYap_Click" />
            </strong>
            <br />
            <br />
            <strong>
            <asp:Button runat="server" Text="Öğretmen Girişi" ID="Button1" class="btn btn-danger" Width="192px" Height="50px" Font-Bold="True" OnClick="Button1_Click" /></strong>&nbsp;
            <strong>
            <asp:Button runat="server" Text="Şifremi Unuttum" ID="Button2" class="btn btn-default" Width="250px" Height="50px" Font-Bold="True" /></strong>&nbsp;
            <strong>
            <asp:Button runat="server" Text="Yardım" ID="Button3" class="btn btn-info" Width="192px" Height="50px" Font-Bold="True" />

            </strong>

        </div>
    </form>
</body>
</html>

```

```c#
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

public partial class LoginPanel : System.Web.UI.Page
{

    SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-HKL3D7O\SQLEXPRESS;Initial Catalog=Dbo_UdemyWeb01;Integrated Security=True");


    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void girisYap_Click(object sender, EventArgs e)
    {
        baglanti.Open();
        SqlCommand komut = new SqlCommand("select * from TBLOGRENCI where NUMARA=@p1 and OGRSIFRE=@p2", baglanti);
        komut.Parameters.AddWithValue("@p1", txtKullaniciAdi.Text);
        komut.Parameters.AddWithValue("@p2", txtSifre.Text);
        SqlDataReader dr = komut.ExecuteReader();
        if (dr.Read())
        {
            Session.Add("numara", txtKullaniciAdi.Text);
            Response.Redirect("OgrenciDefault.aspx");
        }
        else
        {
            txtSifre.Text = "Hatalı Şifre";
        }
        baglanti.Close();
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        baglanti.Open();
        SqlCommand komut = new SqlCommand("select * from TBLOGRETMEN where OGRTNUMARA=@p1 and OGRTSIFRE=@p2", baglanti);
        komut.Parameters.AddWithValue("@p1", txtKullaniciAdi.Text);
        komut.Parameters.AddWithValue("@p2", txtSifre.Text);
        SqlDataReader dr = komut.ExecuteReader();
        if (dr.Read())
        {
            Session.Add("ogrtnumara", txtKullaniciAdi.Text);
            Response.Redirect("Default.aspx");
        }
        else
        {
            txtSifre.Text = "Hatalı Şifre";
        }
        baglanti.Close();

    }
}
```

### [Öğretmen] Öğrenci Listesi
![image](https://user-images.githubusercontent.com/95151751/230774983-d8bee478-cf93-41b1-8c7a-edfe64292910.png)

```c#
<%@ Page Title="" Language="C#" MasterPageFile="~/Ogretmen.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
    <table class="table table-bordered table-hover">
        <tr>
            <th scope="col">ID</th>
            <th scope="col">NUMARA</th>
            <th scope="col">AD</th>
            <th scope="col">SOYAD</th>
            <th scope="col">TELEFON</th>
            <th scope="col">MAIL</th>
            <th scope="col">ŞİFRE</th>
            <th scope="col">İŞLEMLER</th>
        </tr>
        <tbody>

            <asp:Repeater ID="Repeater1" runat="server">

                <ItemTemplate>

                    <tr>
                        <td><%#Eval("OGRID") %></td>
                        <td><%#Eval("NUMARA") %></td>
                        <td><%#Eval("OGRAD") %></td>
                        <td><%#Eval("OGRSOYAD") %></td>
                        <td><%#Eval("OGRTELEFON") %></td>
                        <td><%#Eval("OGRMAIL") %></td>
                        <td><%#Eval("OGRSIFRE") %></td>
                        <td>
                            <asp:HyperLink ID="HyperLink1" NavigateUrl='<%# "~/OgrenciSil.aspx?OGRID="+Eval("OGRID") %>' runat="server" class="btn btn-danger">SİL</asp:HyperLink>
                            <asp:HyperLink ID="HyperLink2" NavigateUrl='<%# "OgrenciGuncelle.aspx?OGRID="+Eval("OGRID") %>' runat="server" class="btn btn-success">GÜNCELLE</asp:HyperLink>
                        </td>
                    </tr>

                </ItemTemplate>

            </asp:Repeater>

        </tbody>
    </table>
</asp:Content>

<%--<th scope="row">1</th>--%>

```

```c#
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        DataSetTableAdapters.TBLOGRENCITableAdapter dt = new DataSetTableAdapters.TBLOGRENCITableAdapter();
        Repeater1.DataSource = dt.OgrenciListesi2();
        Repeater1.DataBind();
    }
}
```

### [Öğretmen] Öğrenci Güncelle
![image](https://user-images.githubusercontent.com/95151751/230776203-58e9e0b5-1e6a-4ad3-86d4-6ea5768f6f4a.png)

```c#
<%@ Page Title="" Language="C#" MasterPageFile="~/Ogretmen.master" AutoEventWireup="true" CodeFile="OgrenciGuncelle.aspx.cs" Inherits="OgrenciGuncelle" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
    <form id="Form1" runat="server">

        <div class="form-group">
            <div>
                <asp:Label for="txtOgrID" runat="server">Öğrenci ID</asp:Label>
                <asp:TextBox ID="txtOgrID" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            <br />
            <div>
                <asp:Label for="txtOgrAd" runat="server">Öğrenci Adı</asp:Label>
                <asp:TextBox ID="txtOgrAd" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            <br />
            <div>
                <asp:Label for="txtOgrSoyad" runat="server">Öğrenci Soyadı</asp:Label>
                <asp:TextBox ID="txtOgrSoyad" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            <br />
            <div>
                <asp:Label for="txtOgrTelefon" runat="server">Öğrenci Telefon</asp:Label>
                <asp:TextBox ID="txtOgrTelefon" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            <br />
            <div>
                <asp:Label for="txtOgrMail" runat="server">Öğrenci Mail</asp:Label>
                <asp:TextBox ID="txtOgrMail" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            <br />
            <div>
                <asp:Label for="txtOgrSifre" runat="server">Öğrenci Şifre</asp:Label>
                <asp:TextBox ID="txtOgrSifre" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            <br />
            <div>
                <asp:Label for="txtOgrFoto" runat="server">Öğrenci Fotoğraf Linki</asp:Label>
                <asp:TextBox ID="txtOgrFoto" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
        </div>
        <asp:Button runat="server" Text="Güncelle" ID="guncelle" class="btn btn-primary" OnClick="guncelle_Click" />

    </form>

</asp:Content>

```

```c#
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class OgrenciGuncelle : System.Web.UI.Page
{

    int id;

    DataSetTableAdapters.TBLOGRENCITableAdapter dt = new DataSetTableAdapters.TBLOGRENCITableAdapter();


    protected void Page_Load(object sender, EventArgs e)
    {
        if (Page.IsPostBack == false)
        {
            try
            {
                id = Convert.ToInt32(Request.QueryString["OGRID"]);
                txtOgrID.Text = id.ToString();
                txtOgrID.Enabled = false;

                txtOgrAd.Text = dt.OgrenciSec(id)[0].OGRAD;
                txtOgrSoyad.Text = dt.OgrenciSec(id)[0].OGRSOYAD;
                txtOgrMail.Text = dt.OgrenciSec(id)[0].OGRMAIL;
                txtOgrTelefon.Text = dt.OgrenciSec(id)[0].OGRTELEFON;
                txtOgrSifre.Text = dt.OgrenciSec(id)[0].OGRSIFRE;
                txtOgrFoto.Text = dt.OgrenciSec(id)[0].OGRFOTOGRAF;

            }
            catch (Exception)
            {
                txtOgrFoto.Text = "Link Girin";
            }

        }

    }

    protected void guncelle_Click(object sender, EventArgs e)
    {
        dt.OgrenciGuncelle(txtOgrAd.Text, txtOgrSoyad.Text, txtOgrTelefon.Text, txtOgrMail.Text, txtOgrSifre.Text, txtOgrFoto.Text, Convert.ToInt32(txtOgrID.Text));
        Response.Redirect("Default.aspx");
    }
}
```

### [Öğretmen] Öğrenci Ekle
![image](https://user-images.githubusercontent.com/95151751/230775043-35c7ed8a-07ef-416a-bd56-06f6f30a6461.png)

```c#
<%@ Page Title="" Language="C#" MasterPageFile="~/Ogretmen.master" AutoEventWireup="true" CodeFile="OgrenciEkle.aspx.cs" Inherits="OgrenciEkle" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
    <form id="Form1" runat="server">

        <div class="form-group">
            <div>
                <asp:Label for="txtOgrAd" runat="server">Öğrenci Adı</asp:Label>
                <asp:TextBox id="txtOgrAd" runat="server" CssClass="form-control" ></asp:TextBox>
            </div>
            <br />
            <div>
                <asp:Label for="txtOgrSoyad" runat="server">Öğrenci Soyadı</asp:Label>
                <asp:TextBox id="txtOgrSoyad" runat="server" CssClass="form-control" ></asp:TextBox>
            </div>
            <br />
            <div>
                <asp:Label for="txtOgrTelefon" runat="server">Öğrenci Telefon</asp:Label>
                <asp:TextBox id="txtOgrTelefon" runat="server" CssClass="form-control" ></asp:TextBox>
            </div>
            <br />
            <div>
                <asp:Label for="txtOgrMail" runat="server">Öğrenci Mail</asp:Label>
                <asp:TextBox id="txtOgrMail" runat="server" CssClass="form-control" ></asp:TextBox>
            </div>
            <br />
            <div>
                <asp:Label for="txtOgrSifre" runat="server">Öğrenci Şifre</asp:Label>
                <asp:TextBox id="txtOgrSifre" runat="server" CssClass="form-control" ></asp:TextBox>
            </div>
            <br />
            <div>
                <asp:Label for="txtOgrFoto" runat="server">Öğrenci Fotoğraf Linki</asp:Label>
                <asp:TextBox id="txtOgrFoto" runat="server" CssClass="form-control" ></asp:TextBox>
            </div>
        </div>
        <asp:Button runat="server" Text="Kaydet" id="kaydet" class="btn btn-info" OnClick="kaydet_Click" />

    </form>
</asp:Content>


```

```c#
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class OgrenciEkle : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void kaydet_Click(object sender, EventArgs e)
    {
        DataSetTableAdapters.TBLOGRENCITableAdapter dt = new DataSetTableAdapters.TBLOGRENCITableAdapter();
        dt.OgrenciEkle(txtOgrAd.Text, txtOgrSoyad.Text, txtOgrTelefon.Text, txtOgrMail.Text, txtOgrSifre.Text, txtOgrFoto.Text);
        Response.Redirect("Default.aspx");
    }
}
```

### [Öğretmen] Dersler
![image](https://user-images.githubusercontent.com/95151751/230775078-0b69f6bc-8caf-4fb9-96d2-72843ed4731d.png)

```c#
<%@ Page Title="" Language="C#" MasterPageFile="~/Ogretmen.master" AutoEventWireup="true" CodeFile="DersListesi.aspx.cs" Inherits="DersListesi" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">

        <table class="table table-bordered table-hover">
        <tr>
            <th scope="col">DERS ID</th>
            <th scope="col">DERS ADI</th>
            <th scope="col">İŞLEMLER</th>
        </tr>
        <tbody>

            <asp:Repeater ID="Repeater1" runat="server">

                <ItemTemplate>

                    <tr>
                        <td><%#Eval("DERSID") %></td>
                        <td><%#Eval("DERSAD") %></td>
                        <td>
                            <asp:HyperLink NavigateUrl='<%# "DersSil.aspx?DERSID="+Eval("DERSID") %>' ID="HyperLink1" runat="server" class="btn btn-danger">SİL</asp:HyperLink>
                            <asp:HyperLink NavigateUrl='<%# "DersGuncelle.aspx?DERSID="+Eval("DERSID") %>' ID="HyperLink2" runat="server" class="btn btn-success">GÜNCELLE</asp:HyperLink>
                        </td>
                    </tr>

                </ItemTemplate>

            </asp:Repeater>

        </tbody>
    </table>

    <asp:HyperLink ID="HyperLink3" NavigateUrl="DersEkle.aspx" runat="server" CssClass="btn btn-info">Ders Ekle</asp:HyperLink>

</asp:Content>

```

```c#
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class DersListesi : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        DataSetTableAdapters.TBLDERSLERTableAdapter dt = new DataSetTableAdapters.TBLDERSLERTableAdapter();
        Repeater1.DataSource = dt.DersListesi();
        Repeater1.DataBind();
    }
}
```

### [Öğretmen] Ders Güncelle
![image](https://user-images.githubusercontent.com/95151751/230776329-e27ee0f7-d05c-4687-bf56-eaec93934999.png)

```c#
<%@ Page Title="" Language="C#" MasterPageFile="~/Ogretmen.master" AutoEventWireup="true" CodeFile="DersGuncelle.aspx.cs" Inherits="DersGuncelle" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">

    <form id="Form1" runat="server">

        <div class="form-group">
            <div>
                <asp:Label for="txtDersID" runat="server">Ders ID</asp:Label>
                <asp:TextBox ID="txtDersID" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
            </div>
            <br />
            <div>
                <asp:Label for="txtDersAdi" runat="server">Ders Adı</asp:Label>
                <asp:TextBox ID="txtDersAdi" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
        </div>
        <asp:Button runat="server" Text="Ders Güncelle" ID="guncelle" class="btn btn-primary" OnClick="guncelle_Click" />

    </form>

</asp:Content>

```

```c#
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class DersGuncelle : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            int id = Convert.ToInt32(Request.QueryString["DERSID"]);
            DataSetTableAdapters.TBLDERSLERTableAdapter dt = new DataSetTableAdapters.TBLDERSLERTableAdapter();
            txtDersID.Text = id.ToString();
            txtDersAdi.Text = dt.DersGetir(id)[0].DERSAD;
        }
    }

    protected void guncelle_Click(object sender, EventArgs e)
    {
        DataSetTableAdapters.TBLDERSLERTableAdapter dt = new DataSetTableAdapters.TBLDERSLERTableAdapter();
        dt.DersGuncelle(txtDersAdi.Text, Convert.ToInt32(txtDersID.Text));
        Response.Redirect("DersListesi.aspx");
    }
}
```

### [Öğretmen] Ders Ekle
![image](https://user-images.githubusercontent.com/95151751/230776373-02b2fd4e-f0df-49d2-90ce-6bba29e06a77.png)

```c#
<%@ Page Title="" Language="C#" MasterPageFile="~/Ogretmen.master" AutoEventWireup="true" CodeFile="DersEkle.aspx.cs" Inherits="DersEkle" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">

    <form id="Form1" runat="server">

        <div class="form-group">
            <div>
                <asp:Label for="txtDers" runat="server">Ders Adı</asp:Label>
                <asp:TextBox id="txtDers" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
        </div>
        <asp:Button runat="server" Text="Oluştur" id="olustur" class="btn btn-info" OnClick="olustur_Click" />

    </form>


</asp:Content>

```

```c#
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class DersEkle : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void olustur_Click(object sender, EventArgs e)
    {
        DataSetTableAdapters.TBLDERSLERTableAdapter dt = new DataSetTableAdapters.TBLDERSLERTableAdapter();
        dt.DersEkle(txtDers.Text);
        Response.Redirect("DersListesi.aspx");
    }
}
```

### [Öğretmen] Gelen Mesajlar
![image](https://user-images.githubusercontent.com/95151751/230775114-af06e388-fe88-42eb-b927-8b1e99d0bf47.png)

```c#
<%@ Page Title="" Language="C#" MasterPageFile="~/Ogretmen.master" AutoEventWireup="true" CodeFile="GelenMesajlar.aspx.cs" Inherits="GelenMesajlar" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">

    <table class="table table-bordered table-hover">
        <tr>
            <th scope="col">ID</th>
            <th scope="col">GÖNDEREN</th>
            <th scope="col">BAŞLIK</th>
            <th scope="col">İÇERİK</th>
        </tr>
        <tbody>

            <asp:Repeater ID="Repeater1" runat="server">

                <ItemTemplate>

                    <tr>
                        <td><%#Eval("MESAJID") %></td>
                        <td><%#Eval("GONDEREN") %></td>
                        <td><%#Eval("BASLIK") %></td>
                        <td><%#Eval("ICERIK") %></td>
<%--                        <td>
                            <asp:HyperLink NavigateUrl='<%# "DuyuruSil.aspx?DUYURUID="+Eval("DUYURUID") %>' ID="HyperLink1" runat="server" class="btn btn-danger">SİL</asp:HyperLink>
                            <asp:HyperLink NavigateUrl='<%# "DuyuruGuncelle.aspx?DUYURUID="+Eval("DUYURUID") %>' ID="HyperLink2" runat="server" class="btn btn-success">GÜNCELLE</asp:HyperLink>
                        </td>--%>
                    </tr>

                </ItemTemplate>

            </asp:Repeater>

        </tbody>
    </table>


</asp:Content>

```

```c#
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class GelenMesajlar : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            DataSetTableAdapters.TBLMESAJLARTableAdapter dt = new DataSetTableAdapters.TBLMESAJLARTableAdapter();
            Repeater1.DataSource = dt.OgretmenGelenMesaj(Session["ogrtnumara"].ToString());
            Repeater1.DataBind();
        }
    }
}
```

### [Öğretmen] Giden Mesajlar
![image](https://user-images.githubusercontent.com/95151751/230775143-0d3cd4af-aaf3-41af-a21f-3b042bb2ae38.png)

```c#
<%@ Page Title="" Language="C#" MasterPageFile="~/Ogretmen.master" AutoEventWireup="true" CodeFile="GidenMesajlar.aspx.cs" Inherits="GidenMesajlar" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
        <table class="table table-bordered table-hover">
        <tr>
            <th scope="col">ID</th>
            <th scope="col">ALICI</th>
            <th scope="col">BAŞLIK</th>
            <th scope="col">İÇERİK</th>
            <th scope="col">TARİH</th>
        </tr>
        <tbody>

            <asp:Repeater ID="Repeater1" runat="server">

                <ItemTemplate>

                    <tr>
                        <td><%#Eval("MESAJID") %></td>
                        <td><%#Eval("ALICI") %></td>
                        <td><%#Eval("BASLIK") %></td>
                        <td><%#Eval("ICERIK") %></td>
                        <td><%#Eval("TARIH") %></td>
<%--                        <td>
                            <asp:HyperLink NavigateUrl='<%# "DuyuruSil.aspx?DUYURUID="+Eval("DUYURUID") %>' ID="HyperLink1" runat="server" class="btn btn-danger">SİL</asp:HyperLink>
                            <asp:HyperLink NavigateUrl='<%# "DuyuruGuncelle.aspx?DUYURUID="+Eval("DUYURUID") %>' ID="HyperLink2" runat="server" class="btn btn-success">GÜNCELLE</asp:HyperLink>
                        </td>--%>
                    </tr>

                </ItemTemplate>

            </asp:Repeater>

        </tbody>
    </table>

</asp:Content>

```

```c#
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class GidenMesajlar : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            DataSetTableAdapters.TBLMESAJLARTableAdapter dt = new DataSetTableAdapters.TBLMESAJLARTableAdapter();
            Repeater1.DataSource = dt.OgretmenGidenMesajlar(Session["ogrtnumara"].ToString());
            Repeater1.DataBind();
        }
    }
}
```

### [Öğretmen] Mesaj Oluştur
![image](https://user-images.githubusercontent.com/95151751/230775170-1c5b777f-1697-482f-acde-0c600df6fde0.png)

```
<%@ Page Title="" Language="C#" MasterPageFile="~/Ogretmen.master" AutoEventWireup="true" CodeFile="MesajOlustur.aspx.cs" Inherits="MesajOlustur" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">

    <form id="Form1" runat="server">

        <div class="form-group">
            <div>
                <asp:Label for="txtGonderen" runat="server">Gönderen</asp:Label>
                <asp:TextBox id="txtGonderen" runat="server" CssClass="form-control" enabled="false" ></asp:TextBox>
            </div>
            <br />
            <div>
                <asp:Label for="txtAlici" runat="server">Alıcı</asp:Label>
                <asp:TextBox id="txtAlici" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            <br />
            <div>
                <asp:Label for="txtMesajBaslik" runat="server">Mesaj Başlık</asp:Label>
                <asp:TextBox id="txtMesajBaslik" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            <br />
            <div>
                <asp:Label for="txtIcerik" runat="server">Mesaj İçerik</asp:Label>                
                <textarea id="txtIcerik" cols="20" rows="7" class="form-control" runat="server" ></textarea>
            </div>
        </div>
        <asp:Button runat="server" Text="Mesaj Gönder" id="btnGonder" class="btn btn-info" OnClick="btnGonder_Click" />

    </form>


</asp:Content>


```

```c#
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MesajOlustur : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        txtGonderen.Text = "0001";
    }

    protected void btnGonder_Click(object sender, EventArgs e)
    {
        if (IsPostBack)
        {
            DataSetTableAdapters.TBLMESAJLARTableAdapter dt = new DataSetTableAdapters.TBLMESAJLARTableAdapter();
            dt.MesajGonder(txtGonderen.Text, txtAlici.Text, txtMesajBaslik.Text,txtIcerik.Value);
            Response.Redirect("GidenMesajlar.aspx");
        }
    }
}
```

### [Öğretmen] Duyuru Listesi
![image](https://user-images.githubusercontent.com/95151751/230775191-b462f27b-6cce-4a63-8e7c-fed3674fef11.png)

```c#
<%@ Page Title="" Language="C#" MasterPageFile="~/Ogretmen.master" AutoEventWireup="true" CodeFile="DuyuruListesi.aspx.cs" Inherits="DuyuruListesi" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
    <table class="table table-bordered table-hover">
        <tr>
            <th scope="col">ID</th>
            <th scope="col">BAŞLIK</th>
            <th scope="col">İÇERİK</th>
            <th scope="col">ÖĞRETMEN</th>
            <th scope="col">İŞLEMLER</th>
        </tr>
        <tbody>

            <asp:Repeater ID="Repeater1" runat="server">

                <ItemTemplate>

                    <tr>
                        <td><%#Eval("DUYURUID") %></td>
                        <td><%#Eval("DUYURUBASLIK") %></td>
                        <td><%#Eval("DUYURUICERIK") %></td>
                        <td><%#Eval("DUYURUOGRT") %></td>
                        <td>
                            <asp:HyperLink NavigateUrl='<%# "DuyuruSil.aspx?DUYURUID="+Eval("DUYURUID") %>' ID="HyperLink1" runat="server" class="btn btn-danger">SİL</asp:HyperLink>
                            <asp:HyperLink NavigateUrl='<%# "DuyuruGuncelle.aspx?DUYURUID="+Eval("DUYURUID") %>' ID="HyperLink2" runat="server" class="btn btn-success">GÜNCELLE</asp:HyperLink>
                        </td>
                    </tr>

                </ItemTemplate>

            </asp:Repeater>

        </tbody>
    </table>

</asp:Content>


<%--
NavigateUrl='<%# "~/OgrenciSil.aspx?OGRID="+Eval("OGRID") %>'
NavigateUrl='<%# "OgrenciGuncelle.aspx?OGRID="+Eval("OGRID") %>'
--%>
```

```c#
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class DuyuruListesi : System.Web.UI.Page
{


    protected void Page_Load(object sender, EventArgs e)
    {
        DataSetTableAdapters.TBLDUYURULARTableAdapter dt = new DataSetTableAdapters.TBLDUYURULARTableAdapter();
        Repeater1.DataSource = dt.DuyuruListesi();
        Repeater1.DataBind();
    }
}
```

### [Öğretmen] Duyuru Güncelle
![image](https://user-images.githubusercontent.com/95151751/230776912-f26c8df5-415c-4d9e-83a9-b5b58219fd25.png)

```c#
<%@ Page Title="" Language="C#" MasterPageFile="~/Ogretmen.master" AutoEventWireup="true" CodeFile="DuyuruGuncelle.aspx.cs" Inherits="DuyuruGuncelle" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">

        <form id="Form1" runat="server">

        <div class="form-group">
            <div>
                <asp:Label for="txtDuyuruID" runat="server">Duyuru ID</asp:Label>
                <asp:TextBox ID="txtDuyuruID" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            <br />
            <div>
                <asp:Label for="txtDuyuruBaslik" runat="server">Duyuru Başlık</asp:Label>
                <asp:TextBox id="txtDuyuruBaslik" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            <br />
            <div>
                <asp:Label for="TextArea1" runat="server">Duyuru İçerik</asp:Label>
                <textarea id="TextArea1" cols="20" rows="6" class="form-control" runat="server"></textarea>
            </div>
        </div>
        <asp:Button runat="server" Text="Oluştur" id="olustur" class="btn btn-primary" OnClick="olustur_Click" />

    </form>


</asp:Content>


```

```c#
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class DuyuruGuncelle : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            int id = Convert.ToInt32(Request.QueryString["DUYURUID"]);
            DataSetTableAdapters.TBLDUYURULARTableAdapter dt = new DataSetTableAdapters.TBLDUYURULARTableAdapter();
            txtDuyuruID.Text = id.ToString();
            txtDuyuruID.Enabled = false;
            txtDuyuruBaslik.Text = dt.DuyuruSec(id)[0].DUYURUBASLIK;
            TextArea1.Value = dt.DuyuruSec(id)[0].DUYURUICERIK;

        }
    }

    protected void olustur_Click(object sender, EventArgs e)
    {
        DataSetTableAdapters.TBLDUYURULARTableAdapter dt = new DataSetTableAdapters.TBLDUYURULARTableAdapter();
        dt.DuyuruGuncelle(txtDuyuruBaslik.Text, TextArea1.Value, Convert.ToInt32(txtDuyuruID.Text));
        Response.Redirect("DuyuruListesi.aspx");
    }
}
```

### [Öğretmen] Duyuru Ekle
![image](https://user-images.githubusercontent.com/95151751/230775222-5fec40e2-a556-4c7f-b334-215f5db2f4f2.png)

```c#
<%@ Page Title="" Language="C#" MasterPageFile="~/Ogretmen.master" AutoEventWireup="true" CodeFile="DuyuruEkle.aspx.cs" Inherits="DuyuruEkle" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">

    <form id="Form1" runat="server">

        <div class="form-group">
            <div>
                <asp:Label for="DropDownList1" runat="server">Duyuru Öğretmen</asp:Label>
                <asp:DropDownList id="DropDownList1" runat="server" cssClass="form-control"></asp:DropDownList>
            </div>
            <br />
            <div>
                <asp:Label for="txtDuyuruBaslik" runat="server">Duyuru Başlık</asp:Label>
                <asp:TextBox id="txtDuyuruBaslik" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            <br />
            <div>
                <asp:Label for="TextArea1" runat="server">Duyuru İçerik</asp:Label>
                <textarea id="TextArea1" cols="20" rows="6" class="form-control" runat="server"></textarea>
            </div>
        </div>
        <asp:Button runat="server" Text="Oluştur" id="olustur" class="btn btn-info" OnClick="olustur_Click" />

    </form>

</asp:Content>


```

```c#
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class DuyuruEkle : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            DataSetTableAdapters.TBLOGRETMENTableAdapter dt = new DataSetTableAdapters.TBLOGRETMENTableAdapter();
            DropDownList1.DataSource = dt.OgretmenListesi();
            DropDownList1.DataTextField = "OGRTADSOYAD";
            DropDownList1.DataValueField = "OGRTID";
            DropDownList1.DataBind();

        }
    }

    protected void olustur_Click(object sender, EventArgs e)
    {
        DataSetTableAdapters.TBLDUYURULARTableAdapter dt = new DataSetTableAdapters.TBLDUYURULARTableAdapter();
        dt.DuyuruEkle(txtDuyuruBaslik.Text, TextArea1.Value.ToString(), Convert.ToInt32(DropDownList1.SelectedValue));
        Response.Redirect("DuyuruListesi.aspx");
    }
}
```

### [Öğretmen] Notlar
![image](https://user-images.githubusercontent.com/95151751/230775245-187a57fb-1886-4f31-a123-63766c99f9cc.png)

```c#
<%@ Page Title="" Language="C#" MasterPageFile="~/Ogretmen.master" AutoEventWireup="true" CodeFile="NotListesi.aspx.cs" Inherits="NotListesi" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">

    <table class="table table-bordered table-hover">
        <tr>
            <th scope="col">ÖĞRENCİ ID</th>
            <th scope="col">AD SOYAD</th>
            <th scope="col">DERS ADI</th>
            <th scope="col">SINAV 1</th>
            <th scope="col">SINAV 2</th>
            <th scope="col">SINAV 3</th>
            <th scope="col">ORTALAMA</th>
            <th scope="col">DURUM</th>
            <th scope="col">GÜNCELLE</th>
        </tr>
        <tbody>

            <asp:Repeater ID="Repeater1" runat="server">

                <ItemTemplate>

                    <tr>
                        <td><%#Eval("OGRENCIID") %></td>
                        <td><%#Eval("OGRENCIADSOYAD") %></td>
                        <td><%#Eval("DERSAD") %></td>
                        <td><%#Eval("SINAV1") %></td>
                        <td><%#Eval("SINAV2") %></td>
                        <td><%#Eval("SINAV3") %></td>
                        <td><%#Eval("ORTALAMA") %></td>
                        <td><%#Eval("DURUM") %></td>
                        <td>
                            <asp:HyperLink ID="HyperLink2" NavigateUrl='<%# "NotGuncelle.aspx?NOTID="+Eval("NOTID") %>' runat="server" class="btn btn-success">GÜNCELLE</asp:HyperLink>
                        </td>
                    </tr>

                </ItemTemplate>

            </asp:Repeater>

        </tbody>
    </table>


</asp:Content>


```

```c#
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class NotListesi : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        DataSetTableAdapters.OgrNotlarTableAdapter dt=new DataSetTableAdapters.OgrNotlarTableAdapter();
        Repeater1.DataSource = dt.NotlariGetir();
        Repeater1.DataBind();
    }
}
```

### [Öğretmen] Not Güncelle
![image](https://user-images.githubusercontent.com/95151751/230776986-67704060-c7de-4770-bf64-ab0bbee8a059.png)

```c#
<%@ Page Title="" Language="C#" MasterPageFile="~/Ogretmen.master" AutoEventWireup="true" CodeFile="NotGuncelle.aspx.cs" Inherits="NotGuncelle" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">

    <form id="Form1" runat="server">

        <div class="form-group">
            <div>
                <asp:Label for="txtDersAdi" runat="server">Ders Adı</asp:Label>
                <asp:TextBox ID="txtDersAdi" Enabled="false" runat="server"  CssClass="form-control"></asp:TextBox>
            </div>
            <br />
            <div>
                <asp:Label for="txtOgrID" runat="server">Öğrenci ID</asp:Label>
                <asp:TextBox ID="txtOgrID" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
            </div>
            <br />
            <div>
                <asp:Label for="txtOgrAdSoyad" runat="server">Öğrenci Adı Soyadı</asp:Label>
                <asp:TextBox ID="txtOgrAdSoyad" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            <br />
            <div>
                <asp:Label for="txtSinav1" runat="server">Sınav 1</asp:Label>
                <asp:TextBox ID="txtSinav1" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            <br />
            <div>
                <asp:Label for="txtSinav2" runat="server">Sınav 2</asp:Label>
                <asp:TextBox ID="txtSinav2" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            <br />
            <div>
                <asp:Label for="txtSinav3" runat="server">Sınav 3</asp:Label>
                <asp:TextBox ID="txtSinav3" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            <br />
            <div>
                <asp:Label for="txtOrtalama" runat="server">Ortalama</asp:Label>
                <asp:TextBox ID="txtOrtalama" Enabled="false" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            <br />
            <div>
                <asp:Label for="txtDurum" runat="server">Durum</asp:Label>
                <asp:TextBox ID="txtDurum" Enabled="false" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
        </div>
        <asp:Button runat="server" Text="Hesapla" ID="hesapla" class="btn btn-toolbar" OnClick="hesapla_Click" />
        <asp:Button runat="server" Text="Güncelle" ID="guncelle" class="btn btn-primary" OnClick="guncelle_Click" />

    </form>


</asp:Content>


```

```c#
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class NotGuncelle : System.Web.UI.Page
{
    int nid;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            nid = Convert.ToInt32(Request.QueryString["NOTID"].ToString());

            DataSetTableAdapters.OgrNotlarTableAdapter dt = new DataSetTableAdapters.OgrNotlarTableAdapter();
            txtOgrID.Text = dt.NotGetir2(nid)[0].OGRENCIID.ToString();
            txtOgrAdSoyad.Text = dt.NotGetir2(nid)[0].OGRENCIADSOYAD.ToString();
            txtDersAdi.Text = dt.NotGetir2(nid)[0].DERSAD.ToString();
            txtSinav1.Text = dt.NotGetir2(nid)[0].SINAV1.ToString();
            txtSinav2.Text = dt.NotGetir2(nid)[0].SINAV2.ToString();
            txtSinav3.Text = dt.NotGetir2(nid)[0].SINAV3.ToString();
            txtOrtalama.Text = dt.NotGetir2(nid)[0].ORTALAMA.ToString();
            txtDurum.Text = dt.NotGetir2(nid)[0].DURUM.ToString();
        }

    }

    protected void hesapla_Click(object sender, EventArgs e)
    {
        double sinav1, sinav2, sinav3, ortalama;
        sinav1 = Convert.ToInt32(txtSinav1.Text);
        sinav2 = Convert.ToInt32(txtSinav2.Text);
        sinav3 = Convert.ToInt32(txtSinav3.Text);
        ortalama = (sinav1 + sinav2 + sinav3) / 3;
        txtOrtalama.Text=ortalama.ToString("0.00");
        if (ortalama >= 50)
        {
            txtDurum.Text = "True";
        }
        else
        {
            txtDurum.Text = "False";
        }
    }

    protected void guncelle_Click(object sender, EventArgs e)
    {
        DataSetTableAdapters.OgrNotlarTableAdapter dt = new DataSetTableAdapters.OgrNotlarTableAdapter();
        dt.NotGuncelle(byte.Parse(txtSinav1.Text), byte.Parse(txtSinav2.Text), byte.Parse(txtSinav3.Text), decimal.Parse(txtOrtalama.Text), bool.Parse(txtDurum.Text), Convert.ToInt32(Request.QueryString["NOTID"].ToString()));
        Response.Redirect("NotListesi.aspx");
    }
}
```

### [Öğretmen] İstatistikler
![image](https://user-images.githubusercontent.com/95151751/230775266-b85bc4c5-10ea-42dc-bd31-20c1294cb952.png)

```c#
<%@ Page Title="" Language="C#" MasterPageFile="~/Ogretmen.master" AutoEventWireup="true" CodeFile="Istatistikler.aspx.cs" Inherits="Istatistikler" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">

    <form id="Form1" runat="server">

        <div class="form-group">
            <div>
                <asp:TextBox ID="Textbox1" runat="server" CssClass="form-control" Enabled="false">Toplam Öğrenci Sayısı: 136</asp:TextBox>
            </div>
            <br />
            <div>
                <asp:TextBox ID="Textbox2" runat="server" CssClass="form-control" Enabled="false">Toplam Öğretmen Sayısı: 14</asp:TextBox>
            </div>
            <br />
            <div>
                <asp:TextBox ID="Textbox3" runat="server" CssClass="form-control" Enabled="false">Toplam Ders Sayısı: 17</asp:TextBox>
            </div>
            <br />
            <div>
                <asp:TextBox ID="Textbox4" runat="server" CssClass="form-control" Enabled="false">Toplam Ders Sayısı: 17</asp:TextBox>
            </div>
            <br />
            <div>
                <asp:TextBox ID="Textbox5" runat="server" CssClass="form-control" Enabled="false">En Başarılı Ders: Matematik</asp:TextBox>
            </div>
            <br />
            <div>
                <asp:TextBox ID="Textbox6" runat="server" CssClass="form-control" Enabled="false">Toplam Atılan Mesaj: 2547</asp:TextBox>
            </div>
            <br />
            <div>
                <asp:TextBox ID="Textbox7" runat="server" CssClass="form-control" Enabled="false">Sistemdeki Duyuru Sayısı: 745</asp:TextBox>
            </div>
            <br />
            <div>
                <asp:TextBox ID="Textbox8" runat="server" CssClass="form-control" Enabled="false">Matematik Not Ortalaması: 65,78</asp:TextBox>
            </div>
            <br />
            <div>
                <asp:TextBox ID="Textbox9" runat="server" CssClass="form-control" Enabled="false">Algoritma Not Ortalaması: 77,12</asp:TextBox>
            </div>
            <br />
            <div>
                <asp:TextBox ID="Textbox10" runat="server" CssClass="form-control" Enabled="false">TÜrkçe Not Ortalaması: 82,17</asp:TextBox>
            </div>
            <br />
            <div>
                <asp:TextBox ID="Textbox11" runat="server" CssClass="form-control" Enabled="false">İstatistik Örnek 1</asp:TextBox>
            </div>
            <br />
            <div>
                <asp:TextBox ID="Textbox12" runat="server" CssClass="form-control" Enabled="false">İstatistik Örnek 2</asp:TextBox>
            </div>
            <br />
        </div>
    </form>


</asp:Content>

```

```c#
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Istatistikler : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        DataSetTableAdapters.DataTable1TableAdapter dt = new DataSetTableAdapters.DataTable1TableAdapter();
        Textbox1.Text = "Toplam Öğrenci Sayısı: " + dt.Istatistik1().ToString();
        Textbox2.Text = "Toplam Öğretmen Sayısı: " + dt.Istatistik2().ToString();
        Textbox3.Text = "Toplam Ders Sayısı: " + dt.Istatistik3().ToString();
        Textbox4.Text = "Matematik Dersinin 1. Sınavındaki En Başarılı Öğrenci: " + dt.Istatistik4().ToString();
        Textbox5.Text = "Fizik Dersinin 1. Sınavındaki En Başarılı Öğrenci: " + dt.Istatistik5().ToString();
        Textbox6.Text = "Dil ve Anlatım Dersinin 1. Sınavındaki En Başarılı Öğrenci: " + dt.Istatistik6().ToString();
        Textbox7.Text = "Edebiyat Dersinin 1. Sınavındaki En Başarılı Öğrenci: " + dt.Istatistik7().ToString();
        Textbox8.Text = "Matematik Dersinin 1. Sınav Ortalaması: " + dt.Istatistik8().ToString();
        Textbox9.Text = "Fizik Dersinin 1. Sınav Ortalaması: " + dt.Istatistik9().ToString();
        Textbox10.Text = "Edebiyat Dersinin 1. Sınav Ortalaması: " + dt.Istatistik10().ToString();
        Textbox11.Text = "Matematik Dersinde Geçen Öğrenci Sayısı: " + dt.Istatistik11().ToString();
        Textbox12.Text = "Matematik Dersinde Kalan Öğrenci Sayısı: " + dt.Istatistik12().ToString();
    }
}
```

### [Öğretmen] Grafikler
![image](https://user-images.githubusercontent.com/95151751/230775289-a6ef279c-19f5-4834-b115-2ce5f23630c8.png)

```c#
<%@ Page Title="" Language="C#" MasterPageFile="~/Ogretmen.master" AutoEventWireup="true" CodeFile="Grafikler.aspx.cs" Inherits="Grafikler" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">



    <form id="form1" runat="server">
        <table class="table table-bordered table-hover">
            <tr>
                <td class="text-center">
                    <asp:Chart ID="Chart1" runat="server" Height="400px" Width="750px" Palette="Bright">
                        <Series>
                            <asp:Series Name="Matematik" Legend="Legend1">
                            </asp:Series>
                        </Series>
                        <ChartAreas>
                            <asp:ChartArea Name="ChartArea1">
                            </asp:ChartArea>
                        </ChartAreas>
                        <Legends>
                            <asp:Legend Name="Legend1">
                            </asp:Legend>
                        </Legends>
                    </asp:Chart>
                </td>
                <td class="text-center">
                    <asp:Chart ID="Chart2" runat="server" Height="400px" Width="750px">
                        <Series>
                            <asp:Series Name="DersAd" ChartType="Area">
                            </asp:Series>
                        </Series>
                        <ChartAreas>
                            <asp:ChartArea Name="ChartArea1">
                            </asp:ChartArea>
                        </ChartAreas>
                    </asp:Chart>
                </td>
            </tr>
            <tr>
                <td class="text-center">
                    <asp:Chart ID="Chart3" runat="server" Height="400px" Width="750px">
                        <Series>
                            <asp:Series Name="Cinsiyet" ChartType="Pie">
                            </asp:Series>
                        </Series>
                        <ChartAreas>
                            <asp:ChartArea Name="ChartArea1">
                            </asp:ChartArea>
                        </ChartAreas>
                    </asp:Chart>
                </td>
                <td class="text-center">
                    <asp:Chart ID="Chart4" runat="server" Height="400px" Width="750px">
                        <Series>
                            <asp:Series Name="Dersler" ChartType="Doughnut">
                            </asp:Series>
                        </Series>
                        <ChartAreas>
                            <asp:ChartArea Name="ChartArea1">
                            </asp:ChartArea>
                        </ChartAreas>
                    </asp:Chart>
                    <asp:SqlDataSource ID="SqlDataSource1" runat="server"></asp:SqlDataSource>
                </td>
            </tr>
        </table>
    </form>

</asp:Content>

```

```c#
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class Grafikler : System.Web.UI.Page
{

    SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-HKL3D7O\SQLEXPRESS;Initial Catalog=Dbo_UdemyWeb01;Integrated Security=True");

    protected void Page_Load(object sender, EventArgs e)
    {

        //Chart 4 --Dersler--
        baglanti.Open();
        SqlCommand komut = new SqlCommand("execute Graf1", baglanti);
        SqlDataReader dr = komut.ExecuteReader();
        while (dr.Read())
        {
            Chart4.Series["Dersler"].Points.AddXY(Convert.ToString(dr[0]), int.Parse(dr[1].ToString()));
        }
        baglanti.Close();


        //CHart 3 --Cinsiyetler--
        baglanti.Open();
        SqlCommand komut2 = new SqlCommand("execute Graf2", baglanti);
        SqlDataReader dr2 = komut2.ExecuteReader();
        while (dr2.Read())
        {
            Chart3.Series["Cinsiyet"].Points.AddXY(Convert.ToString(dr2[0]), int.Parse(dr2[1].ToString()));
        }
        baglanti.Close();


        //Chart 2 --Öğretmenler--
        baglanti.Open();
        SqlCommand komut3 = new SqlCommand("execute Graf3", baglanti);
        SqlDataReader dr3 = komut3.ExecuteReader();
        while (dr3.Read())
        {
            Chart2.Series["DersAd"].Points.AddXY(Convert.ToString(dr3[0]), int.Parse(dr3[1].ToString()));
        }
        baglanti.Close();


        //Chart 1 --Matematik 1. Sınav Sonuçları--
        baglanti.Open();
        SqlCommand komut4 = new SqlCommand("execute Graf4", baglanti);
        SqlDataReader dr4 = komut4.ExecuteReader();
        while (dr4.Read())
        {
            Chart1.Series["Matematik"].Points.AddXY(Convert.ToString(dr4[0]), int.Parse(dr4[1].ToString()));
        }
        baglanti.Close();


    }
}
```

### [Öğrenci] Profilim
![image](https://user-images.githubusercontent.com/95151751/230775379-ea345c33-1806-4a70-be3e-24dc2db8703b.png)

```c#
<%@ Page Title="" Language="C#" MasterPageFile="~/Ogrenci.master" AutoEventWireup="true" CodeFile="OgrenciDefault.aspx.cs" Inherits="OgrenciDefault" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">

    <form id="Form1" runat="server">

        <div class="form-group">
            <div>
                <asp:TextBox ID="Textbox1" runat="server" CssClass="form-control" Enabled="false">Toplam Öğrenci Sayısı: 136</asp:TextBox>
            </div>
            <br />
            <div>
                <asp:TextBox ID="Textbox2" runat="server" CssClass="form-control" Enabled="false">Toplam Öğretmen Sayısı: 14</asp:TextBox>
            </div>
            <br />
            <div>
                <asp:TextBox ID="Textbox3" runat="server" CssClass="form-control" Enabled="false">Toplam Ders Sayısı: 17</asp:TextBox>
            </div>
            <br />
            <div>
                <asp:TextBox ID="Textbox4" runat="server" CssClass="form-control" Enabled="false">Toplam Ders Sayısı: 17</asp:TextBox>
            </div>
            <br />
            <div>
                <asp:TextBox ID="Textbox5" runat="server" CssClass="form-control" Enabled="false">En Başarılı Ders: Matematik</asp:TextBox>
            </div>
            <br />
            <div>
                <asp:TextBox ID="Textbox6" runat="server" CssClass="form-control" Enabled="false">Toplam Atılan Mesaj: 2547</asp:TextBox>
            </div>
            <br />
            <asp:Button runat="server" Text="Şifre Değiştir" ID="sifreDegistir" class="btn btn-primary" OnClick="guncelle_Click"/>

        </div>
    </form>


</asp:Content>


```

```c#
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class OgrenciDefault : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Textbox1.Text = Session["numara"].ToString();

        DataSetTableAdapters.TBLOGRENCITableAdapter dt = new DataSetTableAdapters.TBLOGRENCITableAdapter();
        Textbox2.Text = "Ad Soyad: " + dt.OgrenciPaneliGetir(Textbox1.Text)[0].OGRAD + " " + dt.OgrenciPaneliGetir(Textbox1.Text)[0].OGRSOYAD;
        Textbox3.Text = "Mail Adresi: "+ dt.OgrenciPaneliGetir(Textbox1.Text)[0].OGRMAIL;
        Textbox4.Text = "Şifre: "+ dt.OgrenciPaneliGetir(Textbox1.Text)[0].OGRSIFRE;
        Textbox5.Text = "Telefon Numarası: " + dt.OgrenciPaneliGetir(Textbox1.Text)[0].OGRTELEFON;
        Textbox6.Text = "Fotoğraf Adresi: " + dt.OgrenciPaneliGetir(Textbox1.Text)[0].OGRFOTOGRAF;
    }

    protected void guncelle_Click(object sender, EventArgs e)
    {
        Response.Redirect("OgrenciGuncelle2.aspx?NUMARA=" + Textbox1.Text);
    }
}
```

### [Öğrenci] Şifre Değiştir
![image](https://user-images.githubusercontent.com/95151751/230777103-f3d228b1-443e-4d86-9a2e-fc0c93f32fab.png)

```c#
<%@ Page Title="" Language="C#" MasterPageFile="~/Ogrenci.master" AutoEventWireup="true" CodeFile="OgrenciGuncelle2.aspx.cs" Inherits="OgrenciGuncelle2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">

        <form id="Form1" runat="server">

        <div class="form-group">
            <div>
                <asp:TextBox ID="Textbox1" runat="server" CssClass="form-control" Enabled="False"></asp:TextBox>
            </div>
            <br />
            <div>
                <asp:TextBox ID="Textbox4" runat="server" CssClass="form-control" Enabled="true">Şifre</asp:TextBox>
            </div>
            <br />
            <div>
                <asp:TextBox ID="Textbox5" runat="server" CssClass="form-control" Enabled="true">Şifre Tekrar</asp:TextBox>
            </div>
            <br />
            <asp:Button runat="server" Text="Güncelle" ID="guncelle" class="btn btn-success" OnClick="guncelle_Click"/>

        </div>
    </form>


</asp:Content>


```

```c#
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class OgrenciGuncelle2 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Textbox1.Text = Request.QueryString["NUMARA"];

        if (!IsPostBack)
        {

        }

        //Textbox2.Text = "Ad Soyad: " + dt.OgrenciPaneliGetir(Textbox1.Text)[0].OGRAD + " " + dt.OgrenciPaneliGetir(Textbox1.Text)[0].OGRSOYAD;
        //Textbox3.Text = "Mail Adresi: " + dt.OgrenciPaneliGetir(Textbox1.Text)[0].OGRMAIL;
        //Textbox4.Text = dt.OgrenciPaneliGetir(Textbox1.Text)[0].OGRSIFRE;
        //Textbox5.Text = "Telefon Numarası: " + dt.OgrenciPaneliGetir(Textbox1.Text)[0].OGRTELEFON;
        //Textbox6.Text = "Fotoğraf Adresi: " + dt.OgrenciPaneliGetir(Textbox1.Text)[0].OGRFOTOGRAF;

    }

    protected void guncelle_Click(object sender, EventArgs e)
    {
        if((Textbox4.Text==Textbox5.Text) && Textbox4.Text != "")
        {
            DataSetTableAdapters.TBLOGRENCITableAdapter dt = new DataSetTableAdapters.TBLOGRENCITableAdapter();
            dt.OgrenciSifreGuncelle(Textbox4.Text, Textbox1.Text);
            Response.Redirect("OgrenciDefault.aspx?NUMARA=" + Textbox1.Text);

        }
        else
        {
            Response.Write("Şifre Uyuşmazlığı!");
        }
    }
}
```

### [Öğrenci] Gelen Mesajlar
![image](https://user-images.githubusercontent.com/95151751/230775422-459e10e8-e25e-4504-aea3-618ca7145c08.png)

```c#
<%@ Page Title="" Language="C#" MasterPageFile="~/Ogrenci.master" AutoEventWireup="true" CodeFile="OgrenciGelenMesajlar.aspx.cs" Inherits="OgrenciGelenMesajlar" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">

    <table class="table table-bordered table-hover">
        <tr>
            <th scope="col">GÖNDEREN</th>
            <th scope="col">BAŞLIK</th>
            <th scope="col">İÇERİK</th>
            <th scope="col">TARİH</th>
        </tr>
        <tbody>

            <asp:Repeater ID="Repeater1" runat="server">

                <ItemTemplate>

                    <tr>
                        <td><%#Eval("GONDEREN") %></td>
                        <td><%#Eval("BASLIK") %></td>
                        <td><%#Eval("ICERIK") %></td>
                        <td><%#Eval("TARIH") %></td>
                        <%--                        <td>
                            <asp:HyperLink NavigateUrl='<%# "DuyuruSil.aspx?DUYURUID="+Eval("DUYURUID") %>' ID="HyperLink1" runat="server" class="btn btn-danger">SİL</asp:HyperLink>
                            <asp:HyperLink NavigateUrl='<%# "DuyuruGuncelle.aspx?DUYURUID="+Eval("DUYURUID") %>' ID="HyperLink2" runat="server" class="btn btn-success">GÜNCELLE</asp:HyperLink>
                        </td>--%>
                    </tr>

                </ItemTemplate>

            </asp:Repeater>

        </tbody>
    </table>


</asp:Content>


```

```c#
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class OgrenciGelenMesajlar : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        DataSetTableAdapters.TBLMESAJLARTableAdapter dt = new DataSetTableAdapters.TBLMESAJLARTableAdapter();
        Repeater1.DataSource = dt.OgrenciGelenKutusu1(Session["numara"].ToString());
        Repeater1.DataBind();
    }
}
```

### [Öğrenci] Giden Mesajlar
![image](https://user-images.githubusercontent.com/95151751/230775630-45354a61-7263-4b4d-b1eb-aca4618079b7.png)

```c#
<%@ Page Title="" Language="C#" MasterPageFile="~/Ogrenci.master" AutoEventWireup="true" CodeFile="OgrenciGidenMesajlar.aspx.cs" Inherits="OgrenciGidenMesajlar" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">

    <table class="table table-bordered table-hover">
        <tr>
            <th scope="col">ALICI</th>
            <th scope="col">BAŞLIK</th>
            <th scope="col">İÇERİK</th>
            <th scope="col">TARİH</th>
        </tr>
        <tbody>

            <asp:Repeater ID="Repeater1" runat="server">

                <ItemTemplate>

                    <tr>
                        <td><%#Eval("ALICI") %></td>
                        <td><%#Eval("BASLIK") %></td>
                        <td><%#Eval("ICERIK") %></td>
                        <td><%#Eval("TARIH") %></td>
                        <%--                        <td>
                            <asp:HyperLink NavigateUrl='<%# "DuyuruSil.aspx?DUYURUID="+Eval("DUYURUID") %>' ID="HyperLink1" runat="server" class="btn btn-danger">SİL</asp:HyperLink>
                            <asp:HyperLink NavigateUrl='<%# "DuyuruGuncelle.aspx?DUYURUID="+Eval("DUYURUID") %>' ID="HyperLink2" runat="server" class="btn btn-success">GÜNCELLE</asp:HyperLink>
                        </td>--%>
                    </tr>

                </ItemTemplate>

            </asp:Repeater>

        </tbody>
    </table>


</asp:Content>


```

```c#
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class OgrenciGidenMesajlar : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        DataSetTableAdapters.TBLMESAJLARTableAdapter dt = new DataSetTableAdapters.TBLMESAJLARTableAdapter();
        Repeater1.DataSource = dt.OgrenciGidenKutusu1(Session["numara"].ToString());
        Repeater1 .DataBind();
    }
}
```

### [Öğrenci] Mesaj Oluştur
![image](https://user-images.githubusercontent.com/95151751/230775650-125d7a27-bbc3-4416-974e-793a5b481881.png)

```c#
<%@ Page Title="" Language="C#" MasterPageFile="~/Ogrenci.master" AutoEventWireup="true" CodeFile="OgrenciMesajOlustur.aspx.cs" Inherits="OgrenciMesajOlustur" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">

    <form id="Form1" runat="server">

        <div class="form-group">
            <div>
                <asp:Label for="txtGonderen" runat="server">Gönderen</asp:Label>
                <asp:TextBox ID="txtGonderen" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
            </div>
            <br />
            <div>
                <asp:Label for="txtAlici" runat="server">Alıcı</asp:Label>
                <asp:TextBox ID="txtAlici" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            <br />
            <div>
                <asp:Label for="txtMesajBaslik" runat="server">Mesaj Başlık</asp:Label>
                <asp:TextBox ID="txtMesajBaslik" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            <br />
            <div>
                <asp:Label for="txtIcerik" runat="server">Mesaj İçerik</asp:Label>
                <textarea id="txtIcerik" cols="20" rows="7" class="form-control" runat="server"></textarea>
            </div>
        </div>
        <asp:Button runat="server" Text="Mesaj Gönder" ID="btnGonder" class="btn btn-info" OnClick="btnGonder_Click" />

    </form>

</asp:Content>


```

```c#
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class OgrenciMesajOlustur : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        txtGonderen.Text = Session["numara"].ToString();
    }

    protected void btnGonder_Click(object sender, EventArgs e)
    {
        DataSetTableAdapters.TBLMESAJLARTableAdapter dt = new DataSetTableAdapters.TBLMESAJLARTableAdapter();
        dt.MesajGonder(txtGonderen.Text, txtAlici.Text, txtMesajBaslik.Text, txtIcerik.Value);
        Response.Redirect("OgrenciGidenMesajlar.aspx");
    }
}
```

### [Öğrenci] Duyurular
![image](https://user-images.githubusercontent.com/95151751/230775659-b673551d-15f4-4d98-bb8f-ecebaecf68c7.png)

```c#
<%@ Page Title="" Language="C#" MasterPageFile="~/Ogrenci.master" AutoEventWireup="true" CodeFile="OgrenciDuyuru.aspx.cs" Inherits="OgrenciDuyuru" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">

        <table class="table table-bordered table-hover">
        <tr>
            <th scope="col">ID</th>
            <th scope="col">BAŞLIK</th>
            <th scope="col">İÇERİK</th>
            <th scope="col">ÖĞRETMEN</th>
        </tr>
        <tbody>

            <asp:Repeater ID="Repeater1" runat="server">

                <ItemTemplate>

                    <tr>
                        <td><%#Eval("DUYURUID") %></td>
                        <td><%#Eval("DUYURUBASLIK") %></td>
                        <td><%#Eval("DUYURUICERIK") %></td>
                        <td><%#Eval("OGRTADSOYAD") %></td>
                    </tr>

                </ItemTemplate>

            </asp:Repeater>

        </tbody>
    </table>

</asp:Content>


```

```c#
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class OgrenciDuyuru : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        DataSetTableAdapters.TBLDUYURULARTableAdapter dt = new DataSetTableAdapters.TBLDUYURULARTableAdapter();
        Repeater1.DataSource = dt.OgrenciDuyuruListesi();
        Repeater1.DataBind();

    }
}
```

### [Öğrenci] Sınav Notları
![image](https://user-images.githubusercontent.com/95151751/230775677-db9fa784-df19-4f05-866f-f896e041bf53.png)

```c#
<%@ Page Title="" Language="C#" MasterPageFile="~/Ogrenci.master" AutoEventWireup="true" CodeFile="OgrenciNotu.aspx.cs" Inherits="OgrenciNotu" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">

    <table class="table table-bordered table-hover">
        <tr>
            <th scope="col">ÖĞRENCİ ID</th>
            <th scope="col">AD SOYAD</th>
            <th scope="col">DERS ADI</th>
            <th scope="col">SINAV 1</th>
            <th scope="col">SINAV 2</th>
            <th scope="col">SINAV 3</th>
            <th scope="col">ORTALAMA</th>
            <th scope="col">DURUM</th>
        </tr>
        <tbody>

            <asp:Repeater ID="Repeater1" runat="server">

                <ItemTemplate>

                    <tr>
                        <td><%#Eval("OGRENCIID") %></td>
                        <td><%#Eval("OGRENCIADSOYAD") %></td>
                        <td><%#Eval("DERSAD") %></td>
                        <td><%#Eval("SINAV1") %></td>
                        <td><%#Eval("SINAV2") %></td>
                        <td><%#Eval("SINAV3") %></td>
                        <td><%#Eval("ORTALAMA") %></td>
                        <td><%#Eval("DURUM") %></td>
                    </tr>

                </ItemTemplate>

            </asp:Repeater>

        </tbody>
    </table>


</asp:Content>


```

```c#
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class OgrenciNotu : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        DataSetTableAdapters.OgrNotlarTableAdapter dt = new DataSetTableAdapters.OgrNotlarTableAdapter();
        Repeater1.DataSource = dt.OgrenciNotu(Session["numara"].ToString());
        Repeater1.DataBind();
    }
}
```

# ASP.NET Entity Framework ile Dinamik Admin Panelli CV Sitesi <a name="project6"></a>
### Hakkımda
![image](https://user-images.githubusercontent.com/95151751/231292449-8892f81f-9cf0-4845-84e9-35998b71c62a.png)

```c#
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="_06_CvEntityProje.Default" %>

<!--
Author: W3layouts
Author URL: http://w3layouts.com
License: Creative Commons Attribution 3.0 Unported
License URL: http://creativecommons.org/licenses/by/3.0/
-->
<!DOCTYPE html>
<html>
<head>
    <title>Entity CV Projesi</title>
    <!-- custom-theme -->
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="keywords" content="Delightful Profile template Responsive, Login form web template,Flat Pricing tables,Flat Drop downs  Sign up Web Templates, Flat Web Templates, Login sign up Responsive web template, SmartPhone Compatible web template, free webdesigns for Nokia, Samsung, LG, SonyEricsson, Motorola web design" />
    <script type="/web/application/x-javascript"> addEventListener("load", function() { setTimeout(hideURLbar, 0); }, false);
		function hideURLbar(){ window.scrollTo(0,1); } </script>
    <!-- //custom-theme -->
    <link href="/web/css/style.css" rel="stylesheet" type="text/css" media="all" />
    <!-- js -->
    <script src="/web/js/jquery-2.2.3.min.js"></script>
    <!-- //js -->
    <!-- font-awesome-icons -->
    <link href="/web/css/font-awesome.css" rel="stylesheet">
    <!-- //font-awesome-icons -->
    <link href="/web/css/lightcase.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" type="text/css" href="/web/css/easy-responsive-tabs.css " />
    <link href="//fonts.googleapis.com/css?family=Arsenal:400,400i,700,700i&amp;subset=cyrillic,cyrillic-ext,latin-ext,vietnamese" rel="stylesheet">
</head>
<body>
    <div class="main">
        <h1>YAZILIM KİMLİK KARTI</h1>
        <div class="w3_agile_main_grids">
            <div class="w3layouts_main_grid_left">
                <div class="w3_main_grid_left_grid">
                    <asp:Repeater ID="Repeater1" runat="server">
                        <ItemTemplate>
                            <h2><%# Eval("BILGILER") %></h2>
                        </ItemTemplate>
                    </asp:Repeater>
                    <p>Full Stack Software Developer</p>
                    <div class="w3l_figure">
                        <img src="/web/images/profil-min.png" alt="Berkan Nihat Yıldız" style="width:140px; height:140px;" />
                    </div>
                    <ul class="agileinfo_social_icons">
                        <li><a href="https://github.com/beniyildiz007" class="w3_agileits_facebook"><i class="fa fa-github" aria-hidden="true"></i></a></li>
                        <li><a href="https://www.linkedin.com/in/berkan-nihat-yildiz/" class="wthree_twitter"><i class="fa fa-linkedin" aria-hidden="true"></i></a></li>
                        <li><a href="https://www.instagram.com/beniyildiz007/" class="agileinfo_google"><i class="fa fa-instagram" aria-hidden="true"></i></a></li>
                    </ul>
                </div>
            </div>
            <div class="w3layouts_main_grid_right">
                <div class="w3ls_main_grid_right_grid">
                    <div id="parentHorizontalTab">
                        <ul class="resp-tabs-list hor_1">
                            <li><i class="fa fa-user" aria-hidden="true"></i>HAKKIMDA</li>
                            <li><i class="fa fa-briefcase" aria-hidden="true"></i>ÇALIŞMALARIM</li>
                            <li><i class="fa fa-map-marker" aria-hidden="true"></i>İLETİŞİM</li>
                        </ul>
                        <div class="resp-tabs-container hor_1">
                            <div class="agileits_main_grid_right_grid">
                                <!-- HAKKIMDA YAZISI -->
                                <p style="font-weight: bold; font-size: larger">Eğitim Hayatım</p>
                                <asp:Repeater ID="Repeater2" runat="server">
                                    <ItemTemplate>
                                        <div><%# Eval("EGITIM") %></div>
                                    </ItemTemplate>
                                </asp:Repeater>
                                <p style="font-weight: bold; font-size: larger; margin-top: 15px;">İş Deneyimlerim</p>
                                <asp:Repeater ID="Repeater3" runat="server">
                                    <ItemTemplate>
                                        <div><%# Eval("ISDENEYIMLERI") %></div>
                                    </ItemTemplate>
                                </asp:Repeater>
<%--                                <div class="wthree_tab_grid_sub">
                                    <div class="wthree_tab_grid_sub_left">
                                        <h5>321</h5>
                                        <p>Tweets</p>
                                    </div>
                                    <div class="wthree_tab_grid_sub_left">
                                        <h5>213</h5>
                                        <p>Followers</p>
                                    </div>
                                    <div class="wthree_tab_grid_sub_left">
                                        <h5>123</h5>
                                        <p>Following</p>
                                    </div>
                                    <div class="clear"></div>
                                </div>--%>
                                <br />
                                <br />
                                <div class="agileits_skills">
                                    <h3>YETENEKLERİM</h3>
                                    <div class="w3_agileits_skills_grid">
                                        <ul>
                                            <asp:Repeater ID="Repeater4" runat="server">
                                                <ItemTemplate>
                                                    <li>
                                                        <label><%# Eval("YETENEK") %></label>
                                                        <span></span>%<%# Eval("DERECE") %></li>

                                                </ItemTemplate>
                                            </asp:Repeater>
                                        </ul>
                                    </div>
                                </div>
                            </div>
                            <div class="wthree_main_grid_right_grid">
                                <h3>BİTİRDİĞİM PROJELERİM</h3>
                                <div class="w3_agileits_main_grid_work_grids">
                                    <div class="agile_main_grid_work_gridl">
                                        <a href="/web/images/1.jpg" class="showcase" data-rel="lightcase:myCollection:slideshow" title="Easy Profile">
                                            <img src="/web/images/1.jpg" alt=" " />
                                        </a>
                                    </div>
                                    <div class="agile_main_grid_work_gridl">
                                        <a href="/web/images/2.jpg" class="showcase" data-rel="lightcase:myCollection:slideshow" title="Easy Profile">
                                            <img src="/web/images/2.jpg" alt=" " />
                                        </a>
                                    </div>
                                    <div class="agile_main_grid_work_gridl">
                                        <a href="/web/images/3.jpg" class="showcase" data-rel="lightcase:myCollection:slideshow" title="Easy Profile">
                                            <img src="/web/images/3.jpg" alt=" " />
                                        </a>
                                    </div>
                                    <div class="agile_main_grid_work_gridl">
                                        <a href="/web/images/4.jpg" class="showcase" data-rel="lightcase:myCollection:slideshow" title="Easy Profile">
                                            <img src="/web/images/4.jpg" alt=" " />
                                        </a>
                                    </div>
                                    <div class="agile_main_grid_work_gridl">
                                        <a href="/web/images/5.jpg" class="showcase" data-rel="lightcase:myCollection:slideshow" title="Easy Profile">
                                            <img src="/web/images/5.jpg" alt=" " />
                                        </a>
                                    </div>
                                    <div class="agile_main_grid_work_gridl">
                                        <a href="/web/images/6.jpg" class="showcase" data-rel="lightcase:myCollection:slideshow" title="Easy Profile">
                                            <img src="/web/images/6.jpg" alt=" " />
                                        </a>
                                    </div>
                                    <div class="clear"></div>
                                </div>
                            </div>
                            <div class="wthree_main_grid_right_grid">
                                <h3>İLETİŞİM ADRESLERİM</h3>
                                <form action="#" method="post" runat="server">
                                    <div class="agileits_w3layouts_contact_left">
                                        <asp:TextBox ID="txtAd" runat="server" placeholder="Adınız" style="padding:15px"></asp:TextBox>
                                        <asp:TextBox ID="txtMail" runat="server" placeholder="Mail Adersiniz" style="margin:15px 0px; padding:15px;"></asp:TextBox>
                                        <asp:TextBox ID="TextBox1" runat="server" placeholder="Mesajınız" TextMode="MultiLine" style="padding:15px"></asp:TextBox>
                                    </div>
                                    <div class="agileits_w3layouts_contact_right">
                                        <iframe src="https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d6032.791420422463!2d29.216823697311423!3d40.885133896740264!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x14cac350c8107edd%3A0x1e2dde395846822a!2zU2FwYW4gQmHEn2xhcsSxLCAzNDg5MyBQZW5kaWsvxLBzdGFuYnVs!5e0!3m2!1str!2str!4v1681230584677!5m2!1str!2str" style="border: 0"></iframe>
                                    </div>
                                    <div class="clear"></div>
                                    <div class="agile_submit">
                                        <asp:Button ID="Button1" runat="server" Text="Gönder" OnClick="Button1_Click" />
                                    </div>
                                </form>
                                <div class="wthree_tab_grid">
                                    <ul class="wthree_tab_grid_list">
                                        <li><i class="fa fa-mobile" aria-hidden="true"></i></li>
                                        <li>Telefon<span>+90 507 932 4972</span></li>
                                    </ul>
                                    <ul class="wthree_tab_grid_list">
                                        <li><i class="fa fa-envelope-o" aria-hidden="true"></i></li>
                                        <li>Mail<span><a href="mailto:yildiz.nihatberkan@gmail.com">yildiz.nihatberkan@gmail.com</a></span></li>
                                    </ul>
                                    <ul class="wthree_tab_grid_list">
                                        <li><i class="fa fa-map-marker" aria-hidden="true"></i></li>
                                        <li>Adres<span>Pendik / İstanbul</span></li>
                                    </ul>
                                    <div class="clear"></div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="clear"></div>
        </div>
        <div class="agileits_copyright">
            <p>© 2023 Tüm Hakları Saklıdır.</p>
        </div>
    </div>
    <script src="/web/js/easyResponsiveTabs.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            //Horizontal Tab
            $('#parentHorizontalTab').easyResponsiveTabs({
                type: 'default', //Types: default, vertical, accordion
                width: 'auto', //auto or any width like 600px
                fit: true, // 100% fit in a container
                tabidentify: 'hor_1', // The tab groups identifier
                activate: function (event) { // Callback function if tab is switched
                    var $tab = $(this);
                    var $info = $('#nested-tabInfo');
                    var $name = $('span', $info);
                    $name.text($tab.text());
                    $info.show();
                }
            });
        });
    </script>
    <!-- light-case -->
    <script src="/web/js/lightcase.js"></script>
    <script src="/web/js/jquery.events.touch.js"></script>
    <script>
        $('.showcase').lightcase();
    </script>
    <!-- //light-case -->

</body>
</html>

```

### Çalışmalarım -1
![image](https://user-images.githubusercontent.com/95151751/231292599-f249001a-9032-434a-a0cc-1794fed0f3a1.png)

### Çalışmalarım -2
![image](https://user-images.githubusercontent.com/95151751/231292704-3c5788ce-ca6d-4959-9ac1-12b30535b538.png)

### İletişim
![image](https://user-images.githubusercontent.com/95151751/231292750-5c283c50-2c88-4711-9041-54683855408f.png)

### [Admin Paneli] Yeteneklerim
![image](https://user-images.githubusercontent.com/95151751/231292932-45e055ae-6281-4e5e-bcd9-8e0aa55acb3e.png)
```c#
<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="Yeteneklerim.aspx.cs" Inherits="_06_CvEntityProje.Hakkkimda" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <table class="table table-bordered" style="margin-left: 30px; width: 90%">
        <tr>
            <th>ID</th>
            <th>YETENEK</th>
            <th>SİL</th>
            <th>GÜNCELLE</th>
        </tr>
        <asp:Repeater ID="Repeater1" runat="server">
            <ItemTemplate>
                <tr>
                    <td><%# Eval("ID")  %></td>
                    <td><%# Eval("YETENEK")  %></td>
                    <td>
                        <asp:HyperLink ID="HyperLink1" runat="server" CssClass="btn btn-danger" NavigateUrl='<%# "YetenekSil.aspx?ID="+Eval("ID") %>'>SİL</asp:HyperLink></td>
                    <td>
                        <asp:HyperLink ID="HyperLink2" runat="server" CssClass="btn btn-success" NavigateUrl='<%# "YetenekGuncelle.aspx?ID="+Eval("ID") %>'>GÜNCELLE</asp:HyperLink></td>
                </tr>
            </ItemTemplate>
        </asp:Repeater>
    </table>
    <asp:Button ID="btnEkle" runat="server" Text="Yeni Yetenek Ekle" CssClass="btn btn-primary" OnClick="btnEkle_Click" style="margin-left: 30px;" />

</asp:Content>

```
```c#
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _06_CvEntityProje
{
    public partial class Hakkkimda : System.Web.UI.Page
    {

        Dbo_CvEntityEntities db = new Dbo_CvEntityEntities();

        protected void Page_Load(object sender, EventArgs e)
        {
            Repeater1.DataSource = db.TBLYETENEKLER.ToList();
            Repeater1.DataBind();
        }

        protected void btnEkle_Click(object sender, EventArgs e)
        {
            Response.Redirect("YeniYetenekEkle.aspx");
        }
    }
}
```

### [Admin Paneli] Yeni Yetenek Ekle
![image](https://user-images.githubusercontent.com/95151751/231292996-9fff056a-79f0-4435-9cf5-2f7cfd787455.png)
```c#
<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="YeniYetenekEkle.aspx.cs" Inherits="_06_CvEntityProje.YeniYetenekEkle" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="margin-left:30px">
        <h3>YENİ YETENEK EKLEME SAYFASI</h3>
        <br />
        <asp:TextBox ID="TextBox1" runat="server" placeholder="Yeteneğini gir" CssClass="form-control" Style="max-width: 500px;"></asp:TextBox>
        <br />
        <asp:TextBox ID="TextBox2" runat="server" placeholder="Yetenek Derecesi..." CssClass="form-control" Style="max-width: 500px;"></asp:TextBox>
        <br />
        <asp:Button ID="Button1" runat="server" Text="Kaydet" CssClass="btn btn-info" OnClick="Button1_Click" />

    </div>
</asp:Content>

```

```c#
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _06_CvEntityProje
{
    public partial class YeniYetenekEkle : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Dbo_CvEntityEntities db = new Dbo_CvEntityEntities();
            TBLYETENEKLER t = new TBLYETENEKLER();
            t.YETENEK = TextBox1.Text;
            t.DERECE = Convert.ToByte(TextBox2.Text);
            db.TBLYETENEKLER.Add(t);
            db.SaveChanges();
            Response.Redirect("Yeteneklerim.aspx");
        }
    }
}
```

### [Admin Paneli] Yetenek Güncelle
![image](https://user-images.githubusercontent.com/95151751/231293044-560601cc-c8f4-4407-97d5-cc5292700ad1.png)
```c#
<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="YetenekGuncelle.aspx.cs" Inherits="_06_CvEntityProje.YetenekGuncelle" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div style="margin-left: 30px">
        <h3>YETENEK GÜNCELLEME SAYFASI</h3>
        <br />
        <asp:TextBox ID="txtYetenek" runat="server" placeholder="Yeteneğini gir" CssClass="form-control" Style="max-width: 500px;"></asp:TextBox>
        <br />
        <asp:TextBox ID="TextBox1" runat="server" placeholder="Yetenek Derecesi..." CssClass="form-control" Style="max-width: 500px;"></asp:TextBox>
        <br />
        <asp:Button ID="btnGuncelle" runat="server" Text="Güncelle" CssClass="btn btn-success" OnClick="btnGuncelle_Click"/>

    </div>


</asp:Content>

```

```c#
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _06_CvEntityProje
{
    public partial class YetenekGuncelle : System.Web.UI.Page
    {
        Dbo_CvEntityEntities db = new Dbo_CvEntityEntities();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var deger = db.TBLYETENEKLER.Find(int.Parse(Request.QueryString["ID"]));
                txtYetenek.Text = deger.YETENEK;
                
            }
        }
        
        protected void btnGuncelle_Click(object sender, EventArgs e)
        {
            var ytnk = db.TBLYETENEKLER.Find(int.Parse(Request.QueryString["ID"]));
            ytnk.YETENEK = txtYetenek.Text;
            ytnk.DERECE = Convert.ToByte(TextBox1.Text);
            db.SaveChanges();
            Response.Redirect("Yeteneklerim.aspx");

        }
    }
}
```

### [Admin Paneli] Yetenek Sil

```c#
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _06_CvEntityProje
{
    public partial class YetenekSil : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Dbo_CvEntityEntities db = new Dbo_CvEntityEntities();
            var ytnk = db.TBLYETENEKLER.Find(Convert.ToInt32(Request.QueryString["ID"]));
            db.TBLYETENEKLER.Remove(ytnk);
            db.SaveChanges();
            Response.Redirect("Yeteneklerim.aspx");
        }
    }
}
```

### [Admin Paneli] İletişim
![image](https://user-images.githubusercontent.com/95151751/231293116-2aee111a-c9f4-4552-b62b-ab03745f3bed.png)
```c#
<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="iletisim.aspx.cs" Inherits="_06_CvEntityProje.iletisim" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <table class="table table-bordered" style="margin-left: 30px; width: 90%">
        <tr>
            <th>ID</th>
            <th>AD SOYAD</th>
            <th>MAİL</th>
            <th>MESAJI GÖR</th>
        </tr>
        <asp:Repeater ID="Repeater1" runat="server">
            <itemtemplate>
                <tr>
                    <td><%# Eval("ID")  %></td>
                    <td><%# Eval("ADSOYAD")  %></td>
                    <td><%# Eval("MESAJ")  %></td>
                    <td>
                        <asp:HyperLink ID="HyperLink1" runat="server" CssClass="btn btn-info" NavigateUrl='<%# "MesajDetay.aspx?ID="+Eval("ID") %>'>Mesajı Gör</asp:HyperLink></td>
                </tr>
            </itemtemplate>
        </asp:Repeater>
    </table>


</asp:Content>

```

```c#
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _06_CvEntityProje
{
    public partial class iletisim : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Dbo_CvEntityEntities db = new Dbo_CvEntityEntities();
            var mesajlar = db.TBLILETISIM.ToList();
            Repeater1.DataSource = mesajlar;
            Repeater1.DataBind();
        }
    }
}
```

### [Admin Paneli] Mesaj Detayları
![image](https://user-images.githubusercontent.com/95151751/231293162-d597e7fc-b0bf-4c41-9b49-2a7abf79010a.png)
```c#
<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="MesajDetay.aspx.cs" Inherits="_06_CvEntityProje.MesajDetay" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div style="margin-left: 30px; max-width: 500px;">
        <h3>MESAJ DETAYLARI</h3>
        <br />
        <asp:TextBox ID="txtAdSoyad" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
        <br />
        <asp:TextBox ID="txtMail" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
        <br />
        <asp:TextBox ID="txtMesaj" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
        <br />
        <asp:Button ID="btnMesajlar" runat="server" Text="MESAJLARIM" CssClass="btn btn-info" OnClick="btnMesajlar_Click"/>

    </div>

</asp:Content>

```

```c#
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _06_CvEntityProje
{
    public partial class MesajDetay : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Dbo_CvEntityEntities db = new Dbo_CvEntityEntities();
            var mesaj = db.TBLILETISIM.Find(int.Parse(Request.QueryString["ID"]));
            txtAdSoyad.Text = mesaj.ADSOYAD;
            txtMail.Text = mesaj.MAIL;
            txtMesaj.Text = mesaj.MESAJ;
        }

        protected void btnMesajlar_Click(object sender, EventArgs e)
        {
            Response.Redirect("iletisim.aspx");
        }
    }
}
```


# ASP.NET Bootstrap Login & Admin Panelli Dinamik CV Sitesi <a name="project7"></a>

### Site Ön Yüzü Kodları

```c#
<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>
<html lang="en">

<head>

    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">
    <meta name="description" content="">
    <meta name="author" content="">

    <title>Resume - Start Bootstrap Theme</title>

    <!-- Bootstrap core CSS -->
    <link href="Dosyalar/vendor/bootstrap/css/bootstrap.min.css" rel="stylesheet">

    <!-- Custom fonts for this template -->
    <link href="https://fonts.googleapis.com/css?family=Saira+Extra+Condensed:500,700" rel="stylesheet">
    <link href="https://fonts.googleapis.com/css?family=Muli:400,400i,800,800i" rel="stylesheet">
    <link href="Dosyalar/vendor/fontawesome-free/css/all.min.css" rel="stylesheet">

    <!-- Custom styles for this template -->
    <link href="Dosyalar/css/resume.min.css" rel="stylesheet">
</head>

<body id="page-top">

    <nav class="navbar navbar-expand-lg navbar-dark bg-primary fixed-top" id="sideNav">
        <a class="navbar-brand js-scroll-trigger" href="#page-top">
            <span class="d-block d-lg-none">Clarence Taylor</span>
            <span class="d-none d-lg-block">
                <img class="img-fluid img-profile rounded-circle mx-auto mb-2" src="Dosyalar/img/profile.jpg" alt="">
            </span>
        </a>
        <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarSupportedContent" aria-controls="navbarSupportedContent" aria-expanded="false" aria-label="Toggle navigation">
            <span class="navbar-toggler-icon"></span>
        </button>
        <div class="collapse navbar-collapse" id="navbarSupportedContent">
            <ul class="navbar-nav">
                <li class="nav-item">
                    <a class="nav-link js-scroll-trigger" href="#about">HAKKIMDA</a>
                </li>
                <li class="nav-item">
                    <a class="nav-link js-scroll-trigger" href="#experience">DENEYİMLERİM</a>
                </li>
                <li class="nav-item">
                    <a class="nav-link js-scroll-trigger" href="#education">EĞİTİM HAYATIM</a>
                </li>
                <li class="nav-item">
                    <a class="nav-link js-scroll-trigger" href="#skills">YETENEKLERİM</a>
                </li>
                <li class="nav-item">
                    <a class="nav-link js-scroll-trigger" href="#interests">HOBİLERİM</a>
                </li>
                <li class="nav-item">
                    <a class="nav-link js-scroll-trigger" href="#awards">ÖDÜL VE SERTİFİKALARIM</a>
                </li>
            </ul>
        </div>
    </nav>

    <div class="container-fluid p-0">

        <section class="resume-section p-3 p-lg-5 d-flex d-column" id="about">
            <asp:Repeater ID="Repeater1" runat="server">
                <ItemTemplate>
                    <div class="my-auto">
                        <h1 class="mb-0">
                            <asp:Label ID="lblAd" runat="server" Text='<%# Eval("AD") %>'></asp:Label>

                            <span class="text-primary">
                                <asp:Label ID="lblSoyad" runat="server" Text='<%# Eval("SOYAD") %>'></asp:Label></span>
                        </h1>
                        <div class="subheading mb-5">
                            <asp:Label ID="lblAdres" runat="server" Text='<%# Eval("ADRES") %>'></asp:Label><p></p>
                            <asp:Label ID="lblTelefon" runat="server" Text='<%# Eval("MAIL") %>'></asp:Label><p></p>

                            <asp:Label ID="lblMail" runat="server" Text='<%# Eval("TELEFON") %>'></asp:Label>
                        </div>
                        <p class="lead mb-5">
                            <asp:Label ID="lblHakkimda" runat="server" Text='<%# Eval("KISANOT") %>'></asp:Label>
                        </p>
                        <div class="social-icons">
                            <a href="https://www.linkedin.com/in/berkan-nihat-yildiz/" target="_blank">
                                <i class="fab fa-linkedin-in"></i>
                            </a>
                            <a href="https://www.instagram.com/beniyildiz007/" target="_blank">
                                <i class="fab fa-instagram"></i>
                            </a>
                            <a href="https://github.com/beniyildiz007" target="_blank">
                                <i class="fab fa-github"></i>
                            </a>
                            <a href="https://www.hackerrank.com/beniyildiz007?hr_r=1" target="_blank">
                                <i class="fab fa-hackerrank"></i>
                            </a>
                        </div>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </section>

        <hr class="m-0">

        <section class="resume-section p-3 p-lg-5 d-flex flex-column" id="experience">
            <div class="my-auto">
                <h2 class="mb-5">DENEYİMLERİM</h2>
                <asp:Repeater ID="Repeater2" runat="server">
                    <ItemTemplate>
                        <div class="resume-item d-flex flex-column flex-md-row mb-5">
                            <div class="resume-content mr-auto">
                                <h3 class="mb-0">
                                    <asp:Label ID="Label1" runat="server" Text='<%# Eval("BASLIK") %>'></asp:Label>
                                </h3>
                                <div class="subheading mb-3">
                                    <asp:Label ID="Label2" runat="server" Text='<%# Eval("ALTBASLIK") %>'></asp:Label>
                                </div>
                                <p>
                                    <asp:Label ID="Label3" runat="server" Text='<%# Eval("ACIKLAMA") %>'></asp:Label>
                                </p>
                            </div>
                            <div class="resume-date text-md-right">
                                <span class="text-primary">
                                    <asp:Label ID="Label4" runat="server" Text='<%# Eval("TARIH") %>'></asp:Label>
                                </span>
                            </div>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>

            </div>

        </section>

        <hr class="m-0">

        <section class="resume-section p-3 p-lg-5 d-flex flex-column" id="education">
            <div class="my-auto">
                <h2 class="mb-5">EĞİTİM HAYATIM</h2>
                <asp:Repeater ID="Repeater3" runat="server">
                    <ItemTemplate>
                        <div class="resume-item d-flex flex-column flex-md-row mb-5">
                            <div class="resume-content mr-auto">
                                <h3 class="mb-0">
                                    <asp:Label ID="Label5" runat="server" Text='<%# Eval("BASLIK") %>'></asp:Label></h3>
                                <div class="subheading mb-3">
                                    <asp:Label ID="Label6" runat="server" Text='<%# Eval("ALTBASLIK") %>'></asp:Label>
                                </div>
                                <div>
                                    <asp:Label ID="Label7" runat="server" Text='<%# Eval("ACIKLAMA") %>'></asp:Label>
                                </div>
                                <p>
                                    <asp:Label ID="Label8" runat="server" Text='<%# Eval("GNOT") %>'></asp:Label>
                                </p>
                            </div>
                            <div class="resume-date text-md-right">
                                <span class="text-primary">
                                    <asp:Label ID="Label9" runat="server" Text='<%# Eval("TARIH") %>'></asp:Label></span>
                            </div>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>

            </div>
        </section>

        <hr class="m-0">

        <section class="resume-section p-3 p-lg-5 d-flex flex-column" id="skills">
            <div class="my-auto">
                <h2 class="mb-5">YETENEKLERİM</h2>

                <div class="subheading mb-3">Programlama Dilleri & Araçlar</div>
                <ul class="list-inline dev-icons">
                    <li class="list-inline-item">
                        <i class="fab fa-html5"></i>
                    </li>
                    <li class="list-inline-item">
                        <i class="fab fa-css3-alt"></i>
                    </li>
                    <li class="list-inline-item">
                        <i class="fab fa-js-square"></i>
                    </li>
                    <li class="list-inline-item">
                        <i class="fab fa-angular"></i>
                    </li>
                    <li class="list-inline-item">
                        <i class="fab fa-php"></i>
                    </li>
                    <li class="list-inline-item">
                        <i class="fab fa-react"></i>
                    </li>
                    <li class="list-inline-item">
                        <i class="fab fa-python"></i>
                    </li>
                    <li class="list-inline-item">
                        <i class="fab fa-node-js"></i>
                    </li>
                    <li class="list-inline-item">
                        <i class="fab fa-wordpress"></i>
                    </li>
                </ul>

                <div class="subheading mb-3">İŞ AKIŞI</div>
                <asp:Repeater ID="Repeater4" runat="server">
                    <ItemTemplate>
                        <ul class="fa-ul mb-0">
                            <li>
                                <i class="fa-li fa fa-check"></i>
                                <asp:Label ID="Label11" runat="server" Text='<%#Eval("YETENEK") %>'></asp:Label></li>
                        </ul>
                    </ItemTemplate>
                </asp:Repeater>

            </div>
        </section>

        <hr class="m-0">

        <section class="resume-section p-3 p-lg-5 d-flex flex-column" id="interests">
            <div class="my-auto">
                <h2 class="mb-5">HOBİLERİM</h2>
                <asp:Repeater ID="Repeater5" runat="server">
                    <ItemTemplate>
                        <p>
                            <asp:Label ID="Label10" runat="server" Text='<%# Eval("HOBI") %>'></asp:Label>
                        </p>
                    </ItemTemplate>
                </asp:Repeater>

            </div>
        </section>

        <hr class="m-0">

        <section class="resume-section p-3 p-lg-5 d-flex flex-column" id="awards">
            <div class="my-auto">
                <h2 class="mb-5">SERTİFİKALARIM</h2>
                <asp:Repeater ID="Repeater6" runat="server">
                    <ItemTemplate>
                        <ul class="fa-ul mb-0">
                            <li>
                                <i class="fa-li fa fa-trophy text-warning"></i>
                                <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%# Eval("LINK") %>' Target="_blank"><%# Eval("ODUL") %></asp:HyperLink>
                            </li>
                        </ul>
                    </ItemTemplate>
                </asp:Repeater>

            </div>
        </section>

    </div>

    <!-- Bootstrap core JavaScript -->
    <script src="Dosyalar/vendor/jquery/jquery.min.js"></script>
    <script src="Dosyalar/vendor/bootstrap/js/bootstrap.bundle.min.js"></script>

    <!-- Plugin JavaScript -->
    <script src="Dosyalar/vendor/jquery-easing/jquery.easing.min.js"></script>

    <!-- Custom scripts for this template -->
    <script src="Dosyalar/js/resume.min.js"></script>

</body>

</html>

```

### [Site Ön Yüzü] Hakkımda

![image](https://user-images.githubusercontent.com/95151751/231579686-1ec17f14-afe3-4b26-aecf-f7ed0fa65c5b.png)

### [Site Ön Yüzü] Deneyimlerim

![image](https://user-images.githubusercontent.com/95151751/231579738-314be45b-5424-4b4d-978d-517bc26eb801.png)

### [Site Ön Yüzü] Eğitim Hayatım

![image](https://user-images.githubusercontent.com/95151751/231579811-e79a4782-fddb-4cad-9222-c8ccd7e76096.png)

### [Site Ön Yüzü] Yeteneklerim

![image](https://user-images.githubusercontent.com/95151751/231579855-973159bd-5a18-44a7-aa5c-9c1c3e067e18.png)

### [Site Ön Yüzü] Hobilerim

![image](https://user-images.githubusercontent.com/95151751/231579919-89a84968-4f91-4d95-8c64-e893f78d6175.png)

### [Site Ön Yüzü] Sertifikalarım

![image](https://user-images.githubusercontent.com/95151751/231579990-5a3c3b61-e439-4890-bfe6-7a913e385549.png)


### Login Paneli

![image](https://user-images.githubusercontent.com/95151751/231578988-2bf8f5ab-c963-4fd9-8b41-cede7c92d470.png)

```c#
<%@ Page Language="C#" AutoEventWireup="true" CodeFile="LoginPanel.aspx.cs" Inherits="LoginPanel" %>

<link href="//maxcdn.bootstrapcdn.com/bootstrap/4.1.1/css/bootstrap.min.css" rel="stylesheet" id="bootstrap-css">
<script src="//maxcdn.bootstrapcdn.com/bootstrap/4.1.1/js/bootstrap.min.js"></script>
<script src="//cdnjs.cloudflare.com/ajax/libs/jquery/3.2.1/jquery.min.js"></script>
<!------ Include the above in your HEAD tag ---------->

<!DOCTYPE html>
<html>
<head>
    <title>Login Page</title>
    <!--Made with love by Mutiullah Samim -->

    <!--Bootsrap 4 CDN-->
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.1.3/css/bootstrap.min.css" integrity="sha384-MCw98/SFnGE8fJT3GXwEOngsV7Zt27NXFoaoApmYm81iuXoPkFOJwJ8ERdknLPMO" crossorigin="anonymous">

    <!--Fontawesome CDN-->
    <link rel="stylesheet" href="https://use.fontawesome.com/releases/v5.3.1/css/all.css" integrity="sha384-mzrmE5qonljUremFsqc01SB46JvROS7bZs3IO2EmfFsd15uHvIt+Y8vEf7N7fWAU" crossorigin="anonymous">

    <!--Custom styles-->
    <link href="LoginPanelCSS.css" rel="stylesheet" />
</head>
<body>
    <div class="container">
        <div class="d-flex justify-content-center h-100">
            <div class="card">
                <div class="card-header">
                    <h3>Giriş Yap</h3>
                    <div class="d-flex justify-content-end social_icon">
                        <span><i class="fab fa-linkedin"></i></span>
                        <span><i class="fab fa-instagram"></i></span>
                        <span><i class="fab fa-github-square"></i></span>
                        <span><i class="fab fa-hackerrank"></i></span>
                    </div>
                </div>
                <div class="card-body">
                    <form runat="server">
                        <div class="input-group form-group">
                            <div class="input-group-prepend">
                                <span class="input-group-text"><i class="fas fa-user"></i></span>
                            </div>
                            <%--<input type="text" class="form-control" placeholder="username">--%>
                            <asp:TextBox ID="TextBox1" runat="server" placeholder="Kullanıcı Adı" CssClass="form-control"></asp:TextBox>
                        </div>
                        <div class="input-group form-group">
                            <div class="input-group-prepend">
                                <span class="input-group-text"><i class="fas fa-key"></i></span>
                            </div>
                            <%--<input type="password" class="form-control" placeholder="password">--%>
                            <asp:TextBox ID="TextBox2" runat="server" placeholder="Şifre" CssClass="form-control" TextMode="Password"></asp:TextBox>

                        </div>
                        <div class="row align-items-center remember">
                            <input type="checkbox">Beni Hatırla
				
                        </div>
                        <div class="form-group">
                            <%--<input type="submit" value="Login" class="btn float-right login_btn">--%>
                            <asp:Button ID="btnGiris" runat="server" Text="Giriş Yap" CssClass="btn float-right login_btn" OnClick="btnGiris_Click" />
                        </div>
                    </form>
                </div>
                <div class="card-footer">
                    <div class="d-flex justify-content-center links">
                        Bir hesabınız var mı?<a href="#">Üye Ol</a>
                    </div>
                    <div class="d-flex justify-content-center">
                        <a href="#">Şifrenizi mi Unuttunuz?</a>
                    </div>
                </div>
            </div>
        </div>
    </div>
</body>
</html>
```

```c#
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

public partial class LoginPanel : System.Web.UI.Page
{
    SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-HKL3D7O\SQLEXPRESS;Initial Catalog=Dbo_BlogWeb;Integrated Security=True
");

    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnGiris_Click(object sender, EventArgs e)
    {
        baglanti.Open();
        SqlCommand komut = new SqlCommand("select * from TBLADMIN where KULLANICI=@p1 and SIFRE=@p2", baglanti);
        komut.Parameters.AddWithValue("@p1", TextBox1.Text);
        komut.Parameters.AddWithValue("@p2", TextBox2.Text);
        SqlDataReader dr = komut.ExecuteReader();
        if (dr.Read())
        {
            Response.Redirect("Hakkimda.aspx");
        }
        else
        {
            Response.Write("KULLANICI ADI YA DA ŞİFRE HATALI!");
        }
        baglanti.Close();
    }
}
```

### [Admin Paneli] Hakkımda

![image](https://user-images.githubusercontent.com/95151751/231580390-380ccfa3-f8be-4f50-ac61-c790cf4bc666.png)

```c#
<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.master" AutoEventWireup="true" CodeFile="Hakkimda.aspx.cs" Inherits="Hakkimda" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
    
    <form id="Form1" runat="server">
        <div class="form-group">
            <div>
                <asp:Label for="txtAd" runat="server" Text="Adınız"></asp:Label>
                <asp:TextBox ID="txtAd" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            <br />
            <div>
                <asp:Label for="txtSoyad" runat="server" Text="Soyadınız"></asp:Label>
                <asp:TextBox ID="txtSoyad" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            <br />
            <div>
                <asp:Label for="txtAdres" runat="server" Text="Adresiniz"></asp:Label>
                <asp:TextBox ID="txtAdres" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            <br />
            <div>
                <asp:Label for="txtMail" runat="server" Text="Mail"></asp:Label>
                <asp:TextBox ID="txtMail" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            <br />
            <div>
                <asp:Label for="txtTelefon" runat="server" Text="Telefon"></asp:Label>
                <asp:TextBox ID="txtTelefon" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            <br />
            <div>
                <asp:Label for="txtKisaNot" runat="server" Text="Kısa Not"></asp:Label>
                <asp:TextBox ID="txtKisaNot" runat="server" CssClass="form-control" TextMode="MultiLine" Height="100px"></asp:TextBox>
            </div>
            <br />
            <div>
                <asp:Label for="txtFotograf" runat="server" Text="Fotoğraf"></asp:Label>
                <asp:TextBox ID="txtFotograf" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            <br />
            <asp:Button ID="btnGuncelle" CssClass="btn btn-success" runat="server" Text="Güncelle" OnClick="btnGuncelle_Click" />

        </div>
    </form>
</asp:Content>
```

```c#
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Hakkimda : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            DataSetTableAdapters.TBLHAKKIMDATableAdapter dt = new DataSetTableAdapters.TBLHAKKIMDATableAdapter();
            txtAd.Text = dt.HakkimdaListele()[0].AD;
            txtSoyad.Text = dt.HakkimdaListele()[0].SOYAD;
            txtAdres.Text = dt.HakkimdaListele()[0].ADRES;
            txtMail.Text = dt.HakkimdaListele()[0].MAIL;
            txtTelefon.Text = dt.HakkimdaListele()[0].TELEFON;
            txtKisaNot.Text = dt.HakkimdaListele()[0].KISANOT;
            txtFotograf.Text = dt.HakkimdaListele()[0].FOTOGRAF;

        }
    }

    protected void btnGuncelle_Click(object sender, EventArgs e)
    {
        DataSetTableAdapters.TBLHAKKIMDATableAdapter dt = new DataSetTableAdapters.TBLHAKKIMDATableAdapter();
        dt.HakkimdaGuncelle(txtAd.Text, txtSoyad.Text, txtAdres.Text, txtMail.Text, txtTelefon.Text, txtKisaNot.Text, txtFotograf.Text);
        Response.Redirect("Default.aspx");
    }
}
```

### [Admin Paneli] Deneyimlerim

![image](https://user-images.githubusercontent.com/95151751/231580539-9fbeba1c-a38f-4b51-a444-d4c76292e59c.png)

```c#
<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.master" AutoEventWireup="true" CodeFile="AdminDeneyimler.aspx.cs" Inherits="AdminDeneyimler" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">

    <form id="Form1" runat="server">

        <table class="table table-bordered">
            <tr>
                <th>ID</th>
                <th>BAŞLIK</th>
                <th>ALT BAŞLIK</th>
                <th>AÇIKLAMA</th>
                <th>TARİH</th>
                <th>İŞLEMLER</th>
            </tr>
            <tbody>
                <asp:Repeater ID="Repeater1" runat="server">
                    <ItemTemplate>
                        <tr>
                            <td><%# Eval("ID") %></td>
                            <td><%# Eval("BASLIK") %></td>
                            <td><%# Eval("ALTBASLIK") %></td>
                            <td><%# Eval("ACIKLAMA") %></td>
                            <td><%# Eval("TARIH") %></td>
                            <td>
                                <asp:HyperLink ID="HyperLink1" NavigateUrl='<%# "AdminDeneyimSil.aspx?ID="+ Eval("ID") %>' runat="server" CssClass="btn btn-danger">Sil</asp:HyperLink>
                                <asp:HyperLink ID="HyperLink2" NavigateUrl='<%# "AdminDeneyimGuncelle.aspx?ID="+ Eval("ID") %>' runat="server" CssClass="btn btn-success">Güncelle</asp:HyperLink>
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
            </tbody>
        </table>
        <asp:HyperLink ID="HyperLink3" NavigateUrl="~/AdminDeneyimEkle.aspx" runat="server" CssClass="btn btn-info">DENEYİM EKLE</asp:HyperLink>
    </form>

</asp:Content>


```

```c#
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AdminDeneyimler : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        DataSetTableAdapters.TBLDENEYIMTableAdapter DT = new DataSetTableAdapters.TBLDENEYIMTableAdapter();
        Repeater1.DataSource = DT.DeneyimListele();
        Repeater1.DataBind();
    }

}
```

### [Admin Paneli] Deneyim Ekle

![image](https://user-images.githubusercontent.com/95151751/231580625-f52363b0-6ae6-4fde-ab02-8ef36c29d613.png)

```c#
<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.master" AutoEventWireup="true" CodeFile="AdminDeneyimEkle.aspx.cs" Inherits="AdminDeneyimEkle" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">

        <form id="Form1" runat="server">
        <div class="form-group">
            <div>
                <asp:Label for="txtBaslik" runat="server" Text="BAŞLIK"></asp:Label>
                <asp:TextBox ID="txtBaslik" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            <br />
            <div>
                <asp:Label for="txtAltBaslik" runat="server" Text="ALT BAŞLIK"></asp:Label>
                <asp:TextBox ID="txtAltBaslik" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            <br />
            <div>
                <asp:Label for="txtAciklama" runat="server" Text="AÇIKLAMA"></asp:Label>
                <asp:TextBox ID="txtAciklama" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            <br />
            <div>
                <asp:Label for="txtTarih" runat="server" Text="TARİH"></asp:Label>
                <asp:TextBox ID="txtTarih" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            <br />
            <asp:Button ID="btnKaydet" CssClass="btn btn-info" runat="server" Text="KAYDET" OnClick="btnKaydet_Click" />

        </div>
    </form>

</asp:Content>


```

```c#
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AdminDeneyimEkle : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnKaydet_Click(object sender, EventArgs e)
    {
        DataSetTableAdapters.TBLDENEYIMTableAdapter dt = new DataSetTableAdapters.TBLDENEYIMTableAdapter();
        dt.DeneyimEkle(txtBaslik.Text, txtAltBaslik.Text, txtAciklama.Text, txtTarih.Text);
        Response.Redirect("AdminDeneyimler.aspx");
    }
}
```

### [Admin Paneli] Deneyim Sil

```c#
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AdminDeneyimSil : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        DataSetTableAdapters.TBLDENEYIMTableAdapter dt = new DataSetTableAdapters.TBLDENEYIMTableAdapter();
        dt.DeneyimSil(Convert.ToInt16(Request.QueryString["ID"]));
        Response.Redirect("AdminDeneyimler.aspx");
    }
}
```

### [Admin Paneli] Deneyim Güncelle

![image](https://user-images.githubusercontent.com/95151751/231580764-853e2fda-a052-4bf9-bc87-3e73c5fef77a.png)

```c#
<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.master" AutoEventWireup="true" CodeFile="AdminDeneyimGuncelle.aspx.cs" Inherits="AdminDeneyimGuncelle" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">

            <form id="Form1" runat="server">
        <div class="form-group">
            <div>
                <asp:Label for="txtID" runat="server" Text="ID"></asp:Label>
                <asp:TextBox ID="txtID" runat="server" CssClass="form-control" enabled="false" ></asp:TextBox>
            </div>
            <br />
            <div>
                <asp:Label for="txtBaslik" runat="server" Text="BAŞLIK"></asp:Label>
                <asp:TextBox ID="txtBaslik" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            <br />
            <div>
                <asp:Label for="txtAltBaslik" runat="server" Text="ALT BAŞLIK"></asp:Label>
                <asp:TextBox ID="txtAltBaslik" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            <br />
            <div>
                <asp:Label for="txtAciklama" runat="server" Text="AÇIKLAMA"></asp:Label>
                <asp:TextBox ID="txtAciklama" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            <br />
            <div>
                <asp:Label for="txtTarih" runat="server" Text="TARİH"></asp:Label>
                <asp:TextBox ID="txtTarih" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            <br />
            <asp:Button ID="btnGuncelle" CssClass="btn btn-success" runat="server" Text="Güncelle" OnClick="btnGuncelle_Click" />

        </div>
    </form>

</asp:Content>


```

```c#
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AdminDeneyimGuncelle : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            DataSetTableAdapters.TBLDENEYIMTableAdapter dt = new DataSetTableAdapters.TBLDENEYIMTableAdapter();
            txtID.Text = Request.QueryString["ID"];
            txtBaslik.Text = dt.DeneyimGetir(Convert.ToInt16(Request.QueryString["ID"]))[0].BASLIK;
            txtAltBaslik.Text = dt.DeneyimGetir(Convert.ToInt16(Request.QueryString["ID"]))[0].ALTBASLIK;
            txtAciklama.Text = dt.DeneyimGetir(Convert.ToInt16(Request.QueryString["ID"]))[0].ACIKLAMA;
            txtTarih.Text = dt.DeneyimGetir(Convert.ToInt16(Request.QueryString["ID"]))[0].TARIH;
        }
    }

    protected void btnGuncelle_Click(object sender, EventArgs e)
    {
        //if (!IsPostBack)
        //{
            DataSetTableAdapters.TBLDENEYIMTableAdapter dt = new DataSetTableAdapters.TBLDENEYIMTableAdapter();
            dt.DeneyimGuncelle(txtBaslik.Text, txtAltBaslik.Text, txtAciklama.Text, txtTarih.Text, Convert.ToInt16(txtID.Text));
            Response.Redirect("AdminDeneyimler.aspx");

        //}
    }
}
```

### [Admin Paneli] Eğitim Hayatım

![image](https://user-images.githubusercontent.com/95151751/231580859-390ce01b-6390-49e9-974f-132f974e3d29.png)

```c#
<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.master" AutoEventWireup="true" CodeFile="AdminEgitimler.aspx.cs" Inherits="AdminEgitimler" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">

        <form id="Form1" runat="server">

        <table class="table table-bordered">
            <tr>
                <th>ID</th>
                <th>BAŞLIK</th>
                <th>ALT BAŞLIK</th>
                <th>AÇIKLAMA</th>
                <th>GENEL NOT ORT</th>
                <th>TARİH</th>
                <th>İŞLEMLER</th>
            </tr>
            <tbody>
                <asp:Repeater ID="Repeater1" runat="server">
                    <ItemTemplate>
                        <tr>
                            <td><%# Eval("ID") %></td>
                            <td><%# Eval("BASLIK") %></td>
                            <td><%# Eval("ALTBASLIK") %></td>
                            <td><%# Eval("ACIKLAMA") %></td>
                            <td><%# Eval("GNOT") %></td>
                            <td><%# Eval("TARIH") %></td>
                            <td>
                                <asp:HyperLink ID="HyperLink1" NavigateUrl='<%# "AdminEgitimSil.aspx?ID="+ Eval("ID") %>' runat="server" CssClass="btn btn-danger">Sil</asp:HyperLink>
                                <asp:HyperLink ID="HyperLink2" NavigateUrl='<%# "AdminEgitimGuncelle.aspx?ID="+ Eval("ID") %>' runat="server" CssClass="btn btn-success">Güncelle</asp:HyperLink>
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
            </tbody>
        </table>
        <asp:HyperLink ID="HyperLink3" NavigateUrl="~/AdminEgitimEkle.aspx" runat="server" CssClass="btn btn-info">EĞİTİM EKLE</asp:HyperLink>
    </form>

</asp:Content>


```

```c#
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AdminEgitimler : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        DataSetTableAdapters.TBLEGITIMTableAdapter dt = new DataSetTableAdapters.TBLEGITIMTableAdapter();
        Repeater1.DataSource = dt.EgitimListele();
        Repeater1.DataBind();
    }
}
```

### [Admin Paneli] Eğitim Ekle

![image](https://user-images.githubusercontent.com/95151751/231580929-fbc9e0aa-05f7-4493-82d5-87bf3a0f3ccd.png)

```c#
<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.master" AutoEventWireup="true" CodeFile="AdminEgitimEkle.aspx.cs" Inherits="AdminEgitimEkle" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">

    <form id="Form1" runat="server">
        <div class="form-group">
            <div>
                <asp:Label for="txtBaslik" runat="server" Text="BAŞLIK"></asp:Label>
                <asp:TextBox ID="txtBaslik" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            <br />
            <div>
                <asp:Label for="txtAltBaslik" runat="server" Text="ALT BAŞLIK"></asp:Label>
                <asp:TextBox ID="txtAltBaslik" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            <br />
            <div>
                <asp:Label for="txtAciklama" runat="server" Text="AÇIKLAMA"></asp:Label>
                <asp:TextBox ID="txtAciklama" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            <br />
            <div>
                <asp:Label for="txtGenelNot" runat="server" Text="GENEL NOT ORTALAMASI"></asp:Label>
                <asp:TextBox ID="txtGenelNot" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            <br />
            <div>
                <asp:Label for="txtTarih" runat="server" Text="TARİH"></asp:Label>
                <asp:TextBox ID="txtTarih" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            <br />
            <asp:Button ID="btnKaydet" CssClass="btn btn-info" runat="server" Text="KAYDET" OnClick="btnKaydet_Click" />

        </div>
    </form>

</asp:Content>


```

```c#
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AdminEgitimEkle : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnKaydet_Click(object sender, EventArgs e)
    {
        DataSetTableAdapters.TBLEGITIMTableAdapter dt = new DataSetTableAdapters.TBLEGITIMTableAdapter();
        dt.EgitimEkle(txtBaslik.Text, txtAltBaslik.Text, txtAciklama.Text, txtGenelNot.Text, txtTarih.Text);
        Response.Redirect("AdminEgitimler.aspx");
    }
}
```

### [Admin Paneli] Eğitim Sil

```c#
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AdminEgitimSil : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        DataSetTableAdapters.TBLEGITIMTableAdapter dt = new DataSetTableAdapters.TBLEGITIMTableAdapter();
        dt.EgitimSil(Convert.ToInt16(Request.QueryString["ID"]));
        Response.Redirect("AdminEgitimler.aspx");
    }
}
```

### [Admin Paneli] Eğitim Güncelle

![image](https://user-images.githubusercontent.com/95151751/231581040-9b59c7a4-7240-403f-8055-e91b860e2fdc.png)

```c#
<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.master" AutoEventWireup="true" CodeFile="AdminEgitimGuncelle.aspx.cs" Inherits="AdminEgitimGuncelle" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">

        <form id="Form1" runat="server">
        <div class="form-group">
            <div>
                <asp:Label for="txtID" runat="server" Text="ID"></asp:Label>
                <asp:TextBox ID="txtID" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
            </div>
            <br />
            <div>
                <asp:Label for="txtBaslik" runat="server" Text="BAŞLIK"></asp:Label>
                <asp:TextBox ID="txtBaslik" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            <br />
            <div>
                <asp:Label for="txtAltBaslik" runat="server" Text="ALT BAŞLIK"></asp:Label>
                <asp:TextBox ID="txtAltBaslik" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            <br />
            <div>
                <asp:Label for="txtAciklama" runat="server" Text="AÇIKLAMA"></asp:Label>
                <asp:TextBox ID="txtAciklama" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            <br />
            <div>
                <asp:Label for="txtGenelNot" runat="server" Text="GENEL NOT ORTALAMASI"></asp:Label>
                <asp:TextBox ID="txtGenelNot" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            <br />
            <div>
                <asp:Label for="txtTarih" runat="server" Text="TARİH"></asp:Label>
                <asp:TextBox ID="txtTarih" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            <br />
            <asp:Button ID="btnGuncelle" CssClass="btn btn-success" runat="server" Text="Güncelle" OnClick="btnGuncelle_Click"/>

        </div>
    </form>

</asp:Content>


```

```c#
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AdminEgitimGuncelle : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            DataSetTableAdapters.TBLEGITIMTableAdapter dt = new DataSetTableAdapters.TBLEGITIMTableAdapter();
            short id = short.Parse(Request.QueryString["ID"]);
            txtID.Text = id.ToString();
            txtBaslik.Text = dt.EgitimGetir(id)[0].BASLIK;
            txtAltBaslik.Text = dt.EgitimGetir(id)[0].ALTBASLIK;
            txtAciklama.Text = dt.EgitimGetir(id)[0].ACIKLAMA;
            txtGenelNot.Text = dt.EgitimGetir(id)[0].GNOT;
            txtTarih.Text = dt.EgitimGetir(id)[0].TARIH;

        }
    }

    protected void btnGuncelle_Click(object sender, EventArgs e)
    {
        DataSetTableAdapters.TBLEGITIMTableAdapter dt = new DataSetTableAdapters.TBLEGITIMTableAdapter();
        dt.EgitimGuncelle(txtBaslik.Text, txtAltBaslik.Text, txtAciklama.Text, txtGenelNot.Text, txtTarih.Text, Convert.ToInt16(txtID.Text));
        Response.Redirect("AdminEgitimler.aspx");
    }
}
```

### [Admin Paneli] Yeteneklerim

![image](https://user-images.githubusercontent.com/95151751/231581127-e4036fdc-a73a-4c3e-ab94-5ed2c7bd99f6.png)

```c#
<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.master" AutoEventWireup="true" CodeFile="AdminYetenekler.aspx.cs" Inherits="AdminYetenekler" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">

    <form id="Form1" runat="server">

        <table class="table table-bordered">
            <tr>
                <th>ID</th>
                <th>YETENEKLER</th>
                <th>İŞLEMLER</th>
            </tr>
            <tbody>
                <asp:Repeater ID="Repeater1" runat="server">
                    <ItemTemplate>
                        <tr>
                            <td><%# Eval("ID") %></td>
                            <td><%# Eval("YETENEK") %></td>
                            <td>
                                <asp:HyperLink ID="HyperLink1" NavigateUrl='<%# "AdminYetenekSil.aspx?ID="+ Eval("ID") %>' runat="server" CssClass="btn btn-danger">Sil</asp:HyperLink>
                                <asp:HyperLink ID="HyperLink2" NavigateUrl='<%# "AdminYetenekGuncelle.aspx?ID="+ Eval("ID") %>' runat="server" CssClass="btn btn-success">Güncelle</asp:HyperLink>
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
            </tbody>
        </table>
        <asp:HyperLink ID="HyperLink3" NavigateUrl="~/AdminYetenekEkle.aspx" runat="server" CssClass="btn btn-info">YETENEK EKLE</asp:HyperLink>
    </form>

</asp:Content>


```

```c#
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AdminYetenekler : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        DataSetTableAdapters.TBLYETENEKLERTableAdapter dt = new DataSetTableAdapters.TBLYETENEKLERTableAdapter();
        Repeater1.DataSource = dt.YetenekListesi();
        Repeater1.DataBind();

    }
}
```

### [Admin Paneli] Yetenek Ekle

![image](https://user-images.githubusercontent.com/95151751/231581186-774cab56-78e2-49a1-94c6-1494e58d25b7.png)

```c#
<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.master" AutoEventWireup="true" CodeFile="AdminYetenekEkle.aspx.cs" Inherits="AdminYetenekEkle" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">

    <form id="Form1" runat="server">
        <div class="form-group">
            <div>
                <asp:Label for="txtYetenek" runat="server" Text="YETENEK"></asp:Label>
                <asp:TextBox ID="txtYetenek" runat="server" CssClass="form-control" placeholder="Yeteneğinizi girin..."></asp:TextBox>
            </div>
            <br />
            <asp:Button ID="btnKaydet" CssClass="btn btn-info" runat="server" Text="KAYDET" OnClick="btnKaydet_Click" />

        </div>
    </form>

</asp:Content>


```

```c#
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AdminYetenekEkle : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnKaydet_Click(object sender, EventArgs e)
    {
        DataSetTableAdapters.TBLYETENEKLERTableAdapter dt = new DataSetTableAdapters.TBLYETENEKLERTableAdapter();
        dt.YetenekEkle(txtYetenek.Text);
        Response.Redirect("AdminYetenekler.aspx");
    }
}
```

### [Admin Paneli] Yetenek Sil

```c#
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AdminYetenekSil : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        DataSetTableAdapters.TBLYETENEKLERTableAdapter dt = new DataSetTableAdapters.TBLYETENEKLERTableAdapter();
        dt.YetenekSil(short.Parse(Request.QueryString["ID"]));
        Response.Redirect("AdminYetenekler.aspx");
    }
}
```

### [Admin Paneli] Yetenek Güncelle

![image](https://user-images.githubusercontent.com/95151751/231581249-6078600a-c5d7-4ce4-82a8-4aed41eca556.png)

```c#
<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.master" AutoEventWireup="true" CodeFile="AdminYetenekGuncelle.aspx.cs" Inherits="AdminYetenekGuncelle" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">

    <form id="Form1" runat="server">
        <div class="form-group">
            <div>
                <asp:Label for="txtID" runat="server" Text="ID"></asp:Label>
                <asp:TextBox ID="txtID" runat="server" CssClass="form-control" Enabled="False"></asp:TextBox>
            </div>
            <br />
            <div>
                <asp:Label for="txtYetenek" runat="server" Text="YETENEK"></asp:Label>
                <asp:TextBox ID="txtYetenek" runat="server" CssClass="form-control" placeholder="Yeteneğinizi girin..."></asp:TextBox>
            </div>
            <br />
            <asp:Button ID="btnGuncelle" CssClass="btn btn-success" runat="server" Text="Güncelle" OnClick="btnGuncelle_Click" />

        </div>
    </form>

</asp:Content>


```

```c#
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AdminYetenekGuncelle : System.Web.UI.Page
{
    DataSetTableAdapters.TBLYETENEKLERTableAdapter dt = new DataSetTableAdapters.TBLYETENEKLERTableAdapter();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            txtID.Text = Request.QueryString["ID"];
            txtYetenek.Text = dt.YetenekGetir(short.Parse(Request.QueryString["ID"]))[0].YETENEK;
        }
    }

    protected void btnGuncelle_Click(object sender, EventArgs e)
    {
        dt.YetenekGuncelle(txtYetenek.Text, short.Parse(Request.QueryString["ID"]));
        Response.Redirect("AdminYetenekler.aspx");
    }
}
```

### [Admin Paneli] Hobilerim

![image](https://user-images.githubusercontent.com/95151751/231581406-9c2c0d90-b92c-46ff-a5ba-68769edcfea4.png)

```c#
<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.master" AutoEventWireup="true" CodeFile="AdminHobiler.aspx.cs" Inherits="AdminHobiler" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">

    <form id="Form1" runat="server">

        <table class="table table-bordered">
            <tr>
                <th>ID</th>
                <th>HOBİLER</th>
                <th>İŞLEMLER</th>
            </tr>
            <tbody>
                <asp:Repeater ID="Repeater1" runat="server">
                    <ItemTemplate>
                        <tr>
                            <td><%# Eval("ID") %></td>
                            <td><%# Eval("HOBI") %></td>
                            <td>
                                <asp:HyperLink ID="HyperLink1" NavigateUrl='<%# "AdminHobiSil.aspx?ID="+ Eval("ID") %>' runat="server" CssClass="btn btn-danger">Sil</asp:HyperLink>
                                <asp:HyperLink ID="HyperLink2" NavigateUrl='<%# "HobiGuncelle.aspx?ID="+ Eval("ID") %>' runat="server" CssClass="btn btn-success">Güncelle</asp:HyperLink>
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
            </tbody>
        </table>
        <asp:HyperLink ID="HyperLink3" NavigateUrl="~/AdminHobiEkle.aspx" runat="server" CssClass="btn btn-info">HOBİ EKLE</asp:HyperLink>
    </form>

</asp:Content>


```

```c#
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AdminHobiler : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        DataSetTableAdapters.TBLHOBILERTableAdapter dt = new DataSetTableAdapters.TBLHOBILERTableAdapter();
        Repeater1.DataSource = dt.HobilerListele();
        Repeater1.DataBind();
    }
}
```

### [Admin Paneli] Hobi Ekle

![image](https://user-images.githubusercontent.com/95151751/231581453-e6589641-d7f0-42f7-89fd-b68aa31c1e32.png)

```c#
<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.master" AutoEventWireup="true" CodeFile="AdminHobiEkle.aspx.cs" Inherits="AdminHobiEkle" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">

    <form id="Form1" runat="server">
        <div class="form-group">
            <div>
                <asp:Label for="txtHobi" runat="server" Text="HOBİ"></asp:Label>
                <asp:TextBox ID="txtHobi" runat="server" CssClass="form-control" placeholder="Hobinizi girin..."></asp:TextBox>
            </div>
            <br />
            <asp:Button ID="btnKaydet" CssClass="btn btn-info" runat="server" Text="KAYDET" OnClick="btnKaydet_Click" />

        </div>
    </form>

</asp:Content>


```

```c#
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AdminHobiEkle : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnKaydet_Click(object sender, EventArgs e)
    {
        DataSetTableAdapters.TBLHOBILERTableAdapter dt = new DataSetTableAdapters.TBLHOBILERTableAdapter();
        dt.HobiEkle(txtHobi.Text);
        Response.Redirect("AdminHobiler.aspx");
    }
}
```

### [Admin Paneli] Hobi Sil

```c#
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AdminHobiSil : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        DataSetTableAdapters.TBLHOBILERTableAdapter dt = new DataSetTableAdapters.TBLHOBILERTableAdapter();
        dt.HobiSil(short.Parse(Request.QueryString["ID"]));
        Response.Redirect("AdminHobiler.aspx");
    }
}
```

### [Admin Paneli] Hobi Güncelle

![image](https://user-images.githubusercontent.com/95151751/231581971-cd4d88cb-65de-4169-99f0-4529cab6f571.png)

```c#
<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.master" AutoEventWireup="true" CodeFile="HobiGuncelle.aspx.cs" Inherits="HobiGuncelle" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">

    <form id="Form1" runat="server">
        <div class="form-group">
            <div>
                <asp:Label for="txtID" runat="server" Text="ID"></asp:Label>
                <asp:TextBox ID="txtID" runat="server" CssClass="form-control" Enabled="False"></asp:TextBox>
            </div>
            <div>
                <asp:Label for="txtHobi" runat="server" Text="HOBİ"></asp:Label>
                <asp:TextBox ID="txtHobi" runat="server" CssClass="form-control" placeholder="Hobinizi girin..."></asp:TextBox>
            </div>
            <br />
            <asp:Button ID="btnGuncelle" CssClass="btn btn-success" runat="server" Text="Güncelle" OnClick="btnGuncelle_Click"/>

        </div>
    </form>

</asp:Content>


```

```c#
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class HobiGuncelle : System.Web.UI.Page
{

    DataSetTableAdapters.TBLHOBILERTableAdapter dt = new DataSetTableAdapters.TBLHOBILERTableAdapter();

    protected void Page_Load(object sender, EventArgs e)
    {
        short id = short.Parse(Request.QueryString["ID"]);
        if (!IsPostBack)
        {
            txtID.Text = id.ToString();
            txtHobi.Text = dt.HobiGetir(id)[0].HOBI;        
        }
    }

    protected void btnGuncelle_Click(object sender, EventArgs e)
    {
        dt.HobiGuncelle(txtHobi.Text, short.Parse(Request.QueryString["ID"]));
        Response.Redirect("AdminHobiler.aspx");
    }
}
```

### [Admin Paneli] Sertifikalarım

![image](https://user-images.githubusercontent.com/95151751/231582042-d1f06d50-2b6f-4f92-aa3b-bfdf3409c1bd.png)

```c#
<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.master" AutoEventWireup="true" CodeFile="AdminSertifikalar.aspx.cs" Inherits="AdminSertifikalar" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">

    <form id="Form1" runat="server">

        <table class="table table-bordered">
            <tr>
                <th>ID</th>
                <th>SERTİFİKALAR</th>
                <th>LİNK</th>
                <th>İŞLEMLER</th>
            </tr>
            <tbody>
                <asp:Repeater ID="Repeater1" runat="server">
                    <ItemTemplate>
                        <tr>
                            <td><%# Eval("ID") %></td>
                            <td><%# Eval("ODUL") %></td>
                            <td><%# Eval("LINK") %></td>
                            <td>
                                <asp:HyperLink ID="HyperLink1" NavigateUrl='<%# "AdminSertifikaSil.aspx?ID="+ Eval("ID") %>' runat="server" CssClass="btn btn-danger">Sil</asp:HyperLink>
                                <asp:HyperLink ID="HyperLink2" NavigateUrl='<%# "AdminSertifikaGuncelle.aspx?ID="+ Eval("ID") %>' runat="server" CssClass="btn btn-success">Güncelle</asp:HyperLink>
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
            </tbody>
        </table>
        <asp:HyperLink ID="HyperLink3" NavigateUrl="~/AdminSertifikaEkle.aspx" runat="server" CssClass="btn btn-info">SERTİFİKA EKLE</asp:HyperLink>
    </form>

</asp:Content>


```

```c#
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AdminSertifikalar : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        DataSetTableAdapters.TBLODULLERTableAdapter dt = new DataSetTableAdapters.TBLODULLERTableAdapter();
        Repeater1.DataSource = dt.SertifikaListele();
        Repeater1.DataBind();
    }
}
```

### [Admin Paneli] Sertifika Ekle

![image](https://user-images.githubusercontent.com/95151751/231582117-970239c8-5253-4c8b-b1f3-451465864aca.png)

```c#
<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.master" AutoEventWireup="true" CodeFile="AdminSertifikaEkle.aspx.cs" Inherits="AdminSertifikaEkle" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">

    <form id="Form1" runat="server">
        <div class="form-group">
            <div>
                <asp:Label for="txtSertifika" runat="server" Text="SERTİFİKA ADI"></asp:Label>
                <asp:TextBox ID="txtSertifika" runat="server" CssClass="form-control" placeholder="Sertifikanın adını girin..."></asp:TextBox>
            </div>
            <br />
            <div>
                <asp:Label for="txtLink" runat="server" Text="LİNK"></asp:Label>
                <asp:TextBox ID="txtLink" runat="server" CssClass="form-control" placeholder="Sertifikanın linkini girin..."></asp:TextBox>
            </div>
            <br />
            <asp:Button ID="btnKaydet" CssClass="btn btn-info" runat="server" Text="KAYDET" OnClick="btnKaydet_Click"/>

        </div>
    </form>

</asp:Content>
```

```c#
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AdminSertifikaEkle : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
    }

    protected void btnKaydet_Click(object sender, EventArgs e)
    {
        DataSetTableAdapters.TBLODULLERTableAdapter dt = new DataSetTableAdapters.TBLODULLERTableAdapter();
        dt.SertifikaEkle(txtSertifika.Text, txtLink.Text);
        Response.Redirect("AdminSertifikalar.aspx");
    }
}
```

### [Admin Paneli] Sertifika Sil

```c#
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AdminSertifikaSil : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        DataSetTableAdapters.TBLODULLERTableAdapter dt = new DataSetTableAdapters.TBLODULLERTableAdapter();
        dt.SertifikaSil(short.Parse(Request.QueryString["ID"]));
        Response.Redirect("AdminSertifikalar.aspx");
    }
}
```

### [Admin Paneli] Sertifika Güncelle

![image](https://user-images.githubusercontent.com/95151751/231582178-2d0e86c3-de25-42a8-9db9-08d311ecf10f.png)

```c#
<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.master" AutoEventWireup="true" CodeFile="AdminSertifikaGuncelle.aspx.cs" Inherits="AdminSertifikaGuncelle" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">

    <form id="Form1" runat="server">
        <div class="form-group">
            <div>
                <asp:Label for="txtID" runat="server" Text="ID"></asp:Label>
                <asp:TextBox ID="txtID" runat="server" CssClass="form-control" Enabled="False"></asp:TextBox>
            </div>
            <br />
            <div>
                <asp:Label for="txtSertifika" runat="server" Text="SERTİFİKA ADI"></asp:Label>
                <asp:TextBox ID="txtSertifika" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            <br />
            <div>
                <asp:Label for="txtLink" runat="server" Text="LİNK"></asp:Label>
                <asp:TextBox ID="txtLink" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            <br />
            <asp:Button ID="btnGuncelle" CssClass="btn btn-success" runat="server" Text="GÜNCELLE" OnClick="btnGuncelle_Click" />

        </div>
    </form>

</asp:Content>


```

```c#
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AdminSertifikaGuncelle : System.Web.UI.Page
{

    DataSetTableAdapters.TBLODULLERTableAdapter dt = new DataSetTableAdapters.TBLODULLERTableAdapter();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            short id = short.Parse(Request.QueryString["ID"]);
            txtID.Text = dt.SertifikaGetir(id)[0].ID.ToString();
            txtSertifika.Text = dt.SertifikaGetir(id)[0].ODUL.ToString();
            txtLink.Text = dt.SertifikaGetir(id)[0].LINK.ToString();
        }
    }

    protected void btnGuncelle_Click(object sender, EventArgs e)
    {
        dt.SertifikaGuncelle(txtSertifika.Text, txtLink.Text, short.Parse(txtID.Text));
        Response.Redirect("AdminSertifikalar.aspx");
    }
}
```


# 08- ASP.NET Bootstrap Entity Framework ile Blog Sitesi <a name="project8"></a>

### Anasayfa (Bloglar)
![bloglar](https://user-images.githubusercontent.com/95151751/232872206-917ef259-b94d-4450-8285-861e81b2bda4.png)

```c#
<%@ Page Title="" Language="C#" MasterPageFile="~/Kullanici.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="_08_ASPNET_Entity_Framework_Dizi_Blog_Sitesi.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="content-grids">
            <div class="col-md-8 content-main">
                <div class="content-grid">
                    <asp:Repeater ID="Repeater1" runat="server">
                        <ItemTemplate>
                            <div class="content-grid-info">
                                <img src='<%# Eval("BLOGGORSEL") %>' alt="" style="height: 500px; max-width: 600px" />
                                <div class="post-info">
                                    <h4><a href='BlogDetay.aspx?ID=<%# Eval("BLOGID") %>'>'<%# Eval("BLOGBASLIK") %>'</a>  '<%# Eval("BLOGTARIH") %>'</h4>
                                    <p>'<%# Eval("BLOGICERIK") %>'</p>
                                    <a href='BlogDetay.aspx?ID=<%# Eval("BLOGID") %>'><span></span>Devamını Oku</a>
                                </div>
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>
                </div>
            </div>
            <div class="col-md-4 content-right">
                <div class="recent">
                    <h3>En Son Bloglar</h3>
                    <ul>
                        <asp:Repeater ID="Repeater2" runat="server">
                            <ItemTemplate>
                                <li><a href="#"><%# Eval("BLOGBASLIK") %></a></li>
                            </ItemTemplate>
                        </asp:Repeater>
                    </ul>
                </div>
                <div class="comments">
                    <h3>Son Yorumlar</h3>
                    <ul>
                        <li><a href="#">Amada Doe </a>on <a href="#">Hello World!</a></li>
                        <li><a href="#">Peter Doe </a>on <a href="#">Photography</a></li>
                        <li><a href="#">Steve Roberts  </a>on <a href="#">HTML5/CSS3</a></li>
                    </ul>
                </div>
                <div class="clearfix"></div>
<%--                <div class="archives">
                    <h3>Arşivler</h3>
                    <ul>
                        <li><a href="#">Ocak 2023</a></li>
                        <li><a href="#">Şubat 2023</a></li>
                        <li><a href="#">Mart 2023</a></li>
                        <li><a href="#">Nisan 2023</a></li>
                    </ul>
                </div>--%>
                <div class="categories">
                    <h3>Kategoriler</h3>
                    <ul>
                        <asp:Repeater ID="Repeater3" runat="server">
                            <ItemTemplate>
                                <li><a href="#"><%# Eval("KATEGORIAD") %></a></li>
                            </ItemTemplate>
                        </asp:Repeater>
                    </ul>
                </div>
                <div class="clearfix"></div>
            </div>
            <div class="clearfix"></div>
        </div>
    </div>
</asp:Content>

```

```c#
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using _08_ASPNET_Entity_Framework_Dizi_Blog_Sitesi.Entity;

namespace _08_ASPNET_Entity_Framework_Dizi_Blog_Sitesi
{
    public partial class Default : System.Web.UI.Page
    {
        Dbo_BlogDiziEntities db = new Dbo_BlogDiziEntities();

        protected void Page_Load(object sender, EventArgs e)
        {
            Repeater1.DataSource = db.TBLBLOG.ToList();
            Repeater1.DataBind();

            Repeater2.DataSource = db.TBLBLOG.ToList();
            Repeater2.DataBind();

            Repeater3.DataSource = db.TBLKATEGORI.ToList();
            Repeater3.DataBind();
        }
    }
}
```

### Blog Detay
![BlogDetay](https://user-images.githubusercontent.com/95151751/232872542-691eb2ee-894b-49e3-aad1-72c92c1b1ac9.png)

```c#
<%@ Page Title="" Language="C#" MasterPageFile="~/Kullanici.Master" AutoEventWireup="true" CodeBehind="BlogDetay.aspx.cs" Inherits="_08_ASPNET_Entity_Framework_Dizi_Blog_Sitesi.BlogDetay" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <!DOCTYPE HTML>
    <html>
    <head>
        <link href="web/css/bootstrap.css" rel='stylesheet' type='text/css' />
        <link href="web/css/style.css" rel='stylesheet' type='text/css' />
        <meta name="viewport" content="width=device-width, initial-scale=1">
        <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
        <meta name="keywords" content="Personal Blog Responsive web template, Bootstrap Web Templates, Flat Web Templates, Andriod Compatible web template, 
	Smartphone Compatible web template, free webdesigns for Nokia, Samsung, LG, SonyErricsson, Motorola web design" />
        <script type="application/x-javascript"> addEventListener("load", function() { setTimeout(hideURLbar, 0); }, false); function hideURLbar(){ window.scrollTo(0,1); } </script>
        <!----webfonts---->
        <link href='http://fonts.googleapis.com/css?family=Oswald:100,400,300,700' rel='stylesheet' type='text/css'>
        <link href='http://fonts.googleapis.com/css?family=Lato:100,300,400,700,900,300italic' rel='stylesheet' type='text/css'>
        <!----//webfonts---->
        <script src="http://ajax.googleapis.com/ajax/libs/jquery/2.1.1/jquery.min.js"></script>
        <!--end slider -->
        <!--script-->
        <script type="text/javascript" src="web/js/move-top.js"></script>
        <script type="text/javascript" src="web/js/easing.js"></script>
        <!--/script-->
        <script type="text/javascript">
            jQuery(document).ready(function ($) {
                $(".scroll").click(function (event) {
                    event.preventDefault();
                    $('html,body').animate({ scrollTop: $(this.hash).offset().top }, 900);
                });
            });
        </script>
        <!---->

    </head>
    <body>
        <!---header---->
        <div class="header">
        </div>
        <!--/header-->
        <div class="single">
            <div class="container">
                <div class="col-md-8 single-main">
                    <div class="single-grid">
                        <asp:Repeater ID="Repeater1" runat="server">
                            <ItemTemplate>
                                <img src='<%# Eval("BLOGGORSEL") %>' alt="" style="height: 800px; max-width: 720px; margin-bottom: 20px;" />
                                <p style="font-weight: bold"><%# Eval("BLOGBASLIK") %></p>
                                <p><%# Eval("BLOGICERIK") %></p>
                            </ItemTemplate>
                        </asp:Repeater>
                    </div>
                    <asp:Repeater ID="Repeater2" runat="server">
                        <ItemTemplate>
                            <ul class="comment-list">
                                <li>
                                    <img src="web/images/avatar.png" class="img-responsive" alt="">
                                    <div class="desc">
                                        <p><a href="#" rel="author" style="font-weight: bold;"><%# Eval("KULLANICIAD") %>:</a></p>
                                        <p><%# Eval("YORUMICERIK") %></p>
                                    </div>
                                    <div class="clearfix"></div>
                                </li>
                            </ul>
                        </ItemTemplate>
                    </asp:Repeater>
                    <div class="content-form">
                        <h3>Bir Yorum Yap</h3>
                        <form runat="server">
                            <asp:TextBox ID="txtAd" runat="server" placeholder="Adınız" required=""></asp:TextBox>
                            <asp:TextBox ID="txtEmail" runat="server" placeholder="Email Adresiniz" required=""></asp:TextBox>
                            <asp:TextBox ID="txtMesaj" runat="server" placeholder="Mesajınız" required="" TextMode="MultiLine" Height="150px"></asp:TextBox>
                            <asp:Button ID="btnYorumYap" runat="server" Text="Yorum Yap" OnClick="btnYorumYap_Click" />
                        </form>
                    </div>
                </div>

                <div class="clearfix"></div>
            </div>
            <div class="clearfix"></div>
        </div>
    </body>
    </html>
</asp:Content>

```

```c#
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using _08_ASPNET_Entity_Framework_Dizi_Blog_Sitesi.Entity;

namespace _08_ASPNET_Entity_Framework_Dizi_Blog_Sitesi
{
    public partial class BlogDetay : System.Web.UI.Page
    {

        Dbo_BlogDiziEntities db = new Dbo_BlogDiziEntities();

        protected void Page_Load(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(Request.QueryString["ID"]);
            Repeater1.DataSource = db.TBLBLOG.Where(x => x.BLOGID == id).ToList();
            Repeater1.DataBind();

            Repeater2.DataSource = db.TBLYORUM.Where(x => x.YORUMBLOG == id).ToList();
            Repeater2.DataBind();
        }

        protected void btnYorumYap_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(Request.QueryString["ID"]);
            TBLYORUM t = new TBLYORUM();
            t.KULLANICIAD = txtAd.Text;
            t.MAIL = txtEmail.Text;
            t.YORUMICERIK = txtMesaj.Text;
            t.YORUMBLOG = id;
            db.TBLYORUM.Add(t);
            db.SaveChanges();
            Response.Redirect("BlogDetay.aspx?ID=" + id);
        }
    }
}
```

### Hakkımızda
![hakkimizda](https://user-images.githubusercontent.com/95151751/232872450-16c86c73-6a32-4bff-a7c6-0f63b27e36fa.png)

```c#
<%@ Page Title="" Language="C#" MasterPageFile="~/Kullanici.Master" AutoEventWireup="true" CodeBehind="Hakkimizda.aspx.cs" Inherits="_08_ASPNET_Entity_Framework_Dizi_Blog_Sitesi.Hakkimizda" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Repeater ID="Repeater1" runat="server">
        <ItemTemplate>
            <div class="container">
                <div class="about-section">
                    <div class="about-grid">
                        <h3>HAKKIMIZDA</h3>
                        <p><%# Eval("ACIKLAMA") %></p>
                    </div>
                </div>
            </div>
        </ItemTemplate>
    </asp:Repeater>
</asp:Content>

```

```c#
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using _08_ASPNET_Entity_Framework_Dizi_Blog_Sitesi.Entity;

namespace _08_ASPNET_Entity_Framework_Dizi_Blog_Sitesi
{
    public partial class Hakkimizda : System.Web.UI.Page
    {

        Dbo_BlogDiziEntities db = new Dbo_BlogDiziEntities();

        protected void Page_Load(object sender, EventArgs e)
        {
            Repeater1.DataSource = db.TBLHAKKIMIZDA.ToList();
            Repeater1.DataBind();
        }
    }
}
```

### İletişim
![iletisim](https://user-images.githubusercontent.com/95151751/232872476-c372a21e-15e4-4e63-8fa0-ac0cb9d7ac86.png)

```c#
<%@ Page Title="" Language="C#" MasterPageFile="~/Kullanici.Master" AutoEventWireup="true" CodeBehind="iletisim.aspx.cs" Inherits="_08_ASPNET_Entity_Framework_Dizi_Blog_Sitesi.iletisim" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="contact-content">
        <div class="container">
            <div class="contact-info">
                <h2>İLETİŞİM</h2>
                <p>Blog sayffamızda bulunan film ve dizilere eklemek istedikleriniz için veya yorumlarda yaşayacağınız herhangi bir problem olursa bu panelden bizlere mesaj gönderebilirsiniz. Mesaj gönderme sırasında mutlaka mail adresinizi doğru bir şekilde yazın ki bu mail üzerinden sizlere dönüş yapabilelim.</p>
            </div>
            <div class="contact-details">
                <form runat="server">
                    <asp:TextBox ID="txtAdSoyad" runat="server" placeholder="Ad Soyad" required></asp:TextBox>
                    <asp:TextBox ID="txtMail" runat="server" placeholder="Mail" required></asp:TextBox>
                    <asp:TextBox ID="txtTelefon" runat="server" placeholder="Telefon" required></asp:TextBox>
                    <asp:TextBox ID="txtKonu" runat="server" placeholder="Konu" required></asp:TextBox>
                    <asp:TextBox ID="txtMesaj" runat="server" placeholder="Mesajınız" required TextMode="MultiLine" Height="200px"></asp:TextBox>
                    <asp:Button ID="btnGonder" runat="server" Text="Gönder" OnClick="btnGonder_Click" />
                </form>
            </div>
            <div class="contact-details">
                <div class="col-md-6 contact-map">
                    <div style="max-width:100%;list-style:none; transition: none;overflow:hidden;width:500px;height:500px;"><div id="g-mapdisplay" style="height:100%; width:100%;max-width:100%;"><iframe style="height:100%;width:100%;border:0;" frameborder="0" src="https://www.google.com/maps/embed/v1/place?q=İstanbul,+Türkiye&key=AIzaSyBFw0Qbyq9zTFTd-tUY6dZWTgaQzuU17R8"></iframe></div><a class="googlecoder" rel="nofollow" href="https://www.bootstrapskins.com/themes" id="get-data-for-embed-map">premium bootstrap themes</a><style>#g-mapdisplay img.text-marker{max-width:none!important;background:none!important;}img{max-width:none}</style></div></div>
                <div class="col-md-6 company_address">
                    <h4>Adresimiz</h4>
                    <p>500 Lorem Ipsum Dolor Sit,</p>
                    <p>22-56-2-9 Sit Amet, Lorem,</p>
                    <p>USA</p>
                    <p>Phone:(00) 222 666 444</p>
                    <p>Fax: (000) 123 456 78 0</p>
                    <p>Email: <a href="mailto:info@example.com">info@mycompany.com</a></p>
                    <p>Follow on: <a href="#">Facebook</a>, <a href="#">Twitter</a></p>
                </div>
                <div class="clearfix"></div>
            </div>


        </div>
    </div>



</asp:Content>

```

```c#
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using _08_ASPNET_Entity_Framework_Dizi_Blog_Sitesi.Entity;

namespace _08_ASPNET_Entity_Framework_Dizi_Blog_Sitesi
{
    public partial class iletisim : System.Web.UI.Page
    {
        Dbo_BlogDiziEntities db = new Dbo_BlogDiziEntities();

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void btnGonder_Click(object sender, EventArgs e)
        {
            TBLILETISIM t = new TBLILETISIM();
            t.ADSOYAD = txtAdSoyad.Text;
            t.KONU = txtKonu.Text;
            t.MAIL = txtMail.Text;
            t.TELEFON = txtTelefon.Text;
            t.MESAJ = txtMesaj.Text;
            db.TBLILETISIM.Add(t);
            db.SaveChanges();
            Response.Redirect("iletisim.aspx");
        }
    }
}
```

### Ön Yüz Master Kodları

```c#
<%@ Master Language="C#" AutoEventWireup="true" CodeBehind="Kullanici.master.cs" Inherits="_08_ASPNET_Entity_Framework_Dizi_Blog_Sitesi.Kullanici" %>

<!--
Author: W3layouts
Author URL: http://w3layouts.com
License: Creative Commons Attribution 3.0 Unported
License URL: http://creativecommons.org/licenses/by/3.0/
-->
<!DOCTYPE HTML>
<html>
<head>
    <title>Personal Blog a Blogging Category Flat Bootstarp  Responsive Website Template | Home :: w3layouts</title>
    <asp:ContentPlaceHolder ID="ContentPlaceHolder2" runat="server"></asp:ContentPlaceHolder>
    <link href="web/css/bootstrap.css" rel='stylesheet' type='text/css' />
    <link href="web/css/style.css" rel='stylesheet' type='text/css' />
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="keywords" content="Personal Blog Responsive web template, Bootstrap Web Templates, Flat Web Templates, Andriod Compatible web template, 
	Smartphone Compatible web template, free webdesigns for Nokia, Samsung, LG, SonyErricsson, Motorola web design" />
    <script type="application/x-javascript"> addEventListener("load", function() { setTimeout(hideURLbar, 0); }, false); function hideURLbar(){ window.scrollTo(0,1); } </script>
    <!----webfonts---->
    <link href='http://fonts.googleapis.com/css?family=Oswald:100,400,300,700' rel='stylesheet' type='text/css'>
    <link href='http://fonts.googleapis.com/css?family=Lato:100,300,400,700,900,300italic' rel='stylesheet' type='text/css'>
    <!----//webfonts---->
    <script src="http://ajax.googleapis.com/ajax/libs/jquery/2.1.1/jquery.min.js"></script>
    <!--end slider -->
    <!--script-->
    <script type="text/javascript" src="web/js/move-top.js"></script>
    <script type="text/javascript" src="web/js/easing.js"></script>
    <!--/script-->
    <script type="text/javascript">
        jQuery(document).ready(function ($) {
            $(".scroll").click(function (event) {
                event.preventDefault();
                $('html,body').animate({ scrollTop: $(this.hash).offset().top }, 900);
            });
        });
    </script>
    <!---->

</head>
<body>
    <!---header---->
    <div class="header">
        <div class="container">
            <div class="logo">
                <a href="Default.aspx">
                    <img src="web/images/logo.jpg" title="" /></a>
            </div>
            <!---start-top-nav---->
            <div class="top-menu">
                <div class="search">
                    <form>
                        <input type="text" placeholder="" required="">
                        <input type="submit" value="" />
                    </form>
                </div>
                <span class="menu"></span>
                <ul>
                    <li><a href="Default.aspx">Bloglar</a></li>
                    <li><a href="Hakkimizda.aspx">Hakkımızda</a></li>
                    <li><a href="iletisim.aspx">İletişim</a></li>
                    <div class="clearfix"></div>
                </ul>
            </div>
            <div class="clearfix"></div>
            <script>
                $("span.menu").click(function () {
                    $(".top-menu ul").slideToggle("slow", function () {
                    });
                });
            </script>
            <!---//End-top-nav---->
        </div>
    </div>
    <!--/header-->
    <div class="content">
        <asp:ContentPlaceHolder ID="ContentPlaceHolder1" runat="server"></asp:ContentPlaceHolder>
    </div>
    <!---->
    <div class="footer">
        <div class="container">
            <p>Copyrights © 2023 Dizi&Film Blog Tüm Hakları Saklıdır | Template by <a href="http://w3layouts.com/">W3layouts</a></p>
        </div>
    </div>

```


### [Admin Sayfası] Bloglar
![Bloglar](https://user-images.githubusercontent.com/95151751/232873440-9d59ea16-f28e-44eb-aada-783a74bc1603.png)

```c#
<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="Bloglar.aspx.cs" Inherits="_08_ASPNET_Entity_Framework_Dizi_Blog_Sitesi.AdminSayfalar.Bloglar" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <table class="table table-bordered">
        <tr>
            <th>ID</th>
            <th>BAŞLIK</th>
            <th>TARİH</th>
            <th>TÜR</th>
            <th>KATEGORİ</th>
            <th>SİL</th>
            <th>GÜNCELLE</th>
        </tr>
        <asp:Repeater ID="Repeater1" runat="server">
            <ItemTemplate>
                <tr>
                    <td><%# Eval("BLOGID") %></td>
                    <td><%# Eval("BLOGBASLIK") %></td>
                    <td><%# Eval("BLOGTARIH") %></td>
                    <td><%# Eval("BLOGTUR") %></td>
                    <td><%# Eval("BLOGKATEGORI") %></td>
                    <td>
                        <asp:HyperLink ID="HyperLink1" runat="server" CssClass="btn btn-danger" NavigateUrl='<%# "BlogSil.aspx?BLOGID="+Eval("BLOGID") %>'>Sil</asp:HyperLink>
                    </td>
                    <td>
                        <asp:HyperLink ID="HyperLink2" runat="server" CssClass="btn btn-success" NavigateUrl='<%# "BlogGuncelle.aspx?BLOGID="+Eval("BLOGID") %>'>Güncelle</asp:HyperLink>

                    </td>
                </tr>
            </ItemTemplate>
        </asp:Repeater>
    </table>
    <a href="YeniBlog.aspx" class="btn btn-primary">Yeni Blog</a>
</asp:Content>

```

```c#
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using _08_ASPNET_Entity_Framework_Dizi_Blog_Sitesi.Entity;

namespace _08_ASPNET_Entity_Framework_Dizi_Blog_Sitesi.AdminSayfalar
{
    public partial class Bloglar : System.Web.UI.Page
    {
        Dbo_BlogDiziEntities db = new Dbo_BlogDiziEntities();

        protected void Page_Load(object sender, EventArgs e)
        {
            Repeater1.DataSource = db.TBLBLOG.ToList();
            Repeater1.DataBind();
        }
    }
}
```

### [Admin Sayfası] Yeni Blog
![YeniBlog](https://user-images.githubusercontent.com/95151751/232873512-17d7bee1-3146-42da-80f7-ec1355c5d1b2.png)


```c#
<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="YeniBlog.aspx.cs" Inherits="_08_ASPNET_Entity_Framework_Dizi_Blog_Sitesi.AdminSayfalar.YeniBlog" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <form runat="server" class="form-group">
        <asp:TextBox id="txtBaslik" runat="server" CssClass="form-control" placeholder="Blog Başlık"></asp:TextBox>
        <br />
        <asp:TextBox id="txtTarih" runat="server" CssClass="form-control" placeholder="Blog Tarih"></asp:TextBox>
        <br />
        <asp:TextBox id="txtGorsel" runat="server" CssClass="form-control" placeholder="Blog Görsel"></asp:TextBox>
        <br />
        <asp:DropDownList id="drpTur" runat="server" CssClass="form-control" DataTextField="TURAD" DataValueField="TURID"></asp:DropDownList>
        <br />
        <asp:DropDownList id="drpKategori" runat="server" CssClass="form-control" DataTextField="KATEGORIAD" DataValueField="KATEGORIID"></asp:DropDownList>
        <br />
        <asp:TextBox id="txtIcerik" runat="server" CssClass="form-control" placeholder="Blog İçerik" textmode="multiline" height="200px"></asp:TextBox>
        <br />
        <asp:Button id="btnKaydet" runat="server" Text="Kaydet" CssClass="btn btn-primary" OnClick="btnKaydet_Click" />
    </form>

</asp:Content>

```

```c#
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using _08_ASPNET_Entity_Framework_Dizi_Blog_Sitesi.Entity;

namespace _08_ASPNET_Entity_Framework_Dizi_Blog_Sitesi.AdminSayfalar
{
    public partial class YeniBlog : System.Web.UI.Page
    {
        Dbo_BlogDiziEntities db = new Dbo_BlogDiziEntities();

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                //Türleri Listeleme
                drpTur.DataSource = (from x in db.TBLTUR
                                     select new
                                     {
                                         x.TURID,
                                         x.TURAD
                                     }).ToList();
                drpTur.DataBind();


                //Kategorileri Listeleme
                drpKategori.DataSource = (from x in db.TBLKATEGORI
                                          select new
                                          {
                                              x.KATEGORIID,
                                              x.KATEGORIAD
                                          }).ToList();
                drpKategori.DataBind();
            }
        }

        protected void btnKaydet_Click(object sender, EventArgs e)
        {
            TBLBLOG t = new TBLBLOG();
            t.BLOGBASLIK = txtBaslik.Text;
            t.BLOGTARIH = DateTime.Parse(txtTarih.Text);
            t.BLOGGORSEL = txtGorsel.Text;
            t.BLOGTUR = byte.Parse(drpTur.SelectedValue);
            t.BLOGKATEGORI = byte.Parse(drpKategori.SelectedValue);
            t.BLOGICERIK = txtIcerik.Text;
            db.TBLBLOG.Add(t);
            db.SaveChanges();
            Response.Redirect("Bloglar.aspx");
        }
    }
}
```


### [Admin Sayfası] Blog Sil

```c#
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using _08_ASPNET_Entity_Framework_Dizi_Blog_Sitesi.Entity;

namespace _08_ASPNET_Entity_Framework_Dizi_Blog_Sitesi.AdminSayfalar
{
    public partial class BlogSil : System.Web.UI.Page
    {

        Dbo_BlogDiziEntities db = new Dbo_BlogDiziEntities();

        protected void Page_Load(object sender, EventArgs e)
        {
            int id = int.Parse(Request.QueryString["BLOGID"]);
            db.TBLBLOG.Remove(db.TBLBLOG.Find(id));
            db.SaveChanges();
            Response.Redirect("Bloglar.aspx");
        }
    }
}
```

### [Admin Sayfası] Blog Güncelle
![BlogGuncelle](https://user-images.githubusercontent.com/95151751/232873751-75a4a863-9838-4292-8cf1-bfc2cd72849b.png)


```c#
<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="BlogGuncelle.aspx.cs" Inherits="_08_ASPNET_Entity_Framework_Dizi_Blog_Sitesi.AdminSayfalar.BlogGuncelle" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <form runat="server" class="form-group">
        <asp:TextBox ID="txtID" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
        <br />
        <asp:TextBox ID="txtBaslik" runat="server" CssClass="form-control" placeholder="Blog Başlık"></asp:TextBox>
        <br />
        <asp:TextBox ID="txtTarih" runat="server" CssClass="form-control" placeholder="Blog Tarih"></asp:TextBox>
        <br />
        <asp:TextBox ID="txtGorsel" runat="server" CssClass="form-control" placeholder="Blog Görsel"></asp:TextBox>
        <br />
        <asp:DropDownList ID="drpTur" runat="server" CssClass="form-control" DataTextField="TURAD" DataValueField="TURID"></asp:DropDownList>
        <br />
        <asp:DropDownList ID="drpKategori" runat="server" CssClass="form-control" DataTextField="KATEGORIAD" DataValueField="KATEGORIID"></asp:DropDownList>
        <br />
        <asp:TextBox ID="txtIcerik" runat="server" CssClass="form-control" placeholder="Blog İçerik" TextMode="multiline" Height="200px"></asp:TextBox>
        <br />
        <asp:Button ID="btnGuncelle" runat="server" Text="Güncelle" CssClass="btn btn-success" OnClick="btnGuncelle_Click" />
    </form>

</asp:Content>

```

```c#
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using _08_ASPNET_Entity_Framework_Dizi_Blog_Sitesi.Entity;

namespace _08_ASPNET_Entity_Framework_Dizi_Blog_Sitesi.AdminSayfalar
{
    public partial class BlogGuncelle : System.Web.UI.Page
    {
        Dbo_BlogDiziEntities db = new Dbo_BlogDiziEntities();

        protected void Page_Load(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(Request.QueryString["BLOGID"]);

            if (!IsPostBack)
            {
                //Türleri Listeleme
                drpTur.DataSource = (from x in db.TBLTUR
                                     select new
                                     {
                                         x.TURID,
                                         x.TURAD
                                     }).ToList();
                drpTur.DataBind();


                //Kategorileri Listeleme
                drpKategori.DataSource = (from x in db.TBLKATEGORI
                                          select new
                                          {
                                              x.KATEGORIID,
                                              x.KATEGORIAD
                                          }).ToList();
                drpKategori.DataBind();
            }



            var deger = db.TBLBLOG.Find(id);

            txtID.Text = deger.BLOGID.ToString();
            txtBaslik.Text = deger.BLOGBASLIK;
            txtTarih.Text = deger.BLOGTARIH.ToString();
            txtGorsel.Text = deger.BLOGGORSEL;
            drpKategori.SelectedValue = deger.BLOGKATEGORI.ToString();
            drpTur.SelectedValue = deger.BLOGTUR.ToString();
            txtIcerik.Text = deger.BLOGICERIK;

        }

        protected void btnGuncelle_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(Request.QueryString["BLOGID"]);

            var deger = db.TBLBLOG.Find(id);
            deger.BLOGBASLIK = txtBaslik.Text;
            deger.BLOGTARIH = DateTime.Parse(txtTarih.Text);
            deger.BLOGGORSEL = txtGorsel.Text;
            deger.BLOGKATEGORI = byte.Parse(drpKategori.SelectedValue);
            deger.BLOGTUR = byte.Parse(drpTur.SelectedValue);
            deger.BLOGICERIK = txtIcerik.Text;
            db.SaveChanges();
            Response.Redirect("Bloglar.aspx");
            
        }
    }
}
```


### [Admin Sayfası] Yorumlar
![Yorumlar](https://user-images.githubusercontent.com/95151751/232873809-a8625879-7084-4cbc-9cd1-3338835414d1.png)


```c#
<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="Yorumlar.aspx.cs" Inherits="_08_ASPNET_Entity_Framework_Dizi_Blog_Sitesi.AdminSayfalar.Yorumlar" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <table class="table table-bordered">
        <tr>
            <th>ID</th>
            <th>KULLANICI</th>
            <th>BLOG</th>
            <th>SİL</th>
        </tr>
        <asp:Repeater ID="Repeater1" runat="server">
            <ItemTemplate>
                <tr>
                    <td><%# Eval("YORUMID") %></td>
                    <td><%# Eval("KULLANICIAD") %></td>
                    <td><%# Eval("BLOGBASLIK") %></td>
                    <td>
                        <asp:HyperLink ID="HyperLink1" runat="server" CssClass="btn btn-danger" NavigateUrl='<%# "YorumSil.aspx?YORUMID="+Eval("YORUMID") %>'>Sil</asp:HyperLink>
                    </td>
<%--                    <td>
                        <asp:HyperLink ID="HyperLink2" runat="server" CssClass="btn btn-success" NavigateUrl='<%# "YorumGuncelle.aspx?YORUMID="+Eval("YORUMID") %>'>Güncelle</asp:HyperLink>

                    </td>--%>
                </tr>
            </ItemTemplate>
        </asp:Repeater>
    </table>


</asp:Content>

```

```c#
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using _08_ASPNET_Entity_Framework_Dizi_Blog_Sitesi.Entity;

namespace _08_ASPNET_Entity_Framework_Dizi_Blog_Sitesi.AdminSayfalar
{
    public partial class Yorumlar : System.Web.UI.Page
    {
        Dbo_BlogDiziEntities db = new Dbo_BlogDiziEntities();

        protected void Page_Load(object sender, EventArgs e)
        {
            Repeater1.DataSource = (from x in db.TBLYORUM
                                    select new
                                    {
                                        x.YORUMID,
                                        x.KULLANICIAD,
                                        x.TBLBLOG.BLOGBASLIK
                                    }).ToList();
            Repeater1.DataBind();
        }
    }
}
```


### Admin Sayfası Master Kodları

```c#
<%@ Master Language="C#" AutoEventWireup="true" CodeBehind="Admin.master.cs" Inherits="_08_ASPNET_Entity_Framework_Dizi_Blog_Sitesi.Admin" %>

<!DOCTYPE html>
<html lang="en">
<head>
  <title>Admin Paneli</title>
  <meta charset="utf-8">
  <meta name="viewport" content="width=device-width, initial-scale=1">
  <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/css/bootstrap.min.css">
  <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.6.4/jquery.min.js"></script>
  <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/js/bootstrap.min.js"></script>
</head>
<body>

<nav class="navbar navbar-inverse">
  <div class="container-fluid">
    <div class="navbar-header">
      <a class="navbar-brand" href="../Default.aspx" style="background-color:black;" target="_blank">Dizi & Film Sitesi</a>
    </div>
    <ul class="nav navbar-nav">
      <li><a href="Bloglar.aspx">Bloglar</a></li>
      <li><a href="Yorumlar.aspx">Yorumlar</a></li>
      <li><a href="Mesajlar.aspx">Mesajlar</a></li>
      <li><a href="Hakkimizda.aspx">Hakkımızda</a></li>
    </ul>
  </div>
</nav>
  
<div class="container">
    <asp:ContentPlaceHolder ID="ContentPlaceHolder1" runat="server"></asp:ContentPlaceHolder>
</div>

</body>
</html>

```


# 09- ASP.NET Katmanli Mimari'de Mini Yaz Okulu Projesi <a name="project9"></a>

### Öğrenci Listesi
![OgrenciListesi](https://user-images.githubusercontent.com/95151751/232912975-a9124f86-ab6f-4f5a-9101-95ec794724d3.png)

```c#
<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="OgrenciListesi.aspx.cs" Inherits="OgrenciListesi" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <table class="table table-bordered table-hover">
        <tr>
            <th>Öğrenci ID</th>
            <th>Öğrenci Ad</th>
            <th>Öğrenci Soyad</th>
            <th>Öğrenci Numara</th>
            <th>Öğrenci Şifre</th>
            <th>Öğrenci Fotoğraf</th>
            <th>Bakiye</th>
            <th>İşlemler</th>
        </tr>
        <tbody>
            <asp:Repeater ID="Repeater1" runat="server">
                <ItemTemplate>
                    <tr>
                        <td><%# Eval("OGRID") %></td>
                        <td><%# Eval("AD") %></td>
                        <td><%# Eval("SOYAD") %></td>
                        <td><%# Eval("NUMARA") %></td>
                        <td><%# Eval("SIFRE") %></td>
                        <td><%# Eval("FOTOGRAF") %></td>
                        <td><%# Eval("BAKIYE") %></td>
                        <td>
                            <asp:HyperLink ID="HyperLink1"  CssClass="btn btn-danger" runat="server" NavigateUrl='<%# "OgrenciSil.aspx?OGRID="+Eval("OGRID") %>'>Sil</asp:HyperLink>
                            <asp:HyperLink ID="HyperLink2" CssClass="btn btn-success" runat="server" NavigateUrl='<%# "OgrenciGuncelle.aspx?OGRID="+Eval("OGRID") %>'>Güncelle</asp:HyperLink>
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
        </tbody>
    </table>
</asp:Content>


```

```c#
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EntityLayer;
using DataAccessLayer;
using BusinessLogicLayer;

public partial class OgrenciListesi : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        List<EntityOgrenci> ogrList = BLLOgrenci.BllListele();
        Repeater1.DataSource = ogrList;
        Repeater1.DataBind();
    }
}
```

### Öğrenci Yeni Kayıt
![YeniKayıt](https://user-images.githubusercontent.com/95151751/232913050-3fc3e142-bf1b-4586-9102-2aaa5d10ad94.png)


```c#
<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <form runat="server">
        <div class="form-group">
            <div>
                <asp:Label for="txtOgrAd" runat="server" Text="Öğrenci Adı:" Font-Bold="True"></asp:Label>
                <asp:TextBox runat="server" id="txtOgrAd" CssClass="form-control"></asp:TextBox>
            </div>
            <br />
            <div>
                <asp:Label for="txtOgrSoyad" runat="server" Text="Öğrenci Soyadı:" Font-Bold="True"></asp:Label>
                <asp:TextBox runat="server" id="txtOgrSoyad" CssClass="form-control"></asp:TextBox>
            </div>
            <br />
            <div>
                <asp:Label for="txtOgrNumara" runat="server" Text="Öğrenci Numara:" Font-Bold="True"></asp:Label>
                <asp:TextBox runat="server" id="txtOgrNumara" CssClass="form-control"></asp:TextBox>
            </div>
            <br />
            <div>
                <asp:Label for="txtOgrSifre" runat="server" Text="Öğrenci Şifre:" Font-Bold="True"></asp:Label>
                <asp:TextBox runat="server" id="txtOgrSifre" CssClass="form-control"></asp:TextBox>
            </div>
            <br />
            <div>
                <asp:Label for="txtOgrFoto" runat="server" Text="Öğrenci Fotoğraf:" Font-Bold="True"></asp:Label>
                <asp:TextBox runat="server" id="txtOgrFoto" CssClass="form-control"></asp:TextBox>
            </div>
            <br />
            <asp:Button runat="server" Text="Kaydet" id="btnKaydet" CssClass="btn btn-primary" OnClick="btnKaydet_Click" />


        </div>

    </form>
</asp:Content>


```

```c#
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EntityLayer;
using DataAccessLayer;
using BusinessLogicLayer;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnKaydet_Click(object sender, EventArgs e)
    {
        EntityOgrenci ent = new EntityOgrenci();
        ent.AD = txtOgrAd.Text;
        ent.SOYAD = txtOgrSoyad.Text;
        ent.NUMARA = txtOgrNumara.Text;
        ent.SIFRE = txtOgrSifre.Text;
        ent.FOTOGRAF = txtOgrFoto.Text;
        BLLOgrenci.OgrenciEkleBLL(ent);
        Response.Redirect("OgrenciListesi.aspx");
    }
}
```

### Öğrenci Sil

```c#
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EntityLayer;
using DataAccessLayer;
using BusinessLogicLayer;

public partial class OgrenciSil : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        EntityOgrenci ent = new EntityOgrenci();
        ent.OGRID = Convert.ToInt32(Request.QueryString["OGRID"]);
        BLLOgrenci.BLLOgrenciSil(ent.OGRID);
        Response.Redirect("OgrenciListesi.aspx");
    }
}
```

### Öğrenci Güncelle
![OgrenciGuncelle](https://user-images.githubusercontent.com/95151751/232913064-8d20f425-6dae-447e-849f-4d2782c7e414.png)


```c#
<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="OgrenciGuncelle.aspx.cs" Inherits="OgrenciGuncelle" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <form runat="server">
        <div class="form-group">
            <div>
                <asp:Label for="txtOgrID" runat="server" Text="Öğrenci ID:" Font-Bold="True"></asp:Label>
                <asp:TextBox runat="server" ID="txtOgrID" CssClass="form-control"></asp:TextBox>
            </div>
            <br />
            <div>
                <asp:Label for="txtOgrAd" runat="server" Text="Öğrenci Adı:" Font-Bold="True"></asp:Label>
                <asp:TextBox runat="server" ID="txtOgrAd" CssClass="form-control"></asp:TextBox>
            </div>
            <br />
            <div>
                <asp:Label for="txtOgrSoyad" runat="server" Text="Öğrenci Soyadı:" Font-Bold="True"></asp:Label>
                <asp:TextBox runat="server" ID="txtOgrSoyad" CssClass="form-control"></asp:TextBox>
            </div>
            <br />
            <div>
                <asp:Label for="txtOgrNumara" runat="server" Text="Öğrenci Numara:" Font-Bold="True"></asp:Label>
                <asp:TextBox runat="server" ID="txtOgrNumara" CssClass="form-control"></asp:TextBox>
            </div>
            <br />
            <div>
                <asp:Label for="txtOgrSifre" runat="server" Text="Öğrenci Şifre:" Font-Bold="True"></asp:Label>
                <asp:TextBox runat="server" ID="txtOgrSifre" CssClass="form-control"></asp:TextBox>
            </div>
            <br />
            <div>
                <asp:Label for="txtOgrFoto" runat="server" Text="Öğrenci Fotoğraf:" Font-Bold="True"></asp:Label>
                <asp:TextBox runat="server" ID="txtOgrFoto" CssClass="form-control"></asp:TextBox>
            </div>
            <br />
            <asp:Button runat="server" Text="Güncelle" ID="btnGuncelle" CssClass="btn btn-success" OnClick="btnGuncelle_Click" />


        </div>

    </form>

</asp:Content>


```

```c#
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EntityLayer;
using DataAccessLayer;
using BusinessLogicLayer;

public partial class OgrenciGuncelle : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        int id = Convert.ToInt32(Request.QueryString["OGRID"]);
        txtOgrID.Text = id.ToString();
        txtOgrID.Enabled = false;

        if (!IsPostBack)
        {
            List<EntityOgrenci> ogrList = BLLOgrenci.BLLDetay(id);
            txtOgrAd.Text = ogrList[0].AD.ToString();
            txtOgrSoyad.Text = ogrList[0].SOYAD.ToString();
            txtOgrNumara.Text = ogrList[0].NUMARA.ToString();
            txtOgrFoto.Text = ogrList[0].SIFRE.ToString();
            txtOgrSifre.Text = ogrList[0].SIFRE.ToString();
        }
    }

    protected void btnGuncelle_Click(object sender, EventArgs e)
    {
        EntityOgrenci ent = new EntityOgrenci();
        ent.AD = txtOgrAd.Text;
        ent.SOYAD = txtOgrSoyad.Text;
        ent.SIFRE = txtOgrSifre.Text;
        ent.NUMARA = txtOgrNumara.Text;
        ent.FOTOGRAF = txtOgrFoto.Text;
        ent.OGRID = Convert.ToInt32(txtOgrID.Text);
        BLLOgrenci.BLLOgrenciGuncelle(ent);
        Response.Redirect("OgrenciListesi.aspx");
    }
}
```

### Ders Talebi Oluştur
![Dersler](https://user-images.githubusercontent.com/95151751/232913088-3975c3fc-93bd-4b4b-b212-529c8cd5935e.png)

```c#
<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Dersler.aspx.cs" Inherits="Dersler" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <form runat="server">
        <div>
            <asp:Label ID="Label1" runat="server" Text="Ders Seçin"></asp:Label>
            <asp:DropDownList ID="DropDownList1" runat="server" CssClass="form-control"></asp:DropDownList>
        </div>
        <br />
        <div>
            <asp:Label ID="Label2" runat="server" Text="Öğrenci ID"></asp:Label>
            <asp:TextBox ID="TextBox1" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
        <br />
        <asp:Button ID="btnTalep" runat="server" Text="Ders Talebi Oluştur" CssClass="btn btn-warning" OnClick="btnTalep_Click" />
    </form>
</asp:Content>


```

```c#
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EntityLayer;
using DataAccessLayer;
using BusinessLogicLayer;

public partial class Dersler : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            List<EntityDers> entDers = BLLDers.BllListele();
            DropDownList1.DataSource = BLLDers.BllListele();
            DropDownList1.DataTextField = "DERSAD";
            DropDownList1.DataValueField = "DERSID";
            DropDownList1.DataBind();

        }
    }

    protected void btnTalep_Click(object sender, EventArgs e)
    {
        EntityBasvuruForm ent = new EntityBasvuruForm();
        ent.BASOGRID = int.Parse(TextBox1.Text);
        ent.BASDERSID = int.Parse(DropDownList1.SelectedValue.ToString());
        BLLDers.BLLTalepEkle(ent);
        Response.Redirect("Dersler.aspx");
    }
}
```

# 10- Mvc5 Ürün Takip Projesi <a name="project10"></a>

### Ürünler
![Urunler-1](https://user-images.githubusercontent.com/95151751/232947681-11c3d4c1-b93b-474b-8389-34892983391b.png)

![Urunler-2](https://user-images.githubusercontent.com/95151751/232947697-cb6e4f4b-a98b-473a-83de-e09f044c0beb.png)

![UrunArama](https://user-images.githubusercontent.com/95151751/232947726-6cefabe2-0ec0-4c5a-a04f-87338599d890.png)

```c#
@using _10_MVC01_Youtube_Proje.Models.Entity;
@model List<TBLURUNLER>
@{
    ViewBag.Title = "Index";
    Layout = "~/Views/Shared/_MainLayout.cshtml";
}

<table class="table table-bordered" id="tbl1">
    <thead>
        <tr>
            <th>ÜRÜN ID</th>
            <th>ÜRÜN ADI</th>
            <th>MARKASI</th>
            <th>KATEGORİ</th>
            <th>FİYAT</th>
            <th>STOK</th>
            <th>SİL</th>
            <th>GÜNCELLE</th>
        </tr>
    </thead>
    <tbody>
        @foreach (var urun in Model)
        {
            <tr>
                <th>@urun.URUNID</th>
                <td>@urun.URUNAD</td>
                <td>@urun.MARKA</td>
                <td>
                    @if (urun.TBLKATEGORILER != null)
                    {@urun.TBLKATEGORILER.KATEGORIAD}
            </td>
            <td>@urun.FIYAT</td>
            <td>@urun.STOK</td>
            <td><a href="/URUN/SIL/@urun.URUNID" class="btn btn-danger">SİL</a></td>
            <td><a href="/URUN/UrunGetir/@urun.URUNID" class="btn btn-success">GÜNCELLE</a></td>

        </tr>
    }
    </tbody>
</table>
<a href="/URUN/YeniUrun" class="btn btn-primary"> YENİ URUN EKLE</a>

<script type="text/javascript" src="https://cdn.datatables.net/1.10.22/js/jquery.dataTables.min.js"></script>
<link href="https://cdn.datatables.net/1.10.22/css/jquery.dataTables.min.css" rel="stylesheet" />

<script>
    $("#tbl1").DataTable({
        "language": {
            "url": "//cdn.datatables.net/plug-ins/1.10.24/i18n/Turkish.json"
        }
    });
</script>



```

### Yeni Ürün Ekleme
![YeniUrun](https://user-images.githubusercontent.com/95151751/232947801-ae433b3f-0c1d-4b15-8713-63871089ce2e.png)


```c#
@model _10_MVC01_Youtube_Proje.Models.Entity.TBLURUNLER
@{
    ViewBag.Title = "YeniUrun";
    Layout = "~/Views/Shared/_MainLayout.cshtml";
}

<form method="post" class="form-group">
    <div>
        <label>Ürün Adı</label>
        <input type="text" class="form-control" name="URUNAD" required="" maxlength="30" />
    </div>
    <div style="margin-top:10px">
        <label>Marka</label>
        <input type="text" class="form-control" name="MARKA" required="" maxlength="30" />
    </div>
    <div style="margin-top:10px">
        <label>Kategori Seçiniz</label>
        @Html.DropDownListFor(m => m.TBLKATEGORILER.KATEGORIID, (List<SelectListItem>)ViewBag.dgr, new { @class = "form-control"})
    </div>
    <div style="margin-top:10px">
        <label>Fiyat</label>
        <input type="text" class="form-control" name="FIYAT" required="" maxlength="30" />
    </div>
    <div style="margin-top:10px">
        <label>Stok</label>
        <input type="text" class="form-control" name="STOK" required="" maxlength="30" />
    </div>
    <div style="margin-top:15px">
        <button class="btn btn-info">Ürün Ekle</button>
    </div>
</form>



```


### Ürün Güncelleme
![UrunGuncelle](https://user-images.githubusercontent.com/95151751/232947853-a8e1e358-6f1c-4974-96f0-adcaf29f33b4.png)


```c#
@model _10_MVC01_Youtube_Proje.Models.Entity.TBLURUNLER
@{
    ViewBag.Title = "UrunGetir";
    Layout = "~/Views/Shared/_MainLayout.cshtml";
}

@using (Html.BeginForm("Guncelle", "Urun", FormMethod.Post))
{
    <div class="form-group">
        @Html.LabelFor(m => m.URUNID)
        @Html.TextBoxFor(m => m.URUNID, new { @class = "form-control" })
        <br />
        @Html.LabelFor(m => m.URUNAD)
        @Html.TextBoxFor(m => m.URUNAD, new { @class = "form-control" })
        <br />
        @Html.LabelFor(m => m.MARKA)
        @Html.TextBoxFor(m => m.MARKA, new { @class = "form-control" })
        <br />
        @Html.LabelFor(m => m.URUNKATEGORI)
        @Html.DropDownListFor(m=>m.TBLKATEGORILER.KATEGORIID,(List<SelectListItem>)ViewBag.dgr, new { @class = "form-control" })
        @*@Html.TextBoxFor(m => m.URUNKATEGORI, new { @class = "form-control" })*@
        <br />
        @Html.LabelFor(m => m.FIYAT)
        @Html.TextBoxFor(m => m.FIYAT, new { @class = "form-control" })
        <br />
        @Html.LabelFor(m => m.STOK)
        @Html.TextBoxFor(m => m.STOK, new { @class = "form-control" })
    </div>
    <div>
        <button class="btn btn-success">Ürün Güncelle</button>
    </div>
}



```

### Ürünler Controller

```c#
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using _10_MVC01_Youtube_Proje.Models.Entity;

namespace _10_MVC01_Youtube_Proje.Controllers
{
    public class UrunController : Controller
    {
        Dbo_MvcStokEntities db = new Dbo_MvcStokEntities();
        // GET: Urun
        public ActionResult Index()
        {
            var degerler = db.TBLURUNLER.ToList();
            return View(degerler);
        }

        [HttpGet]
        public ActionResult YeniUrun()
        {
            List<SelectListItem> degerler = (from i in db.TBLKATEGORILER.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = i.KATEGORIAD,
                                                 Value = i.KATEGORIID.ToString()
                                             }).ToList();
            ViewBag.dgr = degerler;
            return View();
        }

        [HttpPost]
        public ActionResult YeniUrun(TBLURUNLER p1)
        {
            var ktg = db.TBLKATEGORILER.Where(m => m.KATEGORIID == p1.TBLKATEGORILER.KATEGORIID).FirstOrDefault();
            p1.TBLKATEGORILER = ktg;
            db.TBLURUNLER.Add(p1);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult SIL(int id)
        {
            db.TBLURUNLER.Remove(db.TBLURUNLER.Find(id));
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult UrunGetir(int id)
        {
            var urun = db.TBLURUNLER.Find(id);

            List<SelectListItem> degerler = (from i in db.TBLKATEGORILER.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = i.KATEGORIAD,
                                                 Value = i.KATEGORIID.ToString()
                                             }).ToList();
            ViewBag.dgr = degerler;
            return View("UrunGetir", urun);
        }

        public ActionResult Guncelle(TBLURUNLER p)
        {
            var urun = db.TBLURUNLER.Find(p.URUNID);
            urun.URUNAD = p.URUNAD;
            urun.MARKA = p.MARKA;
            urun.STOK = p.STOK;
            urun.FIYAT = p.FIYAT;
            //urun.URUNKATEGORI = p.URUNAD;
            var ktg = db.TBLKATEGORILER.Where(m => m.KATEGORIID == p.TBLKATEGORILER.KATEGORIID).FirstOrDefault();
            urun.URUNKATEGORI = ktg.KATEGORIID;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
```

### Kategoriler
![Kategoriler](https://user-images.githubusercontent.com/95151751/232947882-8f10cf22-fdee-442a-b898-dbb5d9ab6543.png)


```c#
@using _10_MVC01_Youtube_Proje.Models.Entity;
@model List<TBLKATEGORILER>
@{
    ViewBag.Title = "Index";
    Layout = "~/Views/Shared/_MainLayout.cshtml";
}

@if (Model != null)
{
    <table class="table table-bordered">
        <tr>
            <th>KATEGORİ ID</th>
            <th>KATEGORİ ADI</th>
            <th>SİL</th>
            <th>GÜNCELLE</th>
        </tr>
        <tbody>
            @foreach (var kt in Model)
            {
            <tr>
                <th>@kt.KATEGORIID</th>
                <td>@kt.KATEGORIAD</td>
                <td><a href="/KATEGORI/SIL/@kt.KATEGORIID" class="btn btn-danger">SİL</a></td>
                <td><a href="/KATEGORI/KategoriGetir/@kt.KATEGORIID" class="btn btn-success">GÜNCELLE</a></td>
            </tr>
            }
        </tbody>
    </table>
    <a href="/KATEGORI/YeniKategori" class="btn btn-primary"> YENİ KATEOGRİ EKLE</a>
}
else
{
    <p>Henüz kategori eklenmemiş.</p>
}

```

### Yeni Kategori Ekle
![YeniKategori](https://user-images.githubusercontent.com/95151751/232947915-39c01ed0-6607-40de-a307-b25727b18540.png)


```c#
@model _10_MVC01_Youtube_Proje.Models.Entity.TBLKATEGORILER
@{
    ViewBag.Title = "YeniKategori";
    Layout = "~/Views/Shared/_MainLayout.cshtml";
}

<form class="form-group" method="post">
    @*<div>
        <label>Kategori Adı</label>
        <input type="text" class="form-control" name="KATEGORIAD" />
    </div>*@
    <div>
        <label>Kategori Adı</label>
        @Html.TextBoxFor(m => m.KATEGORIAD, new {@class="form-control"})
        @Html.ValidationMessageFor(m => m.KATEGORIAD, "", new {@style="color:red"})
    </div>
    <div style="margin-top:15px">
        <button class="btn btn-info">Kategori Ekle</button>
    </div>
</form>

```

### Kategori Güncelle
![KategoriGuncelle](https://user-images.githubusercontent.com/95151751/232947966-bade230a-e30d-4262-ab9f-85914c4579c1.png)


```c#
@model _10_MVC01_Youtube_Proje.Models.Entity.TBLKATEGORILER
@{
    ViewBag.Title = "KategoriGetir";
    Layout = "~/Views/Shared/_MainLayout.cshtml";
}

@using (Html.BeginForm("Guncelle", "Kategori", FormMethod.Post))
{
    <div class="form-group">
        @Html.LabelFor(m => m.KATEGORIID)
        @Html.TextBoxFor(m => m.KATEGORIID, new { @class = "form-control"})
        <br />
        @Html.LabelFor(m => m.KATEGORIAD)
        @Html.TextBoxFor(m => m.KATEGORIAD, new { @class = "form-control" })
    </div>
    <div>
        <button class="btn btn-success">Kategori Güncelle</button>
    </div>
}


```

### Kategoriler Controller

```c#
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using _10_MVC01_Youtube_Proje.Models.Entity;

namespace _10_MVC01_Youtube_Proje.Controllers
{
    public class KategoriController : Controller
    {
        // GET: Kategori
        Dbo_MvcStokEntities db = new Dbo_MvcStokEntities();
        public ActionResult Index()
        {
            var degerler = db.TBLKATEGORILER.ToList();
            return View(degerler);
        }

        [HttpGet]
        public ActionResult YeniKategori()
        {
            return View();
        }

        [HttpPost]
        public ActionResult YeniKategori(TBLKATEGORILER p1)
        {
            if (!ModelState.IsValid)
            {
                return View("YeniKategori");
            }
            db.TBLKATEGORILER.Add(p1);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult SIL(int id)
        {
            db.TBLKATEGORILER.Remove(db.TBLKATEGORILER.Find(id));
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult KategoriGetir(int id)
        {
            var ktgr = db.TBLKATEGORILER.Find(id);
            return View("KategoriGetir", ktgr);
        }

        public ActionResult Guncelle(TBLKATEGORILER p1)
        {
            var ktg = db.TBLKATEGORILER.Find(p1.KATEGORIID);
            ktg.KATEGORIAD = p1.KATEGORIAD;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
```

### Müşteriler
![Musteriler](https://user-images.githubusercontent.com/95151751/232947997-a868d999-f1ee-4a95-9773-8d741d882086.png)


```c#
@using _10_MVC01_Youtube_Proje.Models.Entity;
@model List<TBLMUSTERILER>
@{
    ViewBag.Title = "Index";
    Layout = "~/Views/Shared/_MainLayout.cshtml";
}

<table class="table table-bordered">
    <tr>
        <th>MÜŞTERİ ID</th>
        <th>MÜŞTERİ ADI</th>
        <th>MÜŞTERİ SOYADI</th>
        <th>SİL</th>
        <th>GÜNCELLE</th>
    </tr>
    <tbody>
        @foreach (var must in Model)
        {
            <tr>
                <th>@must.MUSTERIID</th>
                <td>@must.MUSTERIAD</td>
                <td>@must.MUSTERISOYAD</td>
                @*<td><a href="/MUSTERI/SIL/@must.MUSTERIID" class="btn btn-danger">SİL</a></td>*@
                <td>@Html.ActionLink("SİL", "SIL", new { id = must.MUSTERIID }, new { @class = "btn btn-danger", onclick = "return confirm('Gerçekten Silmek İstiyor musunuz?')" })</td>
                <td><a href="/MUSTERI/MusteriGetir/@must.MUSTERIID" class="btn btn-success">GÜNCELLE</a></td>
            </tr>
        }
    </tbody>
</table>
<a href="/MUSTERI/YeniMusteri" class="btn btn-primary"> YENİ MUSTERI EKLE</a>

```


### Yeni Müşteri Ekle
![YeniMusteri](https://user-images.githubusercontent.com/95151751/232948014-cdfaaeeb-7c8e-4803-a9be-814ee186d2a9.png)


```c#
@model _10_MVC01_Youtube_Proje.Models.Entity.TBLMUSTERILER
@{
    ViewBag.Title = "YeniMusteri";
    Layout = "~/Views/Shared/_MainLayout.cshtml";
}

<form method="post" class="form-group">
    <div>
        <label>Müşteri Adı</label>
        @Html.TextBoxFor(m => m.MUSTERIAD, new { @class = "form-control" })
        @Html.ValidationMessageFor(m => m.MUSTERIAD, "", new { @style = "color:red" })
    </div>
    <div style="margin-top:10px">
        <label>Müşteri Soyadı</label>
        <input type="text" class="form-control" name="MUSTERISOYAD" />
    </div>
    <div style="margin-top:15px">
        <button class="btn btn-info" id="btnMusteriEkle">Müşteri Ekle</button>
    </div>
    <script>
        $('#btnMusteriEkle').click(function () {
            alert('Müşteri ekleme işlemi başarıyla gerçekleştirildi!');
        });
    </script>
</form>


```

### Müşteri Güncelle
![MusteriGuncelle](https://user-images.githubusercontent.com/95151751/232948072-b829e297-eac4-4a3b-9338-a39dbb25d957.png)


```c#
@model _10_MVC01_Youtube_Proje.Models.Entity.TBLMUSTERILER
@{
    ViewBag.Title = "MusteriGetir";
    Layout = "~/Views/Shared/_MainLayout.cshtml";
}

@using (Html.BeginForm("Guncelle", "Musteri", FormMethod.Post))
{
    <div class="form-group">
        @Html.LabelFor(m => m.MUSTERIID)
        @Html.TextBoxFor(m => m.MUSTERIID, new { @class = "form-control" })
        <br />
        @Html.LabelFor(m => m.MUSTERIAD)
        @Html.TextBoxFor(m => m.MUSTERIAD, new { @class = "form-control" })
        <br />
        @Html.LabelFor(m => m.MUSTERISOYAD)
        @Html.TextBoxFor(m => m.MUSTERISOYAD, new { @class = "form-control" })
        <br />
    </div>
    <div>
        <button class="btn btn-success">Müşteri Güncelle</button>
    </div>
}


```

### Müşteriler Controller

```c#
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using _10_MVC01_Youtube_Proje.Models.Entity;

namespace _10_MVC01_Youtube_Proje.Controllers
{
    public class MusteriController : Controller
    {
        Dbo_MvcStokEntities db = new Dbo_MvcStokEntities();
        // GET: Musteri
        public ActionResult Index()
        {
            var degerler = db.TBLMUSTERILER.ToList();
            return View(degerler);
        }

        [HttpGet]
        public ActionResult YeniMusteri()
        {
            return View();
        }

        [HttpPost]
        public ActionResult YeniMusteri(TBLMUSTERILER p1)
        {
            if (!ModelState.IsValid)
            {
                return View("YeniMusteri");
            }
            db.TBLMUSTERILER.Add(p1);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult SIL(int id)
        {
            db.TBLMUSTERILER.Remove(db.TBLMUSTERILER.Find(id));
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult MusteriGetir(int id)
        {
            var mus = db.TBLMUSTERILER.Find(id);
            return View("MusteriGetir", mus);
        }

        public ActionResult Guncelle(TBLMUSTERILER p1)
        {
            var musteri = db.TBLMUSTERILER.Find(p1.MUSTERIID);
            musteri.MUSTERIAD = p1.MUSTERIAD;
            musteri.MUSTERISOYAD = p1.MUSTERISOYAD;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
```

### Satışlar
![Satıslar-1](https://user-images.githubusercontent.com/95151751/232948147-8ef8b839-73c6-431a-b62b-d6841c879893.png)

![Satıslar-2](https://user-images.githubusercontent.com/95151751/232948164-0a91e27e-7149-4047-8f25-f9c9fec03799.png)


```c#
@model _10_MVC01_Youtube_Proje.Models.Entity.TBLSATISLAR
@{
    ViewBag.Title = "Index";
    Layout = "~/Views/Shared/_MainLayout.cshtml";
}

<button type="button" class="btn btn-primary" data-toggle="modal" data-target="#Modal1">Satış Yap</button>
<div class="modal" id="Modal1">
    <div class="modal-dialog">
        <div class="modal-content">
            <div class="modal-header">
                <h2 class="modal-title">Satış Yapma Ekranı</h2>
            </div>
            <form method="post" action="/Satis/YeniSatis">
                <div class="modal-body">
                    <label>
                        Ürün Adı
                    </label>
                    @Html.TextBoxFor(m => m.URUN, new { @class = "form-control" })
                    <br />
                    <label>Müşteri Adı Soyadı</label>
                    @Html.TextBoxFor(m => m.MUSTERI, new { @class = "form-control" })
                    <br />
                    <label>Adet</label>
                    @Html.TextBoxFor(m => m.ADET, new { @class = "form-control" })
                    <br />
                    <label>Fiyat</label>
                    @Html.TextBoxFor(m => m.FIYAT, new { @class = "form-control" })
                    <br />
                    <button class="btn btn-info" type="submit">Satış İşlemini Yap</button>
                    <button class="btn btn-danger" type="button" data-dismiss="modal">Vazgeç</button>
                </div>
            </form>
        </div>
    </div>
</div>


```

### Satışlar Controller

```c#
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using _10_MVC01_Youtube_Proje.Models.Entity;

namespace _10_MVC01_Youtube_Proje.Controllers
{
    public class SatisController : Controller
    {
        Dbo_MvcStokEntities db = new Dbo_MvcStokEntities();
        // GET: Satis
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult YeniSatis()
        {
            return View();
        }

        [HttpPost]
        public ActionResult YeniSatis( TBLSATISLAR p)
        {
            db.TBLSATISLAR.Add(p);
            db.SaveChanges();
            return View("Index");
        }
    }
}
```









