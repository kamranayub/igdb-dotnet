using System;

namespace IGDB.Models
{
	public class PopularityPrimitive : ITimestamps
	{
		public DateTimeOffset? CalculatedAt { get; set; }
		public DateTimeOffset? CreatedAt { get; set; }
		public long? GameId { get; set; }
		public IdentityOrValue<ExternalGameSource> ExternalPopularitySource { get; set; }
		public IdentityOrValue<PopularityType> PopularityType { get; set; }
		public DateTimeOffset? UpdatedAt { get; set; }
		public decimal? Value { get; set; }
	}
}
