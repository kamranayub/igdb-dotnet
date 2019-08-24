namespace IGDB.Models
{
  public class AgeRatingContentDescription : IIdentifier
  {
    public AgeRatingContentDescriptionCategory? Category { get; set; }
    public string Description { get; set; }
    public long? Id { get; set; }
  }

  public enum AgeRatingContentDescriptionCategory
  {
    PEGI = 1,
    ESRB = 2
  }
}