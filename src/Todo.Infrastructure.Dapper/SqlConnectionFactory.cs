using System.Data.SqlClient;
using System.Threading.Tasks;

namespace Todo.Infrastructure.Dapper
{
    public class SqlConnectionFactory : ISqlConnectionFactory
    {
        private readonly string connectionString;

        public SqlConnectionFactory(string connectionString)
        {
            if (string.IsNullOrWhiteSpace(connectionString))
            {
                throw new System.ArgumentException($"'{nameof(connectionString)}' cannot be null or whitespace.", nameof(connectionString));
            }

            this.connectionString = connectionString;
        }

        public async Task<SqlConnection> CreateConnectionAsync()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            await connection.OpenAsync();
            return connection;
        }
    }
}