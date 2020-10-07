namespace IGDB.Models
{
  public class GameVersionFeatureValue : IIdentifier, IHasChecksum
  {
    
    public string Checksum { get; set; }
    public IdentityOrValue<Game> Game { get; set; }
    public IdentityOrValue<GameVersionFeature> GameFeature { get; set; }
    public long? Id { get; set; }
    public IncludedFeature? IncludedFeature { get; set; }
    public string Note { get; set; }
  }

  public enum IncludedFeature
  {
    NotIncluded = 0,
    Included = 1,
    PreOrderOnly = 2
  }
}