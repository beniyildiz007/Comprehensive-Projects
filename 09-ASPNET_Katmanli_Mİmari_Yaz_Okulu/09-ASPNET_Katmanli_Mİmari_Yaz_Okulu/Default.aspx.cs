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