using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using Homework1.UnitOfWork;

namespace Homework1.Controllers
{
    public class UserController : Controller
    {
        private UnitOfWorkImpl unitOfWork;

        public UserController()
        {
            unitOfWork = new UnitOfWorkImpl();
        }

        // GET: User
        public ActionResult Index()
        {
            var users = unitOfWork.User.GetAll();

            return View(users.ToList());
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(User user)
        {
            if (ModelState.IsValid)
            {
                unitOfWork.User.Create(user);
                unitOfWork.User.Save();
            }
            else return View(user);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var user = unitOfWork.User.FindById(id);

            return View(user);
        }


        [HttpPost]
        public ActionResult Edit(User user)
        {
            if (ModelState.IsValid)
            {
                unitOfWork.User.Update(user);
                unitOfWork.User.Save();
            }
            else return View(user);

            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            unitOfWork.User.Delete(id);
            unitOfWork.User.Save();

            return RedirectToAction("Index");
        }
    }
}