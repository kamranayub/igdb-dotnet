using System;
using Newtonsoft.Json;

namespace IGDB.Models
{
  public class PlatformVersionReleaseDate : ITimestamps
  {
    public ReleaseDateCategory? Category { get; set; }
    public DateTimeOffset? CreatedAt { get; set; }
    public DateTimeOffset? Date { get; set; }
    public string Human { get; set; }
    public int? Id { get; set; }
    [JsonProperty("m")]
    public int? Month { get; set; }
    public IdentityOrValue<PlatformVersion> PlatformVersion { get; set; }
    public ReleaseDateRegion? Region { get; set; }
    public DateTimeOffset? UpdatedAt { get; set; }
    [JsonProperty("y")]
    public int? Year { get; set; }
  }
}