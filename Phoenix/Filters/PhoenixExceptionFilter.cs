using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Phoenix.Exceptions;

namespace Phoenix.Filters
{
    public class PhoenixExceptionFilter: ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            if(context.Exception is ApiException)
            {
                var exception = context.Exception as ApiException;
                context.HttpContext.Response.StatusCode = exception.StatusCode;
                context.Result = new JsonResult(exception.Message);
            }
        }
    }    
}