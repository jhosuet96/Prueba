using Prueba.Repository.Interface;

namespace Prueba.Repository.GenericRepository
{
    public interface IRepositoryWrapper
    {
         IClienteRepository Cliente { get; }
         ITelefonosContactoRepository Telefenos { get; }

        void Save();
    }
}
