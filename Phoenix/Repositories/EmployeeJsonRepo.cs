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
        private List<Employee> _employees;
        private const string _employeeFilePath = @"C:\temp\employees.json";

        public EmployeeJsonRepo()
        {
            // Open JSON File of Employees and load them into memory
            if(File.Exists(_employeeFilePath))
            {
                var employeeJson = File.ReadAllText(_employeeFilePath);
                _employees = JsonSerializer.Deserialize<List<Employee>>(employeeJson);
            }
        }

        public async Task<IEnumerable<Employee>> Get(System.Guid id)
        {
            return _employees?.Where(e => e.Id == id);
        }

        public async Task Create(Employee employee)
        {
            if(_employees == null)
            {
                _employees = new List<Employee>();
            }
            _employees.Add(employee);
            await File.WriteAllTextAsync(_employeeFilePath, JsonSerializer.Serialize(_employees));
        }        
    }
}