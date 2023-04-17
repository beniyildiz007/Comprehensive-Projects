using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EntityLayer;
using DataAccessLayer;
using BusinessLogicLayer;

public partial class Dersler : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            List<EntityDers> entDers = BLLDers.BllListele();
            DropDownList1.DataSource = BLLDers.BllListele();
            DropDownList1.DataTextField = "DERSAD";
            DropDownList1.DataValueField = "DERSID";
            DropDownList1.DataBind();

        }
    }

    protected void btnTalep_Click(object sender, EventArgs e)
    {
        EntityBasvuruForm ent = new EntityBasvuruForm();
        ent.BASOGRID = int.Parse(TextBox1.Text);
        ent.BASDERSID = int.Parse(DropDownList1.SelectedValue.ToString());
        BLLDers.BLLTalepEkle(ent);
        Response.Redirect("Dersler.aspx");
    }
}