using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Technica.DAL;
using Technica.Models;

namespace Technica.Controllers
{
    public class CheckoutController : Controller
    {
        private TechnicaContext db = new TechnicaContext();

        [Route("Checkout")]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Checkout")]
        public ActionResult IndexPost()
        {
            if (Session["user"] == null)
            {
                return RedirectToAction("Index", "Home");
            }

            User user = Session["user"] as User;
            List<Basket> basket = Session["basket"] as List<Basket>;

            Order order = new Order();
            order.ActualAddress = Request["ActualAddress"];
            order.City = Request["City"];
            order.Country = Request["Country"];
            order.Notes = Request["Notes"];
            order.CurrencyID = (Session["currency"] as Currency).ID;
            order.Date = DateTime.Now;
            order.ZipCode = Request["ZipCode"];
            order.UserID = user.ID;

            List<Product> products = new List<Product>();

            decimal money = 0;
            foreach (Basket b in basket)
            {
                money += b.product.Price;
                products.Add(b.product);
            }

            order.Count = products.Count;
            order.Price = money;
            order.JsonProducts = JsonConvert.SerializeObject(products);

            if (ModelState.IsValid)
            {
                db.Orders.Add(order);
                db.SaveChanges();
                return RedirectToAction("Success");
            }
            return RedirectToAction("Index","Home");
        }

        public ActionResult Success()
        {
            return View();
        }
    }
}