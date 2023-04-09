using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class DuyuruListesi : System.Web.UI.Page
{


    protected void Page_Load(object sender, EventArgs e)
    {
        DataSetTableAdapters.TBLDUYURULARTableAdapter dt = new DataSetTableAdapters.TBLDUYURULARTableAdapter();
        Repeater1.DataSource = dt.DuyuruListesi();
        Repeater1.DataBind();
    }
}