using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using BusinessLayer.Interfaces;
using BusinessLayer.DTO;
using AutoMapper;
using BusinessLayer.Services;
using Homework1.Models;

namespace Homework1.Controllers
{
    public class UserController : Controller
    {
        private IService<UserDTO> userService;
        private IMapper mapper;

        public UserController(IMapper mapper)
        {
            userService = DependencyResolver.Current.GetService<UserService>();
            this.mapper = mapper;
        }

        // GET: User
        public ActionResult Index()
        {
            IEnumerable<UserDTO> userDto = userService.GetAll();
            var viewModel = mapper.Map<IEnumerable<UserDTO>,
                List<UserViewModel>>(userDto);

            return View(viewModel);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(UserViewModel user)
        {
            if (ModelState.IsValid)
            {
                UserDTO userDto = mapper.Map<UserViewModel, UserDTO>(user);
                userService.Save(userDto);
            }
            else return View(user);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var userDto = userService.GetById(id);

            var viewModel = mapper.Map<UserDTO, UserViewModel>(userDto);

            return View(viewModel);
        }


        [HttpPost]
        public ActionResult Edit(UserViewModel user)
        {
            if (ModelState.IsValid)
            {
                var userDto = mapper.Map<UserDTO>(user);
                userService.Save(userDto);
            }
            else return View(user);

            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            userService.Remove(id);

            return RedirectToAction("Index");
        }
    }
}