using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcStok.Models.Entity;

namespace MvcStok.Controllers
{
    public class satisController : Controller
    {
        MVCdbstokEntities db = new MVCdbstokEntities();
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult yenisatis()
        {
            return View();

        }
        [HttpPost]
        public ActionResult yenisatis(satislar p)
                    {
            db.satislar.Add(p);
            db.SaveChanges();
            return View("index");
            
        }
    }
}