using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcStok.Models.Entity;
namespace MvcStok.Controllers
{
    public class musteriController : Controller
    {
        MVCdbstokEntities db = new MVCdbstokEntities();
        public ActionResult Index( string p)
        {
            var degerler = from d in db.musteriler select d;
            if (!string .IsNullOrEmpty(p))
            {
                degerler = degerler.Where(m => m.musteriad.Contains(p));
            }
            return View(degerler.ToList());


           // var degerler = db.musteriler.ToList();
           // return View(degerler);
        }

        [HttpGet]
        public ActionResult yenimusteri()
        {
            return View();
        }

        [HttpPost]
        public ActionResult yenimusteri(musteriler p1)
        {
            db.musteriler.Add(p1);
            db.SaveChanges();
            return RedirectToAction("index");
            
        }
        public ActionResult sil(int id)
        {
            var musteri = db.musteriler.Find(id);
            db.musteriler.Remove(musteri);
            db.SaveChanges();
            return RedirectToAction("index");
        }
        public ActionResult musterigetir(int id)
        {
            var mus = db.musteriler.Find(id);
                return View("musterigetir", mus);
        }

        public ActionResult guncelle(musteriler p1)
        {
            var musteri = db.musteriler.Find(p1.musteriid );
            musteri.musteriad = p1.musteriad;
            musteri.musterisoyad = p1.musterisoyad;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}