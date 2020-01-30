using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Homework1.Models
{
    public class OrderViewModel
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public int BookId { get; set; }

        public UserViewModel Users { get; set; }

        public BookViewModel Books { get; set; }
    }
}