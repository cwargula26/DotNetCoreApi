using Phoenix.Repositories.Interfaces;
using Phoenix.Models;
using System.Collections.Generic;

namespace Phoenix.Repositories
{
    public class OrderJsonRepo : IOrderRepo
    {
        public IEnumerable<Order> Get(System.Guid id)
        {
            throw new System.NotImplementedException();
        }

        public void Create(Order order)
        {
            throw new System.NotImplementedException();
        }
    }
}