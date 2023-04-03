using Microsoft.AspNetCore.Mvc;

namespace Protocolo.Consumer.App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HealthCheckController : ControllerBase
    {
        public HealthCheckController() { }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok($"Api ativa em {DateTime.Now:G}");
        }
    }
}
