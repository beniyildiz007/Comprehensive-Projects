using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using _08_ASPNET_Entity_Framework_Dizi_Blog_Sitesi.Entity;

namespace _08_ASPNET_Entity_Framework_Dizi_Blog_Sitesi.AdminSayfalar
{
    public partial class BlogGuncelle : System.Web.UI.Page
    {
        Dbo_BlogDiziEntities db = new Dbo_BlogDiziEntities();

        protected void Page_Load(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(Request.QueryString["BLOGID"]);

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



            var deger = db.TBLBLOG.Find(id);

            txtID.Text = deger.BLOGID.ToString();
            txtBaslik.Text = deger.BLOGBASLIK;
            txtTarih.Text = deger.BLOGTARIH.ToString();
            txtGorsel.Text = deger.BLOGGORSEL;
            drpKategori.SelectedValue = deger.BLOGKATEGORI.ToString();
            drpTur.SelectedValue = deger.BLOGTUR.ToString();
            txtIcerik.Text = deger.BLOGICERIK;

        }

        protected void btnGuncelle_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(Request.QueryString["BLOGID"]);

            var deger = db.TBLBLOG.Find(id);
            deger.BLOGBASLIK = txtBaslik.Text;
            deger.BLOGTARIH = DateTime.Parse(txtTarih.Text);
            deger.BLOGGORSEL = txtGorsel.Text;
            deger.BLOGKATEGORI = byte.Parse(drpKategori.SelectedValue);
            deger.BLOGTUR = byte.Parse(drpTur.SelectedValue);
            deger.BLOGICERIK = txtIcerik.Text;
            db.SaveChanges();
            Response.Redirect("Bloglar.aspx");
            
        }
    }
}