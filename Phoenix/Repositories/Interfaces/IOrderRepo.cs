using System.Collections.Generic;
using System.Threading.Tasks;
using Phoenix.Models;

namespace Phoenix.Repositories.Interfaces
{
    public interface IOrderRepo
    {
        Task Create(Order order);

        Task<IEnumerable<Order>> GetByCustomerId(System.Guid id);
    }
}