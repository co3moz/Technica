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

        public ActionResult Logout()
        {
            if (Session["user"] == null)
            {
                return RedirectToAction("Index", "Home");
            }

            Session["user"] = null;
            return RedirectToAction("Index", "Home");
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


        public ActionResult Panel()
        {
            if (Session["user"] == null)
            {
                return RedirectToAction("Index", "Home");
            }

            return View(Session["user"]);
        }

        public ActionResult Admin()
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
        public ActionResult ChangeService([Bind(Include = "Password,FirstName,LastName,Phone")] User user)
        {
            if (Session["user"] == null)
            {
                return RedirectToAction("Index", "Home");
            }

            User u = Session["user"] as User;
            u.Password = user.Password;
            u.FirstName = user.FirstName;
            u.LastName = user.LastName;
            if (user.Password != null)
            {
                u.Phone = user.Phone;
            }

            if (ModelState.IsValid)
            {
                db.Entry(u).State = EntityState.Modified;
                db.SaveChanges();
                return Content("ok");
            }
            return Content("Some problems appeared in ModelState");
        }


        // GET: Users
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

            return View(db.Users.ToList());
        }

        // GET: Users/Details/5
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

        // POST: Users/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Email,Password,FirstName,LastName,RegistrationDate,LastAccessDate,Phone")] User user)
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
                db.Users.Add(user);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(user);
        }

        // GET: Users/Edit/5
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
        public ActionResult Edit([Bind(Include = "ID,Email,Password,FirstName,LastName,RegistrationDate,LastAccessDate,Phone")] User user)
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
                db.Entry(user).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(user);
        }

        // GET: Users/Delete/5
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
            if (Session["user"] == null)
            {
                return RedirectToAction("Index", "Home");
            }

            if ((Session["user"] as User).Power == Power.Normal)
            {
                return RedirectToAction("Index", "Home");
            }

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
