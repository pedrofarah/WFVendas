using PedroFarah.WFVendas.Dto;

namespace PedroFarah.WFVendas.Domain.Interfaces.Services
{
    public interface IVendaService
    {
        Task RegistrarVendaAsync(Venda venda);
    }
}
