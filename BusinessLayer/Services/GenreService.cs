using AutoMapper;
using BusinessLayer.DTO;
using BusinessLayer.Interfaces;
using DataLayer.Entities;
using DataLayer.UnitOfWork;
using System.Collections.Generic;

namespace BusinessLayer.Services
{
    public class GenreService : IService<GenreDTO>
    {
        protected IUnitOfWork unitOfWork;
        protected IMapper mapper;

        public GenreService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public GenreDTO GetById(int id)
        {
            var genre = unitOfWork.Genre.FindById(id);

            return mapper.Map<GenreDTO>(genre);
        }

        public IEnumerable<GenreDTO> GetAll()
        {
            IEnumerable<Genre> genres = unitOfWork.Genre.GetAll();

            var res = mapper.Map<IEnumerable<Genre>, List<GenreDTO>>(genres);

            return res;
        }

        public void Remove(int id)
        {
            if (id != 0)
            {
                unitOfWork.Genre.Delete(id);
                unitOfWork.Genre.Save();
            }
        }

        public void Save(GenreDTO dto)
        {
            var genre = mapper.Map<Genre>(dto);

            if (genre.Id == 0)
            {
                Add(genre);
            } 
            else
            {
                Update(genre);
            }
        }

        private void Add(Genre genre)
        {
            unitOfWork.Genre.Create(genre);
            unitOfWork.Genre.Save();
        }

        private void Update(Genre genre)
        {
            unitOfWork.Genre.Update(genre);
            unitOfWork.Genre.Save();
        }
    }
}
