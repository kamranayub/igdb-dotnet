using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using IGDB.Models;
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

    [Post("/{endpoint}")]
    Task<T[]> QueryAsync<T>([Path]string endpoint, [Body] string query = null);
  }

  public static class Client
  {
    public static IGDBApi Create(string apiKey)
    {
      var client = new RestClient("https://api-v3.igdb.com")
      {
        JsonSerializerSettings = new JsonSerializerSettings()
        {
          Converters = new List<JsonConverter>() {
            new IdentityConverter(),
            new UnixTimestampConverter()
          },
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
