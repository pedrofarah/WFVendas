using Npgsql;
using PedroFarah.WFVendas.Dto;
using PedroFarah.WFVendas.Persistence.Interfaces.DataModule;
using PedroFarah.WFVendas.Persistence.Interfaces.Repository;

namespace PedroFarah.WFVendas.Persistence.Repository
{
    public class VendaRepository: BaseRepository, IVendaRepository
    {

        public VendaRepository(IDataModule dataModule)
            : base(dataModule)
        { }

        public async Task RegistrarVendaAsync(Venda venda)
        {
            var vendaCmd = new NpgsqlCommand(
                @"INSERT INTO vendas (cliente_id, total)
                VALUES (@cliente, @total) RETURNING id", DataModule.Connection, DataModule.Transaction);

            vendaCmd.Parameters.AddWithValue("cliente", venda.ClienteId);
            vendaCmd.Parameters.AddWithValue("total", venda.Total);

            venda.Id = (int)(await vendaCmd.ExecuteScalarAsync())!;

            foreach(var item in venda.Itens)
            {
                var itemCmd = new NpgsqlCommand(
                    @"INSERT INTO venda_itens
                    (venda_id, produto_id, quantidade, preco_unitario)
                    VALUES (@idvenda,@produto,@qtd,@preco)", DataModule.Connection, DataModule.Transaction);

                itemCmd.Parameters.AddWithValue("idvenda", venda.Id);
                itemCmd.Parameters.AddWithValue("produto", item.ProdutoId);
                itemCmd.Parameters.AddWithValue("qtd", item.Quantidade);
                itemCmd.Parameters.AddWithValue("preco", item.PrecoUnitario);

                await itemCmd.ExecuteNonQueryAsync();
            }

        }

        public async Task<List<VendaRelatorio>> ObterRelatorioAsync(DateTime dataInicial, DateTime dataFinal)
        {
            var lista = new List<VendaRelatorio>();

            const string sql = @"
                SELECT
                    v.id        AS VendaId,
                    c.nome      AS Cliente,
                    v.data_venda AS DataVenda,
                    v.total     AS Total
                FROM vendas v
                JOIN clientes c ON c.id = v.cliente_id
                WHERE v.data_venda >= @dataInicial
                  AND v.data_venda <  @dataFinal + INTERVAL '1 day'
                ORDER BY v.data_venda, v.id;
            ";

            await using var cmd = new NpgsqlCommand(sql, DataModule.Connection, DataModule.Transaction);
            cmd.Parameters.AddWithValue("dataInicial", dataInicial.Date);
            cmd.Parameters.AddWithValue("dataFinal", dataFinal.Date);

            await using var reader = await cmd.ExecuteReaderAsync();

            while(await reader.ReadAsync())
            {
                lista.Add(new VendaRelatorio
                {
                    VendaId = reader.GetInt32(0),
                    Cliente = reader.GetString(1),
                    DataVenda = reader.GetDateTime(2),
                    Total = reader.GetDecimal(3)
                });
            }

            return lista;
        }

    }
}
