namespace IGDB.Models
{
    public class AlternativeName : IIdentifier
    {
        public string Comment { get; set; }
        public IdentityOrValue<Game> Game { get; set; }
        public long? Id { get; set; }
        public string Name { get; set; }
    }
}