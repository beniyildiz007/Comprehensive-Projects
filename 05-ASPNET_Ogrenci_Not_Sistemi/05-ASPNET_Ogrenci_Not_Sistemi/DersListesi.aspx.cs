﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class DersListesi : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        DataSetTableAdapters.TBLDERSLERTableAdapter dt = new DataSetTableAdapters.TBLDERSLERTableAdapter();
        Repeater1.DataSource = dt.DersListesi();
        Repeater1.DataBind();
    }
}