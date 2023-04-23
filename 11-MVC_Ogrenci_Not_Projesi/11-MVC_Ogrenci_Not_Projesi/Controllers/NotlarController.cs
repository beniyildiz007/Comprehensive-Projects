using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using _11_MVC_Ogrenci_Not_Projesi.Models.EntityFramework;
using _11_MVC_Ogrenci_Not_Projesi.Models;

namespace _11_MVC_Ogrenci_Not_Projesi.Controllers
{
    public class NotlarController : Controller
    {
        // GET: Notlar
        Dbo_MvcOkulEntities db = new Dbo_MvcOkulEntities();
        public ActionResult Index()
        {
            var sinavNotlar = db.TBLNOTLAR.ToList();
            return View(sinavNotlar);
        }

        [HttpGet]
        public ActionResult YeniNotlar()
        {
            return View();
        }

        [HttpPost]
        public ActionResult YeniNotlar(TBLNOTLAR p)
        {
            db.TBLNOTLAR.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Getir(int id)
        {
            var notlar = db.TBLNOTLAR.Find(id);
            return View("Getir", notlar);
        }

        [HttpPost]
        public ActionResult Getir(Class1 model, TBLNOTLAR p, int SINAV1 = 0, int SINAV2 = 0, int SINAV3 = 0, int PROJE = 0)
        {
            if (model.islem == "HESAPLA")
            {
                int ORTALAMA = (SINAV1 + SINAV2 + SINAV3 + PROJE) / 4;
                ViewBag.ort = ORTALAMA;
            }
            if (model.islem == "NOTGUNCELLE")
            {
                var snv = db.TBLNOTLAR.Find(p.NOTID);
                snv.SINAV1 = p.SINAV1;
                snv.SINAV2 = p.SINAV2;
                snv.SINAV3 = p.SINAV3;
                snv.PROJE = p.PROJE;
                snv.ORTALAMA = p.ORTALAMA;
                db.SaveChanges();
                return RedirectToAction("Index", "Notlar");
            }
            return View();
        }
    }
}