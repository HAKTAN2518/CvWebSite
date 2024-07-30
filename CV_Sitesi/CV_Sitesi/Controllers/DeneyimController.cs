using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CV_Sitesi.Models.Entity;
using CV_Sitesi.Repositories;

namespace CV_Sitesi.Controllers
{
    public class DeneyimController : Controller
    {
        // GET: Deneyim
        DeneyimlerRep rep = new DeneyimlerRep();
        public ActionResult Index()
        {
            var degerler = rep.List();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult Deneyimekle()
		{
            return View();

		}
        [HttpPost]
        public ActionResult Deneyimekle(TblDeneyimlerim p)
		{
			if (!ModelState.IsValid)
			{
                return View("Deneyimekle");
			}
            rep.TAdd(p);
            return RedirectToAction("Index");

		}
        public ActionResult DeneyimSil(int id)
		{
            TblDeneyimlerim t = rep.Find(x=> x.ID ==id);
            rep.TDelete(t);
            return RedirectToAction("Index");

		}
        [HttpGet]
        public ActionResult DeneyimGetir( int id)
		{
            TblDeneyimlerim t = rep.Find(x => x.ID == id);
            return View(t);
        }
        [HttpPost]
        public ActionResult DeneyimGetir(TblDeneyimlerim p)
		{
            TblDeneyimlerim t = rep.Find(x => x.ID == p.ID);
            t.ID = p.ID;
            t.Baslik = p.Baslik;
            t.Altbaslik = p.Altbaslik;
            t.Aciklama = p.Aciklama;
            t.Tarih = p.Tarih;
            rep.Tupdate(t);
            return RedirectToAction("Index");
        }
    }
}
	