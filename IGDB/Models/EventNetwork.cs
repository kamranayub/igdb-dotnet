using System;

namespace IGDB.Models
{
  public class EventNetwork : ITimestamps, IIdentifier, IHasChecksum
  {
    public string Checksum { get; set; }
    public DateTimeOffset? CreatedAt { get; set; }
    public IdentityOrValue<Event> Event { get; set; }
    public long? Id { get; set; }
    public IdentityOrValue<NetworkType> NetworkType { get; set; }
    public DateTimeOffset? UpdatedAt { get; set; }
    public string Url { get; set; }
  }
}