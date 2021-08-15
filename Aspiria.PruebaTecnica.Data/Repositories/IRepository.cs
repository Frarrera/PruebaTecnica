using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aspiria.PruebaTecnica.Repositories
{
    interface IRepository<T> where T : class
    {
        T Find(int Id);
        IQueryable<T> Find(string Pattern);
        bool Save(T entity);
        bool Update(T entity);
        bool Delete(int Id);
    }
}
