using Phoenix.Services.Interfaces;
using Phoenix.Models;
using System.Collections.Generic;
using Phoenix.Repositories.Interfaces;
using System;
using System.Threading.Tasks;

namespace Phoenix.Services
{
    public class CustomerBaseService : ICustomerService
    {
        private ICustomerRepo _customerRepo;

        public CustomerBaseService(ICustomerRepo customerRepo)
        {
            _customerRepo = customerRepo;
        }
        public async virtual Task Create(Customer customer)
        {
            // Save to Repo first
            await _customerRepo.Create(customer);
        }

        public virtual IEnumerable<Customer> GetAll(Guid companyId)
        {
            // Get employee from repo
            return _customerRepo.GetAllByCompanyId(companyId);
        }
    }
}