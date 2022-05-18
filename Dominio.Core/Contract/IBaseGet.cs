using System;
using System.Linq.Expressions;

namespace Dominio.Core.Contract
{
    public interface IGetOne<T> where T : class
    {
        T ObtenerOneByExpression(Expression<Func<T, bool>> Expre);
    }
}
