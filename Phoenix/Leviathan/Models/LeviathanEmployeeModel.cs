namespace Phoenix.Leviathan.Models
{
    public class LeviathanEmployeeModel : BaseLeviathanModel
    {
        public System.Guid Id { get; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public  string role { get; set; }
        public string telephone { get; set; }
        public string email { get; set; }
    }
}