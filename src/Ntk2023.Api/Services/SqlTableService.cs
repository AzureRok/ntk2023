using System.Data;
using Microsoft.Data.SqlClient;

namespace Ntk2023.Api.Services
{
    public interface ISqlTableService
    {
        Task<IEnumerable<SqlTable>> GeTables();
    }

    public class SqlTableService : ISqlTableService
    {
        private readonly string _connectionString;
        public SqlTableService(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("ConnectionString is not set!");
        }

        public async Task<IEnumerable<SqlTable>> GeTables()
        {
            await using SqlConnection conn = new SqlConnection(_connectionString);
            await conn.OpenAsync();
            SqlCommand cmd = new SqlCommand("SELECT schema_name(t.schema_id) AS schema_name, t.name AS table_name FROM sys.tables t ORDER BY schema_name, table_name;", conn);
            var reader =await  cmd.ExecuteReaderAsync(CommandBehavior.CloseConnection);

            List<SqlTable> data = new List<SqlTable>();
            while (reader.Read())
            {
                data.Add(new SqlTable(reader.GetSqlString(0).Value, reader.GetSqlString(1).Value));
            }
            return data;
        }
    }
}
