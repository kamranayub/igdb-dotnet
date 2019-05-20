using System;

namespace IGDB.Models
{
  public class Feed : ITimestamps
  {
    public FeedCategory? Category { get; set; }
    public string Content { get; set; }
    public DateTimeOffset? CreatedAt { get; set; }
    public int? FeedLikesCount { get; set; }
    public IdentityOrValue<GameVideo> FeedVideo { get; set; }
    public IdentitiesOrValues<Game> Games { get; set; }
    public string Meta { get; set; }
    public DateTimeOffset? PublishedAt { get; set; }
    public IdentityOrValue<Pulse> Pulse { get; set; }
    public string Slug { get; set; }
    public string Title { get; set; }
    public string Uid { get; set; }
    public DateTimeOffset? UpdatedAt { get; set; }
    public string Url { get; set; }
    public int? User { get; set; }
  }

  public enum FeedCategory
  {
    PulseArticle = 1,
    ComingSoon = 2,
    NewTrailer = 3,
    UserContributedItem = 5,
    UserContributionsItem = 6,
    PageContributedItem = 7
  }
}