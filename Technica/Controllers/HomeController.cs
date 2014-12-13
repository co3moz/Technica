using System;
using System.Collections.Generic;
using System.Data.Entity.SqlServer;
using System.Diagnostics;
using System.Linq;
using System.Net;
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
            ViewBag.RandomProducts = db.Products.OrderBy(x => Guid.NewGuid()).Take(8);
            return View();
        }

        public ActionResult Currency(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Currency currency = db.Currencies.Find(id);
            if (currency != null)
            {
                Session["currency"] = currency;
            }
            return RedirectToAction("Index");
        }

        public ActionResult Language(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Language language = db.Languages.Find(id);
            if (language != null)
            {
                Session["language"] = language;
            }
            return RedirectToAction("Index");
        }
    }
}