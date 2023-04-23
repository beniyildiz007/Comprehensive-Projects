using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using _12_MVC_Stok_Takip_Projesi.Models.Entity;

namespace _12_MVC_Stok_Takip_Projesi.Controllers
{
    public class SatislarController : Controller
    {
        // GET: Satislar
        Dbo_BonusMvcStokEntities db = new Dbo_BonusMvcStokEntities();
        public ActionResult Index()
        {
            var satislar = db.TBLSATISLAR.ToList();
            return View(satislar);
        }

        [HttpGet]
        public ActionResult YeniSatis()
        {
            //Ürünler
            List<SelectListItem> urun = (from x in db.TBLURUNLER.ToList()
                                         select new SelectListItem
                                         {
                                             Text = x.AD,
                                             Value = x.ID.ToString()
                                         }).ToList();
            ViewBag.drop = urun;


            //Personel
            List<SelectListItem> per = (from x in db.TBLPERSONEL.ToList()
                                        select new SelectListItem
                                        {
                                            Text = x.AD + " " + x.SOYAD,
                                            Value = x.ID.ToString()
                                        }).ToList();
            ViewBag.drop2 = per;


            //Müşteriler
            List<SelectListItem> must = (from x in db.TBLMUSTERI.ToList()
                                         select new SelectListItem
                                         {
                                             Text = x.AD + " " + x.SOYAD,
                                             Value = x.ID.ToString()
                                         }).ToList();
            ViewBag.drop3 = must;
            return View();
        }

        [HttpPost]
        public ActionResult YeniSatis(TBLSATISLAR p)
        {
            var urun = db.TBLURUNLER.Where(x => x.ID == p.TBLURUNLER.ID).FirstOrDefault();
            var musteri = db.TBLMUSTERI.Where(x => x.ID == p.TBLMUSTERI.ID).FirstOrDefault();
            var personel = db.TBLPERSONEL.Where(x => x.ID == p.TBLPERSONEL.ID).FirstOrDefault();
            p.TBLURUNLER = urun;
            p.TBLMUSTERI = musteri;
            p.TBLPERSONEL = personel;
            p.TARIH = DateTime.Parse(DateTime.Now.ToShortDateString());
            db.TBLSATISLAR.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}