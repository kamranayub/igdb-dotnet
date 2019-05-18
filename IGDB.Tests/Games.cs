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

        [Fact]
        public async Task ShouldReturnResponseWithSingleGame()
        {
            var games = await _api.GetGamesAsync("fields id,name,genres; where id = 4;");

            Assert.NotNull(games);
            Assert.True(games.Length == 1);

            var game = games[0];

            Assert.Equal("Thief", game.Name);
            Assert.NotEmpty(game.Genres.Ids);
        }

        [Fact]
        public async Task ShouldReturnResponseWithSingleGameExpandedGenres()
        {
            var games = await _api.GetGamesAsync("fields id,name,genres.name; where id = 4;");

            Assert.NotNull(games);

            var game = games[0];

            Assert.Equal("Thief", game.Name);
            Assert.NotEmpty(game.Genres.Values);
            Assert.Equal("Stealth", game.Genres.Values[0].Name);
        }
    }
}
