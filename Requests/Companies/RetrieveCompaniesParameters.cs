namespace HubSpot.NET.Requests
{
    public record RetrieveCompaniesParameters
    {
        public int? Limit { get; set; }

        public string? After { get; set; }

        public IEnumerable<string>? Properties { get; set; }

        public bool? Archived { get; set; }
    }
}
