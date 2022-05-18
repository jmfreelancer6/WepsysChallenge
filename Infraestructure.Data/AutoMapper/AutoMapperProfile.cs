using AutoMapper;
using Dominio.Core.Models;
using Infraestructure.Data.AccessData;

namespace Infraestructure.Data.AutoMapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Tbl_Person, PersonDTO>().ReverseMap();
        }
    }
}
