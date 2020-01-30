using System.Collections.Generic;
using System.Web.Mvc;
using AutoMapper;
using Homework1.Models;
using BusinessLayer.DTO;
using BusinessLayer.Interfaces;
using BusinessLayer.Services;

namespace Homework1.Controllers
{
    public class AuthorController : Controller
    {
        private IService<AuthorDTO> service;
        private IMapper mapper;

        public AuthorController(IMapper mapper)
        {
            service = DependencyResolver.Current.GetService<AuthorService>(); 
            this.mapper = mapper;
        }

        // GET: Author
        public ActionResult Index()
        {
            IEnumerable<AuthorDTO> authorDto = service.GetAll();
            var viewModel = mapper.Map<IEnumerable<AuthorDTO>,
                List<AuthorViewModel>>(authorDto);
            
            return View(viewModel);
        }
        
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(AuthorViewModel author)
        {
           if (ModelState.IsValid)
           {
                AuthorDTO authorDto = mapper.Map<AuthorViewModel, AuthorDTO>(author);
                service.Save(authorDto);
           }
           else return View(author);

           return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var authorDto = service.GetById(id);

            var viewModel = mapper.Map<AuthorDTO, AuthorViewModel>(authorDto);

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Edit(AuthorViewModel author)
        {
            if (ModelState.IsValid)
            {
                var authorDto = mapper.Map<AuthorDTO>(author);
                service.Save(authorDto);
            }
            else return View(author);
            
            return RedirectToAction("Index");
        }


        public ActionResult Delete(int id)
        {
            service.Remove(id);
         
            return RedirectToAction("Index");
        }
    }
}