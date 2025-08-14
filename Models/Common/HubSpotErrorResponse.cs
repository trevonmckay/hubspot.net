namespace HubSpot.NET
{
    public sealed class HubSpotErrorResponse
    {
        public HubSpotErrorResponse(string? status, string? message, string? code, IDictionary<string, object>? context = null)
        {
            Status = status;
            Message = message;
            Code = code;
            Context = context;
        }

        public string? Status { get; }

        public string? Message { get; }

        public string? Code { get; }

        public IDictionary<string, object>? Context { get; }
    }
}
