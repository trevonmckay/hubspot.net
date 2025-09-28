using System.Text.Json.Serialization;

namespace HubSpot.NET.Models
{
    public record CreatedResource
    {
        [JsonInclude]
        public string CreatedResourceId { get; internal set; } = null!;

        [JsonInclude]
        public string? Location { get; set; }

        [JsonInclude]
        public CrmObject Entity { get; internal set; } = null!;
    }
}
