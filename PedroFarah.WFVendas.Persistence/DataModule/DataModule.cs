using Microsoft.Extensions.Configuration;
using Npgsql;
using PedroFarah.WFVendas.Persistence.Interfaces.DataModule;
using PedroFarah.WFVendas.Persistence.Interfaces.Repository;
using PedroFarah.WFVendas.Persistence.Repository;

namespace PedroFarah.WFVendas.Persistence.DataModule
{
    public class DataModule(IConfiguration configuration) : IDataModule
    {
        private NpgsqlConnection? _connection;
        private NpgsqlTransaction? _transaction;

        private bool _disposed;

        public NpgsqlConnection? Connection => _connection ??= new NpgsqlConnection(configuration["ConnectionStrings:DefaultConnection"] ?? "");

        private IClienteRepository? _clienteRepository;
        public IClienteRepository ClienteRepository => _clienteRepository ??= new ClienteRepository(Connection!, _transaction!);

        private IProdutoRepository? _ProdutoRepository;
        public IProdutoRepository ProdutoRepository => _ProdutoRepository ??= new ProdutoRepository(Connection!, _transaction!);

        private IVendaRepository? _VendaRepository;
        public IVendaRepository VendaRepository => _VendaRepository ??= new VendaRepository(Connection!, _transaction!);

        public async Task BeginAsync()
        {
            await Connection!.OpenAsync();

            _transaction = await Connection.BeginTransactionAsync();
        }

        public async Task CommitAsync()
        {
            if(_transaction == null)
                return;

            await _transaction.CommitAsync();
            await DisposeAsync();
        }

        public async Task RollbackAsync()
        {
            if(_transaction == null)
                return;

            await _transaction.RollbackAsync();
            await DisposeAsync();
        }

        public async ValueTask DisposeAsync()
        {
            if(_disposed)
                return;

            if(_transaction != null)
            {
                await _transaction.DisposeAsync();
                _transaction = null;
            }

            if(_connection != null)
            {
                await _connection.DisposeAsync();
                _connection = null;
            }

            _disposed = true;
            GC.SuppressFinalize(this);
        }

        public void Dispose()
        {
            DisposeAsync().AsTask().GetAwaiter().GetResult();
        }

    }
}
