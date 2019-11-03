using System.ComponentModel.DataAnnotations;

namespace Phoenix.Models
{
    public class Customer : BaseModel
    {
        public System.Guid Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]        
        public string Address { get; set; }

        [Required]
        public System.Guid EmployeeId { get; set; }
    }
}