namespace IGDB.Models
{
    public class Follow
    {
        public int? Id { get; set; }
        public IdentityOrValue<Game> Game { get; set; }
        public IdentityOrValue<User> User { get; set; }
    }
}