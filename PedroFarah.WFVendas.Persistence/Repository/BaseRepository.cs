using Npgsql;

namespace PedroFarah.WFVendas.Persistence.Repository
{
    public class BaseRepository(NpgsqlConnection connection, NpgsqlTransaction transaction)
    {
        public NpgsqlConnection Connection => connection;
        public NpgsqlTransaction Transaction => transaction;
    }
}
