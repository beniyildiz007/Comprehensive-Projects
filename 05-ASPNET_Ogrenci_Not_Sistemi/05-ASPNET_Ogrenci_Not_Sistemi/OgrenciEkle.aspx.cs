using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class OgrenciEkle : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void kaydet_Click(object sender, EventArgs e)
    {
        DataSetTableAdapters.TBLOGRENCITableAdapter dt = new DataSetTableAdapters.TBLOGRENCITableAdapter();
        dt.OgrenciEkle(txtOgrAd.Text, txtOgrSoyad.Text, txtOgrTelefon.Text, txtOgrMail.Text, txtOgrSifre.Text, txtOgrFoto.Text);
        Response.Redirect("Default.aspx");
    }
}