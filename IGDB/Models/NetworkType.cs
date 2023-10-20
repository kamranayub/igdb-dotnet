using System;

namespace IGDB.Models
{
  public class NetworkType : ITimestamps, IIdentifier, IHasChecksum
  {
    public string Checksum { get; set; }
    public DateTimeOffset? CreatedAt { get; set; }
    public IdentitiesOrValues<EventNetwork> EventNetworks { get; set; }
    public long? Id { get; set; }
    public string Name { get; set; }
    public DateTimeOffset? UpdatedAt { get; set; }
  }
}