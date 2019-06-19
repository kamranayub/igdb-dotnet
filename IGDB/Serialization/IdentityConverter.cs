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
      return IsAssignableToGenericType(objectType, typeof(IdentityOrValue<>)) ||
      IsAssignableToGenericType(objectType, typeof(IdentitiesOrValues<>));
    }

    public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
    {
      if (reader.TokenType == JsonToken.Null)
      {
        return existingValue;
      }

      var expandedType = objectType.GetGenericArguments()[0];
      var value = reader.Value;

      if (IsAssignableToGenericType(objectType, typeof(IdentitiesOrValues<>)))
      {
        if (reader.TokenType != JsonToken.StartArray)
        {
          throw new InvalidCastException("Cannot convert non-array JSON value to IdentitiesOrValues type");
        }

        // Read first value in array
        var values = new List<object>();
        bool areObjs = false;
        bool areInts = false;
        while (reader.Read() && reader.TokenType != JsonToken.EndArray)
        {
          if (reader.TokenType == JsonToken.StartObject)
          {
            areObjs = true;
            var obj = serializer.Deserialize(reader, expandedType);
            // objects
            values.Add(obj);
          }
          else if (reader.TokenType == JsonToken.Integer)
          {
            areInts = true;

            // Exclude mixed IDs with expanded objects
            // because those are empty pointers
            if (areObjs) {
              continue;
            }

            // int ids
            values.Add(reader.Value);
          }
        }

        // Avoid mixed
        if (areInts && !areObjs)
        {
          return Activator.CreateInstance(objectType, values.Cast<long>().ToArray());
        }
        else if (areObjs)
        {
          var convertedValues = values.ToArray();
          var ctor = objectType.GetConstructor(new[] { typeof(object[]) });
          return ctor.Invoke(new[] { convertedValues });
        }
      }
      else if (IsAssignableToGenericType(objectType, typeof(IdentityOrValue<>)))
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
        
        if (IsAssignableToGenericType(value.GetType(), typeof(IdentitiesOrValues<>)))
        {
          serializer.Serialize(writer, identity.Ids ?? identity.Values ?? null);
        }
        else if (IsAssignableToGenericType(value.GetType(), typeof(IdentityOrValue<>)))
        {
          serializer.Serialize(writer, identity.Id ?? identity.Value ?? null);
        }
        else
        {
          serializer.Serialize(writer, null);
        }
      }
    }

    public static bool IsAssignableToGenericType(Type givenType, Type genericType)
    {
      var interfaceTypes = givenType.GetInterfaces();

      foreach (var it in interfaceTypes)
      {
        if (it.IsGenericType && it.GetGenericTypeDefinition() == genericType)
          return true;
      }

      if (givenType.IsGenericType && givenType.GetGenericTypeDefinition() == genericType)
        return true;

      Type baseType = givenType.BaseType;
      if (baseType == null) return false;

      return IsAssignableToGenericType(baseType, genericType);
    }
  }


}