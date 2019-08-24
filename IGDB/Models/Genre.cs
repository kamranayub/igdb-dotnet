using System;
using Newtonsoft.Json;

namespace IGDB.Models
{
    public class Genre : ITimestamps, IIdentifier
    {
        public DateTimeOffset? CreatedAt { get; set; }

        public DateTimeOffset? UpdatedAt { get; set; }
        public long? Id { get; set; }

        public string Name { get; set; }

        public string Slug { get; set; }

        public string Url { get; set; }
    }
}