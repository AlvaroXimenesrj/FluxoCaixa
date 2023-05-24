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
        [Route("{caixaId}/{data}")]
        public async Task<IActionResult> GetRelatorio(int caixaId, DateTime data)
        {
            var relatorio = await _service.GetRelatorioDiario(caixaId, data);

            return Ok(relatorio);
        }
    }
}
