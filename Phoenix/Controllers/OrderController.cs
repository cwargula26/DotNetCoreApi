using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Phoenix.Filters;
using Phoenix.Models;
using Phoenix.Services.Interfaces;

namespace Phoenix.Controllers
{
    public class OrderController : PhoenixBaseController
    {
        private readonly ILogger<OrderController> _logger;
        private readonly IOrderService _service;

        public OrderController(ILogger<OrderController> logger, IOrderService service)
        {
            _logger = logger;
            _service = service;
        }

        [HttpPost]
        public async Task Create(Order order)
        {
            order.CompanyId = new Guid(this.Request.Headers["CompanyId"]);
            await _service.Create(order);
        }

        [HttpGet]
        [Route("{customerId}")]
        public async Task<IEnumerable<Order>> Get(string customerId)
        {
            return await _service.GetByCustomer(new Guid(customerId));
        }
    }
}