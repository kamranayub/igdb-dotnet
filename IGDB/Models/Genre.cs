using System;
using Newtonsoft.Json;

namespace IGDB
{
    public class Genre
    {
        public DateTimeOffset? CreatedAt { get; set; }

        public DateTimeOffset? UpdatedAt { get; set; }

        public string Name { get; set; }

        public string Slug { get; set; }

        public string Url { get; set; }
    }
}