using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CV_Sitesi.Models.Entity;
using CV_Sitesi.Repositories;

namespace CV_Sitesi.Controllers
{
    
    public class AdminController : Controller
    {
        // GET: Admin

        GenericRepository<TblAdmin> repo = new GenericRepository<TblAdmin>();

        public ActionResult Index()
        {
            var liste = repo.List();
            return View(liste);
        }
        [HttpGet]
        public ActionResult AdminEkle()
        {
            return View();

        }
        [HttpPost]
        public ActionResult AdminEkle(TblAdmin p)
        {
            if (!ModelState.IsValid)
            {
                return View("AdminEkle");
            }
            repo.TAdd(p);
            return RedirectToAction("Index");

        }
        public ActionResult AdminSil(int id)
        {
            TblAdmin t = repo.Find(x => x.ID == id);
            repo.TDelete(t);
            return RedirectToAction("Index");

        }
        [HttpGet]
        public ActionResult AdminDuzenle(int id)
        {
            TblAdmin t = repo.Find(x => x.ID == id);
            return View(t);
        }
        [HttpPost]
        public ActionResult AdminDuzenle (TblAdmin p)
        {
            TblAdmin t = repo.Find(x => x.ID == p.ID);
            t.ID = p.ID;
            t.Kullaniciadi = p.Kullaniciadi;
            t.Sifre = p.Sifre;
            repo.Tupdate(t);
            return RedirectToAction("Index");
        }
    }
}
