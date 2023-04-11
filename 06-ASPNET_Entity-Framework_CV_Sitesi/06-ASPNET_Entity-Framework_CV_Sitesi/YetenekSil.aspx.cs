using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _06_CvEntityProje
{
    public partial class YetenekSil : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Dbo_CvEntityEntities db = new Dbo_CvEntityEntities();
            var ytnk = db.TBLYETENEKLER.Find(Convert.ToInt32(Request.QueryString["ID"]));
            db.TBLYETENEKLER.Remove(ytnk);
            db.SaveChanges();
            Response.Redirect("Yeteneklerim.aspx");
        }
    }
}