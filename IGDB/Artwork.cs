using Newtonsoft.Json;

namespace IGDB
{
    public class Artwork
    {
        [JsonProperty("image_id")]
        public int ImageId { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }
}