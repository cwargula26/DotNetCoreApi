using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Phoenix.Filters;
using Phoenix.Services.Interfaces;

namespace Phoenix.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [ServiceFilter(typeof(PheonixAuthFilter))]
    public class OrderController : ControllerBase
    {
        private readonly ILogger<OrderController> _logger;
        private readonly IOrderService _service;

        public OrderController(ILogger<OrderController> logger, IOrderService service)
        {
            _logger = logger;
            _service = service;
        }
    }
}