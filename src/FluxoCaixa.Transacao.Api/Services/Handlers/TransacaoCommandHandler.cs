using FluxoCaixa.Api.Services.Commands;
using MediatR;

namespace FluxoCaixa.Api.Services.Handlers
{
    public class TransacaoCommandHandler : IRequestHandler<TransacaoCommand, bool>
    {        
        public readonly IService _service;
        public TransacaoCommandHandler(IService service)
        {
            _service = service;
        }
        public async Task<bool> Handle(TransacaoCommand command, CancellationToken cancellationToken)
        {   
            await _service.VerificarExistenciaDeSaldoParaTransacao(command);

            await _service.RealizarTransacao(command);

            return true;
        }
    }
}
