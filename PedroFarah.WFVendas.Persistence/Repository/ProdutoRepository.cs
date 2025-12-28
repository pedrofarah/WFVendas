using Npgsql;
using PedroFarah.WFVendas.Dto;
using PedroFarah.WFVendas.Persistence.Interfaces.Repository;
using System.Data;

namespace PedroFarah.WFVendas.Persistence.Repository
{
    public class ProdutoRepository: BaseRepository, IProdutoRepository
    {
        public ProdutoRepository(NpgsqlConnection connection, NpgsqlTransaction transaction)
            : base(connection, transaction)
        { }

        public async Task InserirAsync(Produto produto)
        {
            const string sql = @"
                INSERT INTO produtos (nome, descricao, preco, estoque)
                VALUES (@nome, @descricao, @preco, @estoque)";

            await using var cmd = new NpgsqlCommand(sql, Connection, Transaction);
            cmd.Parameters.AddWithValue("nome", produto.Nome);
            cmd.Parameters.AddWithValue("descricao", produto.Descricao);
            cmd.Parameters.AddWithValue("preco", produto.Preco);
            cmd.Parameters.AddWithValue("estoque", produto.Estoque);

            await cmd.ExecuteNonQueryAsync();
        }

        public async Task<List<Produto>> ListarAsync()
        {
            const string sql = @"
                SELECT id, nome, descricao, preco, estoque
                FROM produtos
                ORDER BY nome";

            var lista = new List<Produto>();

            await using var cmd = new NpgsqlCommand(sql, Connection, Transaction);
            await using var reader = await cmd.ExecuteReaderAsync();

            while(await reader.ReadAsync())
            {
                lista.Add(new Produto
                {
                    Id = reader.GetInt32(0),
                    Nome = reader.GetString(1),
                    Descricao = reader.IsDBNull(2) ? "" : reader.GetString(2),
                    Preco = reader.GetDecimal(3),
                    Estoque = reader.GetInt32(4)
                });
            }

            return lista;
        }

        public DataTable ListarGrid()
        {
            const string sql = @"
                SELECT 
                    id        AS ""Id"",
                    nome      AS ""Nome"",
                    descricao AS ""Descrição"",
                    preco     AS ""Preço"",
                    estoque   AS ""Estoque""
                FROM produtos
                ORDER BY nome";

            var table = new DataTable();

            NpgsqlDataAdapter npgsqlDataAdapter = new(sql, Connection);
            using var da = npgsqlDataAdapter;
            da.Fill(table);

            return table;
        }

        public async Task<Produto?> ObterPorIdAsync(int id)
        {
            const string sql = @"
                SELECT id, nome, descricao, preco, estoque
                FROM produtos
                WHERE id = @id";

            await using var cmd = new NpgsqlCommand(sql, Connection, Transaction);
            cmd.Parameters.AddWithValue("id", id);

            await using var reader = await cmd.ExecuteReaderAsync();

            if(!await reader.ReadAsync())
                return null;

            return new Produto
            {
                Id = reader.GetInt32(0),
                Nome = reader.GetString(1),
                Descricao = reader.IsDBNull(2) ? "" : reader.GetString(2),
                Preco = reader.GetDecimal(3),
                Estoque = reader.GetInt32(4)
            };
        }

        public async Task AtualizarAsync(Produto produto)
        {
            const string sql = @"
                UPDATE produtos
                SET nome = @nome,
                    descricao = @descricao,
                    preco = @preco,
                    estoque = @estoque
                WHERE id = @id";

            await using var cmd = new NpgsqlCommand(sql, Connection, Transaction);
            cmd.Parameters.AddWithValue("id", produto.Id);
            cmd.Parameters.AddWithValue("nome", produto.Nome);
            cmd.Parameters.AddWithValue("descricao", produto.Descricao);
            cmd.Parameters.AddWithValue("preco", produto.Preco);
            cmd.Parameters.AddWithValue("estoque", produto.Estoque);

            await cmd.ExecuteNonQueryAsync();
        }

        public async Task BaixarEstoqueAsync(Produto produto, int qtd)
        {
            var estoqueCmd = new NpgsqlCommand(
                @"UPDATE produtos SET estoque = estoque - @qtd
                      WHERE id=@id", Connection, Transaction);

            estoqueCmd.Parameters.AddWithValue("qtd", qtd);
            estoqueCmd.Parameters.AddWithValue("id", produto.Id);

            await estoqueCmd.ExecuteNonQueryAsync();
        }

    }
}
