using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
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
    public class EmployeeController : ControllerBase
    {
        private readonly ILogger<EmployeeController> _logger;
        private readonly IEmployeeService _service;

        public EmployeeController(ILogger<EmployeeController> logger, IEmployeeService service)
        {
            _logger = logger;
            _service = service;
        }

        [HttpGet]
        public async Task<string> Get()
        {
            var employees = await _service.GetAllByCompanyId(new Guid(this.Request.Headers["CompanyId"]));
            return employees.FirstOrDefault()?.FirstName;
        }

        [HttpPost]
        public void Post(Employee employee)
        {
           _service.Create(employee);
        }
    }
}