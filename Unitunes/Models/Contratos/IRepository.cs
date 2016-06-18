using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Unitunes.Models.Contratos
{
    interface IRepository<T> where T : class
    {
         T GetById(int id);
         IQueryable<T> GetAll(Expression<Func<T, bool>> filter);
         bool Save(T entity);
         bool Update(T entity);
         bool Delete(int id);
         bool Delete(T entity);
    }
}
