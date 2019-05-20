using System;

namespace IGDB.Models
{
  public interface ITimestamps
  {
    DateTimeOffset? CreatedAt { get; set; }
    DateTimeOffset? UpdatedAt { get; set; }
  }
}