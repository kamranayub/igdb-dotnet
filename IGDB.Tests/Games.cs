using System;
using System.Linq;
using System.Threading.Tasks;
using IGDB.Models;
using RestEase;
using Xunit;

namespace IGDB.Tests
{
  public class Games
  {
    IGDBClient _api;

    public Games()
    {
      _api = new IGDB.IGDBClient(
        Environment.GetEnvironmentVariable("IGDB_CLIENT_ID"),
        Environment.GetEnvironmentVariable("IGDB_CLIENT_SECRET")
      );
    }

    [Fact]
    public async Task ShouldReturnResponseWithoutQuery()
    {
      var games = await _api.QueryAsync<Game>(IGDBClient.Endpoints.Games);

      Assert.NotNull(games);
      Assert.True(games.Length == 10);
    }

    [Fact]
    public async Task ShouldReturnResponseWithSingleGame()
    {
      var games = await _api.QueryAsync<Game>(IGDBClient.Endpoints.Games, "fields id,name,genres; where id = 4;");

      Assert.NotNull(games);
      Assert.True(games.Length == 1);

      var game = games[0];

      Assert.Equal("Thief", game.Name);
      Assert.NotEmpty(game.Genres.Ids);
      Assert.Equal(5, game.Genres.Ids.First());
    }

    [Fact]
    public async Task ShouldReturnResponseWithSingleGameExpandedGenres()
    {
      var games = await _api.QueryAsync<Game>(IGDBClient.Endpoints.Games, "fields id,name,genres.name; where id = 4;");

      Assert.NotNull(games);

      var game = games[0];

      Assert.Equal("Thief", game.Name);
      Assert.NotEmpty(game.Genres.Values);
      Assert.Equal("Shooter", game.Genres.Values[0].Name);
    }

    [Fact]
    public async Task ShouldReturnResponseWithSingleGameCover()
    {
      var games = await _api.QueryAsync<Game>(IGDBClient.Endpoints.Games, "fields id,cover; where id = 4;");

      Assert.NotNull(games);

      var game = games[0];

      Assert.NotNull(game.Cover);
      Assert.NotNull(game.Cover.Id);
      Assert.Equal(96744, game.Cover.Id.Value);
    }

    [Fact]
    public async Task ShouldReturnResponseWithSingleGameExpandedCover()
    {
      var games = await _api.QueryAsync<Game>(IGDBClient.Endpoints.Games, "fields id,cover.*; where id = 4;");

      Assert.NotNull(games);

      var game = games[0];

      Assert.NotNull(game.Cover);
      Assert.NotNull(game.Cover.Value);
      Assert.Equal(756, game.Cover.Value.Width);
    }

    [Fact]
    public async Task ShouldReturnResponseWithUnixTimestamp()
    {
      var games = await _api.QueryAsync<Game>(IGDBClient.Endpoints.Games, "fields id,created_at; where id = 4;");

      Assert.NotNull(games);

      var game = games[0];

      Assert.NotNull(game.CreatedAt);
      Assert.True(game.CreatedAt.Value.Year > 1970);
    }
    
    [Fact]
    public async Task ShouldReturnGameCount()
    {
      var gameCount = await _api.CountAsync(IGDBClient.Endpoints.Games, "where id = 4;");
      
      Assert.NotNull(gameCount);
      Assert.Equal(1, gameCount.Count);
    }
  }
}
