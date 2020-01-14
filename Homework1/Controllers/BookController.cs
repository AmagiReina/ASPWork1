using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using System.IO;

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

                ViewBag.GenresList = db.Genres.ToList();

                return View(books);
            }
        }

        [HttpGet]
        public ActionResult Create()
        {
            using (Model1 db = new Model1())
            {
                ViewBag.AuthorList = new SelectList(db.Authors.ToList(), "Id", "LastName");
                //ViewBag.GenresList = new SelectList(db.Genres.ToList(), "Id", "GenreName");

                return View();
            }
        }

        [HttpPost]
        public ActionResult Create(Book book, HttpPostedFileBase uploadImage)
        {
            using (Model1 db = new Model1())
            {
                if (ModelState.IsValid)
                {
                    byte[] imageData = null;

                    using (var binaryReader = new BinaryReader(uploadImage.InputStream) )
                    {
                        imageData = binaryReader.ReadBytes(uploadImage.ContentLength);
                    }

                    book.BookImage = imageData;


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
                ViewBag.GenresList = new SelectList(db.Genres.ToList(), "id", "GenreName");

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

        public ActionResult GetUsersReadBook(int bookId)
        {
            using (Model1 db = new Model1())
            {
                var users = db.Orders.Where(o => o.BookId == bookId).Select(o => o.UserId);

                List<User> userList = new List<User>();
                foreach (int item in users)
                {
                    var us = db.Users.Where(u => u.Id == item).FirstOrDefault();
                    userList.Add(us);
                }
                return PartialView("Partial/_UsersReadBook", userList);
            }
        }

        /**
         * Genres for dropdown
         */
        public JsonResult GetGenres()
        {
            using (Model1 db = new Model1())
            {
                var genres = db.Genres.ToList();

                return Json(genres, JsonRequestBehavior.AllowGet);
            }
        }

    }
}