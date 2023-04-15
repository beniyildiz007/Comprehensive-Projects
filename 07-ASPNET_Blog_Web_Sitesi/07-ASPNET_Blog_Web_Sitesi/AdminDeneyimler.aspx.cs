using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AdminDeneyimler : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        DataSetTableAdapters.TBLDENEYIMTableAdapter DT = new DataSetTableAdapters.TBLDENEYIMTableAdapter();
        Repeater1.DataSource = DT.DeneyimListele();
        Repeater1.DataBind();
    }

}