using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CV_Sitesi.Models.Entity;
using CV_Sitesi.Repositories;

namespace CV_Sitesi.Controllers
{
    public class YeteneklerController : Controller
    {
        // GET: Yetenekler
       
        GenericRepository<TblYeteneklerim> repo = new GenericRepository<TblYeteneklerim>();
        public ActionResult Index()
        {
            var yetenekler = repo.List();
            return View(yetenekler);
        }
        [HttpGet]
        public ActionResult YetenekEkle()
		{
            return View();
		}
        [HttpPost]
        public ActionResult YetenekEkle( TblYeteneklerim p)
		{
            repo.TAdd(p);
            return RedirectToAction("Index");
		}
        public ActionResult YetenekSil(int id)
		{
            var yeteneksil = repo.Find(x => x.ID == id);
            repo.TDelete(yeteneksil);
            return RedirectToAction("Index");
		}
        [HttpGet]
        public ActionResult YetenekDuzelt( int id)
		{
            var yetenek = repo.Find(x => x.ID == id);
            return View(yetenek);
		}
        [HttpPost] 
        public ActionResult YetenekDuzelt(TblYeteneklerim p)
		{
            var yetenek = repo.Find(x => x.ID == p.ID);
            yetenek.Yetenek = p.Yetenek;
            yetenek.Yetenek_Oran = p.Yetenek_Oran;
            repo.Tupdate(yetenek);
            return RedirectToAction("Index");
		}
    }
}