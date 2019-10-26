using System.Collections.Generic;
using Phoenix.Models;

namespace Phoenix.Services.Interfaces
{
    public interface IOrderService
    {
        // QUESTION: Should this be on the Customer Service?
        IEnumerable<Order> GetByCustomer(System.Guid customerId);

        void Create (Order order);
        
    }
}