using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using _12_MVC_Stok_Takip_Projesi.Models.Entity;

namespace _12_MVC_Stok_Takip_Projesi.Controllers
{
    public class UrunController : Controller
    {
        // GET: Urun
        Dbo_BonusMvcStokEntities db = new Dbo_BonusMvcStokEntities();
        public ActionResult Index(string p)
        {
            //var urunler = db.TBLURUNLER.Where(x => x.DURUM == true).ToList();
            var urunler = db.TBLURUNLER.Where(x => x.DURUM == true);
            if (!string.IsNullOrEmpty(p))
            {
                urunler = urunler.Where(x => x.AD.Contains(p) && x.DURUM == true);
            }
            return View(urunler.ToList());
        }

        [HttpGet]
        public ActionResult YeniUrun()
        {
            List<SelectListItem> ktg = (from x in db.TBLKATEGORI.ToList()
                                        select new SelectListItem
                                        {
                                            Text = x.AD,
                                            Value = x.ID.ToString()
                                        }).ToList();
            ViewBag.drop = ktg;
            return View();
        }

        [HttpPost]
        public ActionResult YeniUrun(TBLURUNLER p)
        {
            var ktgr = db.TBLKATEGORI.Where(x => x.ID == p.TBLKATEGORI.ID).FirstOrDefault();
            p.TBLKATEGORI = ktgr;
            db.TBLURUNLER.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult UrunGetir(int id)
        {
            List<SelectListItem> kat = (from x in db.TBLKATEGORI.ToList()
                                        select new SelectListItem
                                        {
                                            Text = x.AD,
                                            Value = x.ID.ToString()
                                        }).ToList();
            ViewBag.urunkat = kat;
            var urun = db.TBLURUNLER.Find(id);
            return View("UrunGetir", urun);
        }

        public ActionResult UrunGuncelle(TBLURUNLER p)
        {
            var urun = db.TBLURUNLER.Find(p.ID);
            urun.MARKA = p.MARKA;
            urun.SATISFIYAT = p.SATISFIYAT;
            urun.STOK = p.STOK;
            urun.ALISFIYAT = p.ALISFIYAT;
            urun.AD = p.AD;
            var ktg = db.TBLKATEGORI.Where(x => x.ID == p.TBLKATEGORI.ID).FirstOrDefault();
            urun.KATEGORI = ktg.ID;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult UrunSil(TBLURUNLER p)
        {
            var urunbul = db.TBLURUNLER.Find(p.ID);
            urunbul.DURUM = false;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}