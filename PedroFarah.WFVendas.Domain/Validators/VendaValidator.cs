using FluentValidation;
using PedroFarah.WFVendas.Dto;
using PedroFarah.WFVendas.Persistence.Interfaces.DataModule;

namespace PedroFarah.WFVendas.Domain.Validators
{
    public class VendaValidator: AbstractValidator<Venda>
    {
        private readonly IDataModule _dataModule;

        public VendaValidator(IDataModule dataModule)
        {
            _dataModule = dataModule;

            RuleFor(x => x.ClienteId)
                .GreaterThan(0)
                .WithMessage("Cliente é obrigatório.");

            RuleFor(x => x.Itens)
                .NotEmpty()
                .WithMessage("Venda deve conter ao menos um item.");

            RuleForEach(x => x.Itens).ChildRules(item =>
            {
                item.RuleFor(x => x.ProdutoId)
                    .NotEmpty()
                    .GreaterThan(0)
                    .WithMessage("Código do produto é obrigatório.");

                item.RuleFor(x => x.Quantidade)
                    .GreaterThan(0)
                    .WithMessage("Quantidade deve ser maior que zero.");

                item.RuleFor(x => x.PrecoUnitario)
                    .GreaterThan(0)
                    .WithMessage("Preço deve ser maior que zero.");

                item.RuleFor(i => i.Quantidade)
                    .GreaterThan(0)
                    .WithMessage("Quantidade inválida.");

                item.RuleFor(x => x).MustAsync(validarEstoqueAsync).WithMessage("Quantidade insuficiente em estoque.");
            });
        }

        private async Task<bool> validarEstoqueAsync(VendaItem vendaItem, CancellationToken cancellationToken)
        {
            var produto = await _dataModule.ProdutoRepository.ObterPorIdAsync(new Produto { Id = vendaItem.ProdutoId });
            if(produto == null)
                return false;
            return (produto?.Estoque ?? 0) >= vendaItem.Quantidade;
        }
    }
}
