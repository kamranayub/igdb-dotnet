namespace IGDB.Models
{
  public class Website
  {
    public WebsiteCategory Category { get; set; }
    public IdentityOrValue<Game> Game { get; set; }
    public int? Id { get; set; }
    public bool? Trusted { get; set; }
    public string Url { get; set; }
  }
}