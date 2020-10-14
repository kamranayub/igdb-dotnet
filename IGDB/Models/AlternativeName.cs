namespace IGDB.Models
{
  public class AlternativeName : IIdentifier, IHasChecksum
  {
    public string Checksum { get; set; }
    public string Comment { get; set; }
    public IdentityOrValue<Game> Game { get; set; }
    public long? Id { get; set; }
    public string Name { get; set; }
  }
}