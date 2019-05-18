using System;
using Newtonsoft.Json;

namespace IGDB
{
    public class Series
    {
        [JsonProperty("created_at")]
        [JsonConverter(typeof(UnixTimestampConverter))]
        public DateTimeOffset CreatedAt { get; set; }

        [JsonProperty("games")]
        public int[] Games { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("slug")]
        public string Slug { get; set; }
    }
}