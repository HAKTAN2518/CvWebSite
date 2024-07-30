using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CV_Sitesi.Models.Entity;
using CV_Sitesi.Repositories;

namespace CV_Sitesi.Controllers
{
    public class SosyalMedyaController : Controller
    {
        // GET: SosyalMedya
        GenericRepository<TblSosyalMedya> repo = new GenericRepository<TblSosyalMedya>();
        public ActionResult Index()
        {
            var veriler  = repo.List();
            return View(veriler);
        }
        [HttpGet]
        public  ActionResult Ekle()
		{
            return View();
		}
        [HttpPost]
        public ActionResult Ekle(TblSosyalMedya p)
		{
            repo.TAdd(p);
            return RedirectToAction("Index") ;
		}
        [HttpGet]
        public ActionResult SayfaGetir(int id)
		{
            var hesap = repo.Find( x=> x.ID == id);
            return View(hesap);

		}
        [HttpPost]
        public ActionResult SayfaGetir(TblSosyalMedya k)
        {
            var hesap = repo.Find(x => x.ID == k.ID);
            hesap.Ad = k.Ad;
            hesap.icon = k.icon;
            hesap.Link = k.Link;
            repo.Tupdate(hesap);
            return RedirectToAction("Index");

        }
        public ActionResult Sil(int id)
		{
            var sil = repo.Find(x => x.ID == id);
            repo.TDelete(sil);
            return RedirectToAction("Index");

		}
    }
}