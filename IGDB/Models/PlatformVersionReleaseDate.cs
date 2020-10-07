using System;
using Newtonsoft.Json;

namespace IGDB.Models
{
  public class PlatformVersionReleaseDate : ITimestamps, IIdentifier, IHasChecksum
  {
    public ReleaseDateCategory? Category { get; set; }
    public string Checksum { get; set; }
    public DateTimeOffset? CreatedAt { get; set; }
    public DateTimeOffset? Date { get; set; }
    public string Human { get; set; }
    public long? Id { get; set; }
    [JsonProperty("m")]
    public int? Month { get; set; }
    public IdentityOrValue<PlatformVersion> PlatformVersion { get; set; }
    public ReleaseDateRegion? Region { get; set; }
    public DateTimeOffset? UpdatedAt { get; set; }
    [JsonProperty("y")]
    public int? Year { get; set; }
  }
}