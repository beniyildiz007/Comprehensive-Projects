using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class NotGuncelle : System.Web.UI.Page
{
    int nid;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            nid = Convert.ToInt32(Request.QueryString["NOTID"].ToString());

            DataSetTableAdapters.OgrNotlarTableAdapter dt = new DataSetTableAdapters.OgrNotlarTableAdapter();
            txtOgrID.Text = dt.NotGetir2(nid)[0].OGRENCIID.ToString();
            txtOgrAdSoyad.Text = dt.NotGetir2(nid)[0].OGRENCIADSOYAD.ToString();
            txtDersAdi.Text = dt.NotGetir2(nid)[0].DERSAD.ToString();
            txtSinav1.Text = dt.NotGetir2(nid)[0].SINAV1.ToString();
            txtSinav2.Text = dt.NotGetir2(nid)[0].SINAV2.ToString();
            txtSinav3.Text = dt.NotGetir2(nid)[0].SINAV3.ToString();
            txtOrtalama.Text = dt.NotGetir2(nid)[0].ORTALAMA.ToString();
            txtDurum.Text = dt.NotGetir2(nid)[0].DURUM.ToString();
        }

    }

    protected void hesapla_Click(object sender, EventArgs e)
    {
        double sinav1, sinav2, sinav3, ortalama;
        sinav1 = Convert.ToInt32(txtSinav1.Text);
        sinav2 = Convert.ToInt32(txtSinav2.Text);
        sinav3 = Convert.ToInt32(txtSinav3.Text);
        ortalama = (sinav1 + sinav2 + sinav3) / 3;
        txtOrtalama.Text=ortalama.ToString("0.00");
        if (ortalama >= 50)
        {
            txtDurum.Text = "True";
        }
        else
        {
            txtDurum.Text = "False";
        }
    }

    protected void guncelle_Click(object sender, EventArgs e)
    {
        DataSetTableAdapters.OgrNotlarTableAdapter dt = new DataSetTableAdapters.OgrNotlarTableAdapter();
        dt.NotGuncelle(byte.Parse(txtSinav1.Text), byte.Parse(txtSinav2.Text), byte.Parse(txtSinav3.Text), decimal.Parse(txtOrtalama.Text), bool.Parse(txtDurum.Text), Convert.ToInt32(Request.QueryString["NOTID"].ToString()));
        Response.Redirect("NotListesi.aspx");
    }
}