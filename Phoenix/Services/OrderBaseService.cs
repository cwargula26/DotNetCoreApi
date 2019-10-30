using System;
using System.Collections.Generic;
using Phoenix.Models;
using Phoenix.Services.Interfaces;
using Phoenix.Repositories.Interfaces;

namespace Phoenix.Services
{
    public class OrderBaseService : IOrderService
    {
        private IOrderRepo _orderRepo;

        public OrderBaseService(IOrderRepo orderRepo)
        {
            _orderRepo = orderRepo;
        }

        public void Create(Order order)
        {
            _orderRepo.Create(order);
        }

        public IEnumerable<Order> GetByCustomer(Guid customerId)
        {
            return _orderRepo.Get(customerId);
        }
    }

}