using System.Collections.Generic;
using Phoenix.Models;

namespace Phoenix.Repositories.Interfaces
{
    public interface ICustomerRepo
    {
        void Create(Customer customer);

        IEnumerable<Customer> GetAllByCompanyId(System.Guid companyId);
    }
}