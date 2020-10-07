using System;

namespace IGDB.Models
{
  public class GameEngine : ITimestamps, IIdentifier, IHasChecksum
  {

    public string Checksum { get; set; }
    
    public IdentitiesOrValues<Company> Companies { get; set; }

    public DateTimeOffset? CreatedAt { get; set; }

    public string Description { get; set; }
    public IdentityOrValue<GameEngineLogo> Logo { get; set; }
    public long? Id { get; set; }

    public string Name { get; set; }

    public IdentitiesOrValues<Platform> Platforms { get; set; }

    public string Slug { get; set; }

    public DateTimeOffset? UpdatedAt { get; set; }
    public string Url { get; set; }
  }
}