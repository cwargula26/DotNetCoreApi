using Phoenix.Repositories.Interfaces;
using Phoenix.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.IO;
using System.Text.Json;

namespace Phoenix.Repositories
{
    public class CustomerJsonRepo : ICustomerRepo
    {
        private List<Customer> _customers;
        private const string _customerFilePath = @"C:\temp\employees.json";

        public CustomerJsonRepo()
        {
            // Open JSON File of Employees and load them into memory
            if(File.Exists(_customerFilePath))
            {
                var customerJson = File.ReadAllText(_customerFilePath);
                _customers = JsonSerializer.Deserialize<List<Customer>>(customerJson);
            }
        }
        public IEnumerable<Customer> GetAllByCompanyId(System.Guid companyId)
        {
            throw new System.NotImplementedException();
        }

        public async Task Create(Customer customer)
        {
            if(_customers == null)
            {
                _customers = new List<Customer>();
            }
            _customers.Add(customer);
            await File.WriteAllTextAsync(_customerFilePath, JsonSerializer.Serialize(_customers));
        }
    }
}