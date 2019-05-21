namespace IGDB.Models
{
  public class PlatformVersionCompany
  {
    public string Comment { get; set; }
    public IdentityOrValue<Company> Company { get; set; }
    public bool? Developer { get; set; }
    public int? Id { get; set; }
    public bool? Manufacturer { get; set; }
  }
}