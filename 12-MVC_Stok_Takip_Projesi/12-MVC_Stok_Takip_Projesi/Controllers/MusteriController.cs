using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using _12_MVC_Stok_Takip_Projesi.Models.Entity;
using PagedList;
using PagedList.Mvc;

namespace _12_MVC_Stok_Takip_Projesi.Controllers
{
    public class MusteriController : Controller
    {
        // GET: Musteri
        Dbo_BonusMvcStokEntities db = new Dbo_BonusMvcStokEntities();
        [Authorize]
        public ActionResult Index(int sayfa = 1)
        {
            //var musteriListe = db.TBLMUSTERI.ToList();
            var musteriListe = db.TBLMUSTERI.Where(x=>x.DURUM==true).ToList().ToPagedList(sayfa, 3);
            return View(musteriListe);
        }

        [HttpGet]
        public ActionResult YeniMusteri()
        {
            return View();
        }

        [HttpPost]
        public ActionResult YeniMusteri(TBLMUSTERI p)
        {
            if (!ModelState.IsValid)
            {
                return View("YeniMusteri");
            }
            db.TBLMUSTERI.Add(p);
            p.DURUM = true;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult MusteriSil(TBLMUSTERI p)
        {
            var musteriBul = db.TBLMUSTERI.Find(p.ID);
            musteriBul.DURUM = false;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult MusteriGetir(int id)
        {
            var mst = db.TBLMUSTERI.Find(id);
            return View("MusteriGetir", mst);
        }

        public ActionResult MusteriGuncelle(TBLMUSTERI p)
        {
            var mus = db.TBLMUSTERI.Find(p.ID);
            mus.AD = p.AD;
            mus.SOYAD = p.SOYAD;
            mus.SEHIR = p.SEHIR;
            mus.BAKIYE = p.BAKIYE;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}