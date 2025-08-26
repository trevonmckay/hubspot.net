using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace HubSpot.NET.Models
{
    [JsonConverter(typeof(EnumerationJsonConverter))]
    public readonly struct AssociationCategory : IEnumeration<string>, IEquatable<AssociationCategory>
    {
        private readonly string _value;

        public static readonly AssociationCategory HubSpotDefined = new("HUBSPOT_DEFINED");
        public static readonly AssociationCategory InegratorDefined = new("INTEGRATOR_DEFINED");
        public static readonly AssociationCategory UserDefined = new("USER_DEFINED");

        private AssociationCategory(string value)
        {
            _value = value;
        }

        string IEnumeration<string>.Value => _value;

        public bool Equals(string? other)
        {
            return _value is not null && _value.Equals(other, StringComparison.OrdinalIgnoreCase);
        }

        public bool Equals(AssociationCategory other)
        {
            return Equals(other._value);
        }

        public override bool Equals([NotNullWhen(true)] object? obj)
        {
            if (obj is string value)
            {
                return Equals(value);
            }
            else if (obj is AssociationCategory category)
            {
                return Equals(category);
            }

            return false;
        }

        public override int GetHashCode()
        {
            return _value.GetHashCode(StringComparison.OrdinalIgnoreCase);
        }

        public override string ToString()
        {
            return _value;
        }

        public static implicit operator string(AssociationCategory category) => category._value;
        
        public static bool operator ==(AssociationCategory left, AssociationCategory right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(AssociationCategory left, AssociationCategory right)
        {
            return !(left == right);
        }
    }
}
