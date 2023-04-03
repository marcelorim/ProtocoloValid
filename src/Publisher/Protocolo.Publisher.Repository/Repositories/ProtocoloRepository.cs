using Dapper;
using Microsoft.Extensions.Logging;
using Protocolo.Models.Entities;
using Protocolo.Publisher.Repository.Interfaces;

namespace Protocolo.Publisher.Repository.Repositories
{
    public class ProtocoloRepository : IProtocoloRepository
    {
        private readonly ILogger<ProtocoloRepository> _logger;
        private readonly DbSessionPublisher _session;

        public ProtocoloRepository(ILogger<ProtocoloRepository> logger, DbSessionPublisher session)
        {
            _logger = logger;
            _session = session;
        }

        const string queryComAlias = @"SELECT ID, NUM_PROTOCOLO, NUM_VIA_DOCUMENTO, CPF, RG, NOME, NOME_MAE, NOME_PAI, FOTO FROM TB_PROTOCOLO ";

        public async Task<ProtocoloEntity> GetByProtocolo(int numProtocolo)
        {
            string sql = queryComAlias + @"WHERE NUM_PROTOCOLO = @NumProtocolo;";

            var result = await _session.Connection.QueryFirstOrDefaultAsync<ProtocoloEntity>(sql, new { NumProtocolo = numProtocolo });
            return result;
        }

        public async Task<ProtocoloEntity> GetByCpf(int numCpf)
        {
            string sql = queryComAlias + @"WHERE CPF = @Cpf;";

            var result = await _session.Connection.QueryFirstOrDefaultAsync<ProtocoloEntity>(sql, new { Cpf = numCpf });
            return result;
        }

        public async Task<ProtocoloEntity> GetByRg(int numRg)
        {
            string sql = queryComAlias + @"WHERE RG = @id;";

            var result = await _session.Connection.QueryFirstOrDefaultAsync<ProtocoloEntity>(sql, new { Rg = numRg });
            return result;
        }
    }
}
