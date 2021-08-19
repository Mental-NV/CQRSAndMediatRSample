using System.Data.SqlClient;
using System.Threading.Tasks;

namespace Todo.Infrastructure.Dapper
{
    public interface ISqlConnectionFactory
    {
        Task<SqlConnection> CreateConnectionAsync();
    }
}