using FluentValidation;
using FluentValidation.Results;
using FluxoCaixa.Api.Services.Commands;
using FluxoCaixa.Core.Domain;


namespace FluxoCaixa.Api.Services.CommandValidations
{
    public class TransacaoCommandValidation : AbstractValidator<TransacaoCommand>
    {
        public ValidationResult ValidationResult { get; set; }
       
        public TransacaoCommandValidation(TransacaoCommand command, Caixa caixa) 
        {
           
            ValidationResult = new ValidationResult();
            ValidaTransacao(command, caixa);        
        }


        protected ValidationResult ValidaTransacao(TransacaoCommand command, Caixa caixa)
        {           

            RuleFor(c => c.Descricao)
            .NotEmpty().WithMessage("A descrição precisa ser informada");

            RuleFor(c => c.CaixaId)
            .NotEmpty().WithMessage("O id do caixa precisa ser informada");

            RuleFor(c => c.Tipo)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                .WithMessage("O tipo precisa ser informado")
                .Custom((value, context) =>
                {
                    TipoTransacao tipoInformado;

                    if (!Enum.TryParse<TipoTransacao>(command.Tipo, out tipoInformado))
                    {
                        context.AddFailure("O tipo deve ser 'debito' ou 'credito'.");
                    }
                })
                .Custom((value, context) =>
                {
                    if (command.Valor <= 0)
                    {

                        context.AddFailure("O valor informado deve ser superior a zero");

                    }

                })
                .Custom((value, context) =>
                {
                    if (caixa == null)
                    {

                        context.AddFailure("Não foi localizado o caixa com o id informado");

                    }

                })
                .Custom((value, context) =>
                {

                    var tipoInformado = (TipoTransacao)Enum.Parse(typeof(TipoTransacao), command.Tipo);

                    if (tipoInformado == TipoTransacao.debito)
                    {
                        if (caixa.Saldo < command.Valor)
                        {
                            context.AddFailure("Não há saldo suficiente para realizar o débito");
                        }
                    }

                });

            return ValidationResult;
        }
    }
}
