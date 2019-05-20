using System;
using Newtonsoft.Json;

namespace IGDB.Models
{
  public class PlatformVersionReleaseDate : ITimestamps
  {
    public PlatformVersionReleaseDateCategory? Category { get; set; }
    public DateTimeOffset? CreatedAt { get; set; }
    public DateTimeOffset? Date { get; set; }
    public string Human { get; set; }
    [JsonProperty("m")]
    public int? Month { get; set; }
    public IdentityOrValue<PlatformVersion> PlatformVersion { get; set; }
    public PlatformVersionReleaseDateRegion? Region { get; set; }
    public DateTimeOffset? UpdatedAt { get; set; }
    [JsonProperty("y")]
    public int? Year { get; set; }
  }

  public enum PlatformVersionReleaseDateCategory
  {
    YYYYMMMMDD = 0,
    YYYYMMMM = 1,
    YYYY = 2,
    YYYYQ1 = 3,
    YYYYQ2 = 4,
    YYYYQ3 = 5,
    YYYYQ4 = 6,
    TBD = 7
  }

  public enum PlatformVersionReleaseDateRegion
  {
    Europe = 1,
    NorthAmerica = 2,
    Australia = 3,
    NewZealand = 4,
    Japan = 5,
    China = 6,
    Asia = 7,
    Worldwide = 8
  }
}