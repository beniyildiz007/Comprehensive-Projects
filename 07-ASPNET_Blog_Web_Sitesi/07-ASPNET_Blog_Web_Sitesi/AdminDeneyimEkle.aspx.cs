using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AdminDeneyimEkle : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnKaydet_Click(object sender, EventArgs e)
    {
        DataSetTableAdapters.TBLDENEYIMTableAdapter dt = new DataSetTableAdapters.TBLDENEYIMTableAdapter();
        dt.DeneyimEkle(txtBaslik.Text, txtAltBaslik.Text, txtAciklama.Text, txtTarih.Text);
        Response.Redirect("AdminDeneyimler.aspx");
    }
}