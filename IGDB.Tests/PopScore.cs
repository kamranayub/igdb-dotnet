using System;
using System.Linq;
using System.Threading.Tasks;
using IGDB.Models;
using Xunit;

namespace IGDB.Tests
{
	public class PopScore
	{
		IGDBClient _api;

		public PopScore()
		{
			_api = new IGDB.IGDBClient(
			  Environment.GetEnvironmentVariable("IGDB_CLIENT_ID"),
			  Environment.GetEnvironmentVariable("IGDB_CLIENT_SECRET")
			);
		}

		[Fact]
		public async Task ShouldReturnAllPopularityTypes()
		{
			var popularityTypes = await _api.QueryAsync<PopularityType>(IGDBClient.Endpoints.PopularityTypes, "fields *;");

			Assert.NotNull(popularityTypes);
			foreach (var popularityType in popularityTypes)
			{
				Assert.NotNull(popularityType.Checksum);
				Assert.NotNull(popularityType.CreatedAt);
				Assert.NotNull(popularityType.Name);
				Assert.NotNull(popularityType.PopularitySource);
				Assert.NotNull(popularityType.UpdatedAt);
			}
		}

		[Fact]
		public async Task ShouldReturnLimitedPopularityPrimitives()
		{
			var popularityPrimitives = await _api.QueryAsync<PopularityPrimitive>(
				IGDBClient.Endpoints.PopularityPrimitives,
				"fields *; limit 10;");

			Assert.NotNull(popularityPrimitives);
			Assert.True(popularityPrimitives.Length == 10);

			foreach (var popularityPrimitive in popularityPrimitives)
			{
				Assert.NotNull(popularityPrimitive.CalculatedAt);
				//Assert.NotNull(popularityPrimitive.Checksum);
				Assert.NotNull(popularityPrimitive.CreatedAt);
				Assert.NotNull(popularityPrimitive.PopularitySource);
				Assert.NotNull(popularityPrimitive.PopularityType);
				Assert.NotNull(popularityPrimitive.UpdatedAt);
				Assert.NotNull(popularityPrimitive.Value);
			}
		}
	}
}
