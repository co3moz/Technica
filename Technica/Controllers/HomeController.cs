using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Technica.DAL;
using Technica.Models;

namespace Technica.Controllers
{
    public class HomeController : Controller
    {
        private TechnicaContext db = new TechnicaContext();

        public ActionResult Index()
        {
            ViewBag.Currencies = db.Set<Currency>();
            ViewBag.Languages = db.Set<Language>();
            return View();
        }
    }
}