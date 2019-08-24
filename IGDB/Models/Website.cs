namespace IGDB.Models
{
  public class Website : IIdentifier
  {
    public WebsiteCategory Category { get; set; }
    public IdentityOrValue<Game> Game { get; set; }
    public long? Id { get; set; }
    public bool? Trusted { get; set; }
    public string Url { get; set; }
  }
}