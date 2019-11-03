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
    [ApiController]
    [Route("[controller]")]
    [ServiceFilter(typeof(PheonixAuthFilter))]
    public class CustomerController : ControllerBase
    {
        private readonly ILogger<CustomerController> _logger;
        private readonly ICustomerService _service;

        public CustomerController(ILogger<CustomerController> logger, ICustomerService service)
        {
            _logger = logger;
            _service = service;
        }

        [HttpPost]
        public async Task Create(Customer customer)
        {
            customer.CompanyId = new Guid(this.Request.Headers["CompanyId"]);
            await _service.Create(customer);
        }

        [HttpGet]
        public async Task<IEnumerable<Customer>> GetAllByCustomer()
        {
            return await _service.GetAll(new Guid(this.Request.Headers["CompanyId"]));
        }
    }
}