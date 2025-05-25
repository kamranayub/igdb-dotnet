namespace IGDB.Models
{
  public class AgeRating : IIdentifier, IHasChecksum
  {
    public string Checksum { get; set; }
    public IdentityOrValue<AgeRatingOrganization> Organization { get; set; }
    public IdentityOrValue<AgeRatingCategory> RatingCategory { get; set; }
    public IdentitiesOrValues<AgeRatingContentDescriptionV2> RatingContentDescriptions { get; set; }
    public string RatingCoverUrl { get; set; }
    public string Synopsis { get; set; }
    public long? Id { get; set; }
  }
}