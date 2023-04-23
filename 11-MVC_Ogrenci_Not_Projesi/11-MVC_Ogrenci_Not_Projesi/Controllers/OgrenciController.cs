using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using _11_MVC_Ogrenci_Not_Projesi.Models.EntityFramework;

namespace _11_MVC_Ogrenci_Not_Projesi.Controllers
{
    public class OgrenciController : Controller
    {
        // GET: Ogrenci
        Dbo_MvcOkulEntities db = new Dbo_MvcOkulEntities();
        public ActionResult Index()
        {
            var ogrenciler = db.TBLOGRENCILER.ToList();
            return View(ogrenciler);
        }

        [HttpGet]
        public ActionResult YeniOgrenci()
        {
            List<SelectListItem> degerler = (from i in db.TBLKULUPLER.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = i.KULUPAD,
                                                 Value = i.KULUPID.ToString()
                                             }).ToList();
            ViewBag.dgr = degerler;
            return View();
        }

        [HttpPost]
        public ActionResult YeniOgrenci(TBLOGRENCILER p)
        {
            var klp = db.TBLKULUPLER.Where(m => m.KULUPID == p.TBLKULUPLER.KULUPID).FirstOrDefault();
            p.TBLKULUPLER = klp;
            db.TBLOGRENCILER.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Sil(int id)
        {
            var ogrenci = db.TBLOGRENCILER.Find(id);
            db.TBLOGRENCILER.Remove(ogrenci);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Getir(int id)
        {
            var ogrenci = db.TBLOGRENCILER.Find(id);
            return View("Getir", ogrenci);
        }

        public ActionResult Guncelle(TBLOGRENCILER p)
        {
            var ogrenci = db.TBLOGRENCILER.Find(p.OGRENCIID);
            ogrenci.OGRAD = p.OGRAD;
            ogrenci.OGRSOYAD = p.OGRSOYAD;
            ogrenci.OGRFOTO = p.OGRFOTO;
            ogrenci.OGRCINSIYET = p.OGRCINSIYET;
            ogrenci.OGRKULUP = p.OGRKULUP;
            db.SaveChanges();
            return RedirectToAction("Index", "Ogrenci");
        }

    }
}