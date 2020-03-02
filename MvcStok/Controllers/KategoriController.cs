using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcStok.Models.Entity;
using PagedList;
using PagedList.Mvc;

//moderlimi kutuphane olarak tanımlıyorum

namespace MvcStok.Controllers
{
    public class KategoriController : Controller
    {
        MVCdbstokEntities db = new MVCdbstokEntities();
        //benim modelimi tutuyor

        public ActionResult Index(int sayfa=1)
        {
            // var degerler = db.kategoriler.ToList();
            var degerler = db.kategoriler.ToList().ToPagedList(sayfa, 4);
            return View(degerler);
        }
    
        public ActionResult sil(int id)
        {
            var kategori = db.kategoriler.Find(id);
            db.kategoriler.Remove(kategori);
            db.SaveChanges();
            return RedirectToAction("index");
        }
        [HttpGet]
        public ActionResult yenikategori()
        {
            return View();
        }
        [HttpPost]
        public ActionResult yenikategori(kategoriler p1)
        {
            db.kategoriler.Add(p1);
            db.SaveChanges();
                 
            return RedirectToAction("index");
        }
        public ActionResult kategorigetir(int id)
        {
            var ktg = db.kategoriler.Find(id);
            return View("kategorigetir", ktg);
        }
        [HttpPost ]
        public ActionResult guncelle(kategoriler p1)
        {
            var ktg = db.kategoriler.Find(p1.kategoriid);
            ktg.kategoriad = p1.kategoriad;
            db.SaveChanges();
            return RedirectToAction("Index");
                
        }

    }
}