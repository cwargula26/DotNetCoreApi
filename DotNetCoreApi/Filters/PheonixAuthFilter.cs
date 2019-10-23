using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace DotNetCoreApi.Filters
{
    public class PheonixAuthFilter : IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            // Check headers for API User/key
            var user = context.HttpContext.Request.Headers["APIUSER"];
            var key = context.HttpContext.Request.Headers["APIKEY"];

            // There should be more solid authentication process here
            // Each company that uses the system would have their own API credentials
            // but each call would check one place instead of different places depending on the call
            if(user != "UserId" || key != "MyKey")
            {
                context.Result = new UnauthorizedObjectResult("Invalid Credentials");
            }

            if(!context.ModelState.IsValid)
            {
                context.Result = new BadRequestObjectResult(context.ModelState);
            }

        }
    }
}