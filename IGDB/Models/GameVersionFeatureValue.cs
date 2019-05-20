namespace IGDB.Models
{
  public class GameVersionFeatureValue
  {
    public IdentityOrValue<Game> Game { get; set; }
    public IdentityOrValue<GameVersionFeature> Feature { get; set; }
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