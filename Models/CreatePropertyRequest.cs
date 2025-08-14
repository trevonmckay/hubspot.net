namespace HubSpot.NET.Models
{
    public class CreatePropertyRequest
    {
        public bool? Hidden { get; set; }

        public int? DisplayOrder { get; set; }

        public string? Description { get; set; }

        public required string Label { get; set; }

        public required HubSpotDataType Type { get; set; }

        public required string GroupName { get; set; }

        public required string Name { get; set; }

        public required HubSpotFieldType FieldType { get; set; }

        public bool? FormField { get; set; }

        public string? ReferencedObjectType { get; set; }

        public IEnumerable<PropertyOption>? Options { get; set; }

        public string? CalculationFormula { get; set; }

        public bool? HasUniqueValue { get; set; }

        public bool? ExternalOptions { get; set; }
    }
}
