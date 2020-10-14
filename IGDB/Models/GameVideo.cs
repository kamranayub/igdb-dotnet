namespace IGDB.Models
{
  public class GameVideo : IIdentifier, IHasChecksum
  {
    
    public string Checksum { get; set; }
    public IdentityOrValue<Game> Game { get; set; }
    public long? Id { get; set; }
    public string Name { get; set; }
    public string VideoId { get; set; }
  }
}