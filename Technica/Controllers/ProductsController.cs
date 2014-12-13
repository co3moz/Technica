using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Technica.DAL;
using Technica.Models;

namespace Technica.Controllers
{
    public class ProductsController : Controller
    {
        private TechnicaContext db = new TechnicaContext();

        [Route("Products/View/{id}")]
        public ActionResult View_(string id)
        {
            try
            {
                Product product = db.Products.Where(x => x.Name.Replace(" ", "-") == id).First<Product>();
                return View(product);
            }
            catch
            {
                return RedirectToAction("Index", "Home");
            }
            
        }

        



        // GET: Products
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

            return View(db.Products.ToList());
        }

        // GET: Products/Details/5
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
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // GET: Products/Create
        public ActionResult Create()
        {
            if (Session["user"] == null)
            {
                return RedirectToAction("Index", "Home");
            }

            if ((Session["user"] as User).Power == Power.Normal)
            {
                return RedirectToAction("Index", "Home");
            }

            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,CategoryID,Name,Price,OldPrice,Image,SellCount,Stock")] Product product)
        {
            if (Session["user"] == null)
            {
                return RedirectToAction("Index", "Home");
            }

            if ((Session["user"] as User).Power == Power.Normal)
            {
                return RedirectToAction("Index", "Home");
            }

            HttpPostedFileBase photo = Request.Files["photo"];

            if (photo != null && photo.ContentLength > 0)
            {
                var fileName = Path.GetFileName(photo.FileName);
                photo.SaveAs(Path.Combine(Server.MapPath("~") + "/img/upload/", fileName));
                product.Image = Path.Combine("/upload/" ,fileName);
            }

            if (ModelState.IsValid)
            {
                db.Products.Add(product);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(product);
        }

        // GET: Products/Edit/5
        public ActionResult Edit(int? id)
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
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,CategoryID,Name,Price,OldPrice,Image,SellCount,Stock")] Product product)
        {
            if (Session["user"] == null)
            {
                return RedirectToAction("Index", "Home");
            }

            if ((Session["user"] as User).Power == Power.Normal)
            {
                return RedirectToAction("Index", "Home");
            }

            if (ModelState.IsValid)
            {
                db.Entry(product).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(product);
        }

        // GET: Products/Delete/5
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
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Products/Delete/5
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

            Product product = db.Products.Find(id);
            db.Products.Remove(product);
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
