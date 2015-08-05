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
    public class CategoryController : Controller
    {
        private TechnicaContext db = new TechnicaContext();


        [Route("Category/View/{id}")]
        public ActionResult View_(string id)
        {
            try
            {
                Category category = db.Categories.Where(x => x.Name.Replace(" ", "-") == id).First<Category>();
                ViewBag.Products = db.Products.Where(x => x.CategoryID == category.ID);
                return View(category);
            }
            catch
            {
                return RedirectToAction("Index", "Home");
            }

        }


        [HttpPost]
        public ActionResult Search()
        {
            try
            {
                string[] keywords = Request["search"].Split(' ');
                ViewBag.Products = db.Products.Where(q => keywords.Any(k => q.Name.Contains(k)));
                return View();
            }
            catch
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
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

            return View(db.Categories.ToList());
        }


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


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name")] Category category)
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
                string fileName = new Random().Next(100000000, 999999999) + Path.GetFileName(photo.FileName);
                photo.SaveAs(Path.Combine(Server.MapPath("~") + "/img/upload/", fileName));
                category.Image = Path.Combine("upload/", fileName);
            }

            if (ModelState.IsValid)
            {
                db.Categories.Add(category);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(category);
        }


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
            Category category = db.Categories.Find(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }

     
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name")] Category category)
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
                string fileName = new Random().Next(100000000, 999999999)  + Path.GetFileName(photo.FileName);
                photo.SaveAs(Path.Combine(Server.MapPath("~") + "/img/upload/", fileName));
                category.Image = Path.Combine("upload/", fileName);
            }

            if (ModelState.IsValid)
            {
                db.Entry(category).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(category);
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
            Category category = db.Categories.Find(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
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

            Category category = db.Categories.Find(id);
            db.Categories.Remove(category);
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
