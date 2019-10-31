using System.ComponentModel.DataAnnotations;

namespace Phoenix.Models
{
    public class Order : BaseModel
    {
        [Required]
        public string CustomerId { get; set; }

        public int Id { get; set; }

        [Required]
        public string[] Products { get; set; }

        // ASSUMPTION: A Cashier should be a type of employe and a CashierId should be that employee's id
        [Required]
        public System.Guid CashierId { get; set; }

        [Required]
        public decimal CartTotal { get; set; }
    }
}