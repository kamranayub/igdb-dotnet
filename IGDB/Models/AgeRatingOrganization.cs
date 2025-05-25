namespace IGDB.Models
{
  public class AgeRatingOrganization : IIdentifier, IHasChecksum
  {
    public string Checksum { get; set; }
    public string Name { get; set; }
    public long? Id { get; set; }
  }
}