using Phoenix.Repositories.Interfaces;
using Phoenix.Models;
using System.Collections.Generic;

namespace Phoenix.Repositories
{
    public class CustomerJsonRepo : ICustomerRepo
    {
        public IEnumerable<Customer> GetAllByCompanyId(System.Guid companyId)
        {
            throw new System.NotImplementedException();
        }

        public void Create(Customer customer)
        {
            throw new System.NotImplementedException();
        }
    }
}