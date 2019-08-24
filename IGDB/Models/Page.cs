using System;

namespace IGDB.Models
{
  public class Page : ITimestamps, IIdentifier
  {
    public IdentityOrValue<PageBackground> Background { get; set; }
    public string Battlenet { get; set; }
    public PageCategory Category { get; set; }
    public PageColor Color { get; set; }
    public IdentityOrValue<Company> Company { get; set; }
    public int? Country { get; set; }
    public DateTimeOffset? CreatedAt { get; set; }
    public string Description { get; set; }
    public IdentityOrValue<Feed> Feed { get; set; }
    public IdentityOrValue<Game> Game { get; set; }
    public long? Id { get; set; }
    public string Name { get; set; }
    public string Origin { get; set; }
    public int? PageFollowsCount { get; set; }
    public IdentityOrValue<PageLogo> PageLogo { get; set; }
    public string Slug { get; set; }
    public PageSubCategory SubCategory { get; set; }
    public DateTimeOffset? UpdatedAt { get; set; }
    public string Uplay { get; set; }
    public string Url { get; set; }
    public int? User { get; set; }
    public IdentitiesOrValues<PageWebsite> Websites { get; set; }
  }

  public enum PageColor
  {
    Green = 0,
    Blue = 1,
    Red = 2,
    Orange = 3,
    Pink = 4,
    Yellow = 5
  }

  public enum PageCategory
  {
    Personality = 1,
    MediaOrganization = 2,
    ContentCreator = 3,
    ClanTeam = 4
  }

  public enum PageSubCategory
  {
    User = 1,
    Game = 2,
    Company = 3,
    Consumer = 4,
    Industry = 5,
    eSports = 6
  }
}