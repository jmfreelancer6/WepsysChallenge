using Dominio.Core.Contract;
using Infraestructure.Data.Persistent;
using System.ComponentModel.DataAnnotations;

namespace Infraestructure.Data.AccessData
{
    public class UniqueAttribute : ValidationAttribute
    {
        private IGetOne<Tbl_Person> _person = new RepositoryPerson();
        public override bool IsValid(object value)
        {
            Tbl_Person data = _person.ObtenerOneByExpression(a => a.Email == (string)value);
            if (data != null)
            {
                return true;
            }
            return false;
        }
    }
}
