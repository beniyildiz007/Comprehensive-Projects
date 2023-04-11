using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _06_CvEntityProje
{
    public partial class YeniYetenekEkle : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Dbo_CvEntityEntities db = new Dbo_CvEntityEntities();
            TBLYETENEKLER t = new TBLYETENEKLER();
            t.YETENEK = TextBox1.Text;
            t.DERECE = Convert.ToByte(TextBox2.Text);
            db.TBLYETENEKLER.Add(t);
            db.SaveChanges();
            Response.Redirect("Yeteneklerim.aspx");
        }
    }
}