using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AdminYetenekGuncelle : System.Web.UI.Page
{
    DataSetTableAdapters.TBLYETENEKLERTableAdapter dt = new DataSetTableAdapters.TBLYETENEKLERTableAdapter();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            txtID.Text = Request.QueryString["ID"];
            txtYetenek.Text = dt.YetenekGetir(short.Parse(Request.QueryString["ID"]))[0].YETENEK;
        }
    }

    protected void btnGuncelle_Click(object sender, EventArgs e)
    {
        dt.YetenekGuncelle(txtYetenek.Text, short.Parse(Request.QueryString["ID"]));
        Response.Redirect("AdminYetenekler.aspx");
    }
}