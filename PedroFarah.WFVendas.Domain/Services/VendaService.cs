using FluentValidation;
using PedroFarah.WFVendas.Domain.Interfaces.Services;
using PedroFarah.WFVendas.Dto;
using PedroFarah.WFVendas.Persistence.Interfaces.DataModule;

namespace PedroFarah.WFVendas.Domain.Services
{
    public class VendaService: BaseService<Venda>, IVendaService
    {
        public VendaService(IDataModule dataModule, IValidator<Venda> validator)
            : base(dataModule, validator)
        {
        }

        public async Task RegistrarVendaAsync(Venda venda)
        {

            await DataModule.BeginAsync();

            try
            {
                await ValidarAsync(venda);

                await DataModule.VendaRepository.RegistrarVendaAsync(venda);

                foreach(var item in venda.Itens)
                {
                    await DataModule.ProdutoRepository.BaixarEstoqueAsync(item.Produto, item.Quantidade);
                }

                await DataModule.CommitAsync();
            }
            catch
            {
                await DataModule.RollbackAsync();
                throw;
            }

        }

    }
}
