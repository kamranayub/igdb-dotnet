using System;
using Newtonsoft.Json;

namespace IGDB.Models
{
  public class CollectionType : ITimestamps, IHasChecksum
  {
    public string Checksum { get; set; }
    public DateTimeOffset? CreatedAt { get; set; }
    public string Description { get; set; }
    public string Name { get; set; }
    public DateTimeOffset? UpdatedAt { get; set; }
  }
}