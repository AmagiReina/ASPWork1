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
    public class UserService : IService<UserDTO>
    {
        protected IUnitOfWork unitOfWork;
        protected IMapper mapper;

        public UserService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }
        public IEnumerable<UserDTO> GetAll()
        {
            IEnumerable<User> users = unitOfWork.User.GetAll();

            var res = mapper.Map<IEnumerable<User>, List<UserDTO>>(users);

            return res;
        }

        public UserDTO GetById(int id)
        {
            var user = unitOfWork.User.FindById(id);

            return mapper.Map<UserDTO>(user);
        }

        public void Remove(int id)
        {
            if (id != 0)
            {
                unitOfWork.User.Delete(id);
                unitOfWork.User.Save();
            }
        }

        public void Save(UserDTO dto)
        {
            var user = mapper.Map<User>(dto);

            if (user.Id == 0)
            {
                Add(user);
            }
            else
            {
                Update(user);
            }
        }

        private void Add(User user)
        {
            unitOfWork.User.Create(user);
            unitOfWork.User.Save();
        }

        private void Update(User user)
        {
            unitOfWork.User.Update(user);
            unitOfWork.User.Save();
        }
    }
}
