using System;

namespace IGDB.Models
{
  public class InvolvedCompany : ITimestamps, IIdentifier, IHasChecksum
  {
    public string Checksum { get; set; }
    public IdentityOrValue<Company> Company { get; set; }
    public DateTimeOffset? CreatedAt { get; set; }
    public bool? Developer { get; set; }
    public IdentityOrValue<Game> Game { get; set; }
    public long? Id { get; set; }
    public bool? Porting { get; set; }
    public bool? Publisher { get; set; }
    public bool? Supporting { get; set; }
    public DateTimeOffset? UpdatedAt { get; set; }
  }
}