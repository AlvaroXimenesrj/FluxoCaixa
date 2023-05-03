using FluxoCaixa.Api.Data.Repository;
using FluxoCaixa.Api.Domain;
using FluxoCaixa.Api.Errors;
using FluxoCaixa.Api.Services.Commands;
using FluxoCaixa.Core.Domain;

namespace FluxoCaixa.Api.Services
{
    public class Service : IService
    {
        public readonly IRepository _repository;
        public Service(IRepository repository)
        {
            _repository = repository;
        }
        public async Task VerificarExistenciaDeSaldoParaTransacao(TransacaoCommand command)
        {            
            var caixa = await _repository.GetCaixaById(command.CaixaId);            

            if (!command.ValidarTransacao(command, caixa))
                throw new CustomException(command.ValidationResult.Errors.Select(e => e.ErrorMessage));
        }


        public async Task RealizarTransacao(TransacaoCommand command)
        {
            await SalvarTransacao(command);

            await AtualizarCaixa(command);            
        }

        private async Task SalvarTransacao(TransacaoCommand command)
        {
            var tipo = (TipoTransacao)Enum.Parse(typeof(TipoTransacao), command.Tipo);

            var transacao = Transacao.TransacaoFactory(tipo, command.Valor, command.Descricao, command.CaixaId);

           await _repository.SalvarTransacao(transacao);
        }
        private async Task AtualizarCaixa(TransacaoCommand command)
        {
            var caixa = await _repository.GetCaixaById(command.CaixaId);

            var tipo = (TipoTransacao)Enum.Parse(typeof(TipoTransacao), command.Tipo);

            caixa.AtualizarSaldo(command.Valor, tipo);

            await _repository.UpdateCaixa(caixa);
        }

        public async Task<CaixaDTO> CriarCaixa()
        {
            var caixa = await _repository.CriarCaixa();

            var caixaDTO = new CaixaDTO() { Id = caixa.Id, Saldo = caixa.Saldo };

            return caixaDTO;
        }
    }
}