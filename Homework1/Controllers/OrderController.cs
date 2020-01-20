using Homework1.Entities;
using Homework1.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Homework1.Controllers
{
    public class OrderController : Controller
    {
        private UnitOfWorkImpl unitOfWork;

        public OrderController()
        {
            unitOfWork = new UnitOfWorkImpl();
        }

        // GET: Order
        public ActionResult Index()
        {
            var orders = unitOfWork.Order.GetAll();

            ViewBag.UsersList = unitOfWork.User.GetAll().ToList();
            ViewBag.BooksList = unitOfWork.Book.GetAll().ToList();

            return View(orders.ToList());
        }

        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.UsersList = new SelectList(unitOfWork.User.GetAll().ToList(),
                "id", "UsersName");
            ViewBag.BooksList = new SelectList(unitOfWork.Book.GetAll().ToList(),
                "id", "Title");

            return View();           
        }

        [HttpPost]
        public ActionResult Create(Order order)
        {
            if (ModelState.IsValid)
            {
                unitOfWork.Order.Create(order);
                unitOfWork.Book.Save();
            }
            else return View(order);

            return RedirectToAction("Index");
        }
    }
}