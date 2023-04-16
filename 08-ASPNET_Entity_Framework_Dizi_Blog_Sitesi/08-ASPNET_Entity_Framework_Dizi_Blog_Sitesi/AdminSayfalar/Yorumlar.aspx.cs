using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using _08_ASPNET_Entity_Framework_Dizi_Blog_Sitesi.Entity;

namespace _08_ASPNET_Entity_Framework_Dizi_Blog_Sitesi.AdminSayfalar
{
    public partial class Yorumlar : System.Web.UI.Page
    {
        Dbo_BlogDiziEntities db = new Dbo_BlogDiziEntities();

        protected void Page_Load(object sender, EventArgs e)
        {
            Repeater1.DataSource = (from x in db.TBLYORUM
                                    select new
                                    {
                                        x.YORUMID,
                                        x.KULLANICIAD,
                                        x.TBLBLOG.BLOGBASLIK
                                    }).ToList();
            Repeater1.DataBind();
        }
    }
}