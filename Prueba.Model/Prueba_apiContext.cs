using Microsoft.EntityFrameworkCore;

namespace Prueba.Model
{
    public class Prueba_apiContext : DbContext
    {
        public Prueba_apiContext(DbContextOptions<Prueba_apiContext> options) : base(options){ }
        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<TelefonosCliente> TelefonosCliente { get; set; }
    }
}
