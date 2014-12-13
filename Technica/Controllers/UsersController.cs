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
    public class UsersController : Controller
    {
        private TechnicaContext db = new TechnicaContext();

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LoginService([Bind(Include = "Email, Password")] User user)
        {
            if (Session["user"] == null)
            {
                User userFind = db.Users.Where(u => u.Email == user.Email).SingleOrDefault();
                if (userFind != null)
                {
                    if (userFind.Password != user.Password)
                    {
                        return Content("Wrong Password");
                    }
                    userFind.LastAccessDate = DateTime.Now;
                    Session["user"] = userFind;

                    if (ModelState.IsValid)
                    {
                        db.Entry(userFind).State = EntityState.Modified;
                        db.SaveChanges();
                    }
                    return Content("ok");
                }
                return Content("User not exists.");
            }
            return Content("ok");
        }

        [HttpPost]
        public ActionResult LogoutService()
        {
            if (Session["user"] == null)
            {
                return Content("You didn't logined yet.");
            }

            Session["user"] = null;
            return Content("ok");
        }

        public ActionResult Register()
        {
            if (Session["user"] == null)
            {
                return View();
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult RegisterService([Bind(Include = "Email, Password, FirstName, LastName, Phone")] User user)
        {
            if (Session["user"] == null)
            {
                User userFind = db.Users.Where(u => u.Email == user.Email).SingleOrDefault();
                if (userFind != null)
                {
                    return Content("This email has been taken.");
                }

                user.Power = Power.Normal;
                user.LastAccessDate = user.RegistrationDate = DateTime.Now;

                if (ModelState.IsValid)
                {
                    db.Users.Add(user);
                    db.SaveChanges();

                    return Content("ok");
                }
                return Content("Some problems appeared in ModelState");
            }
            return Content("Not legal..");
        }


        // GET: Users
        public ActionResult Index()
        {
            return View(db.Users.ToList());
        }

        // GET: Users/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // GET: Users/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Users/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Email,Password,FirstName,LastName,RegistrationDate,LastAccessDate,Cellphone")] User user)
        {
            if (ModelState.IsValid)
            {
                db.Users.Add(user);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(user);
        }

        // GET: Users/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: Users/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Email,Password,FirstName,LastName,RegistrationDate,LastAccessDate,Cellphone")] User user)
        {
            if (ModelState.IsValid)
            {
                db.Entry(user).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(user);
        }

        // GET: Users/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            User user = db.Users.Find(id);
            db.Users.Remove(user);
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
