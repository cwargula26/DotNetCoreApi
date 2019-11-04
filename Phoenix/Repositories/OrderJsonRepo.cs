using Phoenix.Repositories.Interfaces;
using Phoenix.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.IO;
using System.Text.Json;
using System.Linq;

namespace Phoenix.Repositories
{
    public class OrderJsonRepo : IOrderRepo
    {
        private List<Order> _orders;
        private const string _orderFilePath = @"C:\temp\orders.json";

        public OrderJsonRepo()
        {
            // Open JSON File of Employees and load them into memory
            if(File.Exists(_orderFilePath))
            {
                var orderJson = File.ReadAllText(_orderFilePath);
                _orders = JsonSerializer.Deserialize<List<Order>>(orderJson);
            }
        }

        public async Task<IEnumerable<Order>> GetByCustomerId(string customerId)
        {
            // TODO: Left this as async because if this were pulling from an actual DB I'd await that method
            return _orders?.Where(e => e.CustomerId == customerId);
        }

        public async Task Create(Order order)
        {
            if(_orders == null)
            {
                _orders = new List<Order>();
            }
            _orders.Add(order);
            await File.WriteAllTextAsync(_orderFilePath, JsonSerializer.Serialize(_orders));
        }        
    }
}