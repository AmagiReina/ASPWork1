using Homework1.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Homework1.Controllers
{
    public class OrderController : Controller
    {
        // GET: Order
        public ActionResult Index()
        {
            using (Model1 db = new Model1())
            {
                var orders = db.Orders.ToList();

                ViewBag.UsersList = db.Users.ToList();
                ViewBag.BooksList = db.Books.ToList();

                return View(orders);
            }
        }

        [HttpGet]
        public ActionResult Create()
        {
            using (Model1 db = new Model1())
            {
                ViewBag.UsersList = new SelectList(db.Users.ToList(), "id", "UsersName");
                ViewBag.BooksList = new SelectList(db.Books.ToList(), "id", "Title");

                return View();
            }
        }

        [HttpPost]
        public ActionResult Create(Order order)
        {
            using (Model1 db = new Model1())
            {
                if (ModelState.IsValid)
                {
                    db.Orders.Add(order);
                    db.SaveChanges();
                }
                else return View(order);
            }
            return RedirectToAction("Index");
        }
    }
}