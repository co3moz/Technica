using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Technica.DAL;
using Technica.Models;

namespace Technica.Controllers
{
    public class WishController : Controller
    {
        private TechnicaContext db = new TechnicaContext();

        // GET: Wish
        public ActionResult Index()
        {
            if (Session["user"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            User user = Session["user"] as User;
            ViewBag.Wishes = (from w in db.Wishes
                              join e in db.Products on w.ProductID equals e.ID
                              where w.UserID == user.ID
                              select new WishProduct { wish=w, product=e });

            return View();
        }

        [Route("Wish/Add/{id:int}")]
        public ActionResult Add(int id)
        {
            if (Session["user"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            User user = Session["user"] as User;

            try
            {
                Product product = db.Products.Find(id);
                if (product != null)
                {
                    Wish wish = new Wish { UserID = user.ID, ProductID = product.ID };
                    db.Wishes.Add(wish);
                    db.SaveChanges();
                }
                return Redirect(Request.UrlReferrer.ToString());
            }
            catch
            {
                return RedirectToAction("Index", "Home");
            }
        }

        [Route("Wish/Remove/{id:int}")]
        public ActionResult Remove(int id)
        {
            if (Session["user"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            User user = Session["user"] as User;


            try
            {
                Wish wish = db.Wishes.Find(id);
                if (wish.UserID == user.ID)
                {
                    db.Wishes.Remove(wish);
                    db.SaveChanges();
                    return Redirect(Request.UrlReferrer.ToString());
                }
                throw null;
            }
            catch
            {
                return RedirectToAction("Index", "Home");
            }
        }
    }
}