# IGDB .NET SDK

[![travis build](https://travis-ci.com/kamranayub/igdb-dotnet.svg?branch=master)](https://travis-ci.com/kamranayub/igdb-dotnet) [![Nuget](https://img.shields.io/nuget/v/IGDB.svg)](https://www.nuget.org/packages/IGDB/)

A wrapper around the [IGDBv3 API](https://api-docs.igdb.com) using .NET Core (compatible with .NET Standard 2.0+).

## Usage

### Install

via [Nuget](https://www.nuget.org/packages/IGDB/)

    # .NET Core
    dotnet add package IGDB

    # .NET Framework
    Install-Package IGDB

    # Paket
    paket add IGDB

### Quickstart

Uses [RestEase](https://github.com/canton7/RestEase) so you can easily call the API methods. Since IGDB uses APIcalypse query language, you will need to pass the query as a string. *TODO: Create a query builder.*

Endpoints can be passed using the constants in `IGDB.Client.Endpoints` or as a custom string.

Models are domain objects found in `IGDB.Models` and correspond directly to the [Endpoints documentation](https://api-docs.igdb.com/#endpoints).

Some fields can be [expanded](https://api-docs.igdb.com/#expander) which is handled via the `IdentityOrValue` and `IdentitiesOrValues` wrapper. See below for an example:

```c#
using IGDB;
using IGDB.Models;

var igdb = IGDB.Client.Create(Environment.GetEnvironmentVariable("IGDB_API_KEY"));

// Simple fields
var games = await igdb.QueryAsync<Game>(IGDB.Client.Endpoints.Games, query: "fields id,name; where id = 4;");
var game = games.First();
game.Id; // 4
game.Name; // Thief

// Reference fields
var games = await igdb.QueryAsync<Game>(IGDB.Client.Endpoints.Games, query: "fields id,name,cover; where id = 4;");
var game = games.First();
game.Cover.Id.HasValue; // true
game.Cover.Id.Value; // 65441

// Expanded fields
var games = await igdb.QueryAsync<Game>(IGDB.Client.Endpoints.Games, query: "fields id,name,cover.*; where id = 4;");
var game = games.First();

// Id will not be populated but the full Cover object will be
game.Cover.Id.HasValue; // false
game.Cover.Value.Width; // 756
game.Cover.Value.Height;
```

### Custom Client

You can use [RestEase](https://github.com/canton7/RestEase) directly as well. Create an instance beforehand and pass it to `IGDB.Client.Create(apiKey, client)` overload to attach the required JSON serializer settings and API key.

For example, this is the default way the client is built for you:

```c#
public static IGDBApi Create(string apiKey, RestClient client)
{
  client.JsonSerializerSettings = new JsonSerializerSettings()
  {
    Converters = new List<JsonConverter>() {
        new IdentityConverter(),
        new UnixTimestampConverter()
      },
    ContractResolver = new DefaultContractResolver()
    {
      NamingStrategy = new SnakeCaseNamingStrategy()
    }
  };

  var api = client.For<IGDBApi>();
  api.ApiKey = apiKey;
  return api;
}
```

### Images

Use the `IGDB.ImageHelper` to generate URLs for images. It exposes the raw template URL `IGDB_IMAGE_TEMPLATE` and mapping `ImageSizeMap` of `ImageSize` enum to `string` value:

```c#
var games = await igdb.QueryAsync<Game>(IGDB.Client.Endpoints.Games, query: "fields artworks.image_id; where id = 4;");
var artworkImageId = games.First().Artworks.Values.First().ImageId;

// Thumbnail
var thumb = IGDB.ImageHelper.GetImageUrl(imageId: artworkImageId, size: ImageSize.Thumb, retina: false);
var thumb2X = IGDB.ImageHelper.GetImageUrl(imageId: artworkImageId, size: ImageSize.Thumb, retina: true);

// Covers
var coverSmall = IGDB.ImageHelper.GetImageUrl(imageId: artworkImageId, size: ImageSize.CoverSmall, retina: false);
```

## Contributing

### Prerequisites

- .NET Core SDK 2.2.5
- Visual Studio Code or VS 2017+

### Local Development

Add environment variables:

    export IGDB_CLIENT_ID=[your OAuth app client ID]
    export IGDB_CLIENT_SECRET=[your OAuth app client secret]

These are found in your [Twitch Developer Console](https://dev.twitch.tv/console/apps).

You don't need this to be defined globally but it does need to be in scope while running `dotnet test`.

    dotnet build
    dotnet test
