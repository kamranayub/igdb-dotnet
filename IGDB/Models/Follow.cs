namespace IGDB.Models
{
    public class Follow : IIdentifier
    {
        public long? Id { get; set; }
        public IdentityOrValue<Game> Game { get; set; }
        public IdentityOrValue<User> User { get; set; }
    }
}