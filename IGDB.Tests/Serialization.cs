using System;
using System.Collections.Generic;
using IGDB.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Xunit;

namespace IGDB.Tests
{
  public class SerializationTests
  {
    [Fact]
    public void IdentityConverter_Should_Serialize_and_Deserialize_Id()
    {
      var game = new Game();
      game.ParentGame = new IdentityOrValue<Game>(3);

      var serialized = JsonConvert.SerializeObject(game, IGDB.IGDBClient.DefaultJsonSerializerSettings);
      var deserialized = JsonConvert.DeserializeObject<Game>(serialized, IGDB.IGDBClient.DefaultJsonSerializerSettings);

      Assert.NotNull(deserialized.ParentGame);
      Assert.NotNull(deserialized.ParentGame.Id);
      Assert.Equal(3, deserialized.ParentGame.Id.Value);
    }

    [Fact]
    public void IdentityConverter_Should_Serialize_and_Deserialize_Value()
    {
      var game = new Game();
      game.ParentGame = new IdentityOrValue<Game>(new Game() { Name = "Test" });

      var serialized = JsonConvert.SerializeObject(game, IGDB.IGDBClient.DefaultJsonSerializerSettings);
      var deserialized = JsonConvert.DeserializeObject<Game>(serialized, IGDB.IGDBClient.DefaultJsonSerializerSettings);

      Assert.NotNull(deserialized.ParentGame);
      Assert.NotNull(deserialized.ParentGame.Value.Name);
      Assert.Equal("Test", deserialized.ParentGame.Value.Name);
    }

    [Fact]
    public void IdentityConverter_Should_Serialize_and_Deserialize_Ids()
    {
      var game = new Game();
      game.Genres = new IdentitiesOrValues<Genre>(new long[] { 0, 1, 2, 3 });

      var serialized = JsonConvert.SerializeObject(game, IGDB.IGDBClient.DefaultJsonSerializerSettings);
      var deserialized = JsonConvert.DeserializeObject<Game>(serialized, IGDB.IGDBClient.DefaultJsonSerializerSettings);

      Assert.NotNull(deserialized.Genres);
      Assert.NotNull(deserialized.Genres.Ids);
      Assert.Contains(0, deserialized.Genres.Ids);
      Assert.Contains(3, deserialized.Genres.Ids);
    }

    [Fact]
    public void IdentityConverter_Should_Serialize_and_Deserialize_Nested_Ids()
    {
      var game = new Game();
      var externalGames = new[] {
        new ExternalGame() {
          Game = new IdentityOrValue<Game>(1)
        }
      };
      game.ExternalGames = new IdentitiesOrValues<ExternalGame>(externalGames);

      var serialized = JsonConvert.SerializeObject(game, IGDB.IGDBClient.DefaultJsonSerializerSettings);
      var deserialized = JsonConvert.DeserializeObject<Game>(serialized, IGDB.IGDBClient.DefaultJsonSerializerSettings);

      Assert.NotNull(deserialized.ExternalGames);
      Assert.NotNull(deserialized.ExternalGames.Values);
      Assert.NotNull(deserialized.ExternalGames.Values[0].Game.Id);
      Assert.Equal(1, deserialized.ExternalGames.Values[0].Game.Id.Value);
    }

    [Fact]
    public void IdentityConverter_Should_Serialize_and_Deserialize_Values()
    {
      var game = new Game();
      var genres = new Genre[] {
        new Genre() { Id = 1 },
        new Genre() { Id = 3 }
      };
      game.Genres = new IdentitiesOrValues<Genre>(genres);

      var serialized = JsonConvert.SerializeObject(game, IGDB.IGDBClient.DefaultJsonSerializerSettings);
      var deserialized = JsonConvert.DeserializeObject<Game>(serialized, IGDB.IGDBClient.DefaultJsonSerializerSettings);

      Assert.NotNull(deserialized.Genres);
      Assert.NotNull(deserialized.Genres.Values);
      Assert.Equal(1, deserialized.Genres.Values[0].Id.Value);
      Assert.Equal(3, deserialized.Genres.Values[1].Id.Value);
    }

    [Fact]
    public void IdentityConverter_Should_Serialize_and_Deserialize_Nested_Values()
    {
      var game = new Game();
      var externalGames = new[] {
        new ExternalGame() {
          Game = new IdentityOrValue<Game>(new Game() { Id = 1 })
        }
      };
      game.ExternalGames = new IdentitiesOrValues<ExternalGame>(externalGames);

      var serialized = JsonConvert.SerializeObject(game, IGDB.IGDBClient.DefaultJsonSerializerSettings);
      var deserialized = JsonConvert.DeserializeObject<Game>(serialized, IGDB.IGDBClient.DefaultJsonSerializerSettings);

      Assert.NotNull(deserialized.ExternalGames);
      Assert.NotNull(deserialized.ExternalGames.Values);
      Assert.NotNull(deserialized.ExternalGames.Values[0].Game.Value);
      Assert.Equal(1, deserialized.ExternalGames.Values[0].Game.Value.Id);
    }

    [Fact]
    public void UnixTimestampConverter_Should_Serialize_And_Deserialize_Unix_Time()
    {
      var time = DateTimeOffset.Now;
      var game = new Game()
      {
        CreatedAt = time
      };

      var serialized = JsonConvert.SerializeObject(game, IGDB.IGDBClient.DefaultJsonSerializerSettings);
      var deserialized = JsonConvert.DeserializeObject<Game>(serialized, IGDB.IGDBClient.DefaultJsonSerializerSettings);

      Assert.Equal(time.ToUnixTimeSeconds(), deserialized.CreatedAt.Value.ToUnixTimeSeconds());
    }

    [Fact]
    public void Bug_Identity_Should_Handle_Mixed_Content()
    {
      var serialized = System.IO.File.ReadAllText("fixtures/bug-expanded-mixed-content.json");
      var deserialized = JsonConvert.DeserializeObject<Game[]>(serialized, IGDB.IGDBClient.DefaultJsonSerializerSettings);

      Assert.True(true);
    }
  }
}