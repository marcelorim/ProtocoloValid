using DigitalSignature.Infrastructure.Extensions;
using Microsoft.Extensions.Logging;
using Protocolo.Consumer.Repository.Interfaces;
using Protocolo.Consumer.Service.Interfaces;
using Protocolo.Models.DTO;
using Protocolo.Models.Entities;
using Protocolo.Models.Utils;

namespace Protocolo.Consumer.Service.Services
{
    public class ProtocoloServices : IProtocoloServices
    {
        private readonly ILogger<ProtocoloServices> _logger;
        private readonly IProtocoloRepository _protocoloRepository;

        public ProtocoloServices(ILogger<ProtocoloServices> logger, IProtocoloRepository protocoloRepository)
        {
            _logger = logger;
            _protocoloRepository = protocoloRepository;
        }

        public async Task<RetornoDTO> InserirDadosProtocolo(ProtocoloEntity entity)
        {
            try
            {
                var retorno = await ValidarDadosFila(entity);
                if (!retorno.Sucesso)
                {
                    return await Task.FromResult(retorno);
                }
                else
                {
                    var sucesso = await _protocoloRepository.Insert(entity);
                    return sucesso;

                    return await Task.FromResult(retorno);
                }
            }
            catch (Exception ex)
            {
                _logger.AddLogError(ex.Message);
                throw new Exception(Mensagem.Erro);
            }
        }

        private async Task<RetornoDTO> ValidarDadosFila(ProtocoloEntity entity)
        {
            RetornoDTO retorno = new RetornoDTO();

            try
            {
                //validar


            }
            catch (Exception ex)
            {
                _logger.AddLogError("ERRO: " + ex);
                throw new Exception(Mensagem.Erro);
            }

            return await Task.FromResult(retorno);
        }
    }
}
