namespace IGDB.Models
{
  public class ProductFamily : IIdentifier
  {
    public long? Id { get; set; }
    public string Name { get; set; }
    public string Slug { get; set; }
  }
}