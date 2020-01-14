using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace Homework1.Controllers
{
    public class AuthorController : Controller
    {
        // GET: Author
        public ActionResult Index()
        {
            using (Model1 db = new Model1())
            {
                var authors = db.Authors.ToList();

                return View(authors);
            }
        }

        [HttpGet]
        public ActionResult Create()
        {
            return PartialView("Partial/_Create");
        }

        [HttpPost]
        public ActionResult Create(Author author)
        {
            using (Model1 db = new Model1())
            {
                if (ModelState.IsValid)
                {
                    db.Authors.Add(author);
                    db.SaveChanges();
                }
                else return View(author);
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            using (Model1 db = new Model1())
            {
                var author = db.Authors.Find(id);

                return PartialView("Partial/_Edit", author);
            }
        }

        [HttpPost]
        public ActionResult Edit(Author author)
        {
            using (Model1 db = new Model1())
            {
                if (ModelState.IsValid)
                {
                    db.Entry(author).State = EntityState.Modified;
                    db.SaveChanges();
                }
                else return View(author);
            }
            return RedirectToAction("Index");
        }


        public ActionResult Delete(int id)
        {
            using (Model1 db = new Model1())
            {
                var author = db.Authors.Find(id);
                if (author != null)
                {
                    db.Authors.Remove(author);
                    db.SaveChanges();
                }
            }
            return RedirectToAction("Index");
        }
    }
}