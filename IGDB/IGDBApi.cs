using System;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using RestEase;

namespace IGDB
{
  [Header("Accept", "application/json")]
  public interface IGDBApi
  {
    [Header("user-key")]
    string ApiKey { get; set; }

    [Post("/games")]
    Task<Game[]> GetGamesAsync([Body] string query = null);
  }

  public static class Client
  {
    public static IGDBApi Create(string apiKey)
    {
      var client = new RestClient("https://api-v3.igdb.com")
      {
        JsonSerializerSettings = new JsonSerializerSettings()
        {
          ContractResolver = new DefaultContractResolver()
          {
            NamingStrategy = new SnakeCaseNamingStrategy()
          }
        }
      }.For<IGDBApi>();
      client.ApiKey = apiKey;
      return client;
    }
  }
}
