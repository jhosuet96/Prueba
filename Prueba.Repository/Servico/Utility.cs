using Prueba.Model;
using Prueba.Repository.GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Prueba.Repository.Servico
{
    public class Utility
    {
        IQueryable<Cliente> _cliente;
        IQueryable<TelefonosCliente> _telefonos;
        private IRepositoryWrapper _repo;

        public Utility(IRepositoryWrapper repo)
        {
            _repo=repo;
        }

        public IQueryable<TelefonosCliente> getAllTelefonoCliente()
        {
            _telefonos = _repo.Telefenos.GetAll().Select(n => new TelefonosCliente {
                id = n.id,
                numero = n.numero,
                Cliente = new Cliente {
                    id=n.Cliente.id,
                    nombre=n.Cliente.nombre,
                    direccion=n.Cliente.direccion,
                }                
            });
            return _telefonos;
        }

        public IQueryable<TelefonosCliente> getAllTelephoneByClient(int clienteId)
        {
            var _telefonoData = _repo.Telefenos.FindByCondition(p=> p.ClienteId == clienteId).Select(n => new TelefonosCliente
            {
                id = n.id,
                numero = n.numero,
                Cliente = new Cliente
                {
                    id = n.Cliente.id,
                    nombre = n.Cliente.nombre,
                    direccion = n.Cliente.direccion,
                }
            });
            return _telefonoData;
        }

        public IQueryable<Cliente> getAllClienteTelefono()
        {
            _cliente = _repo.Cliente.GetAll().Select(n => new Cliente
            {
                id = n.id,
                nombre = n.nombre,
                direccion = n.direccion,
                TelefonosClientes = new List<TelefonosCliente>
                {
                    new TelefonosCliente { 
                        id = n.TelefonosClientes.ToList().First().id,  
                        numero = n.TelefonosClientes.ToList().First().numero
                    }
                } 
            });
            return _cliente;
        }
    }
}
