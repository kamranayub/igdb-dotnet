namespace IGDB.Models
{
  public class AgeRatingContentDescription
  {
    public AgeRatingContentDescriptionCategory? Category { get; set; }
    public string Description { get; set; }
    public int? Id { get; set; }
  }

  public enum AgeRatingContentDescriptionCategory
  {
    PEGI = 1,
    ESRB = 2
  }
}