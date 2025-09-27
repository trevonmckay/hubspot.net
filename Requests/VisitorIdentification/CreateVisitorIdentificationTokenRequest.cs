namespace HubSpot.NET.Requests
{
    public record CreateVisitorIdentificationTokenRequest
    {
        public required string Email { get; set; }

        public string? FirstName { get; set; }

        public string? LastName { get; set; }
    }
}
