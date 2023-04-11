using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _06_CvEntityProje
{
    public partial class MesajDetay : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Dbo_CvEntityEntities db = new Dbo_CvEntityEntities();
            var mesaj = db.TBLILETISIM.Find(int.Parse(Request.QueryString["ID"]));
            txtAdSoyad.Text = mesaj.ADSOYAD;
            txtMail.Text = mesaj.MAIL;
            txtMesaj.Text = mesaj.MESAJ;
        }

        protected void btnMesajlar_Click(object sender, EventArgs e)
        {
            Response.Redirect("iletisim.aspx");
        }
    }
}