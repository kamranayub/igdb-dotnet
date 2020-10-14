namespace IGDB.Models
{
  public class Website : IIdentifier, IHasChecksum
  {
    public WebsiteCategory Category { get; set; }
    public string Checksum { get; set; }
    public IdentityOrValue<Game> Game { get; set; }
    public long? Id { get; set; }
    public bool? Trusted { get; set; }
    public string Url { get; set; }
  }

  public enum WebsiteCategory
  {
    Official = 1,
    Wikia = 2,
    Wikipedia = 3,
    Facebook = 4,
    Twitter = 5,
    Twitch = 6,
    Instagram = 8,
    YouTube = 9,
    iPhone = 10,
    iPad = 11,
    Android = 12,
    Steam = 13,
    Reddit = 14,
    Itch = 15,
    EpicGames = 16,
    GOG = 17,
    Discord = 18
  }
}