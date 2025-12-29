using Microsoft.Extensions.Configuration;
using Npgsql;
using PedroFarah.WFVendas.Persistence.Interfaces.DataModule;
using PedroFarah.WFVendas.Persistence.Interfaces.Repository;
using PedroFarah.WFVendas.Persistence.Repository;
using System.Data;

namespace PedroFarah.WFVendas.Persistence.DataModule
{
    public class DataModule : IDataModule, IAsyncDisposable, IDisposable
    {
        private readonly IConfiguration _configuration;

        public DataModule(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        private NpgsqlConnection? _connection;
        private NpgsqlTransaction? _transaction;

        private bool _disposed;

        public NpgsqlConnection? Connection => _connection; // ??= new NpgsqlConnection(_configuration["ConnectionStrings:DefaultConnection"] ?? "");

        public NpgsqlTransaction? Transaction => _transaction;

        public IClienteRepository ClienteRepository
            => new ClienteRepository(this);

        public IProdutoRepository ProdutoRepository
            => new ProdutoRepository(this);

        public IVendaRepository VendaRepository
            => new VendaRepository(this);

        //public async Task BeginAsync()
        //{
        //    //if(Connection == null)
        //    //    throw new InvalidOperationException("Conexão não iniciada.");

        //    _connection ??= new NpgsqlConnection(_configuration["ConnectionStrings:DefaultConnection"] ?? "");

        //    if(Connection.State == System.Data.ConnectionState.Broken)
        //    {
        //        await Connection.CloseAsync().ConfigureAwait(false);
        //    }

        //    if(Connection.State != System.Data.ConnectionState.Open)
        //    {
        //        await Connection.OpenAsync().ConfigureAwait(false);
        //    }

        //    _transaction = await Connection.BeginTransactionAsync()
        //                                   .ConfigureAwait(false);
        //}

        public async Task BeginAsync()
        {
            if(_transaction != null)
            {
                try
                {
                    await _transaction.RollbackAsync();
                }
                finally
                {
                    await _transaction.DisposeAsync();
                    _transaction = null;
                }
            }

            if(_connection != null)
            {
                try
                {
                    if(_connection.State != ConnectionState.Closed)
                    {
                        await _connection.CloseAsync();
                    }
                }
                finally
                {
                    await _connection.DisposeAsync();
                    _connection = null;
                }
            }

            _connection = new NpgsqlConnection(
                _configuration.GetConnectionString("DefaultConnection"));

            await _connection.OpenAsync();

            _transaction = await _connection.BeginTransactionAsync();
        }

        public async Task CommitAsync()
        {
            if(_transaction == null)
                return;

            try
            {
                await _transaction.CommitAsync();
            }
            finally
            {
                await _transaction.DisposeAsync();
                _transaction = null;

                if(_connection != null)
                {
                    await _connection.CloseAsync();
                    await _connection.DisposeAsync();
                    _connection = null;
                }
            }
        }

        public async Task RollbackAsync()
        {
            if(_transaction == null)
                return;

            try
            {
                await _transaction.RollbackAsync();
            }
            finally
            {
                await _transaction.DisposeAsync();
                _transaction = null;

                if(_connection != null)
                {
                    await _connection.CloseAsync();
                    await _connection.DisposeAsync();
                    _connection = null;
                }
            }
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
