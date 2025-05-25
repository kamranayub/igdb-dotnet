using System;
using Newtonsoft.Json;

namespace IGDB.Models
{
  public class ReleaseDate : ITimestamps, IIdentifier, IHasChecksum
  {
    public string Checksum { get; set; }
    public DateTimeOffset? CreatedAt { get; set; }
    public DateTimeOffset? Date { get; set; }
    public IdentityOrValue<DateFormat> DateFormat { get; set; }
    public IdentityOrValue<Game> Game { get; set; }
    public long? Id { get; set; }
    public string Human { get; set; }
    [JsonProperty("m")]
    public int? Month { get; set; }
    public IdentityOrValue<Platform> Platform { get; set; }
    public IdentityOrValue<ReleaseDateRegion> ReleaseRegion { get; set; }
    public IdentityOrValue<ReleaseDateStatus> Status { get; set; }
    public DateTimeOffset? UpdatedAt { get; set; }
    [JsonProperty("y")]
    public int? Year { get; set; }
  }
}