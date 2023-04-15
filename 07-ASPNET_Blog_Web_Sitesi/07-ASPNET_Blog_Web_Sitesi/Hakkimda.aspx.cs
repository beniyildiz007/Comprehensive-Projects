using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Hakkimda : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            DataSetTableAdapters.TBLHAKKIMDATableAdapter dt = new DataSetTableAdapters.TBLHAKKIMDATableAdapter();
            txtAd.Text = dt.HakkimdaListele()[0].AD;
            txtSoyad.Text = dt.HakkimdaListele()[0].SOYAD;
            txtAdres.Text = dt.HakkimdaListele()[0].ADRES;
            txtMail.Text = dt.HakkimdaListele()[0].MAIL;
            txtTelefon.Text = dt.HakkimdaListele()[0].TELEFON;
            txtKisaNot.Text = dt.HakkimdaListele()[0].KISANOT;
            txtFotograf.Text = dt.HakkimdaListele()[0].FOTOGRAF;

        }
    }

    protected void btnGuncelle_Click(object sender, EventArgs e)
    {
        DataSetTableAdapters.TBLHAKKIMDATableAdapter dt = new DataSetTableAdapters.TBLHAKKIMDATableAdapter();
        dt.HakkimdaGuncelle(txtAd.Text, txtSoyad.Text, txtAdres.Text, txtMail.Text, txtTelefon.Text, txtKisaNot.Text, txtFotograf.Text);
        Response.Redirect("Default.aspx");
    }
}