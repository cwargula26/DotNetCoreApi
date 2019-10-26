using System.Collections.Generic;
using Phoenix.Models;

namespace Phoenix.Repositories.Interfaces
{
    public interface IOrderRepo
    {
        void Create(Order order);

        IEnumerable<Order> Get(System.Guid id);
    }
}