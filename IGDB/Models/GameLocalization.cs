using System;
using System.Globalization;

namespace IGDB.Models
{
  public class GameLocalization : ITimestamps, IIdentifier, IHasChecksum
  {

    public string Checksum { get; set; }
    public IdentityOrValue<Cover> Cover { get; set; }
    public DateTimeOffset? CreatedAt { get; set; }
    public IdentityOrValue<Game> Game { get; set; }
    public long? Id { get; set; }
    public string Name { get; set; }
    public IdentityOrValue<Region> Region { get; set; }
    public DateTimeOffset? UpdatedAt { get; set; }
  }
}