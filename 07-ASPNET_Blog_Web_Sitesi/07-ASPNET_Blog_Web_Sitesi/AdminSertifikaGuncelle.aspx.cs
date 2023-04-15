using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AdminSertifikaGuncelle : System.Web.UI.Page
{

    DataSetTableAdapters.TBLODULLERTableAdapter dt = new DataSetTableAdapters.TBLODULLERTableAdapter();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            short id = short.Parse(Request.QueryString["ID"]);
            txtID.Text = dt.SertifikaGetir(id)[0].ID.ToString();
            txtSertifika.Text = dt.SertifikaGetir(id)[0].ODUL.ToString();
            txtLink.Text = dt.SertifikaGetir(id)[0].LINK.ToString();
        }
    }

    protected void btnGuncelle_Click(object sender, EventArgs e)
    {
        dt.SertifikaGuncelle(txtSertifika.Text, txtLink.Text, short.Parse(txtID.Text));
        Response.Redirect("AdminSertifikalar.aspx");
    }
}