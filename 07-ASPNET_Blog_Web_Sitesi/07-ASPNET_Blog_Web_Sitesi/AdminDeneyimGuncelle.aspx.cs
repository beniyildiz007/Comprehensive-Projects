using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AdminDeneyimGuncelle : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            DataSetTableAdapters.TBLDENEYIMTableAdapter dt = new DataSetTableAdapters.TBLDENEYIMTableAdapter();
            txtID.Text = Request.QueryString["ID"];
            txtBaslik.Text = dt.DeneyimGetir(Convert.ToInt16(Request.QueryString["ID"]))[0].BASLIK;
            txtAltBaslik.Text = dt.DeneyimGetir(Convert.ToInt16(Request.QueryString["ID"]))[0].ALTBASLIK;
            txtAciklama.Text = dt.DeneyimGetir(Convert.ToInt16(Request.QueryString["ID"]))[0].ACIKLAMA;
            txtTarih.Text = dt.DeneyimGetir(Convert.ToInt16(Request.QueryString["ID"]))[0].TARIH;
        }
    }

    protected void btnGuncelle_Click(object sender, EventArgs e)
    {
        //if (!IsPostBack)
        //{
            DataSetTableAdapters.TBLDENEYIMTableAdapter dt = new DataSetTableAdapters.TBLDENEYIMTableAdapter();
            dt.DeneyimGuncelle(txtBaslik.Text, txtAltBaslik.Text, txtAciklama.Text, txtTarih.Text, Convert.ToInt16(txtID.Text));
            Response.Redirect("AdminDeneyimler.aspx");

        //}
    }
}