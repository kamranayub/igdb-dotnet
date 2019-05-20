# IGDB .NET SDK

![travis build](https://travis-ci.com/kamranayub/igdb-dotnet.svg?branch=master)

A wrapper around the IGDBv3 API using .NET Core (compatible with .NET Standard 2.0+).

## Usage

### Install

    TBD

### Quickstart

Uses [RestEase](https://github.com/canton7/RestEase) so you can easily call the API methods. Since IGDB uses APIcalypse query language, you will need to pass the query as a string. *TODO: Create a query builder.*

Endpoints can be passed using the constants in `IGDB.Client.Endpoints` or as a custom string.

Some fields can be [expanded](https://api-docs.igdb.com/#expander) which is handled via the `IdentityOrValue` and `IdentitiesOrValues` wrapper. See below for an example:

```c#
using IGDB;

var igdb = IGDB.Client.Create(Environment.GetEnvironmentVariable("IGDB_API_KEY"));

// Simple fields
var games = await igdb.QueryAsync<Game>( IGDB.Client.Endpoints.Games, query: "fields id,name; where id = 4;");
var game = games.First();
game.Id; // 4
game.Name; // Thief

// Reference fields
var games = await igdb.QueryAsync(IGDB.Client.Endpoints.Games, query: "fields id,name,cover; where id = 4;");
var game = games.First();
game.Cover.Id.HasValue; // true
game.Cover.Id.Value; // 65441

// Expanded fields
var games = await igdb.QueryAsync(IGDB.Client.Endpoints.Games, query: "fields id,name,cover.*; where id = 4;");
var game = games.First();

// Id will not be populated but the full Cover object will be
game.Cover.Id.HasValue; // false
game.Cover.Value.Width; // 756
game.Cover.Value.Height;
```

## Contributing

### Prerequisites

- .NET Core SDK 2.2.5
- Visual Studio Code or VS 2017+

### Local Development

Add environment variable:

    export IGDB_API_KEY=<your api key>

You don't need this to be defined globally but it does need to be in scope while running `dotnet test`.

    dotnet build
    dotnet test
