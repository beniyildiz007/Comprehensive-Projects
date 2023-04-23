using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using _11_MVC_Ogrenci_Not_Projesi.Models.EntityFramework;

namespace _11_MVC_Ogrenci_Not_Projesi.Controllers
{
    public class DefaultController : Controller
    {
        // GET: Default
        Dbo_MvcOkulEntities db = new Dbo_MvcOkulEntities();
        public ActionResult Index()
        {
            var dersler = db.TBLDERSLER.ToList();
            return View(dersler);
        }

        [HttpGet]
        public ActionResult YeniDers()
        {
            return View();
        }

        [HttpPost]
        public ActionResult YeniDers(TBLDERSLER p)
        {
            db.TBLDERSLER.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Sil(int id)
        {
            var ders = db.TBLDERSLER.Find(id);
            db.TBLDERSLER.Remove(ders);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Getir(int id)
        {
            var ders = db.TBLDERSLER.Find(id);
            return View("Getir", ders);
        }

        public ActionResult Guncelle(TBLDERSLER p)
        {
            var ders = db.TBLDERSLER.Find(p.DERSID);
            ders.DERSAD = p.DERSAD;
            db.SaveChanges();
            return RedirectToAction("Index", "Default");
        }


    }
}