using System.Collections.Generic;
using DotNetCoreApi.Models;
using DotNetCoreApi.Services.Interfaces;

namespace DotNetCoreApi.Leviathan.Services
{
    public class EmployeeService : IEmployeeService
    {
        public void Create(Employee employee)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Employee> Get()
        {
            return new List<Employee>(){
                new Employee()
                {
                    FirstName = "Chris"
                }
            };
        }
    }
}