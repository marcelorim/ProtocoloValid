using Microsoft.AspNetCore.Mvc;
using Protocolo.Models.Extensions;
using Protocolo.Models.Utils;
using Protocolo.Publisher.Business.Interfaces;

namespace Protocolo.Publisher.App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProtocoloController : ControllerBase
    {
        private readonly ILogger<ProtocoloController> _logger;
        private readonly IProtocoloServices _protocoloServices;

        public ProtocoloController(ILogger<ProtocoloController> logger, IProtocoloServices protocoloServices)
        {
            _logger = logger;
            _protocoloServices = protocoloServices;
        }

        /// <summary>
        /// Inclusão de dados a fila do RabbitMQ
        /// </summary>
        /// <returns></returns>
        [HttpGet("IncluirDadosNaFila")]
        public async Task<IActionResult> InserirFila()
        {
            try
            {
                await _protocoloServices.MontaDadosEnviaFila();
                return Ok(Mensagem.Sucesso);
            }
            catch (Exception ex)
            {
                _logger.LogError(Mensagem.ErroInclusaoFila, ex);
                _logger.AddLogError(Mensagem.ErroInclusaoFila + " : " + ex);
                return new StatusCodeResult(500);
            }
        }

        /// <summary>
        /// Obtém protocolo já processado da fila no banco.
        /// </summary>
        /// <param name="numProtocolo"></param>
        /// <returns>ProtocoloEntity</returns>
        [HttpGet("ObterPorProtocolo/{numProtocolo:long}")]
        public async Task<IActionResult> ObterPorProtocolo(long numProtocolo)
        {
            try
            {
                var retorno = await _protocoloServices.ObterPorParametro(numProtocolo, null, null);
                return Ok(retorno);
            }
            catch (Exception ex)
            {
                _logger.LogError(Mensagem.Erro, ex);
                _logger.AddLogError(Mensagem.ErroInclusaoFila + " : " + ex);
                return new StatusCodeResult(500);
            }
        }

        /// <summary>
        /// Obtém protocolo já processado da fila no banco.
        /// </summary>
        /// <param name="numCpf"></param>
        /// <returns>ProtocoloEntity</returns>
        [HttpGet("ObterPorCpf/{numCpf:long}")]
        public async Task<IActionResult> ObterPorCpf(long numCpf)
        {
            try
            {
                var retorno = await _protocoloServices.ObterPorParametro(null, numCpf, null);
                return Ok(retorno);
            }
            catch (Exception ex)
            {
                _logger.LogError(Mensagem.Erro, ex);
                _logger.AddLogError(Mensagem.ErroInclusaoFila + " : " + ex);
                return new StatusCodeResult(500);
            }
        }

        /// <summary>
        /// Obtém protocolo já processado da fila no banco.
        /// </summary>
        /// <param name="numRg"></param>
        /// <returns>ProtocoloEntity</returns>
        [HttpGet("ObterPorRg/{numRg:long}")]
        public async Task<IActionResult> ObterPorRg(long numRg)
        {
            try
            {
                var retorno = await _protocoloServices.ObterPorParametro(null, null, numRg);
                return Ok(retorno);
            }
            catch (Exception ex)
            {
                _logger.LogError(Mensagem.Erro, ex);
                _logger.AddLogError(Mensagem.ErroInclusaoFila + " : " + ex);
                return new StatusCodeResult(500);
            }
        }
    }
}
