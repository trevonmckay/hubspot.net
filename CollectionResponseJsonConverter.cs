using HubSpot.NET.Models;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace HubSpot.NET
{
    public class CollectionResponseJsonConverter : JsonConverterFactory
    {
        public override bool CanConvert(Type typeToConvert)
        {
            return IsGenericCollectionResponseTypeDefinition(typeToConvert);
        }

        public override JsonConverter? CreateConverter(Type typeToConvert, JsonSerializerOptions options)
        {
            var itemType = typeToConvert.GetGenericArguments()[0];

            var converterType = typeof(CollectionResponseJsonConverter<>).MakeGenericType(itemType);
            if (Activator.CreateInstance(converterType) is not JsonConverter converter)
            {
                throw new InvalidOperationException($"Cannot create converter for {typeToConvert}.");
            }

            return converter;
        }

        private static bool IsGenericCollectionResponseTypeDefinition(Type type)
        {
            return type.IsGenericType && type.GetGenericTypeDefinition() == typeof(CollectionResponse<>);
        }
    }
}
