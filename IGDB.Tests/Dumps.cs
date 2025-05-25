using System;
using System.Linq;
using System.Threading.Tasks;
using IGDB.Models;
using RestEase;
using Xunit;

namespace IGDB.Tests
{
  public class Dumps
  {
    IGDBClient _api;

    public Dumps()
    {
      _api = new IGDB.IGDBClient(
        Environment.GetEnvironmentVariable("IGDB_CLIENT_ID"),
        Environment.GetEnvironmentVariable("IGDB_CLIENT_SECRET")
      );
    }

    [Fact]
    public async Task ShouldReturnDumpsList()
    {
      var dumps = await _api.GetDataDumpsAsync();

      Assert.NotNull(dumps);
      Assert.True(dumps.Length > 10);
    }

    [Fact]
    public async Task ShouldReturnGamesEndpointDump()
    {
      var gameDump = await _api.GetDataDumpEndpointAsync(IGDBClient.Endpoints.Games);

      Assert.NotNull(gameDump);
      Assert.NotNull(gameDump.S3Url);
    }
  }
}