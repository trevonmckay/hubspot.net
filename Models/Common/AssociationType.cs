using System.Diagnostics.CodeAnalysis;

namespace HubSpot.NET.Models
{
    public record AssociationType
    {
        [SetsRequiredMembers]
        public AssociationType(AssociationCategory associationCategory, int assocationTypeId)
        {
            AssociationCategory = associationCategory;
            AssociationTypeId = assocationTypeId;
        }

        [SetsRequiredMembers]
        public AssociationType(AssociationCategory associationCategory, AssociationTypeId assocationTypeId)
            : this(associationCategory, (int)assocationTypeId) { }

        public required AssociationCategory AssociationCategory { get; init; }

        public required int AssociationTypeId { get; init; }
    }
}
