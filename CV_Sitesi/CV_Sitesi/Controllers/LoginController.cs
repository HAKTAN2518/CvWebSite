using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using CV_Sitesi.Models.Entity;
using CV_Sitesi.Repositories;

namespace CV_Sitesi.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        // GET: Login
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        } 
        [HttpPost]
        public ActionResult Index(TblAdmin p)
        {
            DbCVEntities db = new DbCVEntities();
            var kullanici = db.TblAdmin.FirstOrDefault(x => x.Kullaniciadi == p.Kullaniciadi && x.Sifre == p.Sifre);
			if (kullanici != null)
			{
                FormsAuthentication.SetAuthCookie(kullanici.Kullaniciadi, false);
                Session["Kullaniciadi"] = kullanici.Kullaniciadi.ToString();
                return RedirectToAction("Index","Hakkimda");
			}
			else
			{
                return RedirectToAction("Index", "Login");
			}
            
        }
        public ActionResult LogOut()
		{
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Index", "Login");
		}
    }
}