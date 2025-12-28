using PedroFarah.WFVendas.Dto;
using System.Data;

namespace PedroFarah.WFVendas.Domain.Interfaces.Services
{
    public interface IClienteService
    {
        Task InserirAsync(Cliente cliente);
        Task AtualizarAsync(Cliente cliente);
        Task ExcluirAsync(Cliente cliente);
        Task<List<Cliente>> ListarAsync();
        Task<DataTable> ListarGridAsync();
        Task<Cliente?> ObterPorIdAsync(Cliente cliente);
    }
}
