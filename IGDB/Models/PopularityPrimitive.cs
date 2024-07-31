using System;

namespace IGDB.Models
{
	public class PopularityPrimitive : ITimestamps //, IHasChecksum
	{
		public DateTimeOffset? CalculatedAt { get; set; }
		/*
		 * Even though the IGDB API documentation states that the checksum field
		 * is available for this model, the API does not return it. This is why
		 * the Checksum property is commented out for now.
		 */
		//public string Checksum { get; set; }
		public DateTimeOffset? CreatedAt { get; set; }
		public long? GameId { get; set; }
		public PopularitySource? PopularitySource { get; set; }
		public IdentityOrValue<PopularityType> PopularityType { get; set; }
		public DateTimeOffset? UpdatedAt { get; set; }
		public decimal? Value { get; set; }
	}
}
