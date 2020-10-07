namespace IGDB.Models
{
  public class PlatformFamily : IIdentifier
  {
    public string Checksum { get; set; }
    public string Name { get; set; }
    public string Slug { get; set; }
  }
}