using System;

namespace IGDB.Models
{
  public class List : ITimestamps, IIdentifier
  {
    public DateTimeOffset? CreatedAt { get; set; }
    public string Description { get; set; }
    public int? EntriesCount { get; set; }
    public long? Id { get; set; }
    public IdentitiesOrValues<ListEntry> ListEntries { get; set; }
    public int[] ListTags { get; set; }
    public IdentitiesOrValues<Game> ListedGames { get; set; }
    public string Name { get; set; }
    public bool? Numbering { get; set; }
    public bool? Private { get; set; }
    public IdentitiesOrValues<List> SimilarLists { get; set; }
    public string Slug { get; set; }
    public DateTimeOffset? UpdatedAt { get; set; }
    public string Url { get; set; }
    public IdentityOrValue<User> User { get; set; }
  }
}