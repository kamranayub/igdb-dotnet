namespace IGDB.Models
{
  public class PulseUrl : IIdentifier
  {
    public long? Id { get; set; }
    public bool? Trusted { get; set; }
    public string Url { get; set; }
  }
}