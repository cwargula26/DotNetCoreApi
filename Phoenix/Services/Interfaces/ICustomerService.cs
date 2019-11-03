using System.Collections.Generic;
using System;
using Phoenix.Models;
using System.Threading.Tasks;

namespace Phoenix.Services.Interfaces
{
    public interface ICustomerService
    {
        IEnumerable<Customer> GetAll(Guid companyId);

        Task Create(Customer customer);
        
    }
}