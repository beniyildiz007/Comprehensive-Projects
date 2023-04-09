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