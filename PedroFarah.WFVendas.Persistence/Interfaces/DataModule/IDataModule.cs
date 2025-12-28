using PedroFarah.WFVendas.Persistence.Interfaces.Repository;

namespace PedroFarah.WFVendas.Persistence.Interfaces.DataModule
{
    public interface IDataModule : IAsyncDisposable
    {
        IClienteRepository ClienteRepository { get; }
        IProdutoRepository ProdutoRepository { get; }
        Task BeginAsync();
        Task CommitAsync();
        Task RollbackAsync();
    }
}
