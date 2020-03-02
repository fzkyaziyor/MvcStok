using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcStok.Models.Entity;
namespace MvcStok.Controllers
{
    public class UrunController : Controller
    {
        MVCdbstokEntities db = new MVCdbstokEntities();
        public ActionResult Index()

        {
            var degerler = db.urunler.ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult UrunEkle()
        {
            List<SelectListItem> degerler = (from i in db.kategoriler.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = i.kategoriad,
                                                 Value = i.kategoriid.ToString()
                                             }).ToList();
            ViewBag.dgr = degerler;
                       return View();
        }
        [HttpPost ]
        public ActionResult UrunEkle(urunler p1)
        {
            var ktr = db.kategoriler.Where(m => m.kategoriid == p1.kategoriler.kategoriid).FirstOrDefault();
            p1.kategoriler = ktr;
            db.urunler.Add(p1);
            db.SaveChanges();
            return RedirectToAction("index");
        }
        public ActionResult sil(int id)
        {
            var urun = db.urunler.Find(id);
            db.urunler.Remove(urun);
            db.SaveChanges();
            return RedirectToAction("index");
        }
    }
}