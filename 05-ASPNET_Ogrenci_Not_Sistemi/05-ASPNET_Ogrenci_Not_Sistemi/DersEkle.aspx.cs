using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class DersEkle : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void olustur_Click(object sender, EventArgs e)
    {
        DataSetTableAdapters.TBLDERSLERTableAdapter dt = new DataSetTableAdapters.TBLDERSLERTableAdapter();
        dt.DersEkle(txtDers.Text);
        Response.Redirect("DersListesi.aspx");
    }
}