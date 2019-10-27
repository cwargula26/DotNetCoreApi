using Phoenix.Repositories.Interfaces;
using Phoenix.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.IO;
using System.Text.Json;
using System.Linq;

namespace Phoenix.Repositories
{
    public class EmployeeJsonRepo : IEmployeeRepo
    {
        private IEnumerable<Employee> _employees;
        private const string _employeeFilePath = "./employees.json";

        public EmployeeJsonRepo()
        {
            // Open JSON File of Employees and load them into memory
            var employeeJson = File.ReadAllText(_employeeFilePath);
            _employees = JsonSerializer.Deserialize<IEnumerable<Employee>>(employeeJson);
        }

        ~EmployeeJsonRepo()
        {
            // Write to file on destruction
            File.WriteAllText(_employeeFilePath, JsonSerializer.Serialize(_employees));
        }

        public async Task<IEnumerable<Employee>> Get(System.Guid id)
        {
            return _employees.Where(e => e.Id == id);
        }

        public async void Create(Employee employee)
        {
            _employees.Append(employee);
        }
        
    }
}