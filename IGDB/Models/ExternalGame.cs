using System;

namespace IGDB.Models
{
  public class ExternalGame : ITimestamps
  {
    public ExternalCategory? Category { get; set; }

    public DateTimeOffset? CreatedAt { get; set; }

    public IdentityOrValue<Game> Game { get; set; }

    public string Name { get; set; }

    public string Uid { get; set; }

    public DateTimeOffset? UpdatedAt { get; set; }

    public string Url { get; set; }

    public int? Year { get; set; }
  }

  public enum ExternalCategory
  {
    Steam = 1,
    GOG = 5,
    YouTube = 10,
    Microsoft = 11,
    Apple = 13,
    Twitch = 14,
    Android = 15
  }
}