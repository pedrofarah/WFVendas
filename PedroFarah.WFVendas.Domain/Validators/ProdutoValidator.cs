using FluentValidation;
using PedroFarah.WFVendas.Dto;

namespace PedroFarah.WFVendas.Domain.Validators
{
    public class ProdutoValidator : AbstractValidator<Produto>
    {
        public ProdutoValidator()
        {
            RuleFor(x => x.Descricao)
                .NotEmpty()
                .WithMessage("Descrição do produto é obrigatória.")
                .MaximumLength(150);

            RuleFor(x => x.Nome)
                .NotEmpty()
                .WithMessage("Nome do produto é obrigatório.")
                .MaximumLength(150);

            RuleFor(x => x.Preco)
                .GreaterThan(0)
                .WithMessage("Preço deve ser maior que zero.");

            RuleFor(x => x.Estoque)
                .GreaterThanOrEqualTo(0)
                .WithMessage("Estoque não pode ser negativo.");
        }
    }
}
