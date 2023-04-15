using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AdminEgitimGuncelle : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            DataSetTableAdapters.TBLEGITIMTableAdapter dt = new DataSetTableAdapters.TBLEGITIMTableAdapter();
            short id = short.Parse(Request.QueryString["ID"]);
            txtID.Text = id.ToString();
            txtBaslik.Text = dt.EgitimGetir(id)[0].BASLIK;
            txtAltBaslik.Text = dt.EgitimGetir(id)[0].ALTBASLIK;
            txtAciklama.Text = dt.EgitimGetir(id)[0].ACIKLAMA;
            txtGenelNot.Text = dt.EgitimGetir(id)[0].GNOT;
            txtTarih.Text = dt.EgitimGetir(id)[0].TARIH;

        }
    }

    protected void btnGuncelle_Click(object sender, EventArgs e)
    {
        DataSetTableAdapters.TBLEGITIMTableAdapter dt = new DataSetTableAdapters.TBLEGITIMTableAdapter();
        dt.EgitimGuncelle(txtBaslik.Text, txtAltBaslik.Text, txtAciklama.Text, txtGenelNot.Text, txtTarih.Text, Convert.ToInt16(txtID.Text));
        Response.Redirect("AdminEgitimler.aspx");
    }
}