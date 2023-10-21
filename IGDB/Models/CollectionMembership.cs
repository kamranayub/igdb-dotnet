using System;
using Newtonsoft.Json;

namespace IGDB.Models
{
  public class CollectionMembership : ITimestamps, IIdentifier, IHasChecksum
  {
    public string Checksum { get; set; }
    public IdentityOrValue<Collection> Collection { get; set; }
    public DateTimeOffset? CreatedAt { get; set; }
    public IdentityOrValue<Game> Game { get; set; }
    public long? Id { get; set; }
    public string Name { get; set; }
    public IdentityOrValue<CollectionMembershipType> Type { get; set; }
    public DateTimeOffset? UpdatedAt { get; set; }
    public string Url { get; set; }
  }
}