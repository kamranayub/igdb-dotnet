namespace IGDB.Models
{
  public class PlatformFamily : IIdentifier, IHasChecksum
  {
    public string Checksum { get; set; }
    public long? Id { get; set; }
    public string Name { get; set; }
    public string Slug { get; set; }
  }
}