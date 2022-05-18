using Dominio.Core.Contract;
using Infraestructure.Data.AccessData;
using Infraestructure.Data.Repository;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace Infraestructure.Data.Persistent
{
    public class RepositoryPerson : BaseRepository<Tbl_Person>, IGetOne<Tbl_Person>
    {
        public RepositoryPerson():base(new DataContext()) { }

        public Tbl_Person ObtenerOneByExpression(Expression<Func<Tbl_Person, bool>> Expre)
        {
            return _Model.Set<Tbl_Person>().Where(Expre).FirstOrDefault();
        }
    }
}
