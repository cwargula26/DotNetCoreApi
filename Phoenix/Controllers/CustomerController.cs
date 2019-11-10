using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Phoenix.Services.Interfaces;
using Phoenix.Models;
using Phoenix.Filters;

namespace Phoenix.Controllers
{
    public class CustomerController : PhoenixBaseController
    {
        private readonly ILogger<CustomerController> _logger;
        private readonly ICustomerService _service;

        public CustomerController(ILogger<CustomerController> logger, ICustomerService service)
        {
            _logger = logger;
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> Create(Customer customer)
        {
            customer.CompanyId = new Guid(this.Request.Headers["CompanyId"]);
            await _service.Create(customer);
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> GetAllByCustomer()
        {
            return Ok(await _service.GetAll(new Guid(this.Request.Headers["CompanyId"])));
        }
    }
}