using Dapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Protocolo.Consumer.Repository.Interfaces;
using Protocolo.Models.Entities;
using Protocolo.Models.Extensions;
using Protocolo.Models.Utils;
using System.Data.SqlClient;

namespace Protocolo.Consumer.Repository.Repositories
{
    public class ProtocoloRepository : IProtocoloRepository
    {
        private readonly ILogger<ProtocoloRepository> _logger;
        private readonly IConfiguration _configuration;
        private readonly string? connectionString;
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

                //var retorno = linhasAfetadas > 0 ? new RetornoDTO(true, Mensagem.Sucesso) : new RetornoDTO(false, "Nenhum registro incluído!");
                //return retorno;
            }
            catch (Exception ex)
            {
                _logger.AddLogError(ex.Message);
                throw new Exception(Mensagem.Erro);
            }
        }
    }
}
