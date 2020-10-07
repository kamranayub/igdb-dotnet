using System;

namespace IGDB.Models
{
  public class Platform : ITimestamps, IIdentifier, IHasChecksum
  {
    public string Abbreviation { get; set; }
    public string AlternativeName { get; set; }
    public PlatformCategory Category { get; set; }
    public string Checksum { get; set; }
    public DateTimeOffset? CreatedAt { get; set; }
    public int? Generation { get; set; }
    public long? Id { get; set; }
    public string Name { get; set; }
    public IdentityOrValue<PlatformFamily> PlatformFamily { get; set; }
    public IdentityOrValue<PlatformLogo> PlatformLogo { get; set; }
    public string Slug { get; set; }
    public string Summary { get; set; }
    public DateTimeOffset? UpdatedAt { get; set; }
    public string Url { get; set; }
    public IdentitiesOrValues<PlatformVersion> Versions { get; set; }
    public IdentitiesOrValues<PlatformWebsite> Websites { get; set; }
  }

  public enum PlatformCategory
  {
    Console = 1,
    Arcade = 2,
    Platform = 3,
    OperatingSystem = 4,
    PortableConsole = 5,
    Computer = 6
  }
}