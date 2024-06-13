using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Newtonsoft.Json;
using static IGDB.Serialization.LambdaActivator;

namespace IGDB.Serialization
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

        var valuesActivator = GetValuesActivator(objectType);
        var identitiesActivator = GetIdentitiesActivator(objectType);

        // If any are objects, it means the IDs should be ignored
        if (values.All(v => v.GetType().IsAssignableFrom(typeof(long))))
        {
          return identitiesActivator(values.Cast<long>().ToArray());
        }

        var objects = values.Where(v => !v.GetType().IsAssignableFrom(typeof(long)));
        var convertedValues = objects.ToArray();
        return valuesActivator(new[] { convertedValues });
      }
      else if (IsIdentityOrValue(objectType))
      {
        var identityActivator = GetIdentityActivator(objectType);
        var valueActivator = GetValueActivator(objectType);

        if (reader.TokenType == JsonToken.StartObject)
        {
          // objects
          return valueActivator(serializer.Deserialize(reader, expandedType));
        }
        else if (reader.TokenType == JsonToken.Integer)
        {
          // int ids
          return identityActivator((long)reader.Value);
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

    private static readonly string IdentitiesOrValuesName = typeof(IdentitiesOrValues<>).Name;
    private static readonly string IdentityOrValueName = typeof(IdentityOrValue<>).Name;

    public static bool IsIdentityOrValue(Type givenType)
    {
      return givenType.Name.Contains(IdentityOrValueName);
    }

    public static bool IsIdentitiesOrValues(Type givenType)
    {
      return givenType.Name.Contains(IdentitiesOrValuesName);
    }

    private static readonly IDictionary<Type, ObjectActivator> identitiesActivators
    = new Dictionary<Type, ObjectActivator>();
    private static readonly IDictionary<Type, ObjectActivator> valuesActivators
    = new Dictionary<Type, ObjectActivator>();
    private static readonly IDictionary<Type, ObjectActivator> identityActivators
        = new Dictionary<Type, ObjectActivator>();
    private static readonly IDictionary<Type, ObjectActivator> valueActivators
        = new Dictionary<Type, ObjectActivator>();

    public static ObjectActivator GetIdentitiesActivator(Type objectType)
    {
      if (identitiesActivators.ContainsKey(objectType))
      {
        return identitiesActivators[objectType];
      }

      ConstructorInfo ctor = objectType.GetConstructors().Skip(1).First();
      var activator = GetActivator(ctor);
      identitiesActivators[objectType] = activator;
      return activator;
    }

    public static ObjectActivator GetValuesActivator(Type objectType)
    {
      if (valuesActivators.ContainsKey(objectType))
      {
        return valuesActivators[objectType];
      }

      ConstructorInfo ctor = objectType.GetConstructors().Skip(2).First();
      var activator = GetActivator(ctor);
      valuesActivators[objectType] = activator;
      return activator;
    }

    public static ObjectActivator GetIdentityActivator(Type objectType)
    {
      if (identityActivators.ContainsKey(objectType))
      {
        return identityActivators[objectType];
      }

      ConstructorInfo ctor = objectType.GetConstructors().Skip(1).First();
      var activator = GetActivator(ctor);
      identityActivators[objectType] = activator;
      return activator;
    }

    public static ObjectActivator GetValueActivator(Type objectType)
    {
      if (valueActivators.ContainsKey(objectType))
      {
        return valueActivators[objectType];
      }

      ConstructorInfo ctor = objectType.GetConstructors().Skip(2).First();
      var activator = GetActivator(ctor);
      valueActivators[objectType] = activator;
      return activator;
    }
  }



}