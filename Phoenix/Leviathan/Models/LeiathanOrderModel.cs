namespace Phoenix.Leviathan.Models
{
    public class LeviathanOrderBaseModel : BaseLeviathanModel
    {
        public string customerId { get; set; }
        public int Id { get; set; }
        public string[] Products { get; set; }
        public System.Guid cashierId { get; set; }
    }
}