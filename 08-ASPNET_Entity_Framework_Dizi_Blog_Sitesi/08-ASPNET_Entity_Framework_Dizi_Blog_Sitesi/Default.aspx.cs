using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using _08_ASPNET_Entity_Framework_Dizi_Blog_Sitesi.Entity;

namespace _08_ASPNET_Entity_Framework_Dizi_Blog_Sitesi
{
    public partial class Default : System.Web.UI.Page
    {
        Dbo_BlogDiziEntities db = new Dbo_BlogDiziEntities();

        protected void Page_Load(object sender, EventArgs e)
        {
            Repeater1.DataSource = db.TBLBLOG.ToList();
            Repeater1.DataBind();

            Repeater2.DataSource = db.TBLBLOG.ToList();
            Repeater2.DataBind();

            Repeater3.DataSource = db.TBLKATEGORI.ToList();
            Repeater3.DataBind();
        }
    }
}