using Npgsql;
using PedroFarah.WFVendas.Persistence.Interfaces.Repository;

namespace PedroFarah.WFVendas.Persistence.Interfaces.DataModule
{
    public interface IDataModule : IAsyncDisposable
    {
        NpgsqlTransaction? Transaction { get; }
        NpgsqlConnection? Connection { get; }
        IClienteRepository ClienteRepository { get; }
        IProdutoRepository ProdutoRepository { get; }
        IVendaRepository VendaRepository { get; }
        Task BeginAsync();
        Task CommitAsync();
        Task RollbackAsync();
    }
}
