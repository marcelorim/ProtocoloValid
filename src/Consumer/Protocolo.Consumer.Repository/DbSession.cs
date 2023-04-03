using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Protocolo.Consumer.Repository
{
    public sealed class DbSession : IDisposable
    {
        private Guid _id;
        public IDbConnection Connection { get; }
        public IDbTransaction Transaction { get; set; }
        public IConfiguration _configuration { get; }

        public SqlConnection SqlConnection
        {
            get
            {
                return new SqlConnection(_configuration.GetConnectionString("DSApiConnection"));
            }
        }

        public DbSession(IConfiguration configuration)
        {
            _id = Guid.NewGuid();
            _configuration = configuration;
            Connection = SqlConnection;
            Connection.Open();
        }

        public void Dispose() => Connection?.Dispose();
    }
}
