using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using _12_MVC_Stok_Takip_Projesi.Models.Entity;

namespace _12_MVC_Stok_Takip_Projesi.Controllers
{
    public class KategoriController : Controller
    {
        // GET: Kategori
        Dbo_BonusMvcStokEntities db = new Dbo_BonusMvcStokEntities();
        public ActionResult Index()
        {
            var kategoriler = db.TBLKATEGORI.ToList();
            return View(kategoriler);
        }

        [HttpGet]
        public ActionResult YeniKategori()
        {
            return View();
        }

        [HttpPost]
        public ActionResult YeniKategori(TBLKATEGORI p)
        {
            db.TBLKATEGORI.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult KategoriSil(int id)
        {
            var ktg = db.TBLKATEGORI.Find(id);
            db.TBLKATEGORI.Remove(ktg);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult KategoriGetir(int id)
        {
            var ktgr = db.TBLKATEGORI.Find(id);
            return View("KategoriGetir", ktgr);
        }

        [HttpPost]
        public ActionResult KategoriGuncelle(TBLKATEGORI p)
        {
            var ktg = db.TBLKATEGORI.Find(p.ID);
            ktg.AD = p.AD;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}