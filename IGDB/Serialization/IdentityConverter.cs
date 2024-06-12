using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace IGDB
{
  public class IdentityConverter : JsonConverter
  {
    public override bool CanConvert(Type objectType)
    {
      return IsIdentityOrValue(objectType) || IsIdentitiesOrValues(objectType);
    }

    public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
    {
      if (reader.TokenType == JsonToken.Null)
      {
        return existingValue;
      }

      var expandedType = objectType.GetGenericArguments()[0];
      var value = reader.Value;

      if (IsIdentitiesOrValues(objectType))
      {
        if (reader.TokenType != JsonToken.StartArray)
        {
          throw new InvalidCastException("Cannot convert non-array JSON value to IdentitiesOrValues type");
        }

        // Read first value in array
        var values = new List<object>();
        while (reader.Read() && reader.TokenType != JsonToken.EndArray)
        {
          if (reader.TokenType == JsonToken.StartObject)
          {
            var obj = serializer.Deserialize(reader, expandedType);
            // objects
            values.Add(obj);
          }
          else if (reader.TokenType == JsonToken.Integer)
          {
            // int ids
            values.Add(reader.Value);
          }
        }

        // If any are objects, it means the IDs should be ignored
        if (values.All(v => v.GetType().IsAssignableFrom(typeof(long))))
        {
          return Activator.CreateInstance(objectType, values.Cast<long>().ToArray());
        }

        var objects = values.Where(v => !v.GetType().IsAssignableFrom(typeof(long)));
        var convertedValues = objects.ToArray();
        var ctor = objectType.GetConstructor(new[] { typeof(object[]) });
        return ctor.Invoke(new[] { convertedValues });
      }
      else if (IsIdentityOrValue(objectType))
      {
        if (reader.TokenType == JsonToken.StartObject)
        {
          // objects
          return Activator.CreateInstance(objectType, serializer.Deserialize(reader, expandedType));
        }
        else if (reader.TokenType == JsonToken.Integer)
        {
          // int ids
          return Activator.CreateInstance(objectType, (long)reader.Value);
        }
      }

      throw new InvalidCastException("Could not deserialize JSON into identity");
    }

    public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
    {
      if (value != null)
      {
        dynamic identity = value;

        if (IsIdentitiesOrValues(value.GetType()))
        {
          serializer.Serialize(writer, identity.Ids ?? identity.Values ?? null);
        }
        else if (IsIdentityOrValue(value.GetType()))
        {
          serializer.Serialize(writer, identity.Id ?? identity.Value ?? null);
        }
        else
        {
          serializer.Serialize(writer, null);
        }
      }
    }

    public static bool IsIdentityOrValue(Type givenType) {
      return givenType.Name.Contains(typeof(IdentityOrValue<>).Name);
    }

    public static bool IsIdentitiesOrValues(Type givenType) {
      return givenType.Name.Contains(typeof(IdentitiesOrValues<>).Name);
    }
  }


}