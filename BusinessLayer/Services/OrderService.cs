using AutoMapper;
using BusinessLayer.DTO;
using BusinessLayer.Interfaces;
using DataLayer.Entities;
using DataLayer.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Services
{
    public class OrderService : IService<OrderDTO>
    {
        protected IUnitOfWork unitOfWork;
        protected IMapper mapper;

        public OrderService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public IEnumerable<OrderDTO> GetAll()
        {
            IEnumerable<Order> orders = unitOfWork.Order.GetAll();

            var res = mapper.Map<IEnumerable<Order>, List<OrderDTO>>(orders);

            return res;
        }

        public OrderDTO GetById(int id)
        {
            var order = unitOfWork.Order.FindById(id);

            return mapper.Map<OrderDTO>(order);
        }

        public void Remove(int id)
        {
            if (id != 0)
            {
                unitOfWork.Order.Delete(id);
                unitOfWork.Order.Save();
            }
        }

        public void Save(OrderDTO dto)
        {
            var order = mapper.Map<Order>(dto);

            if (order.Id == 0)
            {
                Add(order);
            }
            else
            {
                Update(order);
            }
        }


        private void Add(Order order)
        {
            unitOfWork.Order.Create(order);
            unitOfWork.Order.Save();
        }

        private void Update(Order order)
        {
            unitOfWork.Order.Update(order);
            unitOfWork.Order.Save();
        }
    }
}
