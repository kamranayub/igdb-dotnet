using System;

namespace IGDB.Models
{
  public class GameVersion : ITimestamps, IIdentifier
  {
    public DateTimeOffset? CreatedAt { get; set; }
    public IdentitiesOrValues<GameVersionFeature> Features { get; set; }
    public IdentityOrValue<Game> Game { get; set; }
    public IdentitiesOrValues<Game> Games { get; set; }
    public long? Id { get; set; }
    public DateTimeOffset? UpdatedAt { get; set; }
    public string Url { get; set; }
  }
}