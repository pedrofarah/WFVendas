using PedroFarah.WFVendas.Persistence.Interfaces.DataModule;

namespace PedroFarah.WFVendas.Persistence.Repository
{
    public class BaseRepository
    {
        private readonly IDataModule _dataModule;

        public BaseRepository(IDataModule dataModule)
        {
            _dataModule = dataModule;
        }

        public IDataModule DataModule => _dataModule;
    }
}
