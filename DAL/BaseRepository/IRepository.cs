using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public interface IRepository<TEntity> where TEntity : class
    {
        TEntity GetById(int id);
        void Insert(TEntity entity);
        TEntity InsertAndGet(TEntity entity);
        IEnumerable<TEntity> GetAll();
        void Update(TEntity entity);
        void Delete(TEntity entity);
        void Delete(int id);
    }
}
