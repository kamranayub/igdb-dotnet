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
        bool areInts = false;
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
            areInts = true;
            // int ids
            values.Add(reader.Value);
          }
        }
        if (areInts)
        {
          return Activator.CreateInstance(objectType, values.Cast<long>().ToArray());
        }
        else
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
      JToken t = JToken.FromObject(value);

      // Determine type of identity
      if (t.Type != JTokenType.Null)
      {
        var children = t.Children();
        var populated = children.FirstOrDefault(jt => jt.First.Type != JTokenType.Null && jt.Type == JTokenType.Property);

        if (populated != null && populated.HasValues)
        {
          populated.First.WriteTo(writer);
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