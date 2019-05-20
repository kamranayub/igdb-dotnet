namespace IGDB.Models
{
  public class PageWebsite
  {
    public WebsiteCategory Category { get; set; }
    public bool? Trusted { get; set; }
    public string Url { get; set; }
  }
}