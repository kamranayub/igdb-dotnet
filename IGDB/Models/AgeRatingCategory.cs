namespace IGDB.Models
{
  public class AgeRatingCategory : IIdentifier, IHasChecksum
  {
    public string Checksum { get; set; }
    public IdentityOrValue<AgeRatingOrganization> Organization { get; set; }
    public string Rating { get; set; }
    public long? Id { get; set; }
  }
}