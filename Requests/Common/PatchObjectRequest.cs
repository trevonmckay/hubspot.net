namespace HubSpot.NET.Requests
{
    public class PatchObjectRequest
    {
        public required IDictionary<string, object?> Properties { get; set; }
    }
}
