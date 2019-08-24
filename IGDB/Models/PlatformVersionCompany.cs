namespace IGDB.Models
{
  public class PlatformVersionCompany : IIdentifier
  {
    public string Comment { get; set; }
    public IdentityOrValue<Company> Company { get; set; }
    public bool? Developer { get; set; }
    public long? Id { get; set; }
    public bool? Manufacturer { get; set; }
  }
}