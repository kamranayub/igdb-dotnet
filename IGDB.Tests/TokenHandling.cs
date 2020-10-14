using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using IGDB.Models;
using RestEase;
using Xunit;

namespace IGDB.Tests
{
  public class TokenHandling
  {

    [Fact]
    public async Task ShouldHandleInvalidTokenAndRetryRequest()
    {
      var tokenStore = new InvalidTokenStore();
      var invalidTokenClient = new IGDB.IGDBClient(
        Environment.GetEnvironmentVariable("IGDB_CLIENT_ID"),
        Environment.GetEnvironmentVariable("IGDB_CLIENT_SECRET"),
        tokenStore
      );

      var games = await invalidTokenClient.QueryAsync<Game>("games");

      Assert.True(games.Length > 0);
      Assert.True(tokenStore.Invalidated);
    }

    [Fact]
    public async Task ShouldHandleExpiredTokenAndAcquireNewOne()
    {
      var tokenStore = new ExpiredTokenStore();
      var client = new IGDB.IGDBClient(
        Environment.GetEnvironmentVariable("IGDB_CLIENT_ID"),
        Environment.GetEnvironmentVariable("IGDB_CLIENT_SECRET"),
        tokenStore
      );

      await client.QueryAsync<Game>("games");
      await client.QueryAsync<Game>("games");

      Assert.NotEqual(0, tokenStore.CurrentToken.ExpiresIn);
      Assert.True(tokenStore.Expired);
    }

    [Fact]
    public async Task ShouldUseExistingTokenWhenNotExpired()
    {
      var tokenStore = new UnexpiredTokenStore();
      var client = new IGDB.IGDBClient(
        Environment.GetEnvironmentVariable("IGDB_CLIENT_ID"),
        Environment.GetEnvironmentVariable("IGDB_CLIENT_SECRET"),
        tokenStore
      );

      await client.QueryAsync<Game>("games");
      await client.QueryAsync<Game>("games");

      Assert.True(tokenStore.Acquired);
    }

    class InvalidTokenStore : ITokenStore
    {
      public TwitchAccessToken CurrentToken { get; set; }
      public bool Invalidated { get; set; }

      public Task<TwitchAccessToken> GetTokenAsync()
      {
        if (!Invalidated)
        {
          Invalidated = true;

          var message = new HttpResponseMessage();
          var headers = message.Headers;
          headers.Add("www-authenticate", "OAuth realm='TwitchTV', error='invalid_token'");

          throw new ApiException(
            HttpMethod.Post,
            new Uri("https://fake.com"),
            System.Net.HttpStatusCode.Unauthorized,
            "Unauthorized",
            headers, null, null);
        }

        return Task.FromResult(CurrentToken);
      }

      public Task<TwitchAccessToken> StoreTokenAsync(TwitchAccessToken token)
      {
        CurrentToken = token;
        return Task.FromResult(token);
      }
    }

    class ExpiredTokenStore : ITokenStore
    {
      public TwitchAccessToken CurrentToken { get; set; }
      public bool Expired { get; set; }

      public Task<TwitchAccessToken> GetTokenAsync()
      {
        if (!Expired && CurrentToken != null)
        {
          // Set token to appear to be expired
          CurrentToken.ExpiresIn = 0;
          CurrentToken.TokenAcquiredAt = DateTimeOffset.UtcNow.AddMinutes(-1);

          Expired = true;
        }
        return Task.FromResult(CurrentToken);
      }

      public Task<TwitchAccessToken> StoreTokenAsync(TwitchAccessToken token)
      {
        CurrentToken = token;
        return Task.FromResult(token);
      }
    }

    class UnexpiredTokenStore : ITokenStore
    {
      public TwitchAccessToken CurrentToken { get; set; }
      public bool Acquired { get; set; }

      public Task<TwitchAccessToken> GetTokenAsync()
      {
        return Task.FromResult(CurrentToken);
      }

      public Task<TwitchAccessToken> StoreTokenAsync(TwitchAccessToken token)
      {
        if (Acquired)
        {
          throw new Exception("Already acquired token, should re-use");
        }
        Acquired = true;
        CurrentToken = token;
        return Task.FromResult(token);
      }
    }

  }
}