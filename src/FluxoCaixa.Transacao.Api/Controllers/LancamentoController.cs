using FluxoCaixa.Api.Services.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FluxoCaixa.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LancamentoController : ControllerBase
    {       
        public readonly IMediator _mediatr;        

        public LancamentoController(IMediator mediatr)
        {            
            _mediatr = mediatr;            
        }

        [HttpPost]
        [Route("RealizarTranzacao")]
        public async Task<IActionResult> RealizarTransacao([FromBody] TransacaoCommand command)
        {
            await _mediatr.Send(command);

            return Ok();
        }
    }
}