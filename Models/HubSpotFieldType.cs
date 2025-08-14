using System.Diagnostics.CodeAnalysis;

namespace HubSpot.NET.Models
{
    public readonly struct HubSpotFieldType : IEnumeration<string>
    {
        public static readonly HubSpotFieldType Textarea = new("textarea");

        public static readonly HubSpotFieldType Text = new("text");

        public static readonly HubSpotFieldType Date = new("date");

        public static readonly HubSpotFieldType File = new("file");

        public static readonly HubSpotFieldType Number = new("number");

        public static readonly HubSpotFieldType Select = new("select");

        public static readonly HubSpotFieldType Radio = new("radio");

        public static readonly HubSpotFieldType Checkbox = new("checkbox");

        public static readonly HubSpotFieldType BooleanCheckbox = new("booleancheckbox");

        public static readonly HubSpotFieldType CalculationEquation = new("calculation_equation");

        private readonly string _value;

        private HubSpotFieldType(string value)
        {
            _value = value;
        }

        string IEnumeration<string>.Value => _value;

        public bool Equals(string? other)
        {
            return _value.Equals(other, StringComparison.OrdinalIgnoreCase);
        }

        public bool Equals(HubSpotFieldType other)
        {
            return Equals(other._value);
        }

        public override bool Equals([NotNullWhen(true)] object? obj)
        {
            if (obj is string otherValue)
            {
                return Equals(otherValue);
            }
            else if (obj is HubSpotFieldType other)
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

        public static implicit operator string(HubSpotFieldType propertyType) => propertyType._value;

        public static bool operator ==(HubSpotFieldType left, HubSpotFieldType right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(HubSpotFieldType left, HubSpotFieldType right)
        {
            return !(left == right);
        }

        public static bool operator ==(HubSpotFieldType left, string? right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(HubSpotFieldType left, string? right)
        {
            return !(left == right);
        }
        public static bool operator ==(string? left, HubSpotFieldType right)
        {
            return right.Equals(left);
        }

        public static bool operator !=(string? left, HubSpotFieldType right)
        {
            return !(left == right);
        }
    }
}
