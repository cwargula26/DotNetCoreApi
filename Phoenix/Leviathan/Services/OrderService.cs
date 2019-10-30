using System;
using System.Collections.Generic;
using Phoenix.Models;
using Phoenix.Services.Interfaces;

namespace Phoenix.Leviathan.Services
{
    public class OrderService : IOrderService
    {
        public void Create(Order order)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Order> GetByCustomer(Guid customerId)
        {
            throw new NotImplementedException();
        }
    }
}

