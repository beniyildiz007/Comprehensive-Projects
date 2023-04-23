using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using _12_MVC_Stok_Takip_Projesi.Models.Entity;
using System.Web.Security;

namespace _12_MVC_Stok_Takip_Projesi.Controllers
{
    public class GirisYapController : Controller
    {
        // GET: GirisYap
        Dbo_BonusMvcStokEntities db = new Dbo_BonusMvcStokEntities();
        public ActionResult Giris()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Giris(TBLADMIN p)
        {
            var bilgiler = db.TBLADMIN.FirstOrDefault(x => x.KULLANICI == p.KULLANICI && x.SIFRE == p.SIFRE);
            if (bilgiler != null)
            {
                FormsAuthentication.SetAuthCookie(bilgiler.KULLANICI, false);
                return RedirectToAction("Index", "Musteri");
            }
            else
            {
                return View();
            }
        }
    }
}