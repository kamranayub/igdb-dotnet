using System;

namespace IGDB.Models
{
    public class ArtworkType : IIdentifier, IHasChecksum, ITimestamps
    {
        public string Checksum { get; set; }
        public DateTimeOffset? CreatedAt { get; set; }
        public long? Id { get; set; }
        public string Name { get; set; }
        public string Slug { get; set; }
        public DateTimeOffset? UpdatedAt { get; set; }
    }
}