using AutoMapper;
using DataLayer.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.DTO
{
    public class OrderDTO 
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public int BookId { get; set; }

        public UserDTO Users { get; set; }

        public BookDTO Books { get; set; }
    }
}
