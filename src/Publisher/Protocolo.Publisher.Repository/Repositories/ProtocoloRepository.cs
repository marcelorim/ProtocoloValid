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

        const string queryComAlias = @"   SELECT ID				AS Id, 
		                                         NUM_PROTOCOLO	AS NumProtocolo, 
		                                         NUM_VIA_DOC	AS NumViaDoc, 
		                                         NUM_CPF		AS NumCpf, 
		                                         NUM_RG			AS NumRg, 
		                                         NOME			AS Nome, 
		                                         NOME_MAE		AS NomeMae, 
		                                         NOME_PAI		AS NomePai, 
		                                         FOTO			AS Foto
	                                        FROM TB_PROTOCOLO ";

        public async Task<ProtocoloEntity> GetByParametro(long? numProtocolo, long? numCpf, long? numRg)
        {
            string strParametro = string.Empty;
            object objParametro = new();
            if (numProtocolo.HasValue)
            {
                strParametro = @"WHERE NUM_PROTOCOLO = @NumProtocolo;";
                objParametro = new { NumProtocolo = numProtocolo };
            }
            else if (numCpf.HasValue)
            {
                strParametro = @"WHERE NUM_CPF = @NumCpf;";
                objParametro = new { NumCpf = numCpf };
            }
            else if (numRg.HasValue)
            {
                strParametro = @"WHERE NUM_RG = @NumRg;";
                objParametro = new { NumRg = numRg };
            }

            string sql = queryComAlias + strParametro;

            var result = await _session.Connection.QueryFirstOrDefaultAsync<ProtocoloEntity>(sql, objParametro);
            return result;
        }
    }
}
