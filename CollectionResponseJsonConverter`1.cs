using HubSpot.NET.Models;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace HubSpot.NET
{
    public class CollectionResponseJsonConverter<T> : JsonConverter<CollectionResponse<T>>
    {
        public override CollectionResponse<T>? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (reader.TokenType == JsonTokenType.Null)
            {
                return null;
            }

            if (reader.TokenType != JsonTokenType.StartObject)
            {
                throw new JsonException();
            }

            PageObject? pageObject = null;
            IEnumerable<T>? items = null;
            while (reader.Read())
            {
                if (reader.TokenType == JsonTokenType.PropertyName)
                {
                    string? propName = reader.GetString()?.ToUpperInvariant();
                    reader.Read();

                    switch (propName)
                    {
                        case "RESULTS":
                            items = JsonSerializer.Deserialize<IEnumerable<T>>(ref reader, options);
                            break;
                        case "PAGING":
                            pageObject = JsonSerializer.Deserialize<PageObject>(ref reader, options);
                            break;
                        default:
                            continue;
                    }
                }
                else if (reader.TokenType == JsonTokenType.EndObject)
                {
                    break;
                }
            }

            return new CollectionResponse<T>
            {
                Results = items ?? Enumerable.Empty<T>(),
                Paging = pageObject
            };
        }

        public override void Write(Utf8JsonWriter writer, CollectionResponse<T> value, JsonSerializerOptions options)
        {
            writer.WriteStartObject();
            if (value.Results is not null && options.DefaultIgnoreCondition != JsonIgnoreCondition.WhenWritingNull)
            {
                writer.WritePropertyName(GetJsonPropertyName(nameof(value.Results), options));
                JsonSerializer.Serialize(writer, value.Results, options);
            }

            if (value.Paging is not null && options.DefaultIgnoreCondition != JsonIgnoreCondition.WhenWritingNull)
            {
                writer.WritePropertyName(GetJsonPropertyName(nameof(value.Paging), options));
                JsonSerializer.Serialize(writer, value.Paging, options);
            }
                        
            writer.WriteEndObject();
        }

        private static string GetJsonPropertyName(string propertyName, JsonSerializerOptions options)
        {
            return options.PropertyNamingPolicy?.ConvertName(propertyName) ?? propertyName;
        }
    }
}
