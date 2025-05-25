using System;

namespace IGDB.Models
{
  public class CompanyStatus : ITimestamps, IIdentifier, IHasChecksum
  {
    public string Checksum { get; set; }
    public DateTimeOffset? CreatedAt { get; set; }
    public string Name { get; set; }
    public DateTimeOffset? UpdatedAt { get; set; }
    public long? Id { get; set; }
  }
}