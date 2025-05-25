using System;

namespace IGDB.Models
{
	public class PopularityType : ITimestamps, IHasChecksum
	{
		public string Checksum { get; set; }
		public DateTimeOffset? CreatedAt { get; set; }
		public string Name { get; set; }
		public IdentityOrValue<ExternalGameSource> ExternalPopularitySource { get; set; }
		public DateTimeOffset? UpdatedAt { get; set; }
	}
}
