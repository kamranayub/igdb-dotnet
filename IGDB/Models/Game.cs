using System;
using Newtonsoft.Json;

namespace IGDB
{
  public class Game
  {
    public int? AgeRatings { get; set; }

    public double? AggregatedRating { get; set; }

    public int? AggregatedRatingCount { get; set; }

    public string[] AlternativeNames { get; set; }

    public IdentitiesOrValues<Artwork> Artworks { get; set; }

    public IdentitiesOrValues<Game> Bundles { get; set; }

    public Category? Category { get; set; }

    public IdentityOrValue<Series> Collection { get; set; }

    public IdentityOrValue<Cover> Cover { get; set; }

    public DateTimeOffset? CreatedAt { get; set; }

    public IdentitiesOrValues<Game> Dlcs { get; set; }
    
    public IdentitiesOrValues<Game> Expansions { get; set; }

    public int[] ExternalGames { get; set; }

    public DateTimeOffset? FirstReleaseDate { get; set; }

    public int? Follows { get; set; }

    public int? Franchise { get; set; }

    public int[] Franchises { get; set; }

    public int[] GameEngines { get; set; }

    public int[] GameModes { get; set; }

    public IdentitiesOrValues<Genre> Genres { get; set; }

    public int? Hypes { get; set; }

    public int? Id { get; set; }

    public int[] InvolvedCompanies { get; set; }

    public int[] Keywords { get; set; }

    public int[] MultiplayerModes { get; set; }

    public string Name { get; set; }

    public int? ParentGame { get; set; }

    public int[] Platforms { get; set; }

    public int[] PlayerPerspectives { get; set; }

    public double? Popularity { get; set; }

    public int? PulseCount { get; set; }

    public double? Rating { get; set; }

    public int? RatingCount { get; set; }

    public int[] ReleaseDates { get; set; }

    public int[] Screenshots { get; set; }

    public IdentitiesOrValues<Game> SimilarGames { get; set; }

    public string Slug { get; set; }

    public int[] StandaloneExpansions { get; set; }

    public GameStatus Status { get; set; }

    public string Storyline { get; set; }

    public string Summary { get; set; }

    public int[] Tags { get; set; }

    public int[] Themes { get; set; }

    public int? TimeToBeat { get; set; }

    public double? TotalRating { get; set; }

    public int? TotalRatingCount { get; set; }

    public DateTimeOffset? UpdatedAt { get; set; }

    public string Url { get; set; }

    public int? VersionParent { get; set; }

    public string VersionTitle { get; set; }

    public int[] Videos { get; set; }

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