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