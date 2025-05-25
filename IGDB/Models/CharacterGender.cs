using System;

namespace IGDB.Models
{
  public class CharacterGender : ITimestamps, IIdentifier, IHasChecksum
  {
    public string Checksum { get; set; }
    public string Name { get; set; }
    public long? Id { get; set; }
    public DateTimeOffset? CreatedAt { get; set; }
    public DateTimeOffset? UpdatedAt { get; set; } 
  }
}