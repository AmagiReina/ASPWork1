using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace Homework1.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Index()
        {
            using (Model1 db = new Model1())
            {
                var users = db.Users.ToList();

                return View(users);
            }
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(User user)
        {
            using (Model1 db = new Model1())
            {
                if (ModelState.IsValid)
                {
                    db.Users.Add(user);
                    db.SaveChanges();
                }
                else return View(user);
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            using (Model1 db = new Model1())
            {
                var user = db.Users.Find(id);

                return View(user);
            }
        }


        [HttpPost]
        public ActionResult Edit(User user)
        {
            using (Model1 db = new Model1())
            {
                if (ModelState.IsValid)
                {
                    db.Entry(user).State = EntityState.Modified;
                    db.SaveChanges();
                }
                else return View(user);
            }
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            using (Model1 db = new Model1())
            {
                var user = db.Users.Find(id);
                if (user != null)
                {
                    db.Users.Remove(user);
                    db.SaveChanges();
                }
            }
            return RedirectToAction("Index");
        }
    }
}