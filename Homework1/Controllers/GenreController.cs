using Homework1.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace Homework1.Controllers
{
    public class GenreController : Controller
    {
        // GET: Genre
        public ActionResult Index()
        {
            using (Model1 db = new Model1())
            {
                var genres = db.Genres.ToList();

                return View(genres);
            }  
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Genre genre)
        {
            using (Model1 db = new Model1())
            {
                if (ModelState.IsValid)
                {
                    db.Genres.Add(genre);
                    db.SaveChanges();
                }
                else return View(genre);
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            using (Model1 db = new Model1())
            {
                var genre = db.Genres.Find(id);

                return View(genre);
            }
        }

        [HttpPost]
        public ActionResult Edit(Genre genre)
        {
            using (Model1 db = new Model1())
            {
                if (ModelState.IsValid)
                {
                    db.Entry(genre).State = EntityState.Modified;
                    db.SaveChanges();
                }
                else return View(genre);
            }
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            using (Model1 db = new Model1())
            {
                var genre = db.Genres.Find(id);
                if (genre != null)
                {
                    db.Genres.Remove(genre);
                    db.SaveChanges();
                }
            }
            return RedirectToAction("Index");
        }
    }
}