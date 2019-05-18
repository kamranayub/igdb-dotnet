using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace IGDB
{
    internal class IdentityConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType.IsAssignableFrom(typeof(IdentityOrValue<>)) ||
            objectType.IsAssignableFrom(typeof(IdentitiesOrValues<>));
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null)
            {
                if (objectType.IsAssignableFrom(typeof(IdentityOrValue<>)))
                {
                    return new IdentityOrValue<object>();
                }
                else
                {
                    return new IdentitiesOrValues<object>();
                }
            }

            var expandedType = objectType.GetGenericArguments()[0];
            var value = new JValue(reader.Value);

            if (objectType.IsAssignableFrom(typeof(IdentitiesOrValues<>)))
            {
                if (reader.TokenType != JsonToken.StartArray)
                {
                    throw new InvalidCastException("Cannot convert non-array JSON value to IdentitiesOrValues type");
                }

                // Read first value in array
                reader.Read();

                if (reader.TokenType == JsonToken.StartObject)
                {
                    // TODO
                }
            }
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
}