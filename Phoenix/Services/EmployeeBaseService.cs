using Phoenix.Services.Interfaces;
using Phoenix.Models;
using System.Collections.Generic;
using Phoenix.Repositories.Interfaces;
using System;
using System.Threading.Tasks;

namespace Phoenix.Services
{
    public class EmployeeBaseService : IEmployeeService
    {
        private IEmployeeRepo _employeeRepo;

        public EmployeeBaseService(IEmployeeRepo employeeRepo)
        {
            _employeeRepo = employeeRepo;
        }
        public async virtual void Create(Employee employee)
        {
            // Save to Repo first
            _employeeRepo.Create(employee);
        }

        public async virtual Task<IEnumerable<Employee>> GetAllByCompanyId(Guid companyId)
        {
            // Get employee from repo
            return await _employeeRepo.Get(companyId);
        }
    }
}