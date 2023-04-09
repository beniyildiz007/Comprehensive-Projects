using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MesajOlustur : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        txtGonderen.Text = "0001";
    }

    protected void btnGonder_Click(object sender, EventArgs e)
    {
        if (IsPostBack)
        {
            DataSetTableAdapters.TBLMESAJLARTableAdapter dt = new DataSetTableAdapters.TBLMESAJLARTableAdapter();
            dt.MesajGonder(txtGonderen.Text, txtAlici.Text, txtMesajBaslik.Text,txtIcerik.Value);
            Response.Redirect("GidenMesajlar.aspx");
        }
    }
}