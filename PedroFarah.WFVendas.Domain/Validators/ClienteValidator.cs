using FluentValidation;
using PedroFarah.WFVendas.Dto;
using PedroFarah.WFVendas.Persistence.Interfaces.DataModule;

namespace PedroFarah.WFVendas.Domain.Validators
{
    public class ClienteValidator: AbstractValidator<Cliente>
    {
        private readonly IDataModule _dataModule;

        public ClienteValidator(IDataModule dataModule)
        {
            _dataModule = dataModule;

            RuleFor(x => x.Nome)
                .NotEmpty()
                .WithMessage("Nome do cliente é obrigatório.");

            RuleFor(x => x.Email)
                .NotEmpty()
                .EmailAddress()
                .WithMessage("E-mail inválido.")
                .MaximumLength(150);

            RuleFor(x => x).MustAsync(validarEmailExistenteAsync).WithMessage("O e-mail informado já está cadastrado.");
        }

        private async Task<bool> validarEmailExistenteAsync(Cliente cliente, CancellationToken cancellationToken)
        {
            var retorno = await _dataModule.ClienteRepository.EmailExisteAsync(cliente);
            return !retorno;
        }
    }
}
