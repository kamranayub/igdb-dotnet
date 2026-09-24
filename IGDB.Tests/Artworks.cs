using System;
using System.Threading.Tasks;
using IGDB.Models;
using Xunit;

namespace IGDB.Tests
{
  [Collection("/artworks")]
  public class Artworks
  {
    IGDBClient _api;

    public Artworks()
    {
      _api = IGDBClient.CreateWithDefaults(
        Environment.GetEnvironmentVariable("IGDB_CLIENT_ID"),
        Environment.GetEnvironmentVariable("IGDB_CLIENT_SECRET")
      );
    }

    [Fact]
    public async Task ShouldReturnArtworkTypes()
    {
      var artworkTypes = await _api.QueryAsync<ArtworkType>(IGDBClient.Endpoints.ArtworkTypes, "fields *; limit 50;");

      Assert.NotNull(artworkTypes);
      Assert.NotEmpty(artworkTypes);
      Assert.NotNull(artworkTypes[0].Id);
      Assert.NotNull(artworkTypes[0].Name);
      Assert.NotNull(artworkTypes[0].Slug);
    }

    [Fact]
    public async Task ShouldReturnImageTypes()
    {
      var imageTypes = await _api.QueryAsync<ImageType>(IGDBClient.Endpoints.ImageTypes, "fields *; limit 50;");

      Assert.NotNull(imageTypes);
      Assert.NotEmpty(imageTypes);
      Assert.NotNull(imageTypes[0].Id);
      Assert.NotNull(imageTypes[0].Name);
    }

    [Fact]
    public async Task ShouldReturnArtworkWithExpandedArtworkType()
    {
      var artworks = await _api.QueryAsync<Artwork>(IGDBClient.Endpoints.Artworks, "fields *,artwork_type.*; where artwork_type != null; limit 1;");

      Assert.NotNull(artworks);
      Assert.NotEmpty(artworks);
      Assert.NotNull(artworks[0].ArtworkType.Value);
      Assert.NotNull(artworks[0].ArtworkType.Value.Name);
    }

    [Fact]
    public async Task ShouldReturnArtworkWithExpandedImageType()
    {
      var artworks = await _api.QueryAsync<Artwork>(IGDBClient.Endpoints.Artworks, "fields *,image_type.*; where image_type != null; limit 1;");

      Assert.NotNull(artworks);
      Assert.NotEmpty(artworks);
      Assert.NotNull(artworks[0].ImageType.Value);
      Assert.NotNull(artworks[0].ImageType.Value.Name);
    }

    [Fact]
    public async Task ShouldReturnCoverWithExpandedImageType()
    {
      var covers = await _api.QueryAsync<Cover>(IGDBClient.Endpoints.Covers, "fields *,image_type.*; where image_type != null; limit 1;");

      Assert.NotNull(covers);
      Assert.NotEmpty(covers);
      Assert.NotNull(covers[0].ImageType.Value);
      Assert.NotNull(covers[0].ImageType.Value.Name);
    }
  }
}