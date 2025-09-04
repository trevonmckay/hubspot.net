namespace HubSpot.NET.Models
{
    public record CreatedResource
    {
        public string CreatedResourceId { get; set; }

        public string? Location { get; set; }

        public Entity? Entity { get; set; }
    }
}
