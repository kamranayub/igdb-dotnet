using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace IGDB
{
    internal class UnixTimestampConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType.IsAssignableFrom(typeof(DateTimeOffset));
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var defaultDateTime = default(DateTimeOffset);

            if (reader.TokenType != JsonToken.Null)
            {
                var jValue = new JValue(reader.Value);

                if (reader.TokenType == JsonToken.Integer)
                {
                    var rawValue = reader.Value.ToString();
                    long parsedUnixTimestamp;
                    if (long.TryParse(rawValue, out parsedUnixTimestamp))
                    {
                        return DateTimeOffset.FromUnixTimeMilliseconds(parsedUnixTimestamp);
                    }
                }
            }
            return defaultDateTime;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new InvalidOperationException();
        }
    }
}