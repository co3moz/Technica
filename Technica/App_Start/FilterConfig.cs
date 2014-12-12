using System.Diagnostics;
using System.Web;
using System.Web.Mvc;
using Technica.DAL;
using Technica.Models;
using System.Linq;
using System.Collections.Generic;

namespace Technica
{
    public class LanguageFilter : ActionFilterAttribute
    {
        private TechnicaContext db = new TechnicaContext();

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
                List<Basket> basket = new List<Basket>();
                basket.Add(new Basket { product = db.Products.First<Product>(), quantity = 1 });
                session["basket"] = basket;
            }
            base.OnActionExecuting(filterContext);
        }
    }

    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new LanguageFilter());
        }
    }
}
