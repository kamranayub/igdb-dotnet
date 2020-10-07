namespace IGDB.Models
{
  public class CompanyWebsite : IIdentifier, IHasChecksum
  {
    public WebsiteCategory? Category { get; set; }
    public string Checksum { get; set; }
    public long? Id { get; set; }
    public bool? Trusted { get; set; }
    public string Url { get; set; }
  }
}