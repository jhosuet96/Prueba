using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Prueba.Controller;
using Prueba.Model;
using Prueba.Repository.GenericRepository;
using Prueba.Repository.Servico;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Prueba.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClienteController : ControllerBase
    {

        private IRepositoryWrapper _repository;
        private Utility utility;
        private Cliente _cliente;
        TelefonoController telefonoController;
        public ClienteController(IRepositoryWrapper repository)
        {
            _repository = repository;
            utility = new Utility(repository);
            _cliente=new Cliente();
            telefonoController = new TelefonoController(repository);

        }

        // GET: ClienteController
        [HttpGet("GetAll")]
        [EnableCors("AllowOrigin")]
        public IActionResult GetAll()
        {
            var clienteTelefono = utility.getAllClienteTelefono();

            return Ok(clienteTelefono);
        }

        [HttpGet("GetClientDetails")]
        [EnableCors("AllowOrigin")]
        public IActionResult GetClientDetails([FromQuery] int clienteId)
        {
            var telefonosClientes = utility.getAllTelephoneByClient(clienteId);
            
            return Ok(telefonosClientes);
        }

        [HttpGet("GetById")]
        [EnableCors("AllowOrigin")]
        public IActionResult GetById([FromQuery]int id)
        {
            if (id > 0)
            {
                var cliente = _repository.Cliente.GetById(id);
                return Ok(cliente);
            }
            else
            {
                return NotFound(id);
            }
        }

        // POST: ClienteController/Create
        [HttpPost("AddCliente")]
        [EnableCors("AllowOrigin")]
        public IActionResult AddCliente([FromBody]Cliente cliente)
        {
            try
            {
                _cliente.nombre = cliente.nombre;
                _cliente.direccion=cliente.direccion;

                TelefonosCliente telefonosCliente = new TelefonosCliente();
                _repository.Cliente.Add(_cliente);
                _repository.Save();

                foreach (var item in cliente.TelefonosClientes)
                {
                   
                    telefonosCliente.numero = item.numero;
                    telefonosCliente.ClienteId = _cliente.id; 
                    telefonosCliente.id = 0;
                    _repository.Telefenos.Add(telefonosCliente);
                    _repository.Save();
                    //telefonoController.AddTelefono(telefonosCliente);
                }
              //  _repository.Save();
                return Ok(new
                {
                   // cliente = _cliente,
                    message = "Registro creado EXITOSAMENTE.!"
                }); ;
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
