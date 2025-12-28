
using PedroFarah.WFVendas.Domain.Interfaces.Services;
using PedroFarah.WFVendas.Persistence.Interfaces.DataModule;

namespace PedroFarah.WFVendas.Domain.Services
{
    public class BaseService : IBaseService
    {
        private readonly IDataModule _dataModule;
        public BaseService(IDataModule dataModule)
        {
            _dataModule = dataModule;
        }

        public IDataModule DataModule => _dataModule;
    }
}
