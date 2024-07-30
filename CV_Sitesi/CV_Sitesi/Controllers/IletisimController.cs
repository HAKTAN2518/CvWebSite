using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CV_Sitesi.Models.Entity;
using CV_Sitesi.Repositories;

namespace CV_Sitesi.Controllers
{
    public class IletisimController : Controller
    {
        // GET: Iletisim
        GenericRepository<Tbliletisim> rep = new GenericRepository<Tbliletisim>();
        public ActionResult Index()
        {
            var mesajlar = rep.List();
            return View(mesajlar);
        }
    }
}