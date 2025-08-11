namespace HubSpot.NET
{
    public class SearchContactsRequest
    {
        public string? Query { get; set; }

        public int? Limit { get; set; }

        public string? After { get; set; }

        public IEnumerable<string>? Sorts { get; set; }

        public IEnumerable<string>? Properties { get; set; }

        public IEnumerable<SearchFilterGroup>? FilterGroups { get; set; }
    }
}
