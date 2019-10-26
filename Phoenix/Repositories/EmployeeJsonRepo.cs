using Phoenix.Repositories.Interfaces;
using Phoenix.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Phoenix.Repositories
{
    public class EmployeeJsonRepo : IEmployeeRepo
    {
        public async Task<IEnumerable<Employee>> Get(System.Guid id)
        {
            throw new System.NotImplementedException();
        }

        public async void Create(Employee employee)
        {
            throw new System.NotImplementedException();
        }
        
    }
}