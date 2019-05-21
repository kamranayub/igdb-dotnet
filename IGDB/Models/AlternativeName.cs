namespace IGDB.Models
{
    public class AlternativeName
    {
        public string Comment { get; set; }
        public IdentityOrValue<Game> Game { get; set; }
        public int? Id { get; set; }
        public string Name { get; set; }
    }
}