namespace IGDB.Models
{
  public class ListEntry
  {
    public string Description { get; set; }
    public IdentityOrValue<Game> Game { get; set; }
    public IdentityOrValue<List> List { get; set; }
    public IdentityOrValue<Platform> Platform { get; set; }
    public int? Position { get; set; }
    public int? Private { get; set; }
    public IdentityOrValue<User> User { get; set; }
  }
}