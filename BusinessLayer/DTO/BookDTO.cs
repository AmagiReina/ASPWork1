using AutoMapper;
using DataLayer.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.DTO
{
    public class BookDTO
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public int Price { get; set; }

        public int AuthorId { get; set; }

        public int GenreId { get; set; }

        public int Pages { get; set; }

        public AuthorDTO Author { get; set; }

        public GenreDTO Genre { get; set; }
    }
}
