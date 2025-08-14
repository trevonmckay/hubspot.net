using System.Diagnostics.CodeAnalysis;

namespace HubSpot.NET.Models
{
    public readonly struct HubSpotDataType : IEnumeration<string>
    {
        public static readonly HubSpotDataType String = new("string");

        public static readonly HubSpotDataType Number = new("number");

        public static readonly HubSpotDataType Date = new("date");

        public static readonly HubSpotDataType DateTime = new("datetime");

        public static readonly HubSpotDataType Enumeration = new("enumeration");

        public static readonly HubSpotDataType Bool = new("bool");

        private readonly string _value;

        private HubSpotDataType(string value)
        {
            _value = value;
        }

        string IEnumeration<string>.Value => _value;

        public bool Equals(string? other)
        {
            return _value.Equals(other, StringComparison.OrdinalIgnoreCase);
        }

        public bool Equals(HubSpotDataType other)
        {
            return Equals(other._value);
        }

        public override bool Equals([NotNullWhen(true)] object? obj)
        {
            if (obj is string otherValue)
            {
                return Equals(otherValue);
            }
            else if (obj is HubSpotDataType other)
            {
                return Equals(other);
            }

            return false;
        }

        public override int GetHashCode()
        {
            HashCode hashCode = new();
            hashCode.Add(_value, StringComparer.OrdinalIgnoreCase);
            return hashCode.ToHashCode();
        }

        public override string ToString()
        {
            return _value;
        }

        public static implicit operator string(HubSpotDataType propertyType) => propertyType._value;

        public static bool operator ==(HubSpotDataType left, HubSpotDataType right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(HubSpotDataType left, HubSpotDataType right)
        {
            return !(left == right);
        }

        public static bool operator ==(HubSpotDataType left, string? right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(HubSpotDataType left, string? right)
        {
            return !(left == right);
        }
        public static bool operator ==(string? left, HubSpotDataType right)
        {
            return right.Equals(left);
        }

        public static bool operator !=(string? left, HubSpotDataType right)
        {
            return !(left == right);
        }
    }
}
