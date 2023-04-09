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