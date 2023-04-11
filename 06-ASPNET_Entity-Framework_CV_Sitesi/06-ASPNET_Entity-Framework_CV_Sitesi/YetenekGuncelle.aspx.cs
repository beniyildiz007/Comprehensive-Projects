using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _06_CvEntityProje
{
    public partial class YetenekGuncelle : System.Web.UI.Page
    {
        Dbo_CvEntityEntities db = new Dbo_CvEntityEntities();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var deger = db.TBLYETENEKLER.Find(int.Parse(Request.QueryString["ID"]));
                txtYetenek.Text = deger.YETENEK;
                
            }
        }
        
        protected void btnGuncelle_Click(object sender, EventArgs e)
        {
            var ytnk = db.TBLYETENEKLER.Find(int.Parse(Request.QueryString["ID"]));
            ytnk.YETENEK = txtYetenek.Text;
            ytnk.DERECE = Convert.ToByte(TextBox1.Text);
            db.SaveChanges();
            Response.Redirect("Yeteneklerim.aspx");

        }
    }
}