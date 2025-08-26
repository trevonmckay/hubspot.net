using System.Diagnostics.CodeAnalysis;

namespace HubSpot.NET.Models
{
    public record ObjectReference
    {
        [SetsRequiredMembers]
        public ObjectReference(string id)
        {
            Id = id;
        }

        public required string Id { get; init; }
    }
}
