using System;

namespace IGDB.Models
{
  public class Review : ITimestamps
  {
    public ReviewCategory Category { get; set; }
    public string Conclusion { get; set; }
    public string Content { get; set; }
    public DateTimeOffset? CreatedAt { get; set; }
    public IdentityOrValue<Game> Game { get; set; }
    public string Introduction { get; set; }
    public int? Likes { get; set; }
    public string NegativePoints { get; set; }
    public IdentityOrValue<Platform> Platform { get; set; }
    public string PositivePoints { get; set; }
    public string Slug { get; set; }
    public string Title { get; set; }
    public DateTimeOffset? UpdatedAt { get; set; }
    public string Url { get; set; }
    public IdentityOrValue<User> User { get; set; }
    public IdentityOrValue<Rate> UserRating { get; set; }
    public IdentityOrValue<ReviewVideo> Video { get; set; }
    public int? Views { get; set; }
  }

  public enum ReviewCategory
  {
    Text = 1,
    Video = 2
  }
}