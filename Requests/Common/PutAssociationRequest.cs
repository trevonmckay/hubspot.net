using HubSpot.NET.Models;
using System.Diagnostics.CodeAnalysis;

namespace HubSpot.NET.Requests
{
    public record PutAssociationRequest
    {
        public PutAssociationRequest() { }

        [SetsRequiredMembers]
        public PutAssociationRequest(string objectId, params IEnumerable<AssociationType> associationTypes)
        {
            To = new ObjectReference(objectId);
            Types = associationTypes;
        }

        public required IEnumerable<AssociationType> Types { get; init; }

        public required ObjectReference To { get; init; }
    }
}
