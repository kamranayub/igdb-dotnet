using System;
using Newtonsoft.Json;

namespace IGDB.Models
{
  public class Collection : ITimestamps, IIdentifier, IHasChecksum
  {
    public IdentitiesOrValues<CollectionRelation> AsChildRelations { get; set; }
    public IdentitiesOrValues<CollectionRelation> AsParentRelations { get; set; }
    public string Checksum { get; set; }
    public DateTimeOffset? CreatedAt { get; set; }
    public IdentitiesOrValues<Game> Games { get; set; }
    public long? Id { get; set; }
    public string Name { get; set; }
    public string Slug { get; set; }
    public DateTimeOffset? UpdatedAt { get; set; }
    public IdentityOrValue<CollectionType> Type { get; set; }
    public string Url { get; set; }
  }
}