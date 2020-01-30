using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Homework1.Models
{
    public class BookViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public int Price { get; set; }

        public int AuthorId { get; set; }

        public int GenreId { get; set; }

        public int Pages { get; set; }

        public AuthorViewModel Author { get; set; }

        public GenreViewModel Genre { get; set; }
    }
}