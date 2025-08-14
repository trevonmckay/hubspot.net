using System.Text.Json.Serialization;

namespace HubSpot.NET
{
    public sealed class HubSpotErrorResponse
    {
        [JsonConstructor]
        public HubSpotErrorResponse(string? status = null, string? message = null, string? correlationId = null, IEnumerable<HubSpotError>? errors = null, string? category = null)
        {
            Status = status;
            Message = message;
            CorrelationId = correlationId;
            Errors = errors ?? [];
            Category = category;
        }

        public string? Status { get; }

        public string? Message { get; }

        public string? CorrelationId { get; }

        public IEnumerable<HubSpotError> Errors { get; }

        public string? Category { get; }
    }

    public sealed class HubSpotError
    {
        [JsonConstructor]
        public HubSpotError(string? message, string? code, IDictionary<string, object>? context = null)
        {
            Message = message;
            Code = code;
            Context = context;
        }
        
        public string? Message { get; }
        
        public string? Code { get; }

        public IDictionary<string, object>? Context { get; }
    }
}
