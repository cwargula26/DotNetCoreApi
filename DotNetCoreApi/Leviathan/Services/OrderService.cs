using System;
using System.Collections.Generic;
using DotNetCoreApi.Models;
using DotNetCoreApi.Services.Interfaces;

namespace DotNetCoreApi.Leviathan.Services
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

