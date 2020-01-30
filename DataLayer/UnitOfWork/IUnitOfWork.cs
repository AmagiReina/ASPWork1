using DataLayer.Entities;
using DataLayer.Repository;
using System;

namespace DataLayer.UnitOfWork
{
    public interface IUnitOfWork: IDisposable
    {
        GenericRepository<Author> Author { get; }
        GenericRepository<Book> Book { get; }
        GenericRepository<Genre> Genre { get; }
        GenericRepository<Order> Order { get;  }
        GenericRepository<User> User { get;  }

    }
}
