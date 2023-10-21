using System;

namespace IGDB.Models
{
  public class LanguageSupport : ITimestamps, IIdentifier, IHasChecksum
  {
    public string Checksum { get; set; }
    public DateTimeOffset? CreatedAt { get; set; }
    public long? Id { get; set; }
    public IdentityOrValue<Game> Game { get; set; }
    public IdentityOrValue<Language> Language { get; set; }
    public IdentityOrValue<LanguageSupportType> LanguageSupportType { get; set; }
    public DateTimeOffset? UpdatedAt { get; set; }
  }
}