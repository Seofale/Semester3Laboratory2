using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class EntityFrameworkRepository<T>: IRepository<T> where T: class
    {
        DataContext context = new DataContext();
        public IEnumerable<T> GetAll()
        {
            return context.Set<T>();
        }
        public void Create(T t)
        {
            context.Set<T>().Add(t);
            context.SaveChanges();
        }
        public void Save()
        {
            context.SaveChanges();
        }
        public T GetById(int id)
        {
            return context.Set<T>().Find(id);
        }
        public void Delete(int id)
        {
            T item = context.Set<T>().Find(id);
            if (item != null)
                context.Set<T>().Remove(item);
            context.SaveChanges();
        }
    }
}
