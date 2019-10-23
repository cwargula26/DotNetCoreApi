using System.ComponentModel.DataAnnotations;

namespace DotNetCoreApi.Models
{
    public class Customer 
    {
        public System.Guid Id { get; set; }

        [Required]
        public string Name { get; set; }
        
        public string Address { get; set; }

        [Required]
        public int EmployeeId { get; set; }
    }
}