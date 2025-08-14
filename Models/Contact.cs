using System.Text.Json.Serialization;

namespace HubSpot.NET.Models
{
    public class Contact
    {
        [JsonInclude]
        public string? Id { get; internal set; }

        [JsonInclude]
        public bool? Archived { get; internal set; }

        [JsonInclude]
        public IDictionary<string, object>? Properties { get; internal set; }

        [JsonInclude]
        public DateTimeOffset? CreatedAt { get; internal set; }

        [JsonInclude]
        public DateTimeOffset? UpdatedAt { get; internal set; }

        [JsonInclude]
        public DateTimeOffset? ArchivedAt { get; internal set; }
    }
}
