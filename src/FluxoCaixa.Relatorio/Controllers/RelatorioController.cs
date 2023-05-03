using FluxoCaixa.Relatorio.Services;
using Microsoft.AspNetCore.Mvc;

namespace FluxoCaixa.Relatorio.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RelatorioController : ControllerBase
    {
        private readonly IService _service;

        public RelatorioController(IService service)
        {
            _service = service;
        }
        [HttpGet]
        public async Task<IActionResult> GetRelatorio()
        {
            var relatorio = await _service.GetRelatorioDiario();

            return Ok(relatorio);
        }
    }
}
