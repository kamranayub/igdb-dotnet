namespace IGDB.Models
{
  public class GameVideo : IIdentifier
  {
    public IdentityOrValue<Game> Game { get; set; }
    public long? Id { get; set; }
    public string Name { get; set; }
    public string VideoId { get; set; }
  }
}