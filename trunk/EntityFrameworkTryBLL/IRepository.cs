using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntityFrameworkTryBLL
{
    public interface IRepository<T> where T : class
    {
        void Add(T entity);
        void Delete(T entity);
        T GetById(long Id);
        T Get(Func<T, Boolean> where);
        IEnumerable<T> GetAll();
        IEnumerable<T> GetMany(Func<T, bool> where);
    }
}
