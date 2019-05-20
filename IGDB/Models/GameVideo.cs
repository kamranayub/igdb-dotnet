namespace IGDB.Models
{
  public class GameVideo
  {
    public IdentityOrValue<Game> Game { get; set; }
    public string Name { get; set; }
    public string VideoId { get; set; }
  }
}