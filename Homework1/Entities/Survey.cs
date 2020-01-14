using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Homework1.Entities
{
    public class Survey
    {
        [Key]
        public int Id { get; set; }

        // Survey's user name
        public string UserName { get; set; }

        [ForeignKey("Books")]
        public int BookId { get; set; }

        [ForeignKey("Genres")]
        public int GenreId { get; set; }

        public bool isBookAtLibrary { get; set; }

        public string Comment { get; set; }

        public Book Books { get; set; }

        public Genre Genres { get; set; }

    }
}