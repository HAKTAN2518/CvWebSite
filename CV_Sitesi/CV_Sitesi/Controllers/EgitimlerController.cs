using CV_Sitesi.Models.Entity;
using CV_Sitesi.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CV_Sitesi.Controllers
{
    public class EgitimlerController : Controller
    {
		// GET: Egitimler
		readonly GenericRepository<TblEgitimlerim> repo = new GenericRepository<TblEgitimlerim>();
        public ActionResult Index()
        {
            var egitim = repo.List();
            return View(egitim);
        }
         [HttpGet]
         public ActionResult EgitimEkle()
		{
            return View();
		}
        [HttpPost]
        public ActionResult EgitimEkle(TblEgitimlerim t)
		{
			if (!ModelState.IsValid)
			{
                return View("EgitimEkle");
			}
            repo.TAdd(t);
            return RedirectToAction("Index");
		}
        public ActionResult EgitimSil(int id)
		{
            var egitrim = repo.Find(x => x.ID == id);
            repo.TDelete(egitrim);
            return RedirectToAction("Index");
		}
        [HttpGet]
        public ActionResult EgitimDuzenle(int id)
		{
            var egitim = repo.Find(x => x.ID == id);
            return View(egitim);
		}
        [HttpPost]
        public ActionResult EgitimDuzenle(TblEgitimlerim p)
		{
            var egitim = repo.Find(x => x.ID == p.ID);
            egitim.Baslik = p.Baslik;
            egitim.Altbaslik = p.Altbaslik;
            egitim.Altbaslik2 = p.Altbaslik2;
            egitim.GNO = p.GNO;
            egitim.Tarih = p.Tarih;
            repo.Tupdate(egitim);
            return RedirectToAction("Index");
        }
    }
}