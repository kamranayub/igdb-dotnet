using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using RestEase;

namespace IGDB
{
  public interface ITokenStore
  {
    /// <summary>
    /// Returns the current token from storage
    /// </summary>
    /// <returns></returns>
    Task<TwitchAccessToken> GetTokenAsync();

    /// <summary>
    /// Stores the current token to storage
    /// </summary>
    /// <returns></returns>
    Task<TwitchAccessToken> StoreTokenAsync(TwitchAccessToken token);
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
    public DateTimeOffset TokenAcquiredAt { get; set; }

    public bool HasTokenExpired()
    {
      return (DateTimeOffset.UtcNow - TokenAcquiredAt).TotalSeconds > ExpiresIn;
    }
  }

  public sealed class InMemoryTokenStore : ITokenStore
  {
    private static TwitchAccessToken CurrentToken { get; set; }

    public Task<TwitchAccessToken> StoreTokenAsync(TwitchAccessToken token)
    {
      CurrentToken = token;
      return Task.FromResult(token);
    }

    public Task<TwitchAccessToken> GetTokenAsync()
    {
      return Task.FromResult(CurrentToken);
    }
  }

  internal class TokenManager
  {
    private readonly TwitchOAuthClient _twitchClient;
    private readonly ITokenStore _tokenStore;

    public TokenManager(ITokenStore tokenStore, TwitchOAuthClient twitchClient)
    {
      _tokenStore = tokenStore;
      _twitchClient = twitchClient;
    }

    public async Task<TwitchAccessToken> AcquireTokenAsync()
    {
      var currentToken = await _tokenStore.GetTokenAsync();
      if (currentToken?.HasTokenExpired() == false)
      {
        return currentToken;
      }

      return await RefreshTokenAsync();
    }

    public async Task<TwitchAccessToken> RefreshTokenAsync()
    {
      var accessToken = await _twitchClient.GetClientCredentialTokenAsync();
      accessToken.TokenAcquiredAt = DateTimeOffset.UtcNow;
      var storedToken = await _tokenStore.StoreTokenAsync(accessToken);

      return storedToken;
    }
  }
}