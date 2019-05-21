namespace IGDB.Models
{
  public class TimeToBeat
  {
    public int? Completely { get; set; }
    public int? Id { get; set; }
    public IdentityOrValue<Game> Game { get; set; }
    public int? Hastly { get; set; }
    public int? Normally { get; set; }
  }
}