using AutoMapper;
using BusinessLayer.DTO;
using DataLayer.Entities;
using DataLayer.UnitOfWork;
using Ninject;
using Ninject.Modules;
using System.Web.Mvc;

namespace BusinessLayer.Infrastructure
{
    /**
     *  Ninject module for DI between DataLayer/BusinessLayer
     * */
    public class ServiceModule : NinjectModule
    {
        private string connectionString;

        public ServiceModule(string connection)
        {
            connectionString = connection;
        }

        public override void Load()
        {
            Bind<IUnitOfWork>().To<UnitOfWorkImpl>()
                .WithConstructorArgument(connectionString);
        }
       
    }
}
