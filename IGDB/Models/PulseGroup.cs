using System;

namespace IGDB.Models
{
  public class PulseGroup : ITimestamps
  {
    public DateTimeOffset? CreatedAt { get; set; }
    public IdentityOrValue<Game> Game { get; set; }
    public int? Id { get; set; }
    public string Name { get; set; }
    public DateTimeOffset? PublishedAt { get; set; }
    public IdentitiesOrValues<Pulse> Pulses { get; set; }
    public int[] Tags { get; set; }
    public DateTimeOffset? UpdatedAt { get; set; }
  }
}