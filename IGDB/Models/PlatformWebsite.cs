namespace IGDB.Models
{
  public class PlatformWebsite : IIdentifier
  {
    public WebsiteCategory? Category { get; set; }
    public long? Id { get; set; }
    public bool? Trusted { get; set; }
    public string Url { get; set; }
  }
}