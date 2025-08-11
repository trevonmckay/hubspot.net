namespace HubSpot.NET.Models
{
    public class Contact
    {
        public string? Id { get; internal set; }

        public bool? Archived { get; internal set; }

        public IDictionary<string, object>? Properties { get; internal set; }

        public DateTimeOffset? CreatedAt { get; internal set; }

        public DateTimeOffset? UpdatedAt { get; internal set; }

        public DateTimeOffset? ArchivedAt { get; internal set; }
    }
}
