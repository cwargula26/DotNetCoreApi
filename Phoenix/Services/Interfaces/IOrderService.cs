using System.Collections.Generic;
using System.Threading.Tasks;
using Phoenix.Models;

namespace Phoenix.Services.Interfaces
{
    public interface IOrderService
    {
        // QUESTION: Should this be on the Customer Service?
        Task<IEnumerable<Order>> GetByCustomer(string customerId);

        Task Create (Order order);
        
    }
}