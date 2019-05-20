using Newtonsoft.Json;

namespace IGDB.Models
{
  public class Cover
  {
    public bool? AlphaChannel { get; set; }
    public bool? Animated { get; set; }
    public IdentityOrValue<Game> Game { get; set; }
    public int? Height { get; set; }
    public string ImageId { get; set; }
    public string Url { get; set; }
    public int? Width{get;set;}
  }
}