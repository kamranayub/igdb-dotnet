using System;

namespace IGDB.Models
{
  public class Achievement : ITimestamps
  {
    public IdentityOrValue<AchievementIcon> AchievementIcon { get; set; }
    public AchievementCategory Category { get; set; }
    public DateTimeOffset? CreatedAt { get; set; }
    public string Description { get; set; }
    public string ExternalId { get; set; }
    public IdentityOrValue<Game> Game { get; set; }
    public AchievementLanguage Language { get; set; }
    public string Name { get; set; }
    public double? OwnersPercentage { get; set; }
    public AchievementRank Rank { get; set; }
    public string Slug { get; set; }
    public int[] Tags { get; set; }
    public DateTimeOffset? UpdatedAt { get; set; }
  }

  public enum AchievementRank
  {
    Bronze = 1,
    Silver = 2,
    Gold = 3,
    Platinum = 4
  }

  public enum AchievementCategory
  {
    Playstation = 1,
    Xbox = 2,
    Steam = 3
  }

  public enum AchievementLanguage
  {
    Europe = 1,
    NorthAmerica = 2,
    Australia = 3,
    NewZealand = 4,
    Japan = 5,
    China = 6,
    Asia = 7,
    Worldwide = 8,
    HongKong = 9,
    SouthKorea = 10
  }
}