using AutoMapper;
using BusinessLayer.DTO;
using BusinessLayer.Interfaces;
using DataLayer.Entities;
using DataLayer.UnitOfWork;
using System.Collections.Generic;
using System.Linq;

namespace BusinessLayer.Services
{
    public class AuthorService : IService<AuthorDTO>
    {
        protected IUnitOfWork unitOfWork;
        protected IMapper mapper;

        public AuthorService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public IEnumerable<AuthorDTO> GetAll()
        {
            IEnumerable<Author> authors = unitOfWork.Author.GetAll();

            var res = mapper.Map<IEnumerable<Author>, List<AuthorDTO>>(authors);

            return res;
        }

        public AuthorDTO GetById(int id)
        {
            var author = unitOfWork.Author.FindById(id);

            return mapper.Map<AuthorDTO>(author);
        }

        public void Save(AuthorDTO authorDto)
        {
            var author = mapper.Map<Author>(authorDto);

            if (author.Id == 0)
            {
                Add(author);
            }
            else
            {
                Update(author);
            }
        }

        public void Remove(int id)
        {
            if (id != 0)
            {
                unitOfWork.Author.Delete(id);
                unitOfWork.Author.Save();
            }
        }

        private void Add(Author author)
        {
            unitOfWork.Author.Create(author);
            unitOfWork.Author.Save();
        }

        private void Update(Author author)
        {
            unitOfWork.Author.Update(author);
            unitOfWork.Author.Save();
        }
    }
}
