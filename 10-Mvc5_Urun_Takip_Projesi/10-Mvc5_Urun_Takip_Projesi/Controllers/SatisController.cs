using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using _10_MVC01_Youtube_Proje.Models.Entity;

namespace _10_MVC01_Youtube_Proje.Controllers
{
    public class SatisController : Controller
    {
        Dbo_MvcStokEntities db = new Dbo_MvcStokEntities();
        // GET: Satis
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult YeniSatis()
        {
            return View();
        }

        [HttpPost]
        public ActionResult YeniSatis( TBLSATISLAR p)
        {
            db.TBLSATISLAR.Add(p);
            db.SaveChanges();
            return View("Index");
        }
    }
}