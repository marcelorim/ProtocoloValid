using Microsoft.AspNetCore.Mvc;
using Protocolo.Consumer.Business.Interfaces;

namespace Protocolo.Consumer.App.Controllers
{
    public class ConsumerController : Controller
    {
        private readonly ILogger<ConsumerController> _logger;
        private readonly IConsumerServices _consumerServices;

        public ConsumerController(ILogger<ConsumerController> logger, IConsumerServices consumerServices)
        {
            _logger = logger;
            _consumerServices = consumerServices;
        }

        //public IActionResult Index()
        //{
        //    return View();
        //}

        public async Task<IActionResult> Index()
        {
            try
            {
                await _consumerServices.ConsumirDadosFila();
                return Accepted();
            }
            catch (Exception ex)
            {
                _logger.LogError("Erro ao criar a fila.", ex);
                return new StatusCodeResult(500);
            }
        }
    }
}
