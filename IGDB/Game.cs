using System;
using Newtonsoft.Json;

namespace IGDB
{

  public class Game
  {

    [JsonProperty("age_ratings")]
    public int? AgeRatings { get; set; }

    [JsonProperty("aggregated_rating")]
    public double? AggregatedRating { get; set; }

    [JsonProperty("aggregated_rating_count")]
    public int? AggregatedRatingCount { get; set; }

    [JsonProperty("alternative_names")]
    public string[] AlternativeNames { get; set; }

    [JsonProperty("artworks")]
    [JsonConverter(typeof(IdentityConverter))]
    public IdentitiesOrValues<Artwork> Artworks { get; set; }

    [JsonProperty("bundles")]
    [JsonConverter(typeof(IdentityConverter))]
    public IdentitiesOrValues<Game> Bundles { get; set; }

    [JsonProperty("category")]
    public Category? Category { get; set; }

    [JsonProperty("collection")]
    [JsonConverter(typeof(IdentityConverter))]
    public IdentityOrValue<Series> Collection { get; set; }

    [JsonProperty("cover")]
    public int? Cover { get; set; }

    [JsonProperty("created_at")]
    [JsonConverter(typeof(UnixTimestampConverter))]
    public DateTimeOffset? CreatedAt { get; set; }

    [JsonProperty("dlcs")]
    public int[] Dlcs { get; set; }

    [JsonProperty("expansions")]
    public int[] Expansions { get; set; }

    [JsonProperty("external_games")]
    public int[] ExternalGames { get; set; }

    [JsonProperty("first_release_date")]
    [JsonConverter(typeof(UnixTimestampConverter))]
    public DateTimeOffset? FirstReleaseDate { get; set; }

    [JsonProperty("follows")]
    public int? Follows { get; set; }

    [JsonProperty("franchise")]
    public int? Franchise { get; set; }

    [JsonProperty("franchises")]
    public int[] Franchises { get; set; }

    [JsonProperty("game_engines")]
    public int[] GameEngines { get; set; }

    [JsonProperty("game_modes")]
    public int[] GameModes { get; set; }

    [JsonProperty("genres")]
    [JsonConverter(typeof(IdentityConverter))]
    public IdentitiesOrValues<Genre> Genres { get; set; }

    [JsonProperty("hypes")]
    public int Hypes { get; set; }

    [JsonProperty("id")]
    public int Id { get; set; }

    [JsonProperty("involved_companies")]
    public int[] InvolvedCompanies { get; set; }

    [JsonProperty("keywords")]
    public int[] Keywords { get; set; }

    [JsonProperty("multiplayer_modes")]
    public int[] MultiplayerModes { get; set; }

    [JsonProperty("name")]
    public string Name { get; set; }

    [JsonProperty("parent_game")]
    public int? ParentGame { get; set; }

    [JsonProperty("platforms")]
    public int[] Platforms { get; set; }

    [JsonProperty("player_perspectives")]
    public int[] PlayerPerspectives { get; set; }

    [JsonProperty("popularity")]
    public double? Popularity { get; set; }

    [JsonProperty("pulse_count")]
    public int? PulseCount { get; set; }

    [JsonProperty("rating")]
    public double? Rating { get; set; }

    [JsonProperty("rating_count")]
    public int? RatingCount { get; set; }

    [JsonProperty("release_dates")]
    public int[] ReleaseDates { get; set; }

    [JsonProperty("screenshots")]
    public int[] Screenshots { get; set; }

    [JsonProperty("similar_games")]
    public int[] SimilarGames { get; set; }

    [JsonProperty("slug")]
    public string Slug { get; set; }

    [JsonProperty("standalone_expansions")]
    public int[] StandaloneExpansions { get; set; }

    [JsonProperty("status")]
    public GameStatus Status { get; set; }

    [JsonProperty("storyline")]
    public string Storyline { get; set; }

    [JsonProperty("summary")]
    public string Summary { get; set; }

    [JsonProperty("tags")]
    public int[] Tags { get; set; }

    [JsonProperty("themes")]
    public int[] Themes { get; set; }

    [JsonProperty("time_to_beat")]
    public int? TimeToBeat { get; set; }

    [JsonProperty("total_rating")]
    public double? TotalRating { get; set; }

    [JsonProperty("total_rating_count")]
    public int? TotalRatingCount { get; set; }

    [JsonProperty("updated_at")]
    [JsonConverter(typeof(UnixTimestampConverter))]
    public DateTimeOffset? UpdatedAt { get; set; }

    [JsonProperty("url")]
    public string Url { get; set; }

    [JsonProperty("version_parent")]
    public int? VersionParent { get; set; }

    [JsonProperty("version_title")]
    public string VersionTitle { get; set; }

    [JsonProperty("videos")]
    public int[] Videos { get; set; }

    [JsonProperty("websites")]
    public int[] Websites { get; set; }
  }

  public enum Category
  {
    MainGame = 0,
    DlcAddon = 1,
    Expansion = 2,
    Bundle = 3,
    StandaloneExpansion = 4
  }

  public enum GameStatus
  {
    Released = 0,
    Alpha = 2,
    Beta = 3,
    EarlyAccess = 4,
    Offline = 5,
    Cancelled = 6
  }
}