using System.Collections.Generic;
using Phoenix.Models;
using System;
using System.Threading.Tasks;

namespace Phoenix.Services.Interfaces
{
    public interface IEmployeeService
    {
        Task<IEnumerable<Employee>> GetAllByCompanyId(Guid companyId);
        void Create(Employee employee);
    }
}