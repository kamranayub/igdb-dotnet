using System;

namespace IGDB.Models
{
  public class AgeRatingContentDescriptionV2 : ITimestamps, IIdentifier, IHasChecksum
  {
    public string Checksum { get; set; }
    public DateTimeOffset? CreatedAt { get; set; }
    public IdentityOrValue<AgeRatingOrganization> Organization { get; set; }
    public string Description { get; set; }
    public long? Id { get; set; }
    public DateTimeOffset? UpdatedAt { get; set; }
  }
}