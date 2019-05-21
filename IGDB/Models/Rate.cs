namespace IGDB.Models
{
    public class Rate
    {
        public IdentityOrValue<Game> Game { get; set; }
        public double? Rating { get; set; }
        public IdentityOrValue<User> User { get; set; }
    }
}