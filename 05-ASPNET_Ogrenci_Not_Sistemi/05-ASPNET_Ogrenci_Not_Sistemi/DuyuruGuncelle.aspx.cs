using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class DuyuruGuncelle : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            int id = Convert.ToInt32(Request.QueryString["DUYURUID"]);
            DataSetTableAdapters.TBLDUYURULARTableAdapter dt = new DataSetTableAdapters.TBLDUYURULARTableAdapter();
            txtDuyuruID.Text = id.ToString();
            txtDuyuruID.Enabled = false;
            txtDuyuruBaslik.Text = dt.DuyuruSec(id)[0].DUYURUBASLIK;
            TextArea1.Value = dt.DuyuruSec(id)[0].DUYURUICERIK;

        }
    }

    protected void olustur_Click(object sender, EventArgs e)
    {
        DataSetTableAdapters.TBLDUYURULARTableAdapter dt = new DataSetTableAdapters.TBLDUYURULARTableAdapter();
        dt.DuyuruGuncelle(txtDuyuruBaslik.Text, TextArea1.Value, Convert.ToInt32(txtDuyuruID.Text));
        Response.Redirect("DuyuruListesi.aspx");
    }
}