namespace IGDB.Models
{
  public class CompanyWebsite : IIdentifier, IHasChecksum
  {
    public string Checksum { get; set; }
    public long? Id { get; set; }
    public bool? Trusted { get; set; }
    public IdentityOrValue<WebsiteType> Type { get; set; }
    public string Url { get; set; }
  }
}