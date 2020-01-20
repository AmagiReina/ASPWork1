using Homework1.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using Homework1.UnitOfWork;

namespace Homework1.Controllers
{
    public class GenreController : Controller
    {
        private UnitOfWorkImpl unitOfWork;

        public GenreController()
        {
            unitOfWork = new UnitOfWorkImpl();
        }

        // GET: Genre
        public ActionResult Index()
        {
            var genres = unitOfWork.Genre.GetAll();

            return View(genres.ToList());
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Genre genre)
        {
            if (ModelState.IsValid)
            {
                unitOfWork.Genre.Create(genre);
                unitOfWork.Genre.Save();
            }
            else return View(genre);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var genre = unitOfWork.Genre.FindById(id);

            return View(genre);
        }

        [HttpPost]
        public ActionResult Edit(Genre genre)
        {
            if (ModelState.IsValid)
            {
                unitOfWork.Genre.Update(genre);
                unitOfWork.Genre.Save();
            }
            else return View(genre);

            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            unitOfWork.Genre.Delete(id);
            unitOfWork.Genre.Save();

            return RedirectToAction("Index");
        }
    }
}