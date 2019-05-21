using System;

namespace IGDB.Models
{
  public class Pulse : ITimestamps
  {
    public string Author { get; set; }
    public DateTimeOffset? CreatedAt { get; set; }
    public int? Id { get; set; }
    public string Image { get; set; }
    public DateTimeOffset? PublishedAt { get; set; }
    public IdentityOrValue<PulseSource> PulseSource { get; set; }
    public string Summary { get; set; }
    public int[] Tags { get; set; }
    public string Title { get; set; }
    public string Uid { get; set; }
    public DateTimeOffset? UpdatedAt { get; set; }
    public string[] Videos { get; set; }
    public IdentityOrValue<PulseUrl> Website { get; set; }
  }
}