namespace IGDB.Models
{
  public class TimeToBeat : IIdentifier
  {
    public int? Completely { get; set; }
    public long? Id { get; set; }
    public IdentityOrValue<Game> Game { get; set; }
    public int? Hastly { get; set; }
    public int? Normally { get; set; }
  }
}