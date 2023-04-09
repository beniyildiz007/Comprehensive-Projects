using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class OgrenciMesajOlustur : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        txtGonderen.Text = Session["numara"].ToString();
    }

    protected void btnGonder_Click(object sender, EventArgs e)
    {
        DataSetTableAdapters.TBLMESAJLARTableAdapter dt = new DataSetTableAdapters.TBLMESAJLARTableAdapter();
        dt.MesajGonder(txtGonderen.Text, txtAlici.Text, txtMesajBaslik.Text, txtIcerik.Value);
        Response.Redirect("OgrenciGidenMesajlar.aspx");
    }
}