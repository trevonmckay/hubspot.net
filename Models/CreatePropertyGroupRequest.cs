namespace HubSpot.NET.Models
{
    public class CreatePropertyGroupRequest
    {
        public required string Name { get; set; }

        public int? DisplayOrder { get; set; }

        public required string Label { get; set; }
    }
}
