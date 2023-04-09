using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class DersGuncelle : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            int id = Convert.ToInt32(Request.QueryString["DERSID"]);
            DataSetTableAdapters.TBLDERSLERTableAdapter dt = new DataSetTableAdapters.TBLDERSLERTableAdapter();
            txtDersID.Text = id.ToString();
            txtDersAdi.Text = dt.DersGetir(id)[0].DERSAD;
        }
    }

    protected void guncelle_Click(object sender, EventArgs e)
    {
        DataSetTableAdapters.TBLDERSLERTableAdapter dt = new DataSetTableAdapters.TBLDERSLERTableAdapter();
        dt.DersGuncelle(txtDersAdi.Text, Convert.ToInt32(txtDersID.Text));
        Response.Redirect("DersListesi.aspx");
    }
}