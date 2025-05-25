using System;

namespace IGDB.Models
{
  public class Character : ITimestamps, IIdentifier, IHasChecksum
  {
    public string[] Akas { get; set; }
    public IdentityOrValue<CharacterGender> CharacterGender { get; set; }
    public IdentityOrValue<CharacterSpecies> CharacterSpecies { get; set; }
    public string Checksum { get; set; }
    public string CountryName { get; set; }
    public DateTimeOffset? CreatedAt { get; set; }
    public string Description { get; set; }
    public IdentitiesOrValues<Game> Games { get; set; }
    public long? Id { get; set; }
    public IdentityOrValue<CharacterMugShot> MugShot { get; set; }
    public string Name { get; set; }
    public string Slug { get; set; }
    public DateTimeOffset? UpdatedAt { get; set; }
    public string Url { get; set; }
  }
}