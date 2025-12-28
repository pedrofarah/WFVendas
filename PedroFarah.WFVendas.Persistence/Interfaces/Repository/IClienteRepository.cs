using PedroFarah.WFVendas.Dto;
using System.Data;

namespace PedroFarah.WFVendas.Persistence.Interfaces.Repository
{
    public interface IClienteRepository
    {
        Task InserirAsync(Cliente cliente);
        Task AtualizarAsync(Cliente cliente);
        Task ExcluirAsync(int id);
        DataTable ListarGrid();
        Task<List<Cliente>> ListarAsync();
        Task<Cliente?> ObterPorIdAsync(int id);
        Task<bool> EmailExisteAsync(Cliente cliente);
    }
}
