using AutoMapper;
using BusinessLayer.DTO;
using BusinessLayer.Services;
using DataLayer.Entities;
using Homework1.Models;
using Ninject;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Homework1.Utils
{
    /**
     * Ninject Module for DI between BusinessLayer/PresentationLayer
     * */
    public class ViewModule : NinjectModule
    {
        public override void Load()
        {
            //Bind<IAuthorService>().To<AuthorService>();
            //Bind<IGenreService>().To<GenreService>();

            var mapperConfiguration = CreateConfiguration();
            Bind<MapperConfiguration>().ToConstant(mapperConfiguration).InSingletonScope();
            Bind<IMapper>().ToMethod(ctx =>
            new Mapper(mapperConfiguration, type => ctx.Kernel.Get(type)));
        }

        private MapperConfiguration CreateConfiguration()
        {
            var config = new MapperConfiguration(cfg =>
            {
                // Author
                cfg.CreateMap<Author, AuthorDTO>()
               .ConstructUsing(c => DependencyResolver.Current.GetService<AuthorDTO>());
                cfg.CreateMap<AuthorDTO, AuthorViewModel>()
                .ConstructUsing(c => DependencyResolver.Current.GetService<AuthorViewModel>());
                cfg.CreateMap<AuthorViewModel, AuthorDTO>()
                .ConstructUsing(c => DependencyResolver.Current.GetService<AuthorDTO>());
                cfg.CreateMap<AuthorDTO, Author>()
                .ConstructUsing(c => DependencyResolver.Current.GetService<Author>());

                // Genre
                cfg.CreateMap<Genre, GenreDTO>()
                .ConstructUsing(c => DependencyResolver.Current.GetService<GenreDTO>());
                cfg.CreateMap<GenreDTO, GenreViewModel>()
                .ConstructUsing(c => DependencyResolver.Current.GetService<GenreViewModel>());
                cfg.CreateMap<GenreViewModel, GenreDTO>()
                .ConstructUsing(c => DependencyResolver.Current.GetService<GenreDTO>());
                cfg.CreateMap<GenreDTO, Genre>()
                .ConstructUsing(c => DependencyResolver.Current.GetService<Genre>());

                // Book
                cfg.CreateMap<Book, BookDTO>()
                .ConstructUsing(c => DependencyResolver.Current.GetService<BookDTO>());
                cfg.CreateMap<BookDTO, BookViewModel>()
                .ConstructUsing(c => DependencyResolver.Current.GetService<BookViewModel>());
                cfg.CreateMap<BookViewModel, BookDTO>()
                .ConstructUsing(c => DependencyResolver.Current.GetService<BookDTO>());
                cfg.CreateMap<BookDTO, Book>()
                .ConstructUsing(c => DependencyResolver.Current.GetService<Book>());

                // User
                cfg.CreateMap<User, UserDTO>()
                .ConstructUsing(c => DependencyResolver.Current.GetService<UserDTO>());
                cfg.CreateMap<UserDTO, UserViewModel>()
                .ConstructUsing(c => DependencyResolver.Current.GetService<UserViewModel>());
                cfg.CreateMap<UserViewModel, UserDTO>()
                .ConstructUsing(c => DependencyResolver.Current.GetService<UserDTO>());
                cfg.CreateMap<UserDTO, User>()
                .ConstructUsing(c => DependencyResolver.Current.GetService<User>());

                // Order
                cfg.CreateMap<Order, OrderDTO>()
                .ConstructUsing(c => DependencyResolver.Current.GetService<OrderDTO>());
                cfg.CreateMap<OrderDTO, OrderViewModel>()
                .ConstructUsing(c => DependencyResolver.Current.GetService<OrderViewModel>());
                cfg.CreateMap<OrderViewModel, OrderDTO>()
                .ConstructUsing(c => DependencyResolver.Current.GetService<OrderDTO>());
                cfg.CreateMap<OrderDTO, Order>()
                .ConstructUsing(c => DependencyResolver.Current.GetService<Order>());

            });
            return config;
        }
    }
}