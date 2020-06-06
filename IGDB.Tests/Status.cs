
using System;
using System.Linq;
using System.Threading.Tasks;
using IGDB.Models;
using Xunit;

namespace IGDB.Tests
{
  public class Status
  {
    IGDBApi _api;

    public Status()
    {
      _api = IGDB.Client.Create(Environment.GetEnvironmentVariable("IGDB_API_KEY"));
    }

    [Fact]
    public async Task ShouldReturnApiStatus()
    {
      var status = await _api.GetApiStatus();

      Assert.NotNull(status);
      Assert.True(status.Length == 1);
      Assert.Equal("Free", status.First().Plan);
    }
  }
}