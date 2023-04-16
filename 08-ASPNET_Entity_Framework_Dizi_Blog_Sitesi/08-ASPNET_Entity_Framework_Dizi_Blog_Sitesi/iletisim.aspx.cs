using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using _08_ASPNET_Entity_Framework_Dizi_Blog_Sitesi.Entity;

namespace _08_ASPNET_Entity_Framework_Dizi_Blog_Sitesi
{
    public partial class iletisim : System.Web.UI.Page
    {
        Dbo_BlogDiziEntities db = new Dbo_BlogDiziEntities();

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void btnGonder_Click(object sender, EventArgs e)
        {
            TBLILETISIM t = new TBLILETISIM();
            t.ADSOYAD = txtAdSoyad.Text;
            t.KONU = txtKonu.Text;
            t.MAIL = txtMail.Text;
            t.TELEFON = txtTelefon.Text;
            t.MESAJ = txtMesaj.Text;
            db.TBLILETISIM.Add(t);
            db.SaveChanges();
            Response.Redirect("iletisim.aspx");
        }
    }
}