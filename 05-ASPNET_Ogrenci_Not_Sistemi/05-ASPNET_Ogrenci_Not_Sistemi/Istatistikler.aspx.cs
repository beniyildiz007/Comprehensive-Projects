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