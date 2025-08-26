namespace HubSpot.NET.Requests
{
    public record RetrieveCompanyParameters
    {
        public IEnumerable<string>? Properties { get; init; }

        public IEnumerable<string>? PropertiesWithHistory { get; init; }

        public IEnumerable<string>? Associations { get; init; }

        public bool? Archived { get; init; }
    }
}
