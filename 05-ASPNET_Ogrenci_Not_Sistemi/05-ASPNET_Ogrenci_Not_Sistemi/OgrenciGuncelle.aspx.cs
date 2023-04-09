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