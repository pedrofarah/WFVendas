using PedroFarah.WFVendas.Dto;

namespace PedroFarah.WFVendas.Persistence.Interfaces.Repository
{
    public interface IVendaRepository
    {
        Task RegistrarVendaAsync(Venda venda);
        Task<List<VendaRelatorio>> ObterRelatorioAsync(DateTime dataInicio, DateTime dataFim);
    }
}
