using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Prueba.Model
{
    public class Cliente
    {
        [Key]
        public int id { get; set; }
        public string nombre { get; set; }
        public string direccion { get; set; }

        public virtual ICollection<TelefonosCliente> TelefonosClientes { get; set; }
    }
}