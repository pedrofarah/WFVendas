using PedroFarah.WFVendas.Dto;
using System.Data;

namespace PedroFarah.WFVendas.Domain.Interfaces.Services
{
    public interface IProdutoService
    {
        Task InserirAsync(Produto produto);
        Task AtualizarAsync(Produto produto);
        Task ExcluirAsync(Produto produto);
        Task<List<Produto>> ListarAsync();
        Task<DataTable> ListarGridAsync();
        Task<Produto?> ObterPorIdAsync(Produto produto);
        Task BaixarEstoqueAsync(Produto produto, int qtd);
    }
}
