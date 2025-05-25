using System;

namespace IGDB.Models
{
  public class ExternalGame : ITimestamps, IIdentifier, IHasChecksum
  {

    public string Checksum { get; set; }
    public double[] Countries { get; set; }
    public DateTimeOffset? CreatedAt { get; set; }
    public IdentityOrValue<ExternalGameSource> ExternalGameSource { get; set; }
    public IdentityOrValue<Game> Game { get; set; }
    public IdentityOrValue<GameReleaseFormat> GameReleaseFormat { get; set; }
    public long? Id { get; set; }


    public string Name { get; set; }

    public IdentityOrValue<Platform> Platform { get; set; }

    public string Uid { get; set; }

    public DateTimeOffset? UpdatedAt { get; set; }

    public string Url { get; set; }

    public int? Year { get; set; }
  }
}