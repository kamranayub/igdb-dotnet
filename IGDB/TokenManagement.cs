using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using RestEase;

namespace IGDB
{
  public interface ITokenManager
  {

    /// <summary>
    /// Returns the current non-expired token or retrieves a new one if missing or expired
    /// </summary>
    /// <returns></returns>
    Task<TwitchAccessToken> AcquireTokenAsync();

    /// <summary>
    /// Forces the expiration of the current token and acquires a new one
    /// </summary>
    /// <returns></returns>
    Task<TwitchAccessToken> RefreshTokenAsync();
  }

  [Header("Accept", "application/json")]
  public interface TwitchOAuthAPI
  {
    [Post("/oauth2/token")]
    Task<TwitchAccessToken> GetOAuth2Token([Body(BodySerializationMethod.UrlEncoded)] IDictionary<string, string> data);
  }

  public class TwitchOAuthClient
  {
    private readonly string _clientId;
    private readonly string _clientSecret;
    private readonly TwitchOAuthAPI _api;

    public TwitchOAuthClient(string clientId, string clientSecret)
    {
      _clientId = clientId;
      _clientSecret = clientSecret;
      _api = new RestClient("https://id.twitch.tv")
      {
        JsonSerializerSettings = new JsonSerializerSettings()
        {
          ContractResolver = new DefaultContractResolver()
          {
            NamingStrategy = new SnakeCaseNamingStrategy()
          }
        }
      }.For<TwitchOAuthAPI>();
    }

    public Task<TwitchAccessToken> GetClientCredentialTokenAsync()
    {
      return _api.GetOAuth2Token(new Dictionary<string, string>() {
        {"client_id", _clientId},
        {"client_secret", _clientSecret},
        {"grant_type", "client_credentials"}
      });
    }
  }

  public class TwitchAccessToken
  {
    public string AccessToken { get; set; }
    public string RefreshToken { get; set; }
    public double ExpiresIn { get; set; }
    public string[] Scope { get; set; }
    public string TokenType { get; set; }

    public bool HasTokenExpired(DateTimeOffset utcAcquiredAt)
    {
      return (DateTimeOffset.UtcNow - utcAcquiredAt).TotalSeconds > ExpiresIn;
    }
  }

  public class InMemoryTokenManager : ITokenManager
  {
    private static TwitchAccessToken CurrentToken { get; set; }
    private static DateTimeOffset CurrentTokenUpdatedAt { get; set; }
    private readonly TwitchOAuthClient _twitchClient;

    public InMemoryTokenManager(TwitchOAuthClient twitchClient)
    {
      _twitchClient = twitchClient;
    }

    public async Task<TwitchAccessToken> AcquireTokenAsync()
    {
      if (CurrentToken?.HasTokenExpired(CurrentTokenUpdatedAt) == false)
      {
        return CurrentToken;
      }

      return await RefreshTokenAsync();
    }

    public async Task<TwitchAccessToken> RefreshTokenAsync()
    {
      var accessToken = await _twitchClient.GetClientCredentialTokenAsync();

      CurrentToken = accessToken;
      CurrentTokenUpdatedAt = DateTimeOffset.UtcNow;

      return accessToken;
    }
  }
}