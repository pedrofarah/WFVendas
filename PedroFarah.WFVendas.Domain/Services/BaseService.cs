
using FluentValidation;
using PedroFarah.WFVendas.Persistence.Interfaces.DataModule;
using System.ComponentModel.DataAnnotations;

namespace PedroFarah.WFVendas.Domain.Services
{
    public class BaseService<T> where T : class
    {
        private readonly IDataModule _dataModule;
        private readonly IValidator<T> _validator;

        public BaseService(IDataModule dataModule, IValidator<T> validator)
        {
            _dataModule = dataModule;
            _validator = validator;
        }

        public IDataModule DataModule => _dataModule;

        protected async Task ValidarAsync(T entidade)
        {
            var result = await _validator.ValidateAsync(entidade);

            if(!result.IsValid)
                throw new FluentValidation.ValidationException(result.Errors);
        }
    }
}
