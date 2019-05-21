using System;

namespace IGDB.Models
{
  public class Character : ITimestamps
  {
    public string[] Akas { get; set; }
    public string CountryName { get; set; }
    public DateTimeOffset? CreatedAt { get; set; }
    public string Description { get; set; }
    public IdentitiesOrValues<Game> Games { get; set; }
    public Gender? Gender { get; set; }
    public int? Id { get; set; }
    public IdentityOrValue<CharacterMugShot> MugShot { get; set; }
    public string Name { get; set; }
    public IdentitiesOrValues<People> People { get; set; }
    public string Slug { get; set; }
    public Species? Species { get; set; }
    public DateTimeOffset? UpdatedAt { get; set; }
    public string Url { get; set; }
  }

  public enum Gender
  {
    Male = 1,
    Female = 2,
    Other = 3
  }

  public enum Species
  {
    Human = 1,
    Alien = 2,
    Animal = 3,
    Android = 4,
    Unknown = 5
  }
}