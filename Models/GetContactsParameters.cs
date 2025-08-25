namespace HubSpot.NET.Models
{
    public record GetContactsParameters
    {
        public int? Limit { get; set; }

        public string? After { get; set; }

        public IEnumerable<string>? Properties { get; set; }

        public bool? Archived { get; set; }
    }
}
