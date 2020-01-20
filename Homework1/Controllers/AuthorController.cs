using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using Homework1.UnitOfWork;

namespace Homework1.Controllers
{
    public class AuthorController : Controller
    {
        private UnitOfWorkImpl unitOfWork;

        public AuthorController()
        {
            unitOfWork = new UnitOfWorkImpl();
        }

        // GET: Author
        public ActionResult Index()
        {
            var author = unitOfWork.Author.GetAll();
            
            return View(author.ToList());
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Author author)
        {
           if (ModelState.IsValid)
           {
                unitOfWork.Author.Create(author);
                unitOfWork.Author.Save();
           }
           else return View(author);

           return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var author = unitOfWork.Author.FindById(id);

            return View(author);
        }

        [HttpPost]
        public ActionResult Edit(Author author)
        {
            if (ModelState.IsValid)
            {
                unitOfWork.Author.Update(author);
                unitOfWork.Author.Save();
            }
            else return View(author);
            
            return RedirectToAction("Index");
        }


        public ActionResult Delete(int id)
        {
            unitOfWork.Author.Delete(id);
            unitOfWork.Author.Save();
         
            return RedirectToAction("Index");
        }
    }
}