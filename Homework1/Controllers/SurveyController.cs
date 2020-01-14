using Homework1.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Homework1.Controllers
{
    public class SurveyController : Controller
    {
        // GET: Survey
        [HttpGet]
        public ActionResult Index()
        {
            using (Model1 db = new Model1())
            {
                ViewBag.BookList = new SelectList(db.Books.Take(5).ToList(), "Id", "Title");
                ViewBag.GenreList = new SelectList(db.Genres.Take(3).ToList(), "Id", "GenreName");
            }
            return View();
        }

        [HttpPost]
        public ActionResult Index(Survey survey)
        {
            using (Model1 db = new Model1())
            {
                if (ModelState.IsValid)
                {
                    db.Surveys.Add(survey);
                    db.SaveChanges();
                }
            }

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public ActionResult Stats()
        {
            using (Model1 db = new Model1())
            {
                var surveys = db.Surveys.ToList();
            
                ViewBag.BooksList = db.Books.ToList();
                ViewBag.GenresList = db.Genres.ToList();

                return View(surveys);
            }
            
        }
    }
}