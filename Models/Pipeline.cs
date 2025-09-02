namespace HubSpot.NET.Models
{
    public record PipelineStage
    {
        public string? Id { get; set; }

        public int? DisplayOrder { get; set; }

        public string? Label { get; set; }

        public IDictionary<string, object?>? Metadata { get; set; }

        public string? WritePermissions { get; set; }

        public bool? Archived { get; set; }

        public DateTimeOffset? CreatedAt { get; set; }

        public DateTimeOffset? UpdatedAt { get; set; }

        public DateTimeOffset? ArchivedAt { get; set; }
    }

    public record Pipeline
    {
        public string? Id { get; set; }

        public int? DisplayOrder { get; set; }

        public string? Label { get; set; }

        public IReadOnlyList<PipelineStage>? Stages { get; set; }

        public bool? Archived { get; set; }

        public DateTimeOffset? CreatedAt { get; set; }

        public DateTimeOffset? UpdatedAt { get; set; }

        public DateTimeOffset? ArchivedAt { get; set; }
    }
}
