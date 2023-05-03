using MediatR;
using FluentValidation.Results;

namespace FluxoCaixa.Core.Command
{
    public abstract class Command<T> : IRequest<T> 
    {
        [System.Text.Json.Serialization.JsonIgnore]
        public ValidationResult ValidationResult { get; set; }

        protected Command()
        {
            ValidationResult = new ValidationResult();
        }
    }
}
