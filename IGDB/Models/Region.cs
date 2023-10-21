using System;
using System.Globalization;

namespace IGDB.Models
{
  public class Region : ITimestamps, IIdentifier, IHasChecksum
  {
    public string Category { get; set; }
    public string Checksum { get; set; }
    public DateTimeOffset? CreatedAt { get; set; }
    public long? Id { get; set; }
    public string Identifier { get; set; }
    public string Name { get; set; }
    public DateTimeOffset? UpdatedAt { get; set; }
  }
}