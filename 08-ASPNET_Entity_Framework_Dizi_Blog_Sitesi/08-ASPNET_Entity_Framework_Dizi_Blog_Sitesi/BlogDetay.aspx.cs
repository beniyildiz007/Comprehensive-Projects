using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using _08_ASPNET_Entity_Framework_Dizi_Blog_Sitesi.Entity;

namespace _08_ASPNET_Entity_Framework_Dizi_Blog_Sitesi
{
    public partial class BlogDetay : System.Web.UI.Page
    {

        Dbo_BlogDiziEntities db = new Dbo_BlogDiziEntities();

        protected void Page_Load(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(Request.QueryString["ID"]);
            Repeater1.DataSource = db.TBLBLOG.Where(x => x.BLOGID == id).ToList();
            Repeater1.DataBind();

            Repeater2.DataSource = db.TBLYORUM.Where(x => x.YORUMBLOG == id).ToList();
            Repeater2.DataBind();
        }

        protected void btnYorumYap_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(Request.QueryString["ID"]);
            TBLYORUM t = new TBLYORUM();
            t.KULLANICIAD = txtAd.Text;
            t.MAIL = txtEmail.Text;
            t.YORUMICERIK = txtMesaj.Text;
            t.YORUMBLOG = id;
            db.TBLYORUM.Add(t);
            db.SaveChanges();
            Response.Redirect("BlogDetay.aspx?ID=" + id);
        }
    }
}