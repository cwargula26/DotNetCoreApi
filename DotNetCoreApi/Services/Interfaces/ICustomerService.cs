using System.Collections.Generic;
using DotNetCoreApi.Models;

namespace DotNetCoreApi.Services.Interfaces
{
    public interface ICustomerService
    {
        IEnumerable<Customer> GetAll();

        void Create(Customer customer);
        
    }
}