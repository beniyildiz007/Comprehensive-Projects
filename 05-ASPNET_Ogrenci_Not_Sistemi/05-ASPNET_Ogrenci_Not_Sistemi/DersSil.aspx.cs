using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class DersSil : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        DataSetTableAdapters.TBLDERSLERTableAdapter dt = new DataSetTableAdapters.TBLDERSLERTableAdapter();
        dt.DersSil(Convert.ToInt32(Request.QueryString["DERSID"].ToString()));
        Response.Redirect("DersListesi.aspx");
    }
}