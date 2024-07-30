using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CV_Sitesi.Models.Entity;
using CV_Sitesi.Repositories;

namespace CV_Sitesi.Controllers
{
    public class HakkimdaController : Controller
    {
        
        // GET: Hakkimda
        DbCVEntities db = new DbCVEntities();
        GenericRepository<TblHakkimda> rep = new GenericRepository<TblHakkimda>();
        [HttpGet]
        public ActionResult Index()
        {
            var hakkimda = rep.List();
            
            return View(hakkimda);
        }
        [HttpPost]
        public ActionResult Index(TblHakkimda p)
		{
            var t = rep.Find(x => x.ID == 1);
            t.Aciklama = p.Aciklama;
            t.Ad = p.Ad;
            t.Adres = p.Adres;
            t.Mail = p.Mail;
            t.Soyad = p.Soyad;
            t.Telefon = p.Telefon;
            t.Resim = p.Resim;
            rep.Tupdate(t);
            return RedirectToAction("Index");
		}
    }
}