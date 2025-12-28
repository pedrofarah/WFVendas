using FluentValidation;
using PedroFarah.WFVendas.Dto;
using PedroFarah.WFVendas.Persistence.Interfaces.DataModule;

namespace PedroFarah.WFVendas.Domain.Validators
{
    public class VendaItemValidator: AbstractValidator<VendaItem>
    {
        private readonly IDataModule _dataModule;

        public VendaItemValidator(IDataModule dataModule)
        {
            _dataModule = dataModule;

            RuleFor(x => x.ProdutoId)
                .NotEmpty()
                .GreaterThan(0)
                .WithMessage("Código do produto é obrigatório.");

            RuleFor(x => x.Quantidade)
                .GreaterThan(0)
                .WithMessage("Quantidade deve ser maior que zero.");

            RuleFor(x => x.PrecoUnitario)
                .GreaterThan(0)
                .WithMessage("Preço deve ser maior que zero.");

            RuleFor(x => x).MustAsync(validarEstoqueAsync).WithMessage("Quantidade insuficiente em estoque.");
        }

        private async Task<bool> validarEstoqueAsync(VendaItem vendaItem, CancellationToken cancellationToken)
        {
            var produto = await _dataModule.ProdutoRepository.ObterPorIdAsync(new Produto { Id = vendaItem.ProdutoId });
            if(produto == null)
                return false;
            return (produto?.Estoque ?? 0) < vendaItem.Quantidade;
        }
    }
}
