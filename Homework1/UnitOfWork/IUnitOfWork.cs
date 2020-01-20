using Homework1.Entities;
using Homework1.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework1.UnitOfWork
{
    interface IUnitOfWork: IDisposable
    {
        GenericRepository<Author> Author { get; }
        GenericRepository<Book> Book { get; }
        GenericRepository<Genre> Genre { get; }
        GenericRepository<Order> Order { get;  }
        GenericRepository<User> User { get;  }

    }
}
