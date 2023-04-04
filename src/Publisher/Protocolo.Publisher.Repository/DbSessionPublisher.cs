using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Protocolo.Publisher.Repository
{
    public sealed class DbSessionPublisher : IDisposable
    {
        public IDbConnection Connection { get; }
        public IDbTransaction Transaction { get; set; }
        public IConfiguration _configuration { get; }

        public SqlConnection SqlConnection
        {
            get
            {
                return new SqlConnection(_configuration.GetConnectionString("ProtocoloApiConnection"));
            }
        }

        public DbSessionPublisher(IConfiguration configuration)
        {
            _configuration = configuration;
            Connection = SqlConnection;
            Connection.Open();
        }

        public void Dispose() => Connection?.Dispose();
    }
}
