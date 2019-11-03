using System.Collections.Generic;
using System.Threading.Tasks;
using Phoenix.Models;

namespace Phoenix.Repositories.Interfaces
{
    public interface ICustomerRepo
    {
        Task Create(Customer customer);

        IEnumerable<Customer> GetAllByCompanyId(System.Guid companyId);
    }
}