using Prueba.Model;
using Prueba.Repository.Interface;

namespace Prueba.Repository.Repository
{
    public class ClienteRepository : Repository<Cliente>, IClienteRepository
    {
        public ClienteRepository(Prueba_apiContext ApiContext) : base(ApiContext)
        {
        }
    }
}
