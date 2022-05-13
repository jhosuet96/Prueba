using Prueba.Model;
using Prueba.Repository.Interface;

namespace Prueba.Repository.Repository
{
    public class TelefonosContactoRepository : Repository<TelefonosCliente>, ITelefonosContactoRepository
    {
        public TelefonosContactoRepository(Prueba_apiContext ApiContext) : base(ApiContext)
        {
        }
    }
}
