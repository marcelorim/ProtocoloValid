using Dapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Protocolo.Consumer.Repository.Interfaces;
using Protocolo.Models.DTO;
using Protocolo.Models.Entities;
using Protocolo.Models.Extensions;
using Protocolo.Models.Utils;
using System.Data.SqlClient;
using static Dapper.SqlMapper;

namespace Protocolo.Consumer.Repository.Repositories
{
    public class ProtocoloRepository : IProtocoloRepository
    {
        private readonly ILogger<ProtocoloRepository> _logger;
        private readonly IConfiguration _configuration;
        private readonly string? connectionString;

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

        public ProtocoloRepository(ILogger<ProtocoloRepository> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
            connectionString = _configuration.GetConnectionString("ProtocoloApiConnection");
        }

        public async Task<bool> Insert(ProtocoloEntity entity)
        {
            try
            {
                string sql = @"INSERT INTO dbo.TB_PROTOCOLO (ID, NUM_PROTOCOLO, NUM_VIA_DOC, NUM_CPF, NUM_RG, NOME, NOME_MAE, NOME_PAI, FOTO) 
                                                     VALUES (@Id, @NumProtocolo, @NumViaDoc, @NumCpf, @NumRg, @Nome, @NomeMae, @NomePai, @Foto);";

                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    var linhasAfetadas = await connection.ExecuteAsync(sql, entity);
                    var retorno = linhasAfetadas > 0;
                    connection.Close();

                    return retorno;
                }
            }
            catch (Exception ex)
            {
                _logger.AddLogError(ex.Message);
                throw new Exception(Mensagem.Erro);
            }
        }

        public async Task<ProtocoloEntity> GetByParametro(long? numProtocolo, long? numCpf, long? numRg)
        {
            string strParametro = string.Empty;
            object objParametro = new();
            if (numProtocolo.HasValue)
            {
                strParametro = @"WHERE NUM_PROTOCOLO = @numProtocolo;";
                objParametro = new { numProtocolo };
            }
            else if (numCpf.HasValue)
            {
                strParametro = @"WHERE NUM_CPF = @numCpf;";
                objParametro = new { numCpf };
            }
            else if (numRg.HasValue)
            {
                strParametro = @"WHERE NUM_RG = @numRg;";
                objParametro = new { numRg };
            }

            string sql = queryComAlias + strParametro;
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var entity = await connection.QueryFirstOrDefaultAsync<ProtocoloEntity>(sql, objParametro);
                connection.Close();

                return entity;
            }
        }

        public async Task<ProtocoloEntity> ObterProtocoloPorNumProtocolo(long numProtocolo)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var entity = await connection.QueryFirstOrDefaultAsync<ProtocoloEntity>(queryComAlias, new { NumProtocolo = numProtocolo });
                connection.Close();

                return entity;
            }
        }
    }
}
