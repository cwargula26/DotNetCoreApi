using System.Collections.Generic;
using System;
using Phoenix.Models;
using Phoenix.Services.Interfaces;

namespace Phoenix.Leviathan.Services
{
    public class CustomerService : ICustomerService
    {
        public void Create(Customer customer)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Customer> GetAll(Guid companyId)
        {
            throw new System.NotImplementedException();
        }
    }
}