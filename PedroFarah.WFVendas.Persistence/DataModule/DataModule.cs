using Microsoft.Extensions.Configuration;
using Npgsql;
using PedroFarah.WFVendas.Persistence.Interfaces.DataModule;
using PedroFarah.WFVendas.Persistence.Interfaces.Repository;
using PedroFarah.WFVendas.Persistence.Repository;

namespace PedroFarah.WFVendas.Persistence.DataModule
{
    public class DataModule(IConfiguration configuration) : IDataModule, IAsyncDisposable, IDisposable
    {
        private NpgsqlConnection? _connection;
        private NpgsqlTransaction? _transaction;

        private bool _disposed;

        public NpgsqlConnection? Connection => _connection ??= new NpgsqlConnection(configuration["ConnectionStrings:DefaultConnection"] ?? "");

        public NpgsqlTransaction? Transaction => _transaction;

        public IClienteRepository ClienteRepository
            => new ClienteRepository(this);

        public IProdutoRepository ProdutoRepository
            => new ProdutoRepository(this);

        public IVendaRepository VendaRepository
            => new VendaRepository(this);

        public async Task BeginAsync()
        {
            if(Connection == null)
                throw new InvalidOperationException("Conexão não iniciada.");

            if(Connection.State == System.Data.ConnectionState.Broken)
            {
                await Connection.CloseAsync().ConfigureAwait(false);
            }

            if(Connection.State != System.Data.ConnectionState.Open)
            {
                await Connection.OpenAsync().ConfigureAwait(false);
            }

            _transaction = await Connection.BeginTransactionAsync()
                                           .ConfigureAwait(false);
        }

        public async Task CommitAsync()
        {
            if(Connection!.State != System.Data.ConnectionState.Open)
            {
                throw new InvalidOperationException("Conexão fechada.");
            }

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
                await _transaction.DisposeAsync().ConfigureAwait(false);
                _transaction = null;
            }

            if(_connection != null)
            {
                if(_connection.State != System.Data.ConnectionState.Closed)
                    await _connection.CloseAsync().ConfigureAwait(false);

                await _connection.DisposeAsync().ConfigureAwait(false);
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
