using Phoenix.Services.Interfaces;
using Phoenix.Models;
using System.Collections.Generic;
using Phoenix.Repositories.Interfaces;
using System;

namespace Phoenix.Services
{
    public class CustomerBaseService : ICustomerService
    {
        private ICustomerRepo _customerRepo;

        public CustomerBaseService(ICustomerRepo customerRepo)
        {
            _customerRepo = customerRepo;
        }
        public virtual void Create(Customer customer)
        {
            // Save to Repo first
            _customerRepo.Create(customer);
        }

        public virtual IEnumerable<Customer> GetAll(Guid companyId)
        {
            // Get employee from repo
            return _customerRepo.GetAllByCompanyId(companyId);
        }
    }
}