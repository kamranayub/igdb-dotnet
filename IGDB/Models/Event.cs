using System;

namespace IGDB.Models
{
  public class Event : ITimestamps, IIdentifier, IHasChecksum
  {
    public string Checksum { get; set; }
    public DateTimeOffset? CreatedAt { get; set; }
    public string Description { get; set; }
    public DateTimeOffset? EndTime { get; set; }
    public IdentityOrValue<EventLogo> EventLogo { get; set; }
    public IdentitiesOrValues<EventNetwork> EventNetwork { get; set; }
    public long? Id { get; set; }
    public IdentitiesOrValues<Game> Games { get; set; }
    public string LiveStreamUrl { get; set; }
    public string Name { get; set; }
    public string Slug { get; set; }
    public DateTimeOffset? StartTime { get; set; }
    public string TimeZone { get; set; }
    public DateTimeOffset? UpdatedAt { get; set; }
    public IdentitiesOrValues<GameVideo> Videos { get; set; }
  }
}