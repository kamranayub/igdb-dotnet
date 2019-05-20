using System;
using Newtonsoft.Json;

namespace IGDB.Models
{
  public class Collection : ITimestamps
  {
    public DateTimeOffset? CreatedAt { get; set; }

    public IdentitiesOrValues<Game> Games { get; set; }

    public string Name { get; set; }

    public string Slug { get; set; }

    public DateTimeOffset? UpdatedAt { get; set; }

    public string Url { get; set; }
  }
}