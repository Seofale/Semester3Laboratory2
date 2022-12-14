using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace DataAccessLayer
{
    public interface IRepository<T> where T: class
    {
        IEnumerable<T> GetAll();
        void Create(T t);
        void Save();

        void Delete(int id);
        T GetById(int id);


    }
}
