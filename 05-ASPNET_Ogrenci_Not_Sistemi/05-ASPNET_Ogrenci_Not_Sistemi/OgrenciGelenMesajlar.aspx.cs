﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class OgrenciGelenMesajlar : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        DataSetTableAdapters.TBLMESAJLARTableAdapter dt = new DataSetTableAdapters.TBLMESAJLARTableAdapter();
        Repeater1.DataSource = dt.OgrenciGelenKutusu1(Session["numara"].ToString());
        Repeater1.DataBind();
    }
}