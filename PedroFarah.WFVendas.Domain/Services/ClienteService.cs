using FluentValidation;
using PedroFarah.WFVendas.Domain.Interfaces.Services;
using PedroFarah.WFVendas.Dto;
using PedroFarah.WFVendas.Persistence.Interfaces.DataModule;
using System.Data;

namespace PedroFarah.WFVendas.Domain.Services
{
    public class ClienteService : BaseService<Cliente>, IClienteService
    {
        public ClienteService(IDataModule dataModule, IValidator<Cliente> validator)
            : base(dataModule, validator)
        { 
        }

        public async Task InserirAsync(Cliente cliente)
        {
            await DataModule.BeginAsync();
            try
            {
                Validar(cliente);

                await DataModule.ClienteRepository.InserirAsync(cliente);
                await DataModule.CommitAsync();
            }
            catch
            {
                await DataModule.RollbackAsync();
            }
        }

        public async Task AtualizarAsync(Cliente cliente)
        {
            await DataModule.BeginAsync();
            try
            {
                Validar(cliente);

                await DataModule.ClienteRepository.AtualizarAsync(cliente);
                await DataModule.CommitAsync();
            }
            catch
            {
                await DataModule.RollbackAsync();
            }
        }

        public async Task ExcluirAsync(Cliente cliente)
        {
            if(cliente.Id == 0)
                throw new ArgumentException("Id não informado.");

            await DataModule.BeginAsync();
            try
            {
                await DataModule.ClienteRepository.ExcluirAsync(cliente);
                await DataModule.CommitAsync();
            }
            catch
            {
                await DataModule.RollbackAsync();
            }
        }

        public async Task<List<Cliente>> ListarAsync()
        {
            await DataModule.BeginAsync();
            try
            {
                var ret = await DataModule.ClienteRepository.ListarAsync();
                await DataModule.CommitAsync();
                return ret;
            }
            catch
            {
                await DataModule.RollbackAsync();
                throw;
            }
        }

        public async Task<DataTable> ListarGridAsync()
        {
            await DataModule.BeginAsync();
            try
            {
                var ret = DataModule.ClienteRepository.ListarGrid();
                await DataModule.CommitAsync();
                return ret;
            }
            catch
            {
                await DataModule.RollbackAsync();
                throw;
            }
        }

        public async Task<Cliente?> ObterPorIdAsync(Cliente cliente)
        {
            await DataModule.BeginAsync();
            try
            {
                var ret = await DataModule.ClienteRepository.ObterPorIdAsync(cliente.Id);
                await DataModule.CommitAsync();
                return ret;
            }
            catch
            {
                await DataModule.RollbackAsync();
                throw;
            }
        }

    }
}
