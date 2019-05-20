using System;

namespace IGDB
{
  public class Keyword : ITimestamps
  {
    public DateTimeOffset? CreatedAt { get; set; }
    public string Name { get; set; }
    public string Slug { get; set; }
    public DateTimeOffset? UpdatedAt { get; set; }
    public string Url { get; set; }
  }
}