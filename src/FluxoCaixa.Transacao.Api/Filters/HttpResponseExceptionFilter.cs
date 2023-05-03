using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using FluxoCaixa.Api.Errors;

namespace FluxoCaixa.Api.Filters
{
    public class HttpResponseExceptionFilter : IActionFilter, IOrderedFilter
    {
        public int Order => int.MaxValue - 10;

        public void OnActionExecuting(ActionExecutingContext context) { }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            if (context.Exception is CustomException httpResponseDomainException)
            {
                context.Result = new ObjectResult(new { Errors = httpResponseDomainException.Value })
                {
                    StatusCode = httpResponseDomainException.StatusCode
                };

                context.ExceptionHandled = true;
            }
        }
    }
}
