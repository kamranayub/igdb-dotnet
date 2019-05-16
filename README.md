# IGDB .NET SDK

A wrapper around the IGDBv3 API using .NET Core (compatible with .NET Standard 2.0+).

## Usage

### Install

    TBD

### Quickstart

Uses [RestEase](https://github.com/canton7/RestEase) so you can easily call the API methods. Since IGDB uses APIcalypse query language, you will need to use the QueryBuilder API (or pass the raw string).

Some fields can be [expanded](https://api-docs.igdb.com/#expander) which is handled via the `MaybeExpanded` helper wrapper. If it's not expanded, it'll be a integer or array of integers and if it was expanded, it'll be the full model.

```c#
var igdb = RestClient.For<IGDBApi>("http://api-v3.igdb.com/");

var games = await igdb.GetGamesAsync("fields id, name, genres.name where id = 4");
```

## Contributing

### Prerequisites

- .NET Core SDK 2.2.5
- Visual Studio Code or VS 2017+

### Local Development

    dotnet build
    dotnet test