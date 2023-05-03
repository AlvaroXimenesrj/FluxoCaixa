using FluxoCaixa.Api.Services.CommandValidations;
using FluxoCaixa.Core.Command;
using FluxoCaixa.Core.Domain;

namespace FluxoCaixa.Api.Services.Commands
{
    public class TransacaoCommand : Command<bool>
    {        
        public string Descricao { get; set; }
        public string Tipo { get; set; }
        public decimal Valor { get; set; }
        public int CaixaId { get; set; }

        public bool ValidarTransacao(TransacaoCommand command, Caixa caixa)
        {
            ValidationResult = new TransacaoCommandValidation(this, caixa).Validate(this);
            return ValidationResult.IsValid;
        }

    }
}