using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CV_Sitesi.Models.Entity;

namespace CV_Sitesi.Controllers
{
    [AllowAnonymous]
    public class DefaultController : Controller
    {
        // GET: Default
        DbCVEntities db = new DbCVEntities();
        public ActionResult Index()
        {
            var degerler = db.TblHakkimda.ToList();
            return View(degerler);
        }
        public PartialViewResult SosyalMedya()
        {
            var sosyalmedya = db.TblSosyalMedya.ToList();
            return PartialView(sosyalmedya);
        }
        public PartialViewResult Deneyim()
		{
            var deneyimler = db.TblDeneyimlerim.ToList();
            return PartialView(deneyimler);
		}
        public PartialViewResult Egitimler()
		{
            var egitimler = db.TblEgitimlerim.ToList();
            return PartialView(egitimler);
		}
        public PartialViewResult Yetenekler()
        {
            var yetenekler = db.TblYeteneklerim.ToList();
            return PartialView(yetenekler);
        }
        public PartialViewResult Hobiler()
		{
            var hobiler = db.TblHobilerim.ToList();
            return PartialView(hobiler);
		}
        public PartialViewResult Sertifkalar()
		{
            var sertifcalar = db.TblSertifkalarim.ToList();
            return PartialView(sertifcalar);
		}
        [HttpGet]
        public PartialViewResult iletisim()
		{
            return PartialView();
		}
        [HttpPost]
        public PartialViewResult iletisim(Tbliletisim t)
        {
            t.Tarih = DateTime.Parse(DateTime.Now.ToString());
            db.Tbliletisim.Add(t);
            db.SaveChanges();
            return PartialView();
        }
    }
}