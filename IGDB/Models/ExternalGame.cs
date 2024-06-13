using System;

namespace IGDB.Models
{
  public class ExternalGame : ITimestamps, IIdentifier, IHasChecksum
  {
    public ExternalCategory? Category { get; set; }

    public string Checksum { get; set; }
    public double[] Countries { get; set; }
    public DateTimeOffset? CreatedAt { get; set; }
    public IdentityOrValue<Game> Game { get; set; }
    public long? Id { get; set; }

    public ExternalGameMedia? Media { get; set; }

    public string Name { get; set; }

    public IdentityOrValue<Platform> Platform { get; set; }

    public string Uid { get; set; }

    public DateTimeOffset? UpdatedAt { get; set; }

    public string Url { get; set; }

    public int? Year { get; set; }
  }

  public enum ExternalGameMedia
  {
    Digital = 1,
    Physical = 2
  }

  public enum ExternalCategory
  {
    Steam = 1,
    GOG = 5,
    YouTube = 10,
    Microsoft = 11,
    Apple = 13,
    Twitch = 14,
    Android = 15,
    AmazonAsin = 20,
    AmazonLuna = 22,
    AmazonAdg = 23,
    EpicGameStore = 26,
    Oculus = 28,
    Utomik = 29,
    ItchIO = 30,
    XboxMarketplace = 31,
    Kartridge = 32,
    PlaystationStoreUS = 36,
    FocusEntertainment = 37,
    XboxGamePassUltimateCloud = 54,
    Gamejolt = 55
  }
}