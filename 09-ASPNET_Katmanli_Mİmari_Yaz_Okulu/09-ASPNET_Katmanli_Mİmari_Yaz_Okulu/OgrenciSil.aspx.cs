using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EntityLayer;
using DataAccessLayer;
using BusinessLogicLayer;

public partial class OgrenciSil : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        EntityOgrenci ent = new EntityOgrenci();
        ent.OGRID = Convert.ToInt32(Request.QueryString["OGRID"]);
        BLLOgrenci.BLLOgrenciSil(ent.OGRID);
        Response.Redirect("OgrenciListesi.aspx");
    }
}