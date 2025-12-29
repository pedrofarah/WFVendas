namespace PedroFarah.WFVendas.Dto
{
    public class VendaRelatorio
    {
        public int? VendaId { get; set; }
        public string Cliente { get; set; } = string.Empty;
        public DateTime? DataVenda { get; set; }
        public decimal Total { get; set; }
    }
}
