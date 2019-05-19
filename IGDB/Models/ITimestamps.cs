using System;

namespace IGDB
{
  public interface ITimestamps
  {
    DateTimeOffset? CreatedAt { get; set; }
    DateTimeOffset? UpdatedAt { get; set; }
  }
}