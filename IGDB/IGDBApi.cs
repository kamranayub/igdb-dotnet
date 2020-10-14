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
    /// <summary>
    /// Your secret, private IGDB API token
    /// </summary>
    /// <value></value>
    [Header("client-id")]
    string ClientId { get; set; }

    /// <summary>
    /// Queries a standard IGDB endpoint with an APIcalypse query. See endpoints in <see cref="IGDB.IGDBClient.Endpoints" />.
    /// </summary>
    /// <param name="endpoint">The IGDB endpoint name to query, see <see cref="IGDB.IGDBClient.Endpoints" /></param>
    /// <param name="query">The APIcalypse query to send</param>
    /// <typeparam name="T">The IGDB.Models.* entity to deserialize the response for.</typeparam>
    /// <returns>Array of IGDB models of the specified type</returns>
    [Post("/{endpoint}")]
    Task<T[]> QueryAsync<T>([Path] string endpoint, [Body] string query = null);
  }

  public static class IGDBClient
  {
    public static JsonSerializerSettings DefaultJsonSerializerSettings = new JsonSerializerSettings()
    {
      Converters = new List<JsonConverter>() {
          new IdentityConverter(),
          new UnixTimestampConverter()
        },
      ContractResolver = new DefaultContractResolver()
      {
        NamingStrategy = new SnakeCaseNamingStrategy()
      }
    };

    /// <summary>
    /// Create a IGDB API client based on a custom-created RestEase client. Adds required
    /// JSON serializer settings on top of any existing settings. Uses default in-memory access token management.
    /// </summary>
    /// <returns></returns>
    public static IGDBApi Create(string clientId, string clientSecret)
    {
      return Create(clientId, clientSecret,
        new InMemoryTokenStore());
    }

    /// <summary>
    /// Create a IGDB API client based on a custom-created RestEase client. Adds required
    /// JSON serializer settings on top of any existing settings.
    /// </summary>
    /// <returns></returns>
    public static IGDBApi Create(string clientId, string clientSecret, ITokenStore tokenStore)
    {
      if (tokenStore == null)
      {
        throw new ArgumentNullException(nameof(tokenStore),
          "A ITokenStore is required. Pass InMemoryTokenStore if you do not have a custom store implemented.");
      }

      var tokenManager = new TokenManager(tokenStore, new TwitchOAuthClient(clientId, clientSecret));

      // TODO: Provide custom IRequester to handle when API returns expired token
      var api = new RestClient("https://api.igdb.com/v4", async (request, cancellationToken) =>
      {
        var twitchToken = await tokenManager.AcquireTokenAsync();

        if (twitchToken?.AccessToken != null)
        {
          request.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue(
            "Bearer", twitchToken.AccessToken);
        }

      })
      {
        JsonSerializerSettings = DefaultJsonSerializerSettings
      }.For<IGDBApi>();
      api.ClientId = clientId;
      return api;
    }

    public static class Endpoints
    {
      public const string AgeRating = "age_ratings";
      public const string AgeRatingContentDescriptions = "age_rating_content_descriptions";
      public const string AlternativeNames = "alternative_names";
      public const string Artworks = "artworks";
      public const string Characters = "characters";
      public const string CharacterMugShots = "character_mug_shots";
      public const string Collections = "collections";
      public const string Companies = "companies";
      public const string CompanyWebsites = "company_websites";
      public const string Covers = "covers";
      public const string ExternalGames = "external_games";
      public const string Franchies = "franchises";
      public const string Games = "games";
      public const string GameEngines = "game_engines";
      public const string GameEngineLogos = "game_engine_logos";
      public const string GameVersions = "game_versions";
      public const string GameModes = "game_modes";
      public const string GameVersionFeatures = "game_version_features";
      public const string GameVersionFeatureValues = "game_version_feature_values";
      public const string GameVideos = "game_videos";
      public const string Genres = "genres";
      public const string InvolvedCompanies = "involved_companies";
      public const string Keywords = "keywords";
      public const string MultiplayerModes = "multiplayer_modes";
      public const string Platforms = "platforms";
      public const string PlatformFamilies = "platform_families";
      public const string PlatformLogos = "platform_logos";
      public const string PlatformVersions = "platform_versions";
      public const string PlatformVersionCompanies = "platform_version_companies";
      public const string PlatformVersionReleaseDates = "platform_version_release_dates";
      public const string PlatformWebsites = "platform_websites";
      public const string PlayerPerspectives = "player_perspectives";
      public const string ReleaseDates = "release_dates";
      public const string Screenshots = "screenshots";
      public const string Search = "search";
      public const string Themes = "themes";
      public const string Websites = "websites";
    }
  }
}
