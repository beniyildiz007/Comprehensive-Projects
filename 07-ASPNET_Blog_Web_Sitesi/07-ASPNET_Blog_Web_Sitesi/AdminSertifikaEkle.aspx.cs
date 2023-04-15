using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AdminSertifikaEkle : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
    }

    protected void btnKaydet_Click(object sender, EventArgs e)
    {
        DataSetTableAdapters.TBLODULLERTableAdapter dt = new DataSetTableAdapters.TBLODULLERTableAdapter();
        dt.SertifikaEkle(txtSertifika.Text, txtLink.Text);
        Response.Redirect("AdminSertifikalar.aspx");
    }
}