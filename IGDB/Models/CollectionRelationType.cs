using System;
using Newtonsoft.Json;

namespace IGDB.Models
{
  public class CollectionRelationType : ITimestamps, IIdentifier, IHasChecksum
  {
    public IdentityOrValue<CollectionType> AllowedChildType { get; set; }
    public IdentityOrValue<CollectionType> AllowedParentType { get; set; }
    public string Checksum { get; set; }
    public DateTimeOffset? CreatedAt { get; set; }
    public string Description { get; set; }
    public long? Id { get; set; }
    public string Name { get; set; }
    public DateTimeOffset? UpdatedAt { get; set; }
  }
}