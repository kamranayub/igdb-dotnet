namespace IGDB.Models
{
  public class AgeRatingContentDescriptionV2 : IIdentifier, IHasChecksum
  {
    public string Checksum { get; set; }
    public string Description { get; set; }
    public IdentityOrValue<AgeRatingOrganization> Organization { get; set; }
    public long? Id { get; set; }
  }
}