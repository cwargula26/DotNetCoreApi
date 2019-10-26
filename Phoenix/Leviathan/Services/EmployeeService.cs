using System.Collections.Generic;
using System;
using Phoenix.Models;
using Phoenix.Services;
using Phoenix.Repositories.Interfaces;
using System.Threading.Tasks;
using System.Linq;

namespace Phoenix.Leviathan.Services
{
    public class EmployeeService : EmployeeBaseService
    {
        public EmployeeService(IEmployeeRepo employeeRepo) : base(employeeRepo){}

        public override void Create(Employee employee)
        {
            base.Create(employee);

            // TODO: Save to Leviathan service
            throw new System.NotImplementedException();
        }

        public async override Task<IEnumerable<Employee>> GetAllByCompanyId(Guid companyId)
        {
            var repoEmployees = await base.GetAllByCompanyId(companyId);

            // TODO: REMOVE FOR TESTING ONLY
            repoEmployees.Append(new Employee(){ FirstName = "Chris" });
            return repoEmployees;

            // TOOD: Get employee from Service
            // TODO: determine which is newer and should be returned
            throw new System.NotImplementedException();
        }
    }
}