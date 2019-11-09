namespace Phoenix.Leviathan.Models
{
    public class LeviathanOrderGetModel : LeviathanOrderBaseModel
    {
        // Accepts both strings and numbers
        public object cartTotal { get; set; }
    }
}
