namespace PedroFarah.WFVendas.Dto
{
    public class VendaItem
    {
        public int ProdutoId { get; set; }
        public Produto? Produto { get; set; }
        public int Quantidade { get; set; }
        public decimal PrecoUnitario { get; set; }
    }
}
