

>_Büyük fikirler büyük başarılar getirmez, küçük başarılar büyük başarıları inşa eder._



## İçindekiler (Contents)
1. [C# Hastane Otomasyon Projesi](#project1)
2. [C# Pansiyon Kayıt Otomasyon Projesi](#project2)



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
### Hasta Detay Paneli
[![Berkan Nihat Yıldız](https://i.hizliresim.com/ge3oeiq.jpg)](https://www.linkedin.com/in/berkan-nihat-yildiz/)
### Hasta Bilgi Güncelleme
[![Berkan Nihat Yıldız](https://i.hizliresim.com/f97pp7n.jpg)](https://www.linkedin.com/in/berkan-nihat-yildiz/)
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
