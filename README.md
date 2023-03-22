

>_Büyük fikirler büyük başarılar getirmez, küçük başarılar büyük başarıları inşa eder._



## İçindekiler (Contents)
1. [C# Hastane Otomasyon Projesi](#project1)
2. [C# Pansiyon Kayıt Otomasyon Projesi](#project2)
3. [C# Öğrenci Yurdu Kayıt Otomasyon Projesi](#project3)




# 01- C# Hastane Otomasyon Projesi <a name="project1"></a>
### Başlangıç
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
### Hasta Girişi
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
### Hasta Üye Olma Paneli
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
### Hasta Detay Paneli
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
### Hasta Bilgi Güncelleme
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
### Doktor Detay Paneli
[![Berkan Nihat Yıldız](https://user-images.githubusercontent.com/95151751/224477255-4dbe4247-38f3-4e4d-ab36-c6f7eb1d48cf.png)](https://www.linkedin.com/in/berkan-nihat-yildiz/)
### Doktor Bilgi Düzenleme
[![image](https://user-images.githubusercontent.com/95151751/224477337-a3525c9c-2f69-4a9b-af64-41a577fb9a66.png)](https://www.linkedin.com/in/berkan-nihat-yildiz/)
### Duyurular
[![image](https://user-images.githubusercontent.com/95151751/224477381-cdc78352-aa15-44b9-9c4e-b38f555002ae.png)](https://www.linkedin.com/in/berkan-nihat-yildiz/)
### Sekreter Girişi
[![image](https://user-images.githubusercontent.com/95151751/224477430-1e559b05-f109-42b2-b50f-da8a16509105.png)](https://www.linkedin.com/in/berkan-nihat-yildiz/)
### Sekreter Detay Paneli
[![image](https://user-images.githubusercontent.com/95151751/224477465-47882ef2-433e-4901-830f-6807d05d5e19.png)](https://www.linkedin.com/in/berkan-nihat-yildiz/)
### Doktor paneli
[![image](https://user-images.githubusercontent.com/95151751/224477518-c64e304c-f3ca-4f86-b25f-c17688568254.png)](https://www.linkedin.com/in/berkan-nihat-yildiz/)
### Branş Paneli
[![image](https://user-images.githubusercontent.com/95151751/224477567-6c20776a-6fe5-45b4-9561-3935a2984568.png)](https://www.linkedin.com/in/berkan-nihat-yildiz/)
### Randevu Listesi
[![image](https://user-images.githubusercontent.com/95151751/224477587-85deecaa-e7d1-441b-8e76-1ca60de25edf.png)](https://www.linkedin.com/in/berkan-nihat-yildiz/)

# 02- C# Pansiyon Kayıt Otomasyon Projesi <a name="project2"></a>

### Admin Girişi
[![image](https://user-images.githubusercontent.com/95151751/226797637-0837d15b-96a0-46a4-802c-c9966f1ddb25.png)](https://www.linkedin.com/in/berkan-nihat-yildiz/)

### Anasayfa
[![image](https://user-images.githubusercontent.com/95151751/226797769-eb020630-bb10-4a05-9cea-630a55da49de.png)](https://www.linkedin.com/in/berkan-nihat-yildiz/)

### Yeni Müşteri
[![image](https://user-images.githubusercontent.com/95151751/226797918-e19587be-d530-490b-b5b2-eed6dcca82c7.png)](https://www.linkedin.com/in/berkan-nihat-yildiz/)

### Odalar
[![image](https://user-images.githubusercontent.com/95151751/226797995-75d4034c-fdbc-4f45-92ff-98424eb4457d.png)](https://www.linkedin.com/in/berkan-nihat-yildiz/)

### Müşteriler
[![image](https://user-images.githubusercontent.com/95151751/226798080-8804c5c5-4d1b-4fbc-9f65-fcab07e14004.png)](https://www.linkedin.com/in/berkan-nihat-yildiz/)

### Gelir-Gider Formu
[![image](https://user-images.githubusercontent.com/95151751/226798145-e39137b5-cbb8-4201-a350-8b8b213204d4.png)](https://www.linkedin.com/in/berkan-nihat-yildiz/)

### Stoklar
[![image](https://user-images.githubusercontent.com/95151751/226798207-bae777f7-02dc-410f-8a44-ee5cc5003f36.png)](https://www.linkedin.com/in/berkan-nihat-yildiz/)

### Hakkımızda
[![image](https://user-images.githubusercontent.com/95151751/226798259-c71ab6c5-c136-430d-ac86-ca394e779cba.png)](https://www.linkedin.com/in/berkan-nihat-yildiz/)


# 03- C# Öğrenci Yurdu Kayıt Otomasyon Projesi <a name="project3"></a>

### Admin Girişi
[![image](https://user-images.githubusercontent.com/95151751/226799085-35696fc5-2141-4d02-ac39-4ef44e198571.png)](https://www.linkedin.com/in/berkan-nihat-yildiz/)

### Anasayfa
[![image](https://user-images.githubusercontent.com/95151751/226799122-3bdffbeb-b544-4f44-ba07-999c6bacdbcf.png)](https://www.linkedin.com/in/berkan-nihat-yildiz/)

### Öğrenci Kayıt
[![image](https://user-images.githubusercontent.com/95151751/226799232-86e4777e-b650-4b8e-9fd7-95af913ce015.png)](https://www.linkedin.com/in/berkan-nihat-yildiz/)

### Öğrenci Listesi
[![image](https://user-images.githubusercontent.com/95151751/226799281-b36f264f-e8f8-4894-b7ee-4015c12b76a5.png)](https://www.linkedin.com/in/berkan-nihat-yildiz/)

### Öğrenci Bilgileri Düzenle
[![image](https://user-images.githubusercontent.com/95151751/226799411-7531874b-84a4-4f2b-bce1-1e28f93087a7.png)](https://www.linkedin.com/in/berkan-nihat-yildiz/)

### Bölümler
[![image](https://user-images.githubusercontent.com/95151751/226799468-efddc08a-ea8e-434b-8d05-cfefb281abbd.png)](https://www.linkedin.com/in/berkan-nihat-yildiz/)

### Ödemeler
[![image](https://user-images.githubusercontent.com/95151751/226799588-66e49e73-cd21-42ec-8e8d-65d0cc1cbe5f.png)](https://www.linkedin.com/in/berkan-nihat-yildiz/)

### Gider Ekle
[![image](https://user-images.githubusercontent.com/95151751/226799665-4a958e4d-182b-4f64-bea4-9da765e0b583.png)](https://www.linkedin.com/in/berkan-nihat-yildiz/)

### Gider Listesi
[![image](https://user-images.githubusercontent.com/95151751/226799711-6266178b-ecd0-47bc-a70b-f672b355d5f5.png)](https://www.linkedin.com/in/berkan-nihat-yildiz/)

### Giderleri Güncelle
[![image](https://user-images.githubusercontent.com/95151751/226799765-234cffa1-c13d-4285-b74c-e2e9ec8caa4e.png)](https://www.linkedin.com/in/berkan-nihat-yildiz/)

### Gelir İstatistikleri
[![image](https://user-images.githubusercontent.com/95151751/226799822-9346dae0-3819-44c2-b410-ed0027fae62d.png)](https://www.linkedin.com/in/berkan-nihat-yildiz/)

### Yönetici İşlemleri
[![image](https://user-images.githubusercontent.com/95151751/226800008-1a148e1c-96bd-4c0d-9c0f-e7aa01d6829a.png)](https://www.linkedin.com/in/berkan-nihat-yildiz/)

### Personel İşlemleri
[![image](https://user-images.githubusercontent.com/95151751/226800049-d1e34149-8a35-4d75-8228-8c89f5a1a2db.png)](https://www.linkedin.com/in/berkan-nihat-yildiz/)

### Not Oluştur
[![image](https://user-images.githubusercontent.com/95151751/226800087-58029af7-f61e-4062-a0b0-e249bdef3e39.png)](https://www.linkedin.com/in/berkan-nihat-yildiz/)

### Not Kaydet (saveFileDialog)
[![image](https://user-images.githubusercontent.com/95151751/226800191-a9c7c66a-159f-4469-b73b-639823deb78f.png)](https://www.linkedin.com/in/berkan-nihat-yildiz/)

### Erişim Kolaylığı (calc.exe && mspaint.exe)
[![image](https://user-images.githubusercontent.com/95151751/226800258-96241647-1430-4ec1-94ae-f7d660350ea6.png)](https://www.linkedin.com/in/berkan-nihat-yildiz/)

### Erişim Kolaylığı (Radyolar)
[![image](https://user-images.githubusercontent.com/95151751/226800318-deb108e4-7408-4b3f-a5ba-51b3f22b5973.png)](https://www.linkedin.com/in/berkan-nihat-yildiz/)

### Erişim Kolaylığı (Hakkımızda)
[![image](https://user-images.githubusercontent.com/95151751/226800413-b0da36c4-fdab-429f-9393-571f51099be4.png)](https://www.linkedin.com/in/berkan-nihat-yildiz/)
