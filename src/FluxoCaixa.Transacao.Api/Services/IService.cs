using FluxoCaixa.Api.Domain;
using FluxoCaixa.Api.Services.Commands;

namespace FluxoCaixa.Api.Services
{
    public interface IService
    {
        Task VerificarExistenciaDeSaldoParaTransacao(TransacaoCommand command);
        Task RealizarTransacao(TransacaoCommand command);
        Task<CaixaDTO> CriarCaixa();        

    }
}
