using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class HobiGuncelle : System.Web.UI.Page
{

    DataSetTableAdapters.TBLHOBILERTableAdapter dt = new DataSetTableAdapters.TBLHOBILERTableAdapter();

    protected void Page_Load(object sender, EventArgs e)
    {
        short id = short.Parse(Request.QueryString["ID"]);
        if (!IsPostBack)
        {
            txtID.Text = id.ToString();
            txtHobi.Text = dt.HobiGetir(id)[0].HOBI;        
        }
    }

    protected void btnGuncelle_Click(object sender, EventArgs e)
    {
        dt.HobiGuncelle(txtHobi.Text, short.Parse(Request.QueryString["ID"]));
        Response.Redirect("AdminHobiler.aspx");
    }
}