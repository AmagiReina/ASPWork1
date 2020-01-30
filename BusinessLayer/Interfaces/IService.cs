using BusinessLayer.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Interfaces
{
    public interface IService<T> where T: class
    { 
        IEnumerable<T> GetAll();
        T GetById(int id);
        void Save(T dto);
        void Remove(int id);
    }
}
