using PedroFarah.WFVendas.Dto;
using System.Data;

namespace PedroFarah.WFVendas.Persistence.Interfaces.Repository
{
    public interface IProdutoRepository
    {
        Task InserirAsync(Produto produto);
        Task<List<Produto>> ListarAsync();
        DataTable ListarGrid();
        Task<Produto?> ObterPorIdAsync(int id);
        Task AtualizarAsync(Produto produto);
        Task BaixarEstoqueAsync(Produto produto, int qtd);
    }
}
