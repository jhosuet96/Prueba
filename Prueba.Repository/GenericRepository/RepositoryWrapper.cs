using Prueba.Model;
using Prueba.Repository.Repository;
using Prueba.Repository.Interface;

namespace Prueba.Repository.GenericRepository
{
    public class RepositoryWrapper : IRepositoryWrapper
    {

        private Prueba_apiContext _ApiContext;
        private ITelefonosContactoRepository _telefono;
        private IClienteRepository _cliente;

        public RepositoryWrapper(Prueba_apiContext ApiContext)
        {
            _ApiContext = ApiContext;
        }
      

       public ITelefonosContactoRepository Telefenos
        {
            get {
                if (_telefono == null)
                {
                    _telefono = new TelefonosContactoRepository(_ApiContext);
                }
                
                return _telefono; 
            }
        }

       public IClienteRepository Cliente
        {
            get
            {
                if (_cliente == null)
                {
                    _cliente =new ClienteRepository(_ApiContext);
                }
                return (_cliente);
            }
        }

        public void Save()
        {
            _ApiContext.SaveChanges();
        }
    }
}
