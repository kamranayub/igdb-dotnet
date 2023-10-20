using System;
using Newtonsoft.Json;

namespace IGDB.Models
{
  public class ReleaseDateStatus : ITimestamps, IIdentifier, IHasChecksum
  {
    public string Checksum { get; set; }
    public DateTimeOffset? CreatedAt { get; set; }
    public long? Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public DateTimeOffset? UpdatedAt { get; set; }
  }
}