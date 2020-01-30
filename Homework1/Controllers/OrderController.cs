using AutoMapper;
using BusinessLayer.DTO;
using BusinessLayer.Interfaces;
using BusinessLayer.Services;
using Homework1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Homework1.Controllers
{
    public class OrderController : Controller
    {
        // TODO: Service Factory class in BL to call services from
        private IService<BookDTO> bookService;
        private IService<OrderDTO> orderService;
        private IService<UserDTO> userService;
        private IMapper mapper;

        public OrderController(IMapper mapper)
        {
            bookService = DependencyResolver.Current.GetService<BookService>();
            orderService = DependencyResolver.Current.GetService<OrderService>();
            userService = DependencyResolver.Current.GetService<UserService>();
            this.mapper = mapper;
        }

        // GET: Order
        public ActionResult Index()
        {

            IEnumerable<OrderDTO> orderDto = orderService.GetAll();
            var viewModel = mapper.Map<IEnumerable<OrderDTO>,
                List<OrderViewModel>>(orderDto);
            foreach (var item in viewModel)
            {
                // ViewBag is not working with ViewModels here
                // Using LINQ to show UserName and Title of Book
                // instead of Ids
                item.Users = mapper.Map<UserViewModel>(userService.GetAll()
                    .Where(x => x.Id == item.UserId)
                    .FirstOrDefault());

                item.Books = mapper.Map<BookViewModel>(bookService.GetAll().
                    Where(x => x.Id == item.BookId)
                    .FirstOrDefault());
            }


            return View(viewModel);
        }

        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.UsersList = new SelectList(userService.GetAll().ToList(),
                "id", "UsersName");
            ViewBag.BooksList = new SelectList(bookService.GetAll().ToList(),
                "id", "Title");

            return View();           
        }

        [HttpPost]
        public ActionResult Create(OrderViewModel order)
        {
            if (ModelState.IsValid)
            {
                OrderDTO orderDto = mapper.Map<OrderViewModel, OrderDTO>(order);
                orderService.Save(orderDto);
            }
            else return View(order);

            return RedirectToAction("Index");
        }
    }
}