using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Prueba.Model;
using Prueba.Repository.GenericRepository;
using Prueba.Repository.Servico;
using System;

namespace Prueba.Controller
{
    [ApiController]
    [Route("[controller]")]
    public class TelefonoController : ControllerBase
    {

        private IRepositoryWrapper _repository;
        private Utility utility;

        public TelefonoController(IRepositoryWrapper repository)
        {
            _repository = repository;
            utility = new Utility(repository);

        }

        // GET: ClienteController
        [HttpGet("GetAll")]
        [EnableCors("AllowOrigin")]
        public IActionResult GetAll()
        {
            var telefonoCliente = utility.getAllTelefonoCliente();

            return Ok(new
            {
                telefonoCliente
            });
        }

        [HttpGet("GetById")]
        [EnableCors("AllowOrigin")]
        public IActionResult GetById([FromQuery] int id)
        {
            if (id > 0)
            {
                var telefono = _repository.Telefenos.GetById(id);
                return Ok(telefono);
            }
            else
            {
                return NotFound(id);
            }
        }

        // POST: ClienteController/Create
        [HttpPost("AddTelefono")]
        [EnableCors("AllowOrigin")]
        public IActionResult AddTelefono(TelefonosCliente telefonosContacto)
        {
            try
            {
                _repository.Telefenos.Add(telefonosContacto);
                _repository.Save();
                return Ok(new
                {
                    message = "Registro creado EXITOSAMENTE.!"
                });
            }
            catch (Exception )
            {
                return NotFound(telefonosContacto);
            }
        }
    }

}
