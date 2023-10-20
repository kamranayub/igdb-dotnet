using System;
using Newtonsoft.Json;

namespace IGDB.Models
{
  public class CollectionRelation : ITimestamps, IIdentifier, IHasChecksum
  {
    public string Checksum { get; set; }
    public IdentityOrValue<Collection> ChildCollection { get; set; }
    public DateTimeOffset? CreatedAt { get; set; }
    public long? Id { get; set; }
    public IdentityOrValue<Collection> ParentCollection { get; set; }
    public IdentityOrValue<CollectionRelationType> Type { get; set; }
    public DateTimeOffset? UpdatedAt { get; set; }
  }
}