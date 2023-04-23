using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using _11_MVC_Ogrenci_Not_Projesi.Models.EntityFramework;

namespace _11_MVC_Ogrenci_Not_Projesi.Controllers
{
    public class KuluplerController : Controller
    {
        // GET: Kulupler
        Dbo_MvcOkulEntities db = new Dbo_MvcOkulEntities();
        public ActionResult Index()
        {
            var kulupler = db.TBLKULUPLER.ToList();
            return View(kulupler);
        }

        [HttpGet]
        public ActionResult YeniKulup()
        {
            return View();
        }

        [HttpPost]
        public ActionResult YeniKulup(TBLKULUPLER p)
        {
            db.TBLKULUPLER.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Sil(int id)
        {
            var kulup = db.TBLKULUPLER.Find(id);
            db.TBLKULUPLER.Remove(kulup);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Getir(int id)
        {
            var kulup = db.TBLKULUPLER.Find(id);
            return View("Getir", kulup);
        }

        public ActionResult Guncelle(TBLKULUPLER p)
        {
            var kulup = db.TBLKULUPLER.Find(p.KULUPID);
            kulup.KULUPAD = p.KULUPAD;
            db.SaveChanges();
            return RedirectToAction("Index", "Kulupler");
        }

    }
}