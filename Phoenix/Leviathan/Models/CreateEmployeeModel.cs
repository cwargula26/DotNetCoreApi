namespace Phoenix.Leviathan.Models
{
    public class CreateEmployeeModel : BaseCreateModel
    {
        public System.Guid Id { get; }
        public string firstname { get; set; }
        public string lastname { get; set; }
        public  string role { get; set; }
        public string telephone { get; set; }
        public string email { get; set; }
    }
}