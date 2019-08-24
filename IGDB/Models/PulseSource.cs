namespace IGDB.Models
{
  public class PulseSource : IIdentifier
  {
    public IdentityOrValue<Game> Game { get; set; }
    public long? Id { get; set; }
    public string Name { get; set; }
    public IdentityOrValue<Page> Page { get; set; }
  }
}