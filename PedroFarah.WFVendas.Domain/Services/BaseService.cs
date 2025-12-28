
using FluentValidation;
using PedroFarah.WFVendas.Domain.Interfaces.Services;
using PedroFarah.WFVendas.Persistence.Interfaces.DataModule;

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

        public void Validar(T obj)
        {
            var result = _validator.Validate(obj);
            if(!result.IsValid)
            {
                throw new ValidationException(result.Errors);
            }
        }
    }
}
