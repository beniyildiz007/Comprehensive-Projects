using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _06_CvEntityProje
{
    public partial class Hakkkimda : System.Web.UI.Page
    {

        Dbo_CvEntityEntities db = new Dbo_CvEntityEntities();

        protected void Page_Load(object sender, EventArgs e)
        {
            Repeater1.DataSource = db.TBLYETENEKLER.ToList();
            Repeater1.DataBind();
        }

        protected void btnEkle_Click(object sender, EventArgs e)
        {
            Response.Redirect("YeniYetenekEkle.aspx");
        }
    }
}