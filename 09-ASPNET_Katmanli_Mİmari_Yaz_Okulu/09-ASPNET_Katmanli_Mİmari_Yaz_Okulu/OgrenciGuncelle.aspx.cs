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