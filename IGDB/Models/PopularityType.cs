using System;

namespace IGDB.Models
{
	public class PopularityType : ITimestamps, IHasChecksum
	{
		public string Checksum { get; set; }
		public DateTimeOffset? CreatedAt { get; set; }
		public string Name { get; set; }
		public PopularitySource? PopularitySource { get; set; }
		public DateTimeOffset? UpdatedAt { get; set; }
	}
}
