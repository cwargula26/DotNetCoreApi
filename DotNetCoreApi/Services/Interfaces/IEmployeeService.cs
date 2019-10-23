using System.Collections.Generic;
using DotNetCoreApi.Models;

namespace DotNetCoreApi.Services.Interfaces
{
    public interface IEmployeeService
    {
        IEnumerable<Employee> Get();
        void Create(Employee employee);
    }
}