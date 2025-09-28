using System.Text.Json.Serialization;

namespace HubSpot.NET.Models
{
    public record ModificationMetadata
    {
        [JsonInclude]
        public bool? Archivable { get; internal set; }

        [JsonInclude]
        public bool? ReadOnlyDefinition { get; internal set; }

        [JsonInclude]
        public bool? ReadOnlyOptions { get; internal set; }

        [JsonInclude]
        public bool? ReadOnlyValue { get; internal set; }
    }
}
