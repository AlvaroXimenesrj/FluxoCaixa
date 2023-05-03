using FluxoCaixa.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace FluxoCaixa.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CaixaController : ControllerBase
    {
        public readonly IService _service;
        public CaixaController(IService service)
        {
            _service = service;
        }
      

        [HttpPost]
        [Route("Criar")]
        public async Task<IActionResult> CriarCaixa()
        {
            var caixa = await _service.CriarCaixa();

            return Ok(caixa);
        }
    }
}