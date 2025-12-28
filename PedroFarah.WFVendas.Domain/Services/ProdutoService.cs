using PedroFarah.WFVendas.Dto;
using PedroFarah.WFVendas.Persistence.Interfaces.DataModule;
using System.Data;

namespace PedroFarah.WFVendas.Domain.Services
{
    public class ProdutoService : BaseService
    {
        public ProdutoService(IDataModule dataModule)
            : base(dataModule)
        { }

        public async Task InserirAsync(Produto produto)
        {
            await DataModule.BeginAsync();
            try
            {
                await DataModule.ProdutoRepository.InserirAsync(produto);
                await DataModule.CommitAsync();
            }
            catch
            {
                await DataModule.RollbackAsync();
            }
        }

        public async Task<List<Produto>> ListarAsync()
        {
            await DataModule.BeginAsync();
            try
            {
                var ret = await DataModule.ProdutoRepository.ListarAsync();
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
                var ret = DataModule.ProdutoRepository.ListarGrid();
                await DataModule.CommitAsync();
                return ret;
            }
            catch
            {
                await DataModule.RollbackAsync();
                throw;
            }
        }

        public async Task<Produto?> ObterPorIdAsync(Produto produto)
        {
            await DataModule.BeginAsync();
            try
            {
                var ret = await DataModule.ProdutoRepository.ObterPorIdAsync(produto.Id);
                await DataModule.CommitAsync();
                return ret;
            }
            catch
            {
                await DataModule.RollbackAsync();
                throw;
            }
        }

        public async Task AtualizarAsync(Produto produto)
        {
            await DataModule.BeginAsync();
            try
            {
                await DataModule.ProdutoRepository.AtualizarAsync(produto);
                await DataModule.CommitAsync();
            }
            catch
            {
                await DataModule.RollbackAsync();
            }
        }

        public async Task BaixarEstoqueAsync(Produto produto, int qtd)
        {
            await DataModule.BeginAsync();
            try
            {
                await DataModule.ProdutoRepository.BaixarEstoqueAsync(produto, qtd);
                await DataModule.CommitAsync();
            }
            catch
            {
                await DataModule.RollbackAsync();
            }
        }

    }
}
