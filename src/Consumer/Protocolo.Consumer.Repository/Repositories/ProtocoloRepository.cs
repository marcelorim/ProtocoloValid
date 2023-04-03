using Dapper;
using DigitalSignature.Infrastructure.Extensions;
using Microsoft.Extensions.Logging;
using Protocolo.Consumer.Repository.Interfaces;
using Protocolo.Models.DTO;
using Protocolo.Models.Entities;
using Protocolo.Models.Utils;

namespace Protocolo.Consumer.Repository.Repositories
{
    public class ProtocoloRepository : IProtocoloRepository
    {
        private readonly ILogger<ProtocoloRepository> _logger;
        private DbSession _session;

        public ProtocoloRepository(ILogger<ProtocoloRepository> logger, DbSession session)
        {
            _logger = logger;
            _session = session;
        }

        const string queryComAlias = @"SELECT ID, NUM_PROTOCOLO, NUM_VIA_DOCUMENTO, CPF, RG, NOME, NOME_MAE, NOME_PAI, FOTO FROM TB_PROTOCOLO ";

        public async Task<RetornoDTO> Insert(ProtocoloEntity entity)
        {
            try
            {
                string sql = @"INSERT INTO dbo.TB_PROTOCOLO (ID, NUM_PROTOCOLO, NUM_VIA_DOCUMENTO, CPF, RG, NOME, NOME_MAE, NOME_PAI, FOTO) 
                                                     VALUES (@Id, @NumProtocolo, @NumViaDocumento, @Cpf, @Rg, @Nome, @Responsavel, @NomeMae, @NomePai, @Foto);";

                int linhasAfetadas = await _session.Connection.ExecuteAsync(sql, entity, _session.Transaction);
                var retorno = linhasAfetadas > 0 ? new RetornoDTO(true, Mensagem.Sucesso) : new RetornoDTO(false, "Nenhum registro incluído!");
                return retorno;
            }
            catch (Exception ex)
            {
                _logger.AddLogError(ex.Message);
                throw new Exception(Mensagem.Erro);
            }
        }

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
