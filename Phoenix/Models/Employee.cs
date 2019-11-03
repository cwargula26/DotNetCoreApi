using System.ComponentModel.DataAnnotations;

namespace Phoenix.Models
{
    public class Employee : BaseModel
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

        [Required]
        public string Email { get; set; }
    }
}