using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using AutoMapper;

using BusinessLayer.DTO;
using Homework1.Models;
using BusinessLayer.Interfaces;
using BusinessLayer.Services;

namespace Homework1.Controllers
{
    public class GenreController : Controller
    {
        private IService<GenreDTO> genreService;
        private IMapper mapper;

        public GenreController(IMapper mapper)
        {
            genreService = DependencyResolver.Current.GetService<GenreService>();
            this.mapper = mapper;
        }

        // GET: Genre
        public ActionResult Index()
        {
            IEnumerable<GenreDTO> genreDto = genreService.GetAll();
            var viewModel = mapper.Map<IEnumerable<GenreDTO>,
                List<GenreViewModel>>(genreDto);

            return View(viewModel);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(GenreViewModel genre)
        {
            if (ModelState.IsValid)
            {
                GenreDTO genreDto = mapper.Map<GenreViewModel, GenreDTO>(genre);
                genreService.Save(genreDto);
            }
            else return View(genre);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var genreDto = genreService.GetById(id);

            var viewModel = mapper.Map<GenreDTO, GenreViewModel>(genreDto);

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Edit(GenreViewModel genre)
        {
            if (ModelState.IsValid)
            {
                var genreDto = mapper.Map<GenreDTO>(genre);
                genreService.Save(genreDto);
            }
            else return View(genre);

            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            genreService.Remove(id);

            return RedirectToAction("Index");
        }
    }
}