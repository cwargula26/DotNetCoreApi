using Microsoft.AspNetCore.Mvc;
using Phoenix.Filters;

namespace Phoenix.Controllers
{

    [ApiController]
    [Route("[controller]")]
    [ServiceFilter(typeof(PhoenixAuthFilter))]
    [ServiceFilter(typeof(PhoenixExceptionFilter))]
    public class PhoenixBaseController: ControllerBase
    {
        
    }
    
}