using AutoMapper;
using Dominio.Core.Contract;
using Dominio.Core.Models;
using Infraestructure.Data.AccessData;
using Infraestructure.Data.Persistent;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;


namespace WepsysChallengeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly IMapper _mapper;
        private IBaseRepository<Tbl_Person> _person = new RepositoryPerson();
        public PersonController(IMapper mapper)
        {
            _mapper = mapper;
        }
        [HttpGet]
        public IEnumerable<PersonDTO> Get()
        {
            return _mapper.Map<IEnumerable<PersonDTO>>(_person.getAll());
        }

        [HttpPost]
        public IActionResult Post([FromBody] PersonDTO value)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (!ValidateIfEmailExist(value.Email))
                    {
                        _person.save(_mapper.Map<Tbl_Person>(value));
                        return Ok(new { message = "Se ha guardado correctamente" });
                    }
                    return BadRequest(ErrorModelState.catchError("Este email ya existe"));
                }
                return BadRequest(ErrorModelState.catchError(ModelState));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _person.delete(_person.getOne(id));
                return Ok(new { message = "Se ha eliminado correctamente" });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        private bool ValidateIfEmailExist(string email)
        {
            IGetOne<Tbl_Person> _person = new RepositoryPerson();
            Tbl_Person data = _person.ObtenerOneByExpression(a => a.Email == email);
            if (data != null)
            {
                return true;
            }
            return false;
        }
    }
}
