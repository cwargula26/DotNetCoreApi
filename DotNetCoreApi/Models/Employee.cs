using System.ComponentModel.DataAnnotations;

namespace DotNetCoreApi.Models
{
    public class Employee
    {
        public System.Guid Id { get; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public  string Role { get; set; }

        [Required]
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
    }
}