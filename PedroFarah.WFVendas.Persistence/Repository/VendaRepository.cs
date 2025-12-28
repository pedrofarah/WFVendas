using Npgsql;
using PedroFarah.WFVendas.Dto;
using PedroFarah.WFVendas.Persistence.Interfaces.Repository;

namespace PedroFarah.WFVendas.Persistence.Repository
{
    public class VendaRepository: BaseRepository, IVendaRepository
    {

        public VendaRepository(NpgsqlConnection connection, NpgsqlTransaction transaction)
            : base(connection, transaction)
        { }

        public async Task RegistrarVendaAsync(Venda venda)
        {
            var vendaCmd = new NpgsqlCommand(
                @"INSERT INTO vendas (cliente_id, total)
                VALUES (@cliente, @total) RETURNING id", Connection, Transaction);

            vendaCmd.Parameters.AddWithValue("cliente", venda.ClienteId);
            vendaCmd.Parameters.AddWithValue("total", venda.Total);

            venda.Id = (int)(await vendaCmd.ExecuteScalarAsync())!;

            foreach(var item in venda.Itens)
            {
                var itemCmd = new NpgsqlCommand(
                    @"INSERT INTO venda_itens
                    (venda_id, produto_id, quantidade, preco_unitario)
                    VALUES (@idvenda,@produto,@qtd,@preco)", Connection, Transaction);

                itemCmd.Parameters.AddWithValue("idvenda", venda.Id);
                itemCmd.Parameters.AddWithValue("produto", item.ProdutoId);
                itemCmd.Parameters.AddWithValue("qtd", item.Quantidade);
                itemCmd.Parameters.AddWithValue("preco", item.PrecoUnitario);

                await itemCmd.ExecuteNonQueryAsync();
            }

        }

    }
}
