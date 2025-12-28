using Npgsql;
using PedroFarah.WFVendas.Dto;
using PedroFarah.WFVendas.Persistence.Interfaces.Repository;
using System.Data;

namespace PedroFarah.WFVendas.Persistence.Repository
{
    public class ClienteRepository : BaseRepository, IClienteRepository
    {
        public ClienteRepository(
            NpgsqlConnection connection, 
            NpgsqlTransaction transaction)
        : base(connection, transaction)
        {}

        public async Task InserirAsync(Cliente cliente)
        {
            var cmd = new NpgsqlCommand(
                "INSERT INTO clientes (nome, email, telefone) VALUES (@nome,@email,@telefone)", Connection, Transaction);

            cmd.Parameters.AddWithValue("nome", cliente.Nome);
            cmd.Parameters.AddWithValue("email", cliente.Email);
            cmd.Parameters.AddWithValue("telefone", cliente.Telefone);

            await cmd.ExecuteNonQueryAsync();
        }

        public async Task AtualizarAsync(Cliente cliente)
        {
            const string sql = @"
            UPDATE clientes
               SET nome = @nome,
                   email = @email,
                   telefone = @telefone
             WHERE id = @id"
            ;

            await using var cmd = new NpgsqlCommand(sql, Connection, Transaction);
            cmd.Parameters.AddWithValue("id", cliente.Id);
            cmd.Parameters.AddWithValue("nome", cliente.Nome);
            cmd.Parameters.AddWithValue("email", cliente.Email);
            cmd.Parameters.AddWithValue("telefone", cliente.Telefone ?? "");

            await cmd.ExecuteNonQueryAsync();
        }

        public async Task ExcluirAsync(Cliente cliente)
        {
            const string sql = @"DELETE FROM clientes WHERE id = @id";

            await using var cmd = new NpgsqlCommand(sql, Connection, Transaction);
            cmd.Parameters.AddWithValue("id", cliente.Id);

            await cmd.ExecuteNonQueryAsync();
        }

        public DataTable ListarGrid()
        {
            const string sql = @"
                SELECT 
                    id        AS ""Id"",
                    nome      AS ""Nome"",
                    email     AS ""E-mail"",
                    telefone  AS ""Telefone""
                FROM clientes
                ORDER BY nome";

            var table = new DataTable();

            NpgsqlDataAdapter npgsqlDataAdapter = new(sql, Connection);
            using var da = npgsqlDataAdapter;
            da.Fill(table);

            return table;
        }

        public async Task<List<Cliente>> ListarAsync()
        {
            const string sql = @"
                SELECT id, nome, email, telefone
                FROM clientes
                ORDER BY nome";

            var lista = new List<Cliente>();

            await using var cmd = new NpgsqlCommand(sql, Connection, Transaction);
            await using var reader = await cmd.ExecuteReaderAsync();

            while(await reader.ReadAsync())
            {
                lista.Add(new Cliente
                {
                    Id = reader.GetInt32(0),
                    Nome = reader.GetString(1),
                    Email = reader.GetString(2),
                    Telefone = reader.IsDBNull(3) ? "" : reader.GetString(3)
                });
            }

            return lista;
        }

        public async Task<Cliente?> ObterPorIdAsync(int id)
        {
            const string sql = @"
                SELECT id, nome, email, telefone
                FROM clientes
                WHERE id = @id";

            await using var cmd = new NpgsqlCommand(sql, Connection, Transaction);
            cmd.Parameters.AddWithValue("id", id);

            await using var reader = await cmd.ExecuteReaderAsync();

            if(!await reader.ReadAsync())
                return null;

            return new Cliente
            {
                Id = reader.GetInt32(0),
                Nome = reader.GetString(1),
                Email = reader.GetString(2),
                Telefone = reader.IsDBNull(3) ? "" : reader.GetString(3)
            };
        }

        public async Task<bool> EmailExisteAsync(Cliente cliente)
        {
            var cmd = new NpgsqlCommand(
                "SELECT 1 FROM clientes WHERE email=@email and id!=@id", Connection, Transaction);

            cmd.Parameters.AddWithValue("email", cliente.Email);
            cmd.Parameters.AddWithValue("id", cliente.Id);

            return await cmd.ExecuteScalarAsync() != null;
        }
    }
}
