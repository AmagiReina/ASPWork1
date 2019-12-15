using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace Homework1.Controllers
{
    public class BookController : Controller
    {
        // GET: Book
        public ActionResult Index()
        {
            using (Model1 db = new Model1())
            {
                var books = db.Books.ToList();

                return View(books);
            }
        }

        [HttpGet]
        public ActionResult Create()
        {
            using (Model1 db = new Model1())
            {
                ViewBag.AuthorList = new SelectList(db.Authors.ToList(), "id", "LastName");

                return View();
            }
        }

        [HttpPost]
        public ActionResult Create(Book book)
        {
            using (Model1 db = new Model1())
            {
                if (ModelState.IsValid)
                {
                    db.Books.Add(book);
                    db.SaveChanges();
                }
                else return View(book);
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            using (Model1 db = new Model1())
            {
                var book = db.Books.Find(id);
                ViewBag.AuthorList = new SelectList(db.Authors.ToList(), "Id", "LastName");

                return View(book);
            }
        }

        [HttpPost]
        public ActionResult Edit(Book book)
        {
            using (Model1 db = new Model1())
            {
                if (ModelState.IsValid)
                {
                    db.Entry(book).State = EntityState.Modified;
                    db.SaveChanges();
                }
                else return View(book);
            }
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            using (Model1 db = new Model1())
            {
                var book = db.Books.Find(id);
                if (book != null)
                {
                    db.Books.Remove(book);
                    db.SaveChanges();
                }
            }
            return RedirectToAction("Index");
        }

    }
}