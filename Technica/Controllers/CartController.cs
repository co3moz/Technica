using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Technica.DAL;
using Technica.Models;

namespace Technica.Controllers
{
    public class CartController : Controller
    {
        private TechnicaContext db = new TechnicaContext();

        public ActionResult Index()
        {
            return View();
        }

        [Route("Cart/AddService/{id:int}/{quantity:int}")]
        public ActionResult AddService(int id, int quantity)
        {
            Product product = db.Products.Find(id);
            if (product != null)
            {
                List<Basket> basket = Session["basket"] as List<Basket>;
                basket.Add(new Basket { product =   product, quantity = quantity });
                return Content("ok");
            }
            return Content("Product not exists");
        }


        [Route("Cart/Add/{id:int}/{quantity:int}")]
        public ActionResult Add(int id, int quantity)
        {
            try
            {
                Product product = db.Products.Find(id);
                if (product != null)
                {
                    List<Basket> basket = Session["basket"] as List<Basket>;
                    basket.Add(new Basket { product = product, quantity = quantity });
                }
                return Redirect(Request.UrlReferrer.ToString());
            }
            catch
            {
                return RedirectToAction("Index", "Home");
            }
        }

    }
}