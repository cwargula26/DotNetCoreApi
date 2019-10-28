using System.Collections.Generic;
using System.Threading.Tasks;
using Phoenix.Models;

namespace Phoenix.Repositories.Interfaces
{
    public interface IEmployeeRepo
    {
        Task Create(Employee emp);

        Task<IEnumerable<Employee>> Get(System.Guid companyId);
    }
}