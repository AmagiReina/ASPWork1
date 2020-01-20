using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Homework1.Entities;
using Homework1.Repository;

namespace Homework1.UnitOfWork
{
    public class UnitOfWorkImpl : IUnitOfWork
    {
        Model1 dbContext;
        GenericRepository<Author> author;
        GenericRepository<Book> book;
        GenericRepository<Genre> genre;
        GenericRepository<Order> order;
        GenericRepository<User> user;
        private bool disposed = false;

        public UnitOfWorkImpl()
        {
            dbContext = new Model1();
        }

        public GenericRepository<Author> Author
        {
            get
            {
                if (author == null)
                {
                    author = new GenericRepository<Author>(dbContext);
                }
                return author;
            }
        }

        public GenericRepository<Book> Book
        {
            get
            {
                if (book == null)
                {
                    book = new GenericRepository<Book>(dbContext);
                }
                return book;
            }
        }

        public GenericRepository<Genre> Genre
        {
            get
            {
                if (genre == null)
                {
                    genre = new GenericRepository<Genre>(dbContext);
                }
                return genre;
            }
        }

        public GenericRepository<Order> Order
        {
            get
            {
                if (order == null)
                {
                    order = new GenericRepository<Order>(dbContext);
                }
                return order;
            }
        }

        public GenericRepository<User> User
        {
            get
            {
                if (user == null)
                {
                    user = new GenericRepository<User>(dbContext);
                }
                return user;
            }
        }

        public virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    dbContext.Dispose();
                }
                disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}