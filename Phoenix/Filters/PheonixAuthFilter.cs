using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Phoenix.Filters
{
    public class PheonixAuthFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
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

            var companyId = "24124";

            // Attach the company id along with the request
            // TODO: is there a better way? I'm adding to both the header and query string so that binding will pick it up either place
            context.HttpContext.Request.Headers.Add("CompanyId", companyId);
            context.HttpContext.Request.QueryString.Add("CompanyId", companyId);
        }
    }
}