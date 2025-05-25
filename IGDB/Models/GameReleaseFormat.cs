using System;

namespace IGDB.Models
{
  public class GameReleaseFormat : ITimestamps, IIdentifier, IHasChecksum
  {
    public string Checksum { get; set; }
    public DateTimeOffset? CreatedAt { get; set; }
    public string Format { get; set; }
    public DateTimeOffset? UpdatedAt { get; set; }
    public long? Id { get; set; }
  }
}