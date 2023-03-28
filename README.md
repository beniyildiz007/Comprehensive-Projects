

>_Büyük fikirler büyük başarılar getirmez, küçük başarılar büyük başarıları inşa eder._



## İçindekiler (Contents)
1. [C# Hastane Otomasyon Projesi](#project1)
2. [C# Pansiyon Kayıt Otomasyon Projesi](#project2)
3. [C# Öğrenci Yurdu Kayıt Otomasyon Projesi](#project3)
4. [C# ile DevExpress'te SQL Tabanlı Ticari Otomasyon](#project4)




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
