using HubSpot.NET.Models;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace HubSpot.NET
{
    public class EnumerationJsonConverter : JsonConverterFactory
    {
        public override bool CanConvert(Type typeToConvert)
        {
            return typeToConvert.GetInterfaces().Any(IsGenericEnumerationTypeDefinition);
        }

        public override JsonConverter? CreateConverter(Type typeToConvert, JsonSerializerOptions options)
        {
            var enumerationTypeDefinition = Array.Find(typeToConvert.GetInterfaces(), IsGenericEnumerationTypeDefinition);
            if (enumerationTypeDefinition is null)
            {
                throw new InvalidOperationException($"Cannot create converter for {typeToConvert} because it does not implement IEnumeration.");
            }

            var valueType = enumerationTypeDefinition.GetGenericArguments()[0];

            var converterType = typeof(EnumerationJsonConverterImpl<,>).MakeGenericType(typeToConvert, valueType);
            return (JsonConverter)Activator.CreateInstance(converterType)!;
        }

        private static bool IsGenericEnumerationTypeDefinition(Type type)
        {
            return type.IsGenericType && type.GetGenericTypeDefinition() == typeof(IEnumeration<>);
        }

        private class EnumerationJsonConverterImpl<T, TValue> : JsonConverter<T>
            where T : IEnumeration<TValue>
        {
            public override bool CanConvert(Type typeToConvert)
            {
                var canConvert = typeof(IEnumeration<TValue>).IsAssignableFrom(typeToConvert);
                return canConvert;
            }

            public override T? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
            {
                if (typeof(TValue) == typeof(string) && reader.TokenType == JsonTokenType.String)
                {
                    string stringValue = reader.GetString() ?? throw new JsonException();
                    return Enumeration.FromValue<T, TValue>((TValue)(object)stringValue);
                }

                throw new JsonException();
            }

            public override void Write(Utf8JsonWriter writer, T value, JsonSerializerOptions options)
            {
                if (value.Value is null)
                {
                    writer.WriteNullValue();
                }
                else if (value.Value is string stringValue)
                {
                    writer.WriteStringValue(stringValue);
                }
                else
                {
                    throw new NotImplementedException();
                }
            }
        }
    }
}