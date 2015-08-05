using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Technica.DAL;
using Technica.Models;

namespace Technica.Controllers
{
    public class OrdersController : Controller
    {
        private TechnicaContext db = new TechnicaContext();

        [Route("Orders/View")]
        public ActionResult View_()
        {
            if (Session["user"] == null)
            {
                return RedirectToAction("Index", "Home");
            }

            User user = Session["user"] as User;

            ViewBag.Orders = (from o in db.Orders
                              join c in db.Currencies on o.CurrencyID equals c.ID
                              where o.UserID == user.ID
                              select new OrderCurrency { order = o, currency = c });
            return View();
        }


        public ActionResult Index()
        {
            if (Session["user"] == null)
            {
                return RedirectToAction("Index", "Home");
            }

            if ((Session["user"] as User).Power == Power.Normal)
            {
                return RedirectToAction("Index", "Home");
            }
            ViewBag.Users = db.Users;
            ViewBag.Hidden = true;
            ViewBag.Orders = (from o in db.Orders
                              join c in db.Currencies on o.CurrencyID equals c.ID
                              where o.Hidden == false
                              select new OrderCurrency { order = o, currency = c });
            return View();
        }

        public ActionResult All()
        {
            if (Session["user"] == null)
            {
                return RedirectToAction("Index", "Home");
            }

            if ((Session["user"] as User).Power == Power.Normal)
            {
                return RedirectToAction("Index", "Home");
            }
            ViewBag.Users = db.Users;
            ViewBag.Hidden = false;
            ViewBag.Orders = (from o in db.Orders
                              join c in db.Currencies on o.CurrencyID equals c.ID
                              select new OrderCurrency { order = o, currency = c });
            return View("Index");
        }


        public ActionResult Details(int? id)
        {
            if (Session["user"] == null)
            {
                return RedirectToAction("Index", "Home");
            }

            if ((Session["user"] as User).Power == Power.Normal)
            {
                return RedirectToAction("Index", "Home");
            }

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrderCurrency order = (from o in db.Orders
                          join c in db.Currencies on o.CurrencyID equals c.ID
                          where o.ID == id
                          select new OrderCurrency { order = o, currency = c }).First<OrderCurrency>();

            if (order == null)
            {
                return HttpNotFound();
            }
            ViewBag.Users = db.Users;
           
            return View(order);
        }


        public ActionResult Delete(int? id)
        {
            if (Session["user"] == null)
            {
                return RedirectToAction("Index", "Home");
            }

            if ((Session["user"] as User).Power == Power.Normal)
            {
                return RedirectToAction("Index", "Home");
            }

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrderCurrency order = (from o in db.Orders
                                   join c in db.Currencies on o.CurrencyID equals c.ID
                                   where o.ID == id
                                   select new OrderCurrency { order = o, currency = c }).First<OrderCurrency>();

            if (order == null)
            {
                return HttpNotFound();
            }
            ViewBag.Users = db.Users;
            return View(order);
        }

        public ActionResult Hide(int? id)
        {
            if (Session["user"] == null)
            {
                return RedirectToAction("Index", "Home");
            }

            if ((Session["user"] as User).Power == Power.Normal)
            {
                return RedirectToAction("Index", "Home");
            }

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = db.Orders.Find(id);
            order.Hidden = true;

            db.SaveChanges();
            return Redirect(Request.UrlReferrer.ToString());
        }

        public ActionResult Show(int? id)
        {
            if (Session["user"] == null)
            {
                return RedirectToAction("Index", "Home");
            }

            if ((Session["user"] as User).Power == Power.Normal)
            {
                return RedirectToAction("Index", "Home");
            }

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = db.Orders.Find(id);
            order.Hidden = false;

            db.SaveChanges();
            return Redirect(Request.UrlReferrer.ToString());
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            if (Session["user"] == null)
            {
                return RedirectToAction("Index", "Home");
            }

            if ((Session["user"] as User).Power == Power.Normal)
            {
                return RedirectToAction("Index", "Home");
            }

            Order order = db.Orders.Find(id);
            db.Orders.Remove(order);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
