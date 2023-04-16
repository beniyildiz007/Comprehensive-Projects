using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using _08_ASPNET_Entity_Framework_Dizi_Blog_Sitesi.Entity;

namespace _08_ASPNET_Entity_Framework_Dizi_Blog_Sitesi.AdminSayfalar
{
    public partial class YeniBlog : System.Web.UI.Page
    {
        Dbo_BlogDiziEntities db = new Dbo_BlogDiziEntities();

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                //Türleri Listeleme
                drpTur.DataSource = (from x in db.TBLTUR
                                     select new
                                     {
                                         x.TURID,
                                         x.TURAD
                                     }).ToList();
                drpTur.DataBind();


                //Kategorileri Listeleme
                drpKategori.DataSource = (from x in db.TBLKATEGORI
                                          select new
                                          {
                                              x.KATEGORIID,
                                              x.KATEGORIAD
                                          }).ToList();
                drpKategori.DataBind();
            }
        }

        protected void btnKaydet_Click(object sender, EventArgs e)
        {
            TBLBLOG t = new TBLBLOG();
            t.BLOGBASLIK = txtBaslik.Text;
            t.BLOGTARIH = DateTime.Parse(txtTarih.Text);
            t.BLOGGORSEL = txtGorsel.Text;
            t.BLOGTUR = byte.Parse(drpTur.SelectedValue);
            t.BLOGKATEGORI = byte.Parse(drpKategori.SelectedValue);
            t.BLOGICERIK = txtIcerik.Text;
            db.TBLBLOG.Add(t);
            db.SaveChanges();
            Response.Redirect("Bloglar.aspx");
        }
    }
}