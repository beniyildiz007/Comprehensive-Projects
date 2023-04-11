using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _06_CvEntityProje
{
    public partial class Default : System.Web.UI.Page
    {
        Dbo_CvEntityEntities db = new Dbo_CvEntityEntities();

        protected void Page_Load(object sender, EventArgs e)
        {
            Repeater1.DataSource = db.TBLHAKKIMDA.ToList();
            Repeater1.DataBind();
            Repeater2.DataSource = db.TBLHAKKIMDA.ToList();
            Repeater2.DataBind();
            Repeater3.DataSource = db.TBLHAKKIMDA.ToList();
            Repeater3.DataBind();
            Repeater4.DataSource = db.TBLYETENEKLER.ToList();
            Repeater4.DataBind();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            TBLILETISIM t = new TBLILETISIM();
            t.ADSOYAD = txtAd.Text;
            t.MAIL = txtMail.Text;
            t.MESAJ = TextBox1.Text;
            db.TBLILETISIM.Add(t);
            db.SaveChanges();

            txtAd.Text = "";
            txtMail.Text = "";
            TextBox1.Text = "";
        }
    }
}