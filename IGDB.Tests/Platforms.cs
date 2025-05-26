using System;
using System.Linq;
using System.Threading.Tasks;
using IGDB.Models;
using Xunit;

namespace IGDB.Tests
{
  [Collection("/platforms")]
  public class Platforms
  {
    IGDBClient _api;

    public Platforms()
    {
      _api = IGDBClient.CreateWithDefaults(
        Environment.GetEnvironmentVariable("IGDB_CLIENT_ID"),
        Environment.GetEnvironmentVariable("IGDB_CLIENT_SECRET")
      );
    }

    [Fact]
    public async Task ShouldReturnResponseWithLogsVersionsAndReleaseDates()
    {
      // Xbox 360
      var plaforms = await _api.QueryAsync<Platform>(IGDBClient.Endpoints.Platforms, "fields *,platform_logo.*,versions.*,versions.platform_version_release_dates.*; where id = 12;");

      Assert.NotNull(plaforms);

      var platform = plaforms[0];

      Assert.NotNull(platform.PlatformLogo.Value);
      Assert.NotNull(platform.Versions.Values);
      Assert.True(platform.Versions.Values.Length > 0, "No versions found");
      Assert.NotNull(platform.Versions.Values[1].PlatformVersionReleaseDates.Values);
    }
  }
}