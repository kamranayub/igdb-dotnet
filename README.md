# IGDB .NET SDK

[![travis build](https://travis-ci.com/kamranayub/igdb-dotnet.svg?branch=master)](https://travis-ci.com/kamranayub/igdb-dotnet) [![Nuget](https://img.shields.io/nuget/v/IGDB.svg)](https://www.nuget.org/packages/IGDB/)

A wrapper around the [IGDBv4 API](https://api-docs.igdb.com) using .NET Core (compatible with .NET Standard 2.0+). Note, IGDBv3 is now deprecated and no longer supported so previous versions of this library (1.x) are no longer supported.

## Where is this being used?

I built this library primarily for [Keep Track of My Games](https://keeptrackofmygames.com), an app to help organize and track your game collection. That means I use this library in production and I'm motivated to keep it up-to-date and fix issues.

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

Uses [RestEase](https://github.com/canton7/RestEase) so you can easily call the API methods. Since IGDB uses APIcalypse query language, you will need to pass the query as a string. _TODO: Create a query builder._

Endpoints can be passed using the constants in `IGDB.IGDBClient.Endpoints` or as a custom string.

Models are domain objects found in `IGDB.Models` and correspond directly to the [Endpoints documentation](https://api-docs.igdb.com/#endpoints).

Some fields can be [expanded](https://api-docs.igdb.com/#expander) which is handled via the `IdentityOrValue` and `IdentitiesOrValues` wrapper.

The IGDB API uses the Twitch Developer program to power its API so it requires an OAuth client app ID and secret, which you can find in your [Developer Portal](https://dev.twitch.tv/console/apps). Passing these to the `IGDBClient.Create` method will handle the OAuth bearer token management for you (see _Custom Token Management_ below for details).

See below for an example:

```c#
using IGDB;
using IGDB.Models;

var igdb = new IGDBClient(
  // Found in Twitch Developer portal for your app
  Environment.GetEnvironmentVariable("IGDB_CLIENT_ID"),
  Environment.GetEnvironmentVariable("IGDB_CLIENT_SECRET")
);

// Simple fields
var games = await igdb.QueryAsync<Game>(IGDBClient.Endpoints.Games, query: "fields id,name; where id = 4;");
var game = games.First();
game.Id; // 4
game.Name; // Thief

// Reference fields
var games = await igdb.QueryAsync<Game>(IGDBClient.Endpoints.Games, query: "fields id,name,cover; where id = 4;");
var game = games.First();
game.Cover.Id.HasValue; // true
game.Cover.Id.Value; // 65441

// Expanded fields
var games = await igdb.QueryAsync<Game>(IGDBClient.Endpoints.Games, query: "fields id,name,cover.*; where id = 4;");
var game = games.First();

// Id will not be populated but the full Cover object will be
game.Cover.Id.HasValue; // false
game.Cover.Value.Width; // 756
game.Cover.Value.Height;
```

### Custom Token Management

By default this client will request a OAuth bearer token on your behalf that is valid for 60 days and will store it statically **in memory**. If an invalid token is used and a 401 response is received, it will automatically acquire a new token and retry the request. See `TokenManagement.cs` for the default implementation.

To customize this behavior, such as storing the bearer token in persistent storage like SQL or NoSQL, you will have to pass your own `ITokenStore` implementation.

```c#
using IGDB;

class CustomTokenStore : ITokenStore {

  Task<TwitchAccessToken> GetTokenAsync() {

    // Get token from database, etc.
    var token = // ...
    return token;
  }

  Task<TwitchAccessToken> StoreTokenAsync(TwitchAccessToken token) {
    // Store new token in database, etc.
    return token;
  }

}

// Create an IGDB API client, passing custom token store
var api = new IGDBClient(clientId, clientSecret, new CustomTokenStore());
```

- `GetTokenAsync` - Gets a token
- `StoreTokenAsync` - Stores a new token

When using dependency injection, the lifetime of the `ITokenStore` can be whatever you prefer -- a singleton is used by default.

> Note: If you build a token store, please open a PR and add a link here so others can use it!

### Default Serialization Settings

IGDB uses some _interesting_ patterns to serialize responses. When using field expansion (`foo.*`) it will expand that JSON property to be an array of objects instead of just an array of IDs. The default serializer settings of this client will handle all of this for you. It also handles serializing/deserializing `snake_case` naming and Unix timestamps.

To get a reference to the default serializer settings (for example, to serialize/deserialize yourself separately), you can access the static variable `IGDBClient.DefaultJsonSerializerSettings`.

### Images

Use the `IGDB.ImageHelper` to generate URLs for images. It exposes the raw template URL `IGDB_IMAGE_TEMPLATE` and mapping `ImageSizeMap` of `ImageSize` enum to `string` value:

```c#
var games = await igdb.QueryAsync<Game>(IGDB.IGDBClient.Endpoints.Games, query: "fields artworks.image_id; where id = 4;");
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
