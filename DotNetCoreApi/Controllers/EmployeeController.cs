using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using DotNetCoreApi.Services.Interfaces;
using DotNetCoreApi.Models;
using DotNetCoreApi.Filters;

namespace DotNetCoreApi.Controllers
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
        public string Get(){
            var employees = _service.Get();
            return employees.FirstOrDefault()?.FirstName;
        }

        [HttpPost]
        public void Post(Employee employee)
        {
            _service.Create(employee);
        }
    }
}