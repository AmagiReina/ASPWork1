using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using BusinessLayer.DTO;
using BusinessLayer.Interfaces;
using BusinessLayer.Services;
using Homework1.Models;

namespace Homework1.Controllers
{
    public class BookController : Controller
    {
        // TODO: Service Factory class in BL to call services from
        private IService<BookDTO> bookService;
        private IService<AuthorDTO> authorService;
        private IService<GenreDTO> genreService;
        private IMapper mapper;

        public BookController(IMapper mapper)
        {
            bookService = DependencyResolver.Current.GetService<BookService>();
            authorService = DependencyResolver.Current.GetService<AuthorService>();
            genreService = DependencyResolver.Current.GetService<GenreService>();
            this.mapper = mapper;
        }

        // GET: Book
        public ActionResult Index()
        {
            IEnumerable<BookDTO> bookDto = bookService.GetAll();
            var viewModel = mapper.Map<IEnumerable<BookDTO>,
                List<BookViewModel>>(bookDto);

            return View(viewModel);
        }

        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.AuthorList = new SelectList(authorService.GetAll()
                .ToList(), "id", "LastName");
            ViewBag.GenresList = new SelectList(genreService.GetAll()
                .ToList(),"id", "GenreName");

            return View();
        }

        [HttpPost]
        public ActionResult Create(BookViewModel book)
        {
            if (ModelState.IsValid)
            {
                BookDTO bookDto = mapper.Map<BookViewModel, BookDTO>(book);
                bookService.Save(bookDto);
            }
            else return View(book);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var bookDto = bookService.GetById(id);

            var viewModel = mapper.Map<BookDTO, BookViewModel>(bookDto);

            ViewBag.AuthorList = new SelectList(authorService.GetAll()
                .ToList(), "id", "LastName");
            ViewBag.GenresList = new SelectList(genreService.GetAll()
                .ToList(), "id", "GenreName");

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Edit(BookViewModel book)
        {
            if (ModelState.IsValid)
            {
                var bookDto = mapper.Map<BookDTO>(book);
                bookService.Save(bookDto);
            }
            else return View(book);

            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            bookService.Remove(id);

            return RedirectToAction("Index");
        }

        #region Not included in Generic Repository implementation
        /*
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
        }*/
        #endregion
        
    }
}