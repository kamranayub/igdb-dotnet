using System;

namespace IGDB.Models
{
  public class GameType : ITimestamps, IIdentifier, IHasChecksum
  {
    public string Checksum { get; set; }
    public DateTimeOffset? CreatedAt { get; set; }
    public string Type { get; set; }
    public DateTimeOffset? UpdatedAt { get; set; }
    public long? Id { get; set; }
  }
}