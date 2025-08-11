namespace HubSpot.NET
{
    public class SearchFilter
    {
        public string? HighValue { get; set; }

        public string? PropertyName { get; set; }

        public IEnumerable<string>? Values { get; set; }

        public string? Value { get; set; }

        public SearchFilterOperator Operator { get; set; }
    }
}
