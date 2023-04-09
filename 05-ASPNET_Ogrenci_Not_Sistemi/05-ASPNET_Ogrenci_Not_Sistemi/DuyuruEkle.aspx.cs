using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class DuyuruEkle : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            DataSetTableAdapters.TBLOGRETMENTableAdapter dt = new DataSetTableAdapters.TBLOGRETMENTableAdapter();
            DropDownList1.DataSource = dt.OgretmenListesi();
            DropDownList1.DataTextField = "OGRTADSOYAD";
            DropDownList1.DataValueField = "OGRTID";
            DropDownList1.DataBind();

        }
    }

    protected void olustur_Click(object sender, EventArgs e)
    {
        DataSetTableAdapters.TBLDUYURULARTableAdapter dt = new DataSetTableAdapters.TBLDUYURULARTableAdapter();
        dt.DuyuruEkle(txtDuyuruBaslik.Text, TextArea1.Value.ToString(), Convert.ToInt32(DropDownList1.SelectedValue));
        Response.Redirect("DuyuruListesi.aspx");
    }
}