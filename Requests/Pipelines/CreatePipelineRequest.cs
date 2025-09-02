using System.Diagnostics.CodeAnalysis;

namespace HubSpot.NET.Requests
{
    public record CreatePipelineStageRequest
    {
        public CreatePipelineStageRequest() { }

        [SetsRequiredMembers]
        public CreatePipelineStageRequest(string label, int displayOrder, IDictionary<string, object?>? metadata = null)
        {
            Label = label;
            DisplayOrder = displayOrder;
            Metadata = metadata;
        }

        public required int DisplayOrder { get; set; }

        public required string Label { get; set; }

        public IDictionary<string, object?>? Metadata { get; set; }
    }

    public record CreatePipelineRequest
    {
        public CreatePipelineRequest() { }

        [SetsRequiredMembers]
        public CreatePipelineRequest(string label, int displayOrder, IEnumerable<CreatePipelineStageRequest> stages)
        {
            Label = label;
            DisplayOrder = displayOrder;
            Stages = stages;
        }

        public required int DisplayOrder { get; set; }

        public required IEnumerable<CreatePipelineStageRequest> Stages { get; set; }

        public required string Label { get; set; }
    }
}
