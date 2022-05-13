using System.ComponentModel.DataAnnotations.Schema;

namespace Prueba.Model
{
    public class TelefonosCliente
    {
        public int id { get; set; }

        [ForeignKey(nameof(Prueba.Model.Cliente))]
        public int ClienteId { get; set; }
        public string numero { get; set; }

        public virtual Cliente Cliente { get; set; }


    }
}
