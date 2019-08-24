namespace IGDB.Models
{
  public class GameVersionFeature : IIdentifier
  {
    public GameVersionFeatureCategory Category { get; set; }
    public string Description { get; set; }
    public long? Id { get; set; }
    public int? Position { get; set; }
    public string Title { get; set; }
    public IdentitiesOrValues<GameVersionFeatureValue> Values { get; set; }
  }

  public enum GameVersionFeatureCategory
  {
    Boolean = 0,
    Description = 1
  }
}