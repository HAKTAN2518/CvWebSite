using CV_Sitesi.Models.Entity;
using CV_Sitesi.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace CV_Sitesi.Controllers
{
    public class SertifkalarController : Controller
    {
        // GET: Sertifkalar
         GenericRepository<TblSertifkalarim> repok = new GenericRepository<TblSertifkalarim>();
        public ActionResult Index()
        {
            var sertifika = repok.List();
            return View(sertifika);
        }
        [HttpGet]
        public ActionResult SertifkaDuzenle(int id)
		{
            var sertifka = repok.Find(x => x.ID == id);
            return View(sertifka);
		}
        [HttpPost]
        public ActionResult SertifkaDuzenle(TblSertifkalarim p)
		{
            var sertifka = repok.Find(x => x.ID == p.ID);
            sertifka.ID = p.ID;
            sertifka.Tarih = p.Tarih;
            sertifka.Aciklma = p.Aciklma;
            repok.Tupdate(sertifka);
            return RedirectToAction("Index");
        }
        public ActionResult SertifkaSil(int id)
		{
            var sertifka = repok.Find(x => x.ID == id);
            repok.TDelete(sertifka);
            return RedirectToAction("Index");
        }
        [HttpGet]
         public ActionResult SertifkaEkle()
		{
            return View();
		}
        [HttpPost]
        public ActionResult SertifkaEkle(TblSertifkalarim p)
		{
            repok.TAdd(p);
            return RedirectToAction("Index");
		}
    }   

}