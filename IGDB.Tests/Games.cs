using System;
using System.Threading.Tasks;
using RestEase;
using Xunit;

namespace IGDB.Tests
{
  public class Games
  {
    IGDBApi _api;

    public Games()
    {
      _api = new RestClient("https://api-v3.igdb.com/").For<IGDBApi>();
      _api.ApiKey = Environment.GetEnvironmentVariable("IGDB_API_KEY");
    }

    [Fact]
    public async Task ShouldReturnResponseWithoutQuery()
    {
      var games = await _api.GetGamesAsync();

      Assert.NotNull(games);
      Assert.True(games.Length == 10);
    }
  }
}
