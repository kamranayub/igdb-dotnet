using System;
using System.Threading.Tasks;
using Xunit;

namespace IGDB.Tests
{
  public class GameTimeToBeats
  {
    IGDBClient _api;

    public GameTimeToBeats()
    {
      _api = new IGDB.IGDBClient(
        Environment.GetEnvironmentVariable("IGDB_CLIENT_ID"),
        Environment.GetEnvironmentVariable("IGDB_CLIENT_SECRET")
      );
    }

    [Fact]
    public async Task Should_Return_GameTimeToBeat_Data()
    {
      var games = await _api.QueryAsync<IGDB.Models.GameTimeToBeat>(IGDBClient.Endpoints.GameTimeToBeats, query: "fields *; where id = 3575;");
      Assert.NotNull(games);
      Assert.NotEmpty(games);
      Assert.Equal(3575, games[0].Id);
      Assert.Equal(201711, games[0].GameId);
      Assert.Equal(1, games[0].Count);
      Assert.Equal(14400, games[0].Hastily);
      Assert.Equal(28800, games[0].Normally);
      Assert.Equal(32400, games[0].Completely);
    }
  }
}