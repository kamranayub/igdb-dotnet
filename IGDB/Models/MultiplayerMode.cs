using Newtonsoft.Json;

namespace IGDB.Models
{
  public class MultiplayerMode : IIdentifier
  {
    [JsonProperty("campaigncoop")]
    public bool? CampaignCoop { get; set; }
    [JsonProperty("dropin")]
    public bool? DropIn { get; set; }
    public IdentityOrValue<Game> Game { get; set; }
    public long? Id { get; set; }
    [JsonProperty("lancoop")]
    public bool? LanCoop { get; set; }
    [JsonProperty("offlinecoop")]
    public bool? OfflineCoop { get; set; }
    [JsonProperty("offlinecoopmax")]
    public int? OfflineCoopMax { get; set; }
    [JsonProperty("offlinemax")]
    public int? OfflineMax { get; set; }
    [JsonProperty("onlinecoop")]
    public bool? OnlineCoop { get; set; }
    [JsonProperty("onlinecoopmax")]
    public int? OnlineCoopMax { get; set; }
    [JsonProperty("onlinemax")]
    public int? OnlineMax { get; set; }
    public IdentityOrValue<Platform> Platform { get; set; }
    [JsonProperty("splitscreen")]
    public bool? SplitScreen { get; set; }
    [JsonProperty("splitscreenonline")]
    public bool? SplitScreenOnline { get; set; }
  }
}