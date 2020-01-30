using AutoMapper;
using BusinessLayer.DTO;
using BusinessLayer.Interfaces;
using DataLayer.Entities;
using DataLayer.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Services
{
    public class BookService: IService<BookDTO>
    {
        protected IUnitOfWork unitOfWork;
        protected IMapper mapper;

        public BookService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public BookDTO GetById(int id)
        {
            var book = unitOfWork.Book.FindById(id);

            return mapper.Map<BookDTO>(book);
        }

        public IEnumerable<BookDTO> GetAll()
        {
            IEnumerable<Book> books = unitOfWork.Book.GetAll();

            var res = mapper.Map<IEnumerable<Book>, List<BookDTO>>(books);

            return res;
        }

        public void Remove(int id)
        {
            if (id != 0)
            {
                unitOfWork.Book.Delete(id);
                unitOfWork.Book.Save();
            }
        }

        public void Save(BookDTO dto)
        {
            var book = mapper.Map<Book>(dto);

            if (book.Id == 0)
            {
                Add(book);
            }
            else
            {
                Update(book);
            }
        }

        private void Add(Book book)
        {
            unitOfWork.Book.Create(book);
            unitOfWork.Book.Save();
        }

        private void Update(Book book)
        {
            unitOfWork.Book.Update(book);
            unitOfWork.Book.Save();
        }
    }
}
