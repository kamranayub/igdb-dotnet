using System;
using System.Collections.Generic;
using System.Threading.Tasks;
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
    string ClientId { get; set; }
    string ClientSecret { get; set; }

    [Post("/oauth2/token")]
    Task<TwitchAccessToken> GetOAuth2Token([Body(BodySerializationMethod.UrlEncoded)] IDictionary<string, string> data);
  }

  /// <summary>
  /// Simple Twitch Authentication client to retrieve a token
  /// See: https://dev.twitch.tv/docs/authentication/getting-tokens-oauth#oauth-client-credentials-flow
  /// </summary>
  public static class TwitchAuthClient
  {
    public static TwitchOAuthAPI Create(string clientId, string clientSecret)
    {
      var api = RestClient.For<TwitchOAuthAPI>("https://id.twitch.tv");
      api.ClientId = clientId;
      api.ClientSecret = clientSecret;
      return api;
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
    private readonly TwitchOAuthAPI _twitchClient;

    public InMemoryTokenManager(TwitchOAuthAPI twitchClient)
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
      var accessToken = await _twitchClient.GetOAuth2Token(new Dictionary<string, string>() {
        {"client_id", _twitchClient.ClientId},
        {"client_secret", _twitchClient.ClientSecret},
        {"grant_type", "client_credentials"}
      });

      CurrentToken = accessToken;
      CurrentTokenUpdatedAt = DateTimeOffset.UtcNow;

      return accessToken;
    }
  }
}