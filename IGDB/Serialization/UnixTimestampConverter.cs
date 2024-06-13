using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace IGDB.Serialization
{
  public class UnixTimestampConverter : JsonConverter
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
        if (reader.TokenType == JsonToken.Integer)
        {
          var rawValue = reader.Value.ToString();
          long parsedUnixTimestamp;
          if (long.TryParse(rawValue, out parsedUnixTimestamp))
          {
            try
            {
              return DateTimeOffset.FromUnixTimeSeconds(parsedUnixTimestamp);
            }
            catch (ArgumentOutOfRangeException)
            {
              // it's invalid
            }
          }
        }
      }
      return defaultDateTime;
    }

    public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
    {
      var offset = value as DateTimeOffset?;

      if (offset.HasValue)
      {
        JToken.FromObject(offset.Value.ToUnixTimeSeconds()).WriteTo(writer);
      }
      else
      {
        JToken.FromObject(value).WriteTo(writer);
      }
    }
  }
}