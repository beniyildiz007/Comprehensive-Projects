using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class OgrenciDuyuru : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        DataSetTableAdapters.TBLDUYURULARTableAdapter dt = new DataSetTableAdapters.TBLDUYURULARTableAdapter();
        Repeater1.DataSource = dt.OgrenciDuyuruListesi();
        Repeater1.DataBind();

    }
}