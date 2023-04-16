using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using _08_ASPNET_Entity_Framework_Dizi_Blog_Sitesi.Entity;

namespace _08_ASPNET_Entity_Framework_Dizi_Blog_Sitesi.AdminSayfalar
{
    public partial class BlogSil : System.Web.UI.Page
    {

        Dbo_BlogDiziEntities db = new Dbo_BlogDiziEntities();

        protected void Page_Load(object sender, EventArgs e)
        {
            int id = int.Parse(Request.QueryString["BLOGID"]);
            db.TBLBLOG.Remove(db.TBLBLOG.Find(id));
            db.SaveChanges();
            Response.Redirect("Bloglar.aspx");
        }
    }
}