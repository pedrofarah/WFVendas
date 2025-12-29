namespace PedroFarah.WFVendas.Dto
{
    public class Venda
    {
        public int Id { get; set; }
        public int ClienteId { get; set; }
        public Cliente? Cliente { get; set; }
        public DateTime DataVenda { get; set; }
        public decimal Total { get; set; }
        public List<VendaItem> Itens { get; set; } = new();
    }
}
