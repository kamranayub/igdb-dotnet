using System;

namespace IGDB.Models
{
  public class AgeRatingCategory : ITimestamps, IIdentifier, IHasChecksum
  {
    public string Checksum { get; set; }
    public DateTimeOffset? CreatedAt { get; set; }
    public IdentityOrValue<AgeRatingOrganization> Organization { get; set; }
    public string Rating { get; set; }
    public long? Id { get; set; }
    public DateTimeOffset? UpdatedAt { get; set; }
  }
}