namespace HubSpot.NET.Requests
{
    public record CreateObjectRequest
    {
        public IEnumerable<PutAssociationRequest>? Associations { get; set; }

        public IDictionary<string, object>? Properties { get; set; }
    }
}
