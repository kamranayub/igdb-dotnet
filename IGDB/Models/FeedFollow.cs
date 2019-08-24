using System;

namespace IGDB.Models
{
  public class FeedFollow : ITimestamps, IIdentifier
  {
    public DateTimeOffset? CreatedAt { get; set; }
    public long? Id { get; set; }
    public FeedFollowCategory? Feed { get; set; }
    public DateTimeOffset? PublishedAt { get; set; }
    public DateTimeOffset? UpdatedAt { get; set; }
    public int? User { get; set; }
  }

  public enum FeedFollowCategory
  {
    PulseArticle = 1,
    ComingSoon = 2,
    NewTrailer = 3,
    UserContributedItem = 5,
    UserContributionsItem = 6,
    PageContributedItem = 7
  }
}