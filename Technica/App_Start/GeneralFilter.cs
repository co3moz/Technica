using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Technica.DAL;
using Technica.Models;

namespace Technica.App_Start
{
    public class GeneralFilter : ActionFilterAttribute
    {
        private readonly TechnicaContext db = new TechnicaContext();

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var session = filterContext.RequestContext.HttpContext.Session;
            var viewbag = filterContext.Controller.ViewBag;

            Debug.WriteLine("Request Comes");

            viewbag.Currencies = db.Set<Currency>();
            viewbag.Languages = db.Set<Language>();
            viewbag.Categories = db.Set<Category>();

            if (session["language"] == null)
            {
                session["language"] = db.Languages.First<Language>();
            }

            if (session["currency"] == null)
            {
                session["currency"] = db.Currencies.First<Currency>();
            }

            if (session["basket"] == null)
            {
                session["basket"] = new List<Basket>();
            }

            base.OnActionExecuting(filterContext);
        }
    }
}