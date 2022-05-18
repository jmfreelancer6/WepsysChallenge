using System.Collections.Generic;

namespace Dominio.Core.Contract
{
    public interface IBaseRepository<T> where T : class
    {
        public void save(T entity);
        public void delete(T entity);
        public IEnumerable<T> getAll();
        public T getOne(int id);

    }
}
