using Microsoft.AspNetCore.Mvc;
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

        [HttpGet("InserirFila")]
        public async Task<IActionResult> InserirFila()
        {
            try
            {
                await _protocoloServices.MontaDadosEnviaFila();
                return Accepted();
            }
            catch (Exception ex)
            {
                _logger.LogError("Erro ao criar a fila.", ex);
                return new StatusCodeResult(500);
            }
        }

        [HttpGet("{numProtocolo:int}")]
        public async Task<IActionResult> ObterPorProtocolo(int numProtocolo)
        {
            try
            {
                await _protocoloServices.ObterPorProtocolo(numProtocolo); return Accepted();
                //var retorno = await _protocoloServices.ObterPorProtocolo(numProtocolo);
                //return Ok(retorno);
            }
            catch (Exception ex)
            {
                _logger.LogError(Mensagem.Erro, ex);
                return new StatusCodeResult(500);
            }
        }
    }
}
