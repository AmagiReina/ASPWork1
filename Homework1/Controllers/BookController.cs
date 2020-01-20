using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using Homework1.UnitOfWork;

namespace Homework1.Controllers
{
    public class BookController : Controller
    {
        private UnitOfWorkImpl unitOfWork;

        public BookController()
        {
            unitOfWork = new UnitOfWorkImpl();
        }

        // GET: Book
        public ActionResult Index()
        {
            var books = unitOfWork.Book.GetAll();

            ViewBag.GenresList = unitOfWork.Genre.GetAll().ToList();

            return View(books.ToList());
        }

        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.AuthorList = new SelectList(unitOfWork.Author.GetAll()
                .ToList(), "id", "LastName");
            ViewBag.GenresList = new SelectList(unitOfWork.Genre.GetAll()
                .ToList(),"id", "GenreName");

            return View();
        }

        [HttpPost]
        public ActionResult Create(Book book)
        {
            if (ModelState.IsValid)
            {
                unitOfWork.Book.Create(book);
                unitOfWork.Book.Save();
            }
            else return View(book);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var book = unitOfWork.Book.FindById(id);

            ViewBag.AuthorList = new SelectList(unitOfWork.Author.GetAll()
                 .ToList(), "id", "LastName");
            ViewBag.GenresList = new SelectList(unitOfWork.Genre.GetAll()
                .ToList(), "id", "GenreName");

            return View(book);
        }

        [HttpPost]
        public ActionResult Edit(Book book)
        {
            if (ModelState.IsValid)
            {
                unitOfWork.Book.Update(book);
                unitOfWork.Book.Save();
            }
            else return View(book);

            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            unitOfWork.Book.Delete(id);
            unitOfWork.Book.Save();

            return RedirectToAction("Index");
        }

        #region Not included in Generic Repository implementation
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
        #endregion

    }
}