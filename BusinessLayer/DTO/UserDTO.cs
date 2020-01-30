using AutoMapper;
using DataLayer.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.DTO
{
    public class UserDTO 
    {
        public int Id { get; set; }

        public string UsersName { get; set; }
    }
}
