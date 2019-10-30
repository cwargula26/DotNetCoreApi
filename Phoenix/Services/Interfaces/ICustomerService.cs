using System.Collections.Generic;
using System;
using Phoenix.Models;

namespace Phoenix.Services.Interfaces
{
    public interface ICustomerService
    {
        IEnumerable<Customer> GetAll(Guid companyId);

        void Create(Customer customer);
        
    }
}