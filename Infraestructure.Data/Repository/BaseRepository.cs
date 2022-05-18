using Dominio.Core.Contract;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Infraestructure.Data.Repository
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        protected DbContext _Model;
        public BaseRepository(DbContext Model)
        {
            _Model = Model;
        }
        public void delete(T entity)
        {
            _Model.Set<T>().Remove(entity);
            _Model.SaveChanges();
        }

        public IEnumerable<T> getAll()
        {
            return _Model.Set<T>();
        }

        public T getOne(int id)
        {
            return _Model.Set<T>().Find(id);
        }

        public void save(T entity)
        {
            _Model.Set<T>().Add(entity);
            _Model.SaveChanges();
        }
    }
}
