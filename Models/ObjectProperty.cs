using System.Text.Json.Serialization;

namespace HubSpot.NET.Models
{
    public record ObjectProperty
    {
        [JsonInclude]
        public int? DisplayOrder { get; internal set; }

        [JsonInclude]
        public string? FieldType { get; internal set; }

        [JsonInclude]
        public bool? FormField { get; internal set; }

        [JsonInclude]
        public string? GroupName { get; internal set; }

        [JsonInclude]
        public bool? HasUniqueValue { get; internal set; }

        [JsonInclude]
        public bool? Hidden { get; internal set; }

        [JsonInclude]
        public string? Label { get; internal set; }

        [JsonInclude]
        public ModificationMetadata? ModificationMetadata { get; internal set; }

        [JsonInclude]
        public string? Name { get; internal set; }

        [JsonInclude]
        public IReadOnlyList<PropertyOption>? Options { get; internal set; }

        [JsonInclude]
        public string? Type { get; internal set; }
    }
}
