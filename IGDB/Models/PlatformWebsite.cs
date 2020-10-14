namespace IGDB.Models
{
  public class PlatformWebsite : IIdentifier, IHasChecksum
  {
    public PlatformWebsiteCategory? Category { get; set; }
    public string Checksum { get; set; }
    public long? Id { get; set; }
    public bool? Trusted { get; set; }
    public string Url { get; set; }
  }

  public enum PlatformWebsiteCategory
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
    Discord = 15,
    GooglePlus = 16,
    Tumblr = 17,
    LinkedIn = 18,
    Pinterest = 19,
    SoundCloud = 20
  }
}