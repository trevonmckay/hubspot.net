using HubSpot.NET.Models;

namespace HubSpot.NET.Requests
{
    public record PutAssociationRequest
    {
        public required IEnumerable<AssociationType> Types { get; init; }

        public required ObjectReference To { get; init; }
    }
}
