namespace IGDB.Models
{
  public class PulseSource
  {
    public IdentityOrValue<Game> Game { get; set; }
    public int? Id { get; set; }
    public string Name { get; set; }
    public IdentityOrValue<Page> Page { get; set; }
  }
}