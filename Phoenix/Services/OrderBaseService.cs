using System;
using System.Collections.Generic;
using Phoenix.Models;
using Phoenix.Services.Interfaces;
using Phoenix.Repositories.Interfaces;
using System.Threading.Tasks;

namespace Phoenix.Services
{
    public class OrderBaseService : IOrderService
    {
        private IOrderRepo _orderRepo;

        public OrderBaseService(IOrderRepo orderRepo)
        {
            _orderRepo = orderRepo;
        }

        public virtual async Task Create(Order order)
        {
            await _orderRepo.Create(order);
        }

        public virtual async Task<IEnumerable<Order>> GetByCustomer(System.Guid customerId)
        {
            return await _orderRepo.GetByCustomerId(customerId);
        }
    }

}