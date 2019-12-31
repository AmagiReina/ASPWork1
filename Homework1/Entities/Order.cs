using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Homework1.Entities
{
    public class Order
    {   
        [Key]
        public int Id { get; set; }

        [ForeignKey("Users")]
        public int UserId { get; set; }

        [ForeignKey("Books")]
        public int BookId { get; set; }

        public User Users { get; set; }

        public Book Books { get; set; }
    }
}