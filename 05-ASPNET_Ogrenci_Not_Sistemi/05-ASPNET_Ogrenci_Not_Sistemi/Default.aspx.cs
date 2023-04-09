using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        DataSetTableAdapters.TBLOGRENCITableAdapter dt = new DataSetTableAdapters.TBLOGRENCITableAdapter();
        Repeater1.DataSource = dt.OgrenciListesi2();
        Repeater1.DataBind();
    }
}